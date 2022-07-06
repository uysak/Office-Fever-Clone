using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATM : MonoBehaviour,Interfaces.ICollectible
{
    private bool canCollect = true;

    CollectedObjManager collectedObjManager;

    public void Collect()
    {
        if (collectedObjManager.getMoneysCount() == 0 || canCollect == false)
            return;
        canCollect = false;
        GameObject Money = collectedObjManager.getLastMoneyOnList();
        StartCoroutine(LerpPosition(Money, this.transform.position, .25f));
        collectedObjManager.RemoveLastMoneyOnList(Money);
    }

    // Start is called before the first frame update
    void Start()
    {
        collectedObjManager = GameObject.FindGameObjectWithTag("Player").GetComponent<CollectedObjManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LerpPosition(GameObject TakedFolder, Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = TakedFolder.transform.position;
        while (time < duration)
        {
            TakedFolder.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        TakedFolder.transform.position = targetPosition;
        canCollect = true;
        //Moneys.Remove(TakedFolder);
        //Destroy(TakedFolder);
    }

}
