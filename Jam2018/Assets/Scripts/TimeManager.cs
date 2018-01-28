using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float timer;
    public Text textTime;

    private void Update()
    {
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        if(minutes < 10 && seconds < 10)
        {
            textTime.text = "0" + minutes + ":" + "0" + seconds;
        }
        if(minutes < 10 && seconds >= 10)
        {
            textTime.text = "0" + minutes + ":" + seconds;
        }
        if (minutes >= 10 && seconds > 10)
        {
            textTime.text =  minutes + ":" + seconds;
        }

    }
}
