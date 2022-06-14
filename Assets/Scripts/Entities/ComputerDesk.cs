using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerDesk : MonoBehaviour
{
    private GameObject FolderTray;
    private GameObject MoneyTray;
    [SerializeField] GameObject Money;
    [SerializeField] GameObject textMax;

    private List<GameObject> Folders = new List<GameObject>();
    private List<GameObject> Moneys = new List<GameObject>();

    private Animation animation;
    private GameObject Secretary;

    private Vector3 FolderPosition;
    private Vector3 MoneyPosition;
    // Start is called before the first frame update
    void Start()
    {
        Secretary  = this.transform.GetChild(0).gameObject;
        FolderTray = this.transform.GetChild(7).gameObject;
        MoneyTray  = this.transform.GetChild(8).gameObject;

        animation = Secretary.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeFolder(GameObject TakedFolder)
    {
        Folders.Add(TakedFolder);
        TakedFolder.transform.SetParent(this.transform);
        TakedFolder.transform.rotation = FolderTray.transform.rotation;

        if (Folders.Count == 1)
        {
            FolderPosition = FolderTray.transform.position;
            FolderPosition.y += 0.1f;
            StartCoroutine(LerpPosition(TakedFolder, FolderPosition,.05f));
        }
        else
        {
            FolderPosition = FolderTray.transform.position;
            FolderPosition.y += (Folders.Count * 0.05f);
            StartCoroutine(LerpPosition(TakedFolder, FolderPosition,.05f));
        }

    }
    
    public GameObject GiveMoney()
    {
        return Moneys[Moneys.Count - 1];
    }
    public void RemoveLastMoneyFromList()
    {
        Moneys.RemoveAt(Moneys.Count - 1);
    }
    IEnumerator LerpPosition(GameObject TakedFolder,Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = TakedFolder.transform.position;
        while (time < duration)
        {
            TakedFolder.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        TakedFolder.transform.position = targetPosition;
    }

    public void CheckFolder()
    {
        if(Folders.Count == 0)
        {
            CancelInvoke("Work");
            animation.clip = animation.GetClip("Sitting");
            animation.Play();
        }
        else if(Folders.Count > 0 && Folders.Count < 20)
        {
            textMax.SetActive(false);
            animation.clip = animation.GetClip("Typing");
            animation.Play();
            Work();
        }
        else
        {
            animation.clip = animation.GetClip("Typing");
            animation.Play();
            Work();
            textMax.SetActive(true);
        }
    }
    public void Work()
    {
        int index = Folders.Count - 1;
        Destroy(Folders[index]);
        Folders.RemoveAt(index);
        if(Moneys.Count == 0)
        {
            MoneyPosition = MoneyTray.transform.position;
        }
        else
        {
            MoneyPosition = Moneys[Moneys.Count - 1].transform.position;
            MoneyPosition.y += 0.1f;
        }
        Moneys.Add(Instantiate(Money, MoneyPosition, MoneyTray.transform.rotation, MoneyTray.transform));
    }

    public int getMoneysCount()
    {
        return Moneys.Count;
    }
    public int getFoldersCount()
    {
        return Folders.Count;
    }
}
