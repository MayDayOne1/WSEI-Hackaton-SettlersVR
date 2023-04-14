using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DayAndNightCycleManager : MonoBehaviour
{

    public event Action onHourPassed;

    public static DayAndNightCycleManager instance;
    public Light mainLight;
    public int irlSecondsPerGameHour;
    public int HoursPassedInADay = 0;
    public int DaysPassed = 0;
    public Vector2 DayTime = new Vector2(8, 20);
    public bool isDay;
    public float initialSunOffset;

    private bool wasEventSent = false;
    private int irlSecPerGameDay;
    private float dayPercent;

    private int gameHourModulo() => (int)Mathf.Round(Time.time) % irlSecondsPerGameHour;

    private void OnValidate()
    {
        RotateSun();
        CheckIfDay();
    }

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        irlSecPerGameDay = 24 * irlSecondsPerGameHour;
    }

    private void Update()
    {
        SendEventHourPassed();
        dayPercent = DayPercentage();
        RotateSun();
        CheckIfDay();
    }

    private void SendEventHourPassed()
    {
        if (gameHourModulo() == 0)
        {
            if (!wasEventSent)
            {
                onHourPassed();
                HoursPassedInADay++;
                if (HoursPassedInADay > 23)
                {
                    HoursPassedInADay = 0;
                    DaysPassed++;
                }
                wasEventSent = true;
            }
        }
        else
        {
            wasEventSent = false;
        }
    }

    private float DayPercentage() => (Time.time % irlSecPerGameDay) / irlSecPerGameDay;

    private void RotateSun()
    {
        Vector3 newRot = new Vector3(initialSunOffset + 360 * dayPercent, 0, 0);
        mainLight.transform.rotation = Quaternion.Euler(newRot);
    }

    private void CheckIfDay()
    {
        if (HoursPassedInADay > DayTime.x && HoursPassedInADay < DayTime.y)
            isDay = true;
        else 
            isDay = false;
    }
}
