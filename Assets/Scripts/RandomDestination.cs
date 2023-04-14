using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomDestination : MonoBehaviour
{
    private Vector3 NPoint;
    private NavMeshAgent nma = null;
    public NavMeshSurface nms;
    float radius = 30f;

    void Start()
    {
        nma = this.GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    private void SetRandomDestination()
    {
        var randomPointOnSphere = Random.onUnitSphere * radius;

        Vector3 result = Vector3.zero;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPointOnSphere, out hit, 1000.0f, NavMesh.AllAreas))
        {
            result = hit.position;
        }


        //NPoint = new Vector3 (this.transform.position.x,this.transform.position.y,this.transform.position.z);
        nma.SetDestination(result);
    }
}
