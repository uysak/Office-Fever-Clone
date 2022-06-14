using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectManager : MonoBehaviour
{
    private CollectedObjManager collectedObjManager;
    private bool canCollect;
    private GameObject CollectedObj;
    private GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        collectedObjManager = this.GetComponent<CollectedObjManager>();
    }


    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("PrinterDesk") && collectedObjMovementManager.getCollectedObjectsCount() < 20)
    //    {
    //        if(collision.gameObject.GetComponent<PrinterController>().getFolderCount() > 0)
    //        {
    //            StartCoroutine(Collect(collision.gameObject));
    //        }
    //    }

    //    else if (collision.gameObject.CompareTag("ComputerDesk"))
    //    {
    //        if (collectedObjMovementManager.getCollectedObjectsCount() > 0 && collision.gameObject.GetComponent<ComputerDesk>().getFoldersCount() < 20)
    //        {
    //            StartCoroutine(GiveFolder(collision.gameObject));
    //        }
    //        StartCoroutine(TakeMoney(collision.gameObject));
    //    }
    //    else if (collision.gameObject.CompareTag("ATM"))
    //    {
    //        Debug.LogWarning("ATM");
    //        test = collectedObjMovementManager.GiveMoney();
    //        StartCoroutine(LerpPosition(test, collision.gameObject.transform.position, 0.5f));
            
    //    }
    //}


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PrinterDesk") && collectedObjManager.getCollectedObjectsCount() < 20)
        {
            if (other.gameObject.GetComponent<PrinterController>().getFolderCount() > 0)
            {
                StartCoroutine(Collect(other.gameObject));
            }
        }

        else if (other.gameObject.CompareTag("ComputerDesk"))
        {
            if (collectedObjManager.getCollectedObjectsCount() > 0 && other.gameObject.GetComponent<ComputerDesk>().getFoldersCount() < 20)
            {
                StartCoroutine(GiveFolder(other.gameObject));
            }
            StartCoroutine(TakeMoney(other.gameObject));
        }
        else if (other.gameObject.CompareTag("ATM"))
        {
            Debug.LogWarning("ATM");
            test = collectedObjManager.GiveMoney();
            StartCoroutine(LerpPosition(test, other.gameObject.transform.position, 0.5f));

        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("PrinterDesk"))
    //    {
    //        StartCoroutine(Collect(other.gameObject));
    //        //CollectedObj = other.gameObject.GetComponent<PrinterController>().getLastFolder();
    //        //other.gameObject.GetComponent<PrinterController>().RemoveLastFolderFromList();
    //        //collectedObjMovementManager.AddFolder(CollectedObj);
    //    }
    //    else if (other.gameObject.CompareTag("ComputerDesk") && wait == false)
    //    {
    //        wait = true;
    //        StartCoroutine(GiveFolder(other.gameObject));
    //        StartCoroutine(TakeMoney(other.gameObject));
    //    }
    //}
   
    IEnumerator Collect(GameObject Obj)
    {
        CollectedObj = Obj.gameObject.GetComponent<PrinterController>().getLastFolder();
        Obj.gameObject.GetComponent<PrinterController>().RemoveLastFolderFromList();
        collectedObjManager.AddFolder(CollectedObj);
        yield return new WaitForSeconds(0.2f);
    }

    IEnumerator TakeMoney(GameObject Desk)
    {
        if (Desk.GetComponent<ComputerDesk>().getMoneysCount() != 0)
        {
            CollectedObj = Desk.gameObject.GetComponent<ComputerDesk>().GiveMoney();
            CollectedObj.transform.DOScale(0.8f, 0.5f);
            Debug.LogWarning(CollectedObj.name);
            collectedObjManager.AddMoney(CollectedObj);
            Desk.gameObject.GetComponent<ComputerDesk>().RemoveLastMoneyFromList();
            yield return new WaitForSeconds(.2f);
           
        }
    }

    IEnumerator GiveFolder(GameObject Desk)
    {
        Desk.GetComponent<ComputerDesk>().TakeFolder(collectedObjManager.GiveFolder());
        collectedObjManager.RemoveLastFolderFromList();
        yield return new WaitForSeconds(.2f);
    }

    IEnumerator LerpPosition(GameObject Obj, Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = Obj.transform.position;
        while (time < duration)
        {
            Obj.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        Obj.transform.position = targetPosition;
        collectedObjManager.RemoveLastMoneyFromList();
        Destroy(Obj);
    }



}
