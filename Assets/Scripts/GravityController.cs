using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private bool IsGrabbed = false;
    void Update()
    {
        if (IsGrabbed)
        {
            this.GetComponent<Gravity>().enabled = false;
        }
        else
        {
            this.GetComponent<Gravity>().enabled = true;
        }
    }
}
