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

    private void OnColliderEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Creature" || collision.gameObject.tag == "Enemy")
        {
            NavMeshAgent agent = collision.gameObject.GetComponent<NavMeshAgent>();
            if (agent != null)
            {
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
        
        
       
    }
}
