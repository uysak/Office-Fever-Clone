using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObjManager : MonoBehaviour
{
    private List<GameObject> Folders = new List<GameObject>();
    private List<GameObject> Moneys = new List<GameObject>();

    [SerializeField] GameObject CollectedObjectsParent;

    [SerializeField] GameObject FolderCarryTray;
    [SerializeField] GameObject MoneyCarryTray;

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
                Folders[index].transform.position = Vector3.Lerp(Folders[index].transform.position, new Vector3(FolderCarryTray.transform.position.x, FolderCarryTray.transform.position.y, FolderCarryTray.transform.position.z), 10f * Time.deltaTime); //new Vector3(Carry.transform.position.x, Carry.transform.position.y, Carry.transform.position.z);
            }
            else
            {
                Folders[index].transform.position = Vector3.Lerp(Folders[index].transform.position, new Vector3(Folders[index - 1].transform.position.x, Folders[index - 1].transform.position.y + 0.1f, Folders[index - 1].transform.position.z), 10f * Time.deltaTime);  //new Vector3(CollectedObjects[index - 1].transform.position.x, CollectedObjects[index - 1].transform.position.y+0.1f, CollectedObjects[index - 1].transform.position.z);
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
                Moneys[index].transform.position = Vector3.Lerp(Moneys[index].transform.position, new Vector3(MoneyCarryTray.transform.position.x, MoneyCarryTray.transform.position.y, MoneyCarryTray.transform.position.z), 10f * Time.deltaTime); //new Vector3(Carry.transform.position.x, Carry.transform.position.y, Carry.transform.position.z);
            }
            else
            {
                Moneys[index].transform.position = Vector3.Lerp(Moneys[index].transform.position, new Vector3(Moneys[index - 1].transform.position.x, Moneys[index - 1].transform.position.y + 0.1f, Moneys[index - 1].transform.position.z), 10f * Time.deltaTime);  //new Vector3(CollectedObjects[index - 1].transform.position.x, CollectedObjects[index - 1].transform.position.y+0.1f, CollectedObjects[index - 1].transform.position.z);
            }
            Moneys[index].transform.rotation = this.transform.rotation;
        }
    }

    public void AddFolder(GameObject Folder)
    {
        Folders.Add(Folder);
        Folder.transform.SetParent(this.transform);
    }
    public void AddMoney(GameObject Money)
    {
        Moneys.Add(Money);
        Money.transform.SetParent(this.transform);
    }

    public GameObject GiveFolder()
    {
        return Folders[getCollectedObjectsCount()-1].gameObject;
    }
    public GameObject GiveMoney()
    {
        return Moneys[getMoneysCount() - 1].gameObject;
    }

    public int getCollectedObjectsCount()
    {
        return Folders.Count;
    }
    public int getMoneysCount()
    {
        return Moneys.Count;
    }
    public void RemoveLastFolderFromList()
    {
        Folders.RemoveAt(getCollectedObjectsCount()-1);
    }
    public void RemoveLastMoneyFromList()
    {
        Moneys.RemoveAt(getMoneysCount() - 1);
    }



}
