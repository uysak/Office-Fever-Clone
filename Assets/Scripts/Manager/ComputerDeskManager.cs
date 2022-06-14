using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerDeskManager : MonoBehaviour
{
    private List<GameObject> SecretaryDesks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int index = 0; index < this.transform.childCount; index++)
        {
            SecretaryDesks.Add(this.transform.GetChild(index).gameObject);
        }
        InvokeRepeating("CheckWork", 1, 1);
    }

    public void CheckWork()
    {
        for (int index = 0; index < SecretaryDesks.Count; index++)
        {
            SecretaryDesks[index].GetComponent<ComputerDesk>().CheckFolder();
        }
    }
}
