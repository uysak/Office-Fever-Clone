using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObjMovementManager : MonoBehaviour
{
    private List<GameObject> CollectedObjects = new List<GameObject>();
    [SerializeField] GameObject CollectedObjectsParent;

    [SerializeField] GameObject Carry;
    private float carryOffset;

    // Start is called before the first frame update
    void Start()
    {
        carryOffset = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        for(int index = 0; index < CollectedObjects.Count; index++)
        {
            if (index == 0)
            {
                CollectedObjects[index].transform.position = Vector3.Lerp(CollectedObjects[index].transform.position, new Vector3(Carry.transform.position.x, Carry.transform.position.y, Carry.transform.position.z), 10f * Time.deltaTime); //new Vector3(Carry.transform.position.x, Carry.transform.position.y, Carry.transform.position.z);
            }
            else
            {
                CollectedObjects[index].transform.position = Vector3.Lerp(CollectedObjects[index].transform.position, new Vector3(CollectedObjects[index - 1].transform.position.x, CollectedObjects[index - 1].transform.position.y + 0.1f, CollectedObjects[index - 1].transform.position.z), 10f * Time.deltaTime);  //new Vector3(CollectedObjects[index - 1].transform.position.x, CollectedObjects[index - 1].transform.position.y+0.1f, CollectedObjects[index - 1].transform.position.z);
            }
            CollectedObjects[index].transform.rotation = this.transform.rotation;
        }
    }

    public void AddFolder(GameObject Folder)
    {
        CollectedObjects.Add(Folder);
        Folder.transform.SetParent(this.transform);
    }

    public int getCollectedObjectsCount()
    {
        return CollectedObjects.Count;
    }


}
