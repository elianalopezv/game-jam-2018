﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;


    public GameObject[] destinationBox;
    public GameObject currentBox;
    public GameObject cube;
    public GameObject player;

    public string[] letters;

    public bool letsMove;

    public Vector3[] rotationsCube;

    public int idBox;

    private float timeRotation;
    private float scanTime = 1.5f;

    private int letterCount;

    private bool canStorageAction = true;
    private bool secuenceDefined;


	void Awake()
	{
		if(Instance == null)
			Instance = this;
	}

    private void Start()
    {
        currentBox = destinationBox[0];
        idBox++;
        letters = new string[2];
    }
    private void Update()
    {
        if(canStorageAction)
        {
//            if(letterCount < letters.Length)
//            {
////                if (Input.GetKeyDown(KeyCode.A) && canStorageAction && letterCount < letters.Length)
////                {
////                    letters[letterCount] = "A";
////                    canStorageAction = false;
////                }
////                if (Input.GetKeyDown(KeyCode.S) && canStorageAction && letterCount < letters.Length)
////                {
////                    letters[letterCount] = "S";
////                    canStorageAction = false;
////                }
//            }
//            else
//            {
//                letsMove = true;
//            }
        }
        else
        {
            ReloadToScan();
        }

		//if(OrderManager.Instance.orderStack.Count > 0) CalculateDestinations ();
    }


	public void AddParameter(string Parameter){
		if(canStorageAction)
		{
			if(letterCount < letters.Length)
			{
				letters[letterCount] = Parameter;
			    canStorageAction = false;
				if(letterCount >= letters.Length -1 )
				{
					Movement ();
				}

				//                if (Input.GetKeyDown(KeyCode.A) && canStorageAction && letterCount < letters.Length)
				//                {
				//                    letters[letterCount] = "A";
				//                    canStorageAction = false;
				//                }
				//                if (Input.GetKeyDown(KeyCode.S) && canStorageAction && letterCount < letters.Length)
				//                {
				//                    letters[letterCount] = "S";
				//                    canStorageAction = false;
				//                }
			}
		}
		else
		{
			ReloadToScan();
		}
	}

    private void Movement()
    {
		player.GetComponent<Player> ().StartMovements (letters);
    }
    private void StayInYourBox()
    {
        player.transform.position = currentBox.transform.position;
    }
    private void RotateCube()
    {

    }
    private void ReloadToScan()
    {
        scanTime -= Time.deltaTime;
        if(scanTime <= 0)
        {
            scanTime = 1.5f;
            canStorageAction = true;
            letterCount++;
        }
    }

	public void CalculateDestinations()
	{
		foreach (var order in OrderManager.Instance.orderStack) 
		{
			switch (order) 
			{
			case OrderManager.Order.Forward:
				destinationBox [0].GetComponent<MeshRenderer> ().material.color = Color.green;
				break;
			default:
				destinationBox [0].GetComponent<MeshRenderer> ().material.color = Color.red;
				break;
				
			}
		}
	}

}
