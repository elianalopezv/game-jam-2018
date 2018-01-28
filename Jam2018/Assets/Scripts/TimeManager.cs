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
