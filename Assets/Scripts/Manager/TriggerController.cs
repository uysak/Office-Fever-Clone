using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerController : MonoBehaviour
{
    private CollectedObjManager collectedObjManager;
    private bool canCollect;
    private GameObject CollectedObj;
    private GameObject test;

    private GameObject DetectedObj;

    // Start is called before the first frame update
    void Start()
    {
        collectedObjManager = this.GetComponent<CollectedObjManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<Interfaces.ICollectible>() != null)
        {
            other.gameObject.GetComponent<Interfaces.ICollectible>().Collect();
        }

        if (other.gameObject.GetComponent<Interfaces.IGiveable>() != null)
        {
            other.gameObject.GetComponent<Interfaces.IGiveable>().Give(this.gameObject);
        }
    }
}
