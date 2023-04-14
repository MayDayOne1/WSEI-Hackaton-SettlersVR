using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tatakae : MonoBehaviour
{
    private NavMeshAgent nma = null;
    public NavMeshSurface nms;
    public Transform village;

    void Start()
    {
        nma = this.GetComponent<NavMeshAgent>();
        SetAttackDestination();
    }

    private void Update()
    {
        SetAttackDestination();
    }

    private void SetAttackDestination()
    {
        nma.destination = village.position;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Villager have died");
    }
}

