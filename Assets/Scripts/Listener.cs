using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Villager Have died");
    }

}
