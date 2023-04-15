using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tatakae : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent = null;
    private Animator _animator;
    private GameObject _villagePos;



    void Awake()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _villagePos = GameObject.Find("village");
        
        SendAgent();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SendAgent();
    }

    public void SendAgent()
    {
        if(_navMeshAgent.enabled == false)
        {
            return;
        }
        _navMeshAgent.SetDestination(_villagePos.transform.position);
    }


    public void DisableAgent()
    {
        _navMeshAgent.enabled = false;
    }

    public void EnableAgent()
    {
        _navMeshAgent.enabled = true;
    }
}

