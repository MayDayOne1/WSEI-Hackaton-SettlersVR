using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtualGrasp;

public class PlanetRotationEventHandler : MonoBehaviour
{
    public GameObject rotationObj;

    public Quaternion lastFrameRot;
    public Quaternion thisFrameRot;

    public static PlanetRotationEventHandler instance;

    public event Action planetRotates;
    public event Action planetStopped;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        
        instance.planetRotates += NotStop;
        instance.planetStopped += Stop;
    }

    // Start is called before the first frame update
    void Start()
    {
        lastFrameRot = rotationObj.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        thisFrameRot = rotationObj.transform.rotation;
        if (thisFrameRot != lastFrameRot)
        {
            planetRotates();
        }
        else
        {
            planetStopped(); 
        }
        lastFrameRot = thisFrameRot;
    }

    public void Stop()
    {
        Debug.Log("zzzzzz");
    }

    public void NotStop()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }
}
