using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterDeskManager : MonoBehaviour
{
    private List<GameObject> PrinterDesks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int index = 0; index < this.transform.childCount; index++)
        {
            PrinterDesks.Add(this.transform.GetChild(index).gameObject);
        }
        InvokeRepeating("SpawnFolder", 1, 1);
    }

    private void SpawnFolder()
    {
        for (int index = 0; index < PrinterDesks.Count; index++)
        {
            PrinterDesks[index].GetComponent<PrinterController>().SpawnFolder();
        }
    }

}
