using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BePushable : XRGrabInteractable
{
    public float pushForce = 5f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody collidedRigidbody = collision.collider.GetComponent<Rigidbody>();
        if(collidedRigidbody != null )
        {
            Vector3 pushDirection = transform.forward;
            collidedRigidbody.AddForce(pushDirection * pushForce, ForceMode.VelocityChange);
        }
    }
}
