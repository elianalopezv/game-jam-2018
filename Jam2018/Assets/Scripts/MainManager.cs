using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public GameObject transition;
    public GameObject canvasMenu;
    public GameObject tutorialScreen;
    private bool inTutorial;
    Animator animCanvas;

    public void Start()
    {
        animCanvas = canvasMenu.GetComponent<Animator>();
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (inTutorial)
                GoBack();
            else
            {
                Debug.LogWarningFormat("SalioDelApk");
                Application.Quit();
            }
        }
    }
    public void StartButton()
    {
        transition.SetActive(true);
        StartCoroutine(StartProcess());
    }
    public void TutorialButton()
    {
        animCanvas.SetBool("Revert", true);
        tutorialScreen.SetActive(true);
        inTutorial = true;
    }
    public void GoBack()
    {
        animCanvas.SetBool("Revert", false);
        tutorialScreen.SetActive(false);
        inTutorial = false;
    }
    private IEnumerator StartProcess()
    {
        yield return new WaitForSeconds(1.8f);
        //SceneManager.LoadScene("MasterScene");
    }
}
