using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNightCycleManager : MonoBehaviour
{
    public static DayAndNightCycleManager instance;
    public event Action onHourPassed;

    public int irlSecondsPerGameHour;

    public bool eventSent = false;

    private int TimeModulo() => (int)Mathf.Round(Time.time) % irlSecondsPerGameHour;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
    }

    private void Update()
    {
        if(TimeModulo() == 0)
        {
            if (!eventSent)
            {
                onHourPassed();
                eventSent = true;
            }
        }
        else
        {
            eventSent = false;
        }
    }
}
