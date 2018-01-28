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
	float playTime = 120;

    private void Update()
    {

	

		if (playTime > 0)

		{

			playTime = playTime - 1 * Time.deltaTime;



		}
		else
		{
			if (OnFinishTime != null) {

				OnFinishTime (true);
			}
		}
		textTime.text = playTime.ToString("0");

    }
}
