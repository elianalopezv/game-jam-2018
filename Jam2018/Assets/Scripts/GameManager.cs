using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;


    public GameObject[] destinationBox;
    public GameObject currentBox;
    public GameObject cube;
    public GameObject player;
    public GameObject tutorialManager;
    public Slider sliderBar;
    public Color[] scanColor;

    public string[] letters;

    public bool letsMove;

    public Vector3[] rotationsCube;

    public int idBox;

    private float speed = .5f;
    private float timeRotation;
    private float scanTime = 1.5f;
    private float incrementAmount = .2f;

    private int letterCount;

    private bool canStorageAction = true;
    private bool secuenceDefined;
    private bool inPause;


	void Awake()
	{
		if(Instance == null)
			Instance = this;
	}

    private void Start()
    {
        currentBox = destinationBox[0];
        idBox++;
        letters = new string[4];
    }
    private void Update()
    {
//        if(canStorageAction)
//        {
////            if(letterCount < letters.Length)
////            {
//////                if (Input.GetKeyDown(KeyCode.A) && canStorageAction && letterCount < letters.Length)
//////                {
//////                    letters[letterCount] = "A";
//////                    canStorageAction = false;
//////                }
//////                if (Input.GetKeyDown(KeyCode.S) && canStorageAction && letterCount < letters.Length)
//////                {
//////                    letters[letterCount] = "S";
//////                    canStorageAction = false;
//////                }
////            }
////            else
////            {
////                letsMove = true;
////            }
//        }
//        else
//        {
//            ReloadToScan();
//        }
//        if (letsMove)
//            Movement();
//        else
//            StayInYourBox();
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            //SliderUpdate();
            ResumeGame();
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
					letsMove = true;
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
        Vector3 direccion = (player.transform.position - destinationBox[idBox].transform.position).normalized;
        Vector3 move = player.transform.position - (direccion * speed * Time.deltaTime);
        //player.transform.rotation = destinationBox[idBox].transform.rotation;
         timeRotation += Time.deltaTime * .0035f;
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, destinationBox[idBox].transform.rotation, timeRotation);
        player.transform.position = move;
        if((player.transform.position - destinationBox[idBox].transform.position).magnitude < .05f)
        {
            if(destinationBox[idBox].GetComponent<Tiles>().myString == letters[idBox])
            {
                currentBox = destinationBox[idBox];
                if (idBox < destinationBox.Length - 1)
                    idBox++;
                else
                {
                    letsMove = false;
                }
            }
            else
            {
                player.SetActive(false);
            }
        }
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
			case OrderManager.Order.Catch:
				destinationBox [0].GetComponent<MeshRenderer> ().material.color = Color.green;
				break;
			default:
				destinationBox [0].GetComponent<MeshRenderer> ().material.color = Color.red;
				break;
				
			}
		}
	}
    public void PauseButton()
    {
        inPause = true;
        tutorialManager.SetActive(true);
        Time.timeScale = 0;
    }
    private void ResumeGame()
    {
        inPause = false;
        tutorialManager.SetActive(false);
        Time.timeScale = 1;
    }
    public void SliderUpdate()
    {
        sliderBar.value += incrementAmount;
    }
}
