using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PushByHand : XRGrabInteractable
{
    private Rigidbody rb;
    public float pushForce = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!");
        if (other.gameObject.tag == "Creature")
        {
            NavMeshAgent agent = other.gameObject.GetComponent<NavMeshAgent>();
            Debug.Log("Agent: " + agent);
            if (agent != null)
            {
                Debug.Log("Agent disabled!");
                agent.enabled = false;
            }
            Rigidbody collidedRigidbody = other.GetComponent<Rigidbody>();
            if (collidedRigidbody != null)
            {
                Vector3 pushDirection = transform.forward;
                collidedRigidbody.AddForce(pushDirection * pushForce, ForceMode.VelocityChange);

                Destroy(other.gameObject, 3f);
            }
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Tatakae>().OnMonsterDie();
        }
    }

    private void OnColliderEnter(Collision collision)
    {
        Debug.Log("Collision!");
        if (collision.gameObject.tag == "Creature")
        {
            NavMeshAgent agent = collision.gameObject.GetComponent<NavMeshAgent>();
            Debug.Log("Agent: " + agent);
            if (agent != null)
            {
                Debug.Log("Agent disabled!");
                agent.enabled = false;
            }
            Rigidbody collidedRigidbody = collision.collider.GetComponent<Rigidbody>();
            if (collidedRigidbody != null)
            {
                Vector3 pushDirection = transform.forward;
                collidedRigidbody.AddForce(pushDirection * pushForce, ForceMode.VelocityChange);

                Destroy(collision.gameObject, 3f);
            }
        }

        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject, .5f);
        }
        
        
       
    }
}
