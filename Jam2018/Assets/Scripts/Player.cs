using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {

    public Action<bool> OnDie;
    public Action<bool> OnWin;
    public Action<bool> OnCompleteMove;
    public GameManager manager;
	public Transform currentCube;
	public int currentMovement = 0;
	public float speed = 1f;
	public bool onDestination = false;
	public string[] movesList = null;
	public float maxDelay = 0.5f;
	public float timeWhenArrived = 0f;
	public bool waiting = false;
	private Transform rex;
    private GameObject flashParticle;
	public Animator animator;
	public Transform startPosition;


	void Start()
	{
		rex = transform.GetChild (0);
        flashParticle = transform.GetChild(1).gameObject;
        animator = GetComponentInChildren<Animator> ();
//		{"m_LeftArrow",  == Left
//		"m_Target", == Right
//		"m_P", == back
//		"m_Plus", == Forward
		// hash ==  Accion
		//dot ==  LOGO NO ACTION

//		};

		/*string[] list = {

			"m_Plus",
			"m_LeftArrow",
			"m_Target",
			"m_Plus",
			"m_LeftArrow",
			"m_P"

		};
		StartMovements(list);*/
	}

	void Update()
	{

		if (!onDestination && movesList != null) {
			
			transform.position += transform.forward * Time.deltaTime * speed;
					
		}

		if (onDestination && (Time.time - timeWhenArrived) > maxDelay) {

			onDestination = false;
			currentMovement++;

			if (currentMovement < movesList.Length && movesList !=null)
				ExecuteMovement (movesList [currentMovement]);
			else
            {
                StayInCube();
                if(OnCompleteMove != null)
                {
                    OnCompleteMove(true);
                }
            }
			

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
		case "icon_front":
			MoveForward ();
			break;

		case "icon_right":
			MoveRight ();
			break;

		case "icon_back":
			MoveBack ();
			break;

		case "icon_left":
			MoveLeft ();
			break;



		default:
			Debug.Log ("Not a command!");
			break;
		}

		animator.SetTrigger ("Walk");
	}

	public void StayInCube()
	{
		transform.position = currentCube.transform.position;
        transform.localPosition = new Vector3(transform.localPosition.x, 3, transform.localPosition.z);
        onDestination = false;
		movesList = null;
		animator.SetTrigger ("Idle2");
	}



	public void OnDestination(Transform newCurrent, Tiles.myProperty property)
	{
		onDestination = true;
		transform.position = newCurrent.position;
		rex.localPosition = new Vector3 (0, 0, 0);
		transform.localPosition = new Vector3(transform.localPosition.x,3,transform.localPosition.z);
		currentCube = newCurrent;
		timeWhenArrived = Time.time;

		RunProperty (property);

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
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y-90, 0);
	}

	public void RunProperty(Tiles.myProperty property)
	{

		switch (property) 
		{
		case Tiles.myProperty.Walkable:
			break;
		case Tiles.myProperty.Interactable:
			Interact ();
			break;
		case Tiles.myProperty.Dieable:
			Die ();
			break;
		case Tiles.myProperty.Winable:
			Win ();
			break;
			}
		}

	public void Die()
	{
		Debug.Log ("Died!");
		movesList = null;
		Destroy(this.gameObject); //TODO  Die animation
        if(OnDie != null)
        {
            OnDie(true);
        }
		// TODO Reset level

	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Infection")
        {
            other.transform.parent.GetComponent<AudioSource>().Play();
            print("tocoInfeccion");
            other.gameObject.SetActive(false);
            manager.SliderUpdate();
        }
    }
    public void Win()
	{
		Debug.Log ("Win!");
		movesList = null;
        flashParticle.SetActive(true);
        if(OnWin != null)
        {
            OnWin(true);
        }
		//TODO Pass next level!
	}

	public void Walk()
	{
		maxDelay = 0.5f; // Set default delay only to continue
	}

	public void Interact()
	{
		maxDelay = 1f; //Set time delay to show catch animation
		animator.SetTrigger ("Idle2"); // TODO use catch animation

	}



}





