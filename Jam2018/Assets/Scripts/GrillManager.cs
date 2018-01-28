using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrillManager : MonoBehaviour
{
    public GameObject myGrill;
    public Sprite[] actionImage;
    public string[] actionName;
    private GameManager gManager;
    public int idAction;
    private int numberOfActions;

    private void Start()
    {
        gManager = GetComponent<GameManager>();
        actionName = new string[gManager.letters.Length];
        numberOfActions = actionName.Length;
        DeleteMyGrill();
        gManager.OnSendString += SendedString;
    }
    private void Update()
    {
       
    }
    private void SendedString(string myString)
    {
        actionName[idAction] = myString;
        myGrill.transform.GetChild(idAction).GetChild(0).gameObject.SetActive(true);
        switch (actionName[idAction])
            {
                case "icon_front":
                    myGrill.transform.GetChild(idAction).GetChild(0).GetComponent<Image>().sprite = actionImage[2];
                    idAction++;
                    break;

                case "icon_right":
                    myGrill.transform.GetChild(idAction).GetChild(0).GetComponent<Image>().sprite = actionImage[5];
                    idAction++;
                    break;

                case "icon_back":
                    myGrill.transform.GetChild(idAction).GetChild(0).GetComponent<Image>().sprite = actionImage[1];
                    idAction++;
                    break;

                case "icon_left":
                    myGrill.transform.GetChild(idAction).GetChild(0).GetComponent<Image>().sprite = actionImage[4];
                    idAction++;
                    break;


                default:
                    Debug.Log("Not a command!");
                    break;
            }
    }
    private void DeleteMyGrill()
    {
        for(int i = 0; i<6 ; i++)
        {
            myGrill.transform.GetChild(i).gameObject.SetActive(false);
            myGrill.transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
        }
        for (int i = 0; i < numberOfActions; i++)
        {
            myGrill.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void EraseAction()
    {
        idAction = 0;
        for (int i = 0; i < actionName.Length; i++)
        {
            actionName[i] = null;
        }
        DeleteMyGrill();
    }

}
