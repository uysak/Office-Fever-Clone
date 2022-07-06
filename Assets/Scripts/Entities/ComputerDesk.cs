using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerDesk : MonoBehaviour,Interfaces.ICollectible,Interfaces.IGiveable
{

    CollectedObjManager collectedObjManager;

    private bool canGiveMoney = true;
    private bool canCollect = true;

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

        collectedObjManager = GameObject.FindGameObjectWithTag("Player").GetComponent<CollectedObjManager>();
    }

    public void Collect()
    {
        if (Folders.Count > 20 || collectedObjManager.getFoldersCount() == 0 || canCollect == false)
            return;
        canCollect = false;

        GameObject Folder = collectedObjManager.getLastFolderOnList();
        Folders.Add(Folder);
        collectedObjManager.RemoveLastFolderOnList(Folder);
        Folder.transform.SetParent(this.transform);
        Folder.transform.rotation = FolderTray.transform.rotation;

        if (Folders.Count == 1)
        {
            FolderPosition = FolderTray.transform.position;
            FolderPosition.y += 0.1f;
            StartCoroutine(LerpPositionFolder(Folder, FolderPosition, 0.20f));
        }
        else
        {
            FolderPosition = FolderTray.transform.position;
            FolderPosition.y += (Folders.Count * 0.05f);
            StartCoroutine(LerpPositionFolder(Folder, FolderPosition, 0.20f));
        }
    }

    public void Give(GameObject WhoGiven)
    {
        if (getMoneysCount() == 0 || canGiveMoney == false )
            return;
        canGiveMoney = false;

        GameObject Money = Moneys[getMoneysCount() - 1];
        WhoGiven.GetComponent<CollectedObjManager>().AddMoney(Money);
        //StartCoroutine(collectedObjManager.LerpPositionMoney(Money, collectedObjManager.getMoneyTrayPos(), 0.30f));
        StartCoroutine(LerpPositionMoney(Money, collectedObjManager.getMoneyTrayPos(), 0.20f));
        Moneys.Remove(Money);
    }

    public void RemoveLastMoneyFromList()
    {
        Moneys.RemoveAt(Moneys.Count - 1);
    }
    IEnumerator LerpPositionMoney(GameObject TakedMoney,Vector3 targetPosition, float duration)
    {
        //if (TakedMoney == null)
        //    yield return null;

        float time = 0;
        Vector3 startPosition = TakedMoney.transform.position;
        while (time < duration)
        {
            targetPosition = collectedObjManager.getMoneyTrayPos();
            TakedMoney.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        if(TakedMoney != null)
            TakedMoney.transform.position = targetPosition;
        canGiveMoney = true;
    }
    IEnumerator LerpPositionFolder(GameObject TakedFolder, Vector3 targetPosition, float duration)
    {
        if (TakedFolder == null)
            yield return null;
        float time = 0;
        Vector3 startPosition = TakedFolder.transform.position;
        while (time < duration)
        {
            if(TakedFolder != null)
                TakedFolder.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        if(TakedFolder != null)
            TakedFolder.transform.position = targetPosition;
        canCollect = true;
    }


    public void CheckFolder()
    {
        if(Folders.Count == 0)
        {
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
