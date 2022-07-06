using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectedObjManager : MonoBehaviour
{
    private List<GameObject> Folders = new List<GameObject>();
    private List<GameObject> Moneys = new List<GameObject>();

    [SerializeField] GameObject CollectedObjectsParent;

    [SerializeField] GameObject FolderCarryTray;
    [SerializeField] GameObject MoneyCarryTray;
    private GameObject CollectedObj;

    private bool canCollectFolder = true;
    public bool canGiveMoney = true;

    private float lerpSpeed = 30f;


    public bool isPlayerCarry;
    private float carryOffset;

    // Start is called before the first frame update
    void Start()
    {
        carryOffset = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        FolderMovement();
        MoneyMovement();
    }
    public void FolderMovement()
    {
        for (int index = 0; index < Folders.Count; index++)
        {
            if (index == 0)
            {
                Folders[index].transform.position = Vector3.Lerp(Folders[index].transform.position, new Vector3(FolderCarryTray.transform.position.x, FolderCarryTray.transform.position.y, FolderCarryTray.transform.position.z), lerpSpeed * Time.deltaTime); //new Vector3(Carry.transform.position.x, Carry.transform.position.y, Carry.transform.position.z);
            }
            else
            {
                Folders[index].transform.position = Vector3.Lerp(Folders[index].transform.position, new Vector3(Folders[index - 1].transform.position.x, Folders[index - 1].transform.position.y + 0.1f, Folders[index - 1].transform.position.z), lerpSpeed * Time.deltaTime);  //new Vector3(CollectedObjects[index - 1].transform.position.x, CollectedObjects[index - 1].transform.position.y+0.1f, CollectedObjects[index - 1].transform.position.z);
            }
            Folders[index].transform.rotation = this.transform.rotation;
        }

    }
    public void MoneyMovement()
    {
        for (int index = 0; index < Moneys.Count; index++)
        {
            if (index == 0)
            {
                Moneys[index].transform.position = Vector3.Lerp(Moneys[index].transform.position, new Vector3(MoneyCarryTray.transform.position.x, MoneyCarryTray.transform.position.y, MoneyCarryTray.transform.position.z), lerpSpeed * Time.deltaTime); //new Vector3(Carry.transform.position.x, Carry.transform.position.y, Carry.transform.position.z);
            }
            else
            {
                Moneys[index].transform.position = Vector3.Lerp(Moneys[index].transform.position, new Vector3(Moneys[index - 1].transform.position.x, Moneys[index - 1].transform.position.y + 0.1f, Moneys[index - 1].transform.position.z), lerpSpeed * Time.deltaTime);  //new Vector3(CollectedObjects[index - 1].transform.position.x, CollectedObjects[index - 1].transform.position.y+0.1f, CollectedObjects[index - 1].transform.position.z);
            }
            Moneys[index].transform.rotation = this.transform.rotation;
        }
    }

    public void AddMoney(GameObject Money)
    {
        Moneys.Add(Money);

    }

    public void AddFolder(GameObject Folder)
    {
        Folders.Add(Folder);
        //Folder.transform.SetParent(this.transform);
    //    Folder.transform.position = FolderCarryTray.transform.position;
    //    LerpPosition(Folder, FolderCarryTray.transform.position, 0.15f);
    }

    public GameObject getLastFolderOnList()
    {
        return (Folders[Folders.Count - 1]);
    }

    public GameObject getLastMoneyOnList()
    {
        return Moneys[Moneys.Count - 1];
    }
    public IEnumerator LerpPositionMoney(GameObject TakedMoney, Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = TakedMoney.transform.position;
        while (time < duration)
        {
            if(TakedMoney != null)
                TakedMoney.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        TakedMoney.transform.position = targetPosition;
        canGiveMoney = true;
    }
    public IEnumerator LerpPositionFolder(GameObject TakedFolder, Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = TakedFolder.transform.position;
        while (time < duration)
        {
            if(TakedFolder != null)
            {
                TakedFolder.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            }
            time += Time.deltaTime;
            yield return null;
        }
        TakedFolder.transform.position = targetPosition;

        canCollectFolder = true;

    }

    public int getFoldersCount()
    {
        return Folders.Count;
    }

    public int getMoneysCount()
    {
        return Moneys.Count;
    }
    public void RemoveLastFolderOnList(GameObject Obj)
    {
        Folders.Remove(Obj);
    }
    public void RemoveLastMoneyOnList(GameObject Obj)
    {
        Moneys.Remove(Obj);
    }

    public Vector3 getMoneyTrayPos()
    {
        if (getMoneysCount() == 0)
            return MoneyCarryTray.transform.position;
        else
            return Moneys[getMoneysCount() - 1].transform.position;
    }
    public Vector3 getFolderTrayPos()
    {
        if (getFoldersCount() == 0)
            return FolderCarryTray.transform.position;
        else
            return Folders[getFoldersCount() - 1].transform.position;
    }

    public bool getCanCollect()
    {
        return canCollectFolder;
    }
    public void setCanCollect(bool canCollect)
    {
        this.canCollectFolder = canCollect;
    }
}
