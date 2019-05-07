using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Timers;

public class DigitalClock : MonoBehaviour
{
    public static Text clockText;
    public Text clock;
    public  double minutes;
    public  int hours;
    public int day =1;
    public int season = 1;
    private  DateTime time;
    public bool am;
    private  System.Timers.Timer aTimer;
    public OptionsMenu OptionsMenu;
    public farmland f;
    private void Start()
    {
        hours = 6;
        minutes = 0;
        am = true;
     
        SetTimer();
    }
    public void restart()
    {
        aTimer.Close();
        hours = 6;
        minutes = 0;
        am = true;
        SetTimer();
        day++;
        f.onDayEnd();
        if (day > 28)
        {
            day = 1;
            season++;
            if (season > 4)
            {
                season = 1;
            }
        }
    }

    private void SetTimer()
    {
        aTimer = new System.Timers.Timer(1000);
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }

    private void OnTimedEvent(System.Object source, ElapsedEventArgs e)
    {
        if (!OptionsMenu.GameIsPaused)
        {
            minutes++;
            if (minutes > 59)
            {
                minutes = 0;
                hours++;
            }
            if (hours == 12 && minutes == 0)
            {
                if (am)
                {
                    am = false;
                }
                else
                {
                    am = true;
                    day++;
                    f.onDayEnd();
                    if (day > 28)
                    {
                        day = 1;
                        season++;
                        if (season > 4)
                        {
                            season = 1;
                        }
                    }
                }
            }
            if (hours > 12)
            {
                hours = 1;
            }
        }
    }

    private void Update()
    {
        if (am)
        {
            if(minutes<10)
            {
                clock.text = hours + ":0" + minutes + "am";
            }
            else
            clock.text = hours + ":" + minutes + "am";
        }
        else
        {
            if (minutes < 10)
            {
                clock.text = hours + ":0" + minutes + "pm";
            }
            else
                clock.text = hours + ":" + minutes + "pm";
        }
    }
}

