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

    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        base.OnSelectEntering(interactor);

        Vector3 initPos = interactor.transform.position;
        Vector3 handDelta = interactor.transform.position - initPos;
        rb.AddForce(handDelta * pushForce, ForceMode.VelocityChange);
    }
}
