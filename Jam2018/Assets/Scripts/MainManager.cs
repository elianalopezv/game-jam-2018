using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public GameObject transition;

    public void StartButton()
    {
        transition.SetActive(true);
        StartCoroutine(StartProcess());
    }
    public void TutorialButton()
    {

    }
    private IEnumerator StartProcess()
    {
        yield return new WaitForSeconds(1.8f);
        //SceneManager.LoadScene("MasterScene");
    }
}
