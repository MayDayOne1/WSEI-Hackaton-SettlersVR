using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tatakae : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent = null;
    private Animator _animator;

    void Awake()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        GameObject _villagePos = GameObject.Find("village");
        _navMeshAgent.SetDestination(_villagePos.transform.position);

        _animator = GetComponent<Animator>();
    }

    public void Attack()
    {

    }
}

