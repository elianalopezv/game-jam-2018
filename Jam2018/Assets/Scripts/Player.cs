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
	private Transform rex;


	void Start()
	{
		rex = transform.GetChild (0);
//		{"m_LeftArrow",  == Left
//		"m_Target", == Right
//		"m_P", == back
//		"m_Plus", == Forward
		// hash ==  Accion
		//dot ==  LOGO NO ACTION

//		};

		string[] list = {

			"m_Plus",
			"m_Target",

		};
		StartMovements(list);
	}

	void Update()
	{

		if (!onDestination && movesList != null) {
			
			transform.position += transform.forward * Time.deltaTime * speed;
					
		}

		if (onDestination && (Time.time - timeWhenArrived) > maxDelay) {

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
		case "m_Plus":
			MoveForward ();
			break;

		case "m_Target":
			MoveRight ();
			break;

		case "m_P":
			MoveBack ();
			break;

		case "m_LeftArrow":
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
		transform.position = newCurrent.position;
		rex.localPosition = new Vector3 (0, 0, 0);
		transform.localPosition = new Vector3(transform.localPosition.x,3,transform.localPosition.z);
		currentCube = newCurrent;
		timeWhenArrived = Time.time;


	}

	public void MoveForward()
	{
		return;
	}

	public void MoveBack()
	{
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y+180, 0);
	}

	public void MoveRight()
	{
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y+90, 0);
	}

	public void MoveLeft()
	{
		Debug.Log ("Left");


		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y-90, 0);
	}




}
