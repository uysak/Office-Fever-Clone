using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    private CollectedObjMovementManager collectedObjMovementManager;
    private bool canCollect;

    private GameObject CollectedObj;
    // Start is called before the first frame update
    void Start()
    {
        collectedObjMovementManager = this.GetComponent<CollectedObjMovementManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PrinterDesk"))
        {
            StartCoroutine(Collect(other.gameObject));
            //CollectedObj = other.gameObject.GetComponent<PrinterController>().getLastFolder();
            //other.gameObject.GetComponent<PrinterController>().RemoveLastFolderFromList();
            //collectedObjMovementManager.AddFolder(CollectedObj);
        }
    }
   
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PrinterDesk"))
        {

        }
    }

    IEnumerator Collect(GameObject Obj)
    {
        if(collectedObjMovementManager.getCollectedObjectsCount() < 20)
        {
            CollectedObj = Obj.gameObject.GetComponent<PrinterController>().getLastFolder();
            Obj.gameObject.GetComponent<PrinterController>().RemoveLastFolderFromList();
            collectedObjMovementManager.AddFolder(CollectedObj);
            yield return new WaitForSeconds(0.2f);
        }

    }
}
