using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeManager : MonoBehaviour
{
    public Action<bool> OnFinishTime;
    public float timer = 120f;
    public Text textTime;

    private void Update()
    {
        timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        if(minutes < 10 && seconds < 10)
        {
            textTime.text = "0" +Mathf.Abs(minutes) + ":" + "0" + Mathf.Abs(seconds);
        }
        if(minutes < 10 && seconds >= 10)
        {
            textTime.text = "0" + Mathf.Abs(minutes) + ":" + Mathf.Abs(seconds);
        }
        if (minutes >= 10 && seconds > 10)
        {
            textTime.text = Mathf.Abs(minutes) + ":" + Mathf.Abs(seconds);
        }
        if(timer >= 0)
        {
            timer = 0;
            if(OnFinishTime != null)
            {
                OnFinishTime(true);
            }
        }

    }
}
