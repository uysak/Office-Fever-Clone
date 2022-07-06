using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterController : MonoBehaviour,Interfaces.IGiveable
{
    [SerializeField] GameObject Folder;
    //[SerializeField] GameObject Secretary;
    private bool canGive = true;

    private GameObject FolderTray;
    private Vector3 spawnPos;
    private List<GameObject> Folders = new List<GameObject>();

    private CollectedObjManager collectedObjManager;


    // Start is called before the first frame update
    void Start()
    {
        collectedObjManager = GameObject.FindGameObjectWithTag("Player").GetComponent<CollectedObjManager>();
        FolderTray = this.gameObject.transform.GetChild(3).gameObject;
    }


    public void SpawnFolder()
    {
        if(Folders.Count == 0)
        {
            spawnPos = FolderTray.transform.position;
            spawnPos.y += 0.2f;
            Folders.Add(Instantiate(Folder, spawnPos, Folder.transform.rotation, FolderTray.transform));
        }
        else if (Folders.Count < 10 && Folders.Count !=0)
        {
            spawnPos = Folders[Folders.Count-1].transform.position;
            spawnPos.y += 0.1f;
            Folders.Add(Instantiate(Folder, spawnPos, Folder.transform.rotation,FolderTray.transform));
        }

    }

    public void Give(GameObject WhoGiven)
    {
        if (getFolderCount() == 0 || canGive == false || collectedObjManager.getFoldersCount() >= 20)
            return;
        canGive = false;
        collectedObjManager.setCanCollect(false);
        GameObject Folder = Folders[getFolderCount() - 1];
        WhoGiven.GetComponent<CollectedObjManager>().AddFolder(Folder);
       // StartCoroutine(collectedObjManager.LerpPositionFolder(Folder, collectedObjManager.getFolderTrayPos(), 1f));
        StartCoroutine(LerpPosition(Folder,collectedObjManager.getFolderTrayPos(), 0.15f));
        RemoveLastFolderOnList(Folder);
    }

    public int getFolderCount()
    {
        return Folders.Count;
    }

    public void RemoveLastFolderOnList(GameObject Obj)
    {
        Folders.Remove(Obj);
    }

    IEnumerator LerpPosition(GameObject TakedFolder, Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = TakedFolder.transform.position;
        while (time < duration)
        {
            targetPosition = collectedObjManager.getFolderTrayPos();
            TakedFolder.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        
        TakedFolder.transform.position = targetPosition;
        //Moneys.Remove(TakedFolder);
        //Destroy(TakedFolder);
        canGive = true;
    }



}
