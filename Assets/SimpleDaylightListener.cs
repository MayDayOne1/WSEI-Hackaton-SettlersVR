using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class SimpleDaylightListener : MonoBehaviour
{
    private void Start()
    {
        DayAndNightCycleManager.instance.onHourPassed += simpleListener;
    }

    private void simpleListener()
    {
        Debug.Log(gameObject.name+": Hour Passed");
    }
}
