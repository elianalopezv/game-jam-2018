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
    public Image myImageScan;
    public Color[] scanColor;

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



	public void AddParameter(string Parameter){
		if(canStorageAction)
		{
			if(letterCount < letters.Length)
			{	Debug.Log (letters.Length + " "+letterCount);
				letters[letterCount] = Parameter;
			    canStorageAction = false;
				if(letterCount >= letters.Length)
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
	}

    private void Movement()
    {
		player.GetComponent<Player> ().StartMovements (letters);
    }

    private void RotateCube()
    {

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
