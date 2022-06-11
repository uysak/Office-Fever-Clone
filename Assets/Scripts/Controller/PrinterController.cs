using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterController : MonoBehaviour
{
    [SerializeField] GameObject Folder;

    private GameObject FolderTray;
    private Vector3 spawnPos;
    private List<GameObject> Folders = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFolder", 1, 1);
        FolderTray = this.gameObject.transform.GetChild(3).gameObject;
        spawnPos = FolderTray.transform.position;
        spawnPos.y += 0.2f;
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

    public GameObject getLastFolder()
    {
        return Folders[Folders.Count-1];
    }
    public void RemoveLastFolderFromList()
    {
        Folders.RemoveAt(Folders.Count - 1);
    }
}
