using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
    public Action<String> OnSendString;
    public GameObject[] destinationBox;
    public Transform arCamera;
    public GameObject currentBox;
    public GameObject cube;
    public GameObject player;
    public GameObject tutorialManager;
    public GameObject LoseScreen;
    public GameObject winScreen;
    private GrillManager grill;
    public Slider sliderBar;
    public Color[] scanColor;

    public string[] letters;

    public bool letsMove;

    public Vector3[] rotationsCube;

    public int idBox;

    private float timeRotation;
    private float scanTime = 0f;
    private float incrementAmount = 1f;

    public GameObject tranAnim;
    public int letterCount;

    private bool canStorageAction = true;
    private TimeManager timeReference;
    private bool secuenceDefined;
    private bool alreadyMove;
    private bool loser;
    private bool winner;
    private bool inPause;
    private bool playTheAnim;

    private Player playerReference;


	void Awake()
	{
		if(Instance == null)
			Instance = this;
	}

    private void Start()
    {
        timeReference = GetComponent<TimeManager>();
        tranAnim.gameObject.SetActive(true);
        tranAnim.GetComponent<Animator>().SetBool("Inv", true);
        playerReference = player.GetComponent<Player>();
        grill = GetComponent<GrillManager>();
        currentBox = destinationBox[0];
        timeReference.OnFinishTime += OnTimeOver;
        idBox++;
        letters = new string[5];
        playerReference.OnCompleteMove += OnCompleteMovement;
        playerReference.OnDie += OnLose;
        playerReference.OnWin += OnWin;
        Destroy(tranAnim, 1f);
    }

	private void Update()
	{
		if(!canStorageAction)
		{
            ReloadToScan();
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            //SliderUpdate();
            ResumeGame();
            if(loser)
            {
                StartCoroutine(ChangeScene(0));
                loser = false;
            }
            if (winner)
            {
                StartCoroutine(ChangeScene(0));
                winner = false;
            }
        }
        arCamera.position = new Vector3(0, 0, 0);
        arCamera.rotation = Quaternion.Euler(45, 0, 0);

        //if(OrderManager.Instance.orderStack.Count > 0) CalculateDestinations ();
    }



	public void AddParameter(string Parameter){
		if(canStorageAction)
		{
            //grill.actionName[letterCount] = Parameter;
            if(OnSendString != null)
            {
                OnSendString(Parameter);
            }
            if (letterCount <= letters.Length)
			{	
				letters[letterCount] = Parameter;
                canStorageAction = false;
				if(letterCount >= letters.Length -1)
				{
                    //Debug.Break ();
                    secuenceDefined = true;
					//Movement ();
				}
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

	private void ReloadToScan()
	{
		scanTime -= Time.deltaTime;
		if(scanTime <= 0)
		{
			scanTime = 0f;
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
    public void PlayButton()
    {
        if(secuenceDefined)
        {
            Movement();
        }
    }
    private void OnCompleteMovement(bool complete)
    {
        for(int i = 0; i < letters.Length; i++)
        {
            letters[i] = null;
        }
        letterCount = 0;
        secuenceDefined = false;
        grill.EraseAction();
    }
    private void OnLose(bool lose)
    {
        LoseScreen.SetActive(true);
        loser = true;
    }
    private IEnumerator ChangeScene(int sceneNumber)
    {
        //Hacer Transicion
        SceneManager.LoadScene(sceneNumber);
        yield return new WaitForSeconds(2);
    }
    private void OnWin(bool win)
    {
        print("EnAccion");
        winScreen.SetActive(true);
        winner = true;
    }
    private void OnTimeOver(bool overTime)
    {
        OnLose(true);
    }
}
