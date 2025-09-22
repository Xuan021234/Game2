using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public GameObject SpawnHere;

    public void Reborn()
    {
        GetComponent<Health>().RefillHP();
        this.transform.position = SpawnHere.transform.position;
    }
}
