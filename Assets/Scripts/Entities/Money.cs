using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    CollectedObjManager collectedObjMovementManager;
    


    // Start is called before the first frame update
    void Start()
    {
        collectedObjMovementManager = GameObject.Find("Player").GetComponent<CollectedObjManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void Collect()
    //{
    //    collectedObjMovementManager.AddMoney(this.gameObject);
    //}
}
