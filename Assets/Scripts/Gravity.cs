using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Transform gravityTarget;
    public float gravity = 9.81f;
    Rigidbody rb;
    public bool autoOrient = false;
    public float autoOrientSpeed = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        ProcessGravity();
    }
    void ProcessGravity()
    {
        Vector3 diff = transform.position - gravityTarget.position;
        rb.AddForce(-diff * gravity * (rb.mass));
        Debug.DrawRay(transform.position, diff.normalized, Color.red);

        if (autoOrient) { AutoOrient(-diff); }
    }
    void AutoOrient(Vector3 down)
    {
        Quaternion orientationDirection = Quaternion.FromToRotation(-transform.up, down) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, orientationDirection, autoOrientSpeed * Time.deltaTime);
    }
}
