using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folder : MonoBehaviour
{
    CollectedObjManager collectedObjManager;
    // Start is called before the first frame update
    void Start()
    {
        collectedObjManager = GameObject.FindGameObjectWithTag("Player").GetComponent<CollectedObjManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void Collect()
    //{
    //    collectedObjManager.AddFolder(this.gameObject);
    //}

}
