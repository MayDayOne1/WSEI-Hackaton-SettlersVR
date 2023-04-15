using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class Tatakae : MonoBehaviour
{
    [SerializeField] VisualEffect graph;

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
        if (_navMeshAgent.enabled == false)
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

    public void OnMonsterDie()
    {
        StartCoroutine(Die());

    }

    IEnumerator Die()
    {
        _animator.SetTrigger("Death");
        graph.Play();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}

