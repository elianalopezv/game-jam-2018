using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Transform currentCube;
	public int currentMovement = 0;
	public float speed = 1f;
	public bool onDestination = false;
	public string[] movesList = null;
	public float maxDelay = 1f;
	public float timeWhenArrived = 0f;
	public bool waiting = false;

	void Start()
	{
		string[] list = {"m_LeftArrow",
			"m_LeftArrow",
			"m_LeftArrow",
			"m_Target",
			"m_LeftArrow",
			"m_P",
			"m_Plus",
			"m_LeftArrow"
		};
		StartMovements(list);
	}

	void Update()
	{


		if (!onDestination && movesList != null) {
			
			transform.position += transform.forward * Time.deltaTime * speed;
			
		}
		else if (onDestination && (Time.time - timeWhenArrived) > maxDelay) {

			onDestination = false;
			currentMovement++;

			if (currentMovement < movesList.Length)
				ExecuteMovement (movesList [currentMovement]);
			else
				StayInCube ();

		}
	}

	public void StartMovements(string[] movesList)
	{
		this.movesList = movesList;
		currentMovement = 0;
		ExecuteMovement (this.movesList [currentMovement]);
	}

	public void ExecuteMovement(string name)
	{
		switch (name)
		{
		case "m_LeftArrow":
			MoveForward ();
			break;

		case "m_Target":
			MoveRight ();
			break;

		case "m_Plus":
			MoveBack ();
			break;

		case "m_P":
			MoveLeft ();
			break;

		case "m_Dot": //Jump
			break;

		case "m_Hash": //Action
			break;

		default:
			Debug.Log ("Not a command!");
			break;
		}

		GetComponentInChildren<Animator> ().SetTrigger ("Walk");
	}

	public void StayInCube()
	{
		transform.position = currentCube.transform.position;
		onDestination = false;
		movesList = null;

	}

	public void OnDestination(Transform newCurrent)
	{
		onDestination = true;
		currentCube = newCurrent;
		timeWhenArrived = Time.time;
	}

	public void MoveForward()
	{
		return;
	}

	public void MoveBack()
	{
		transform.localRotation = Quaternion.Euler (0, 180, 0);
	}

	public void MoveRight()
	{
		transform.localRotation = Quaternion.Euler (0, 90, 0);
	}

	public void MoveLeft()
	{
		transform.localRotation = Quaternion.Euler (0, -90, 0);
	}




}
