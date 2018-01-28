using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrillManager : MonoBehaviour
{
    public GameObject myGrill;
    public Image[] actionImage;
    public string[] actionName;
    public GameObject[] grillElement;
    private GameManager gManager;

    private void Start()
    {
        gManager = GetComponent<GameManager>();
        actionName = new string[gManager.letters.Length];
    }
}
