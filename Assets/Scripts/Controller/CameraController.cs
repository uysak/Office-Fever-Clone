using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Vector3 offset;
    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        offset = Player.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, Player.transform.position - offset, 15 * Time.deltaTime);
    }
}
