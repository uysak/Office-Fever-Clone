using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaces : MonoBehaviour
{
    public interface ICollectible
    {
        void Collect();
    }

    public interface IGiveable
    {
        void Give(GameObject WhoGiven);
    }
}
