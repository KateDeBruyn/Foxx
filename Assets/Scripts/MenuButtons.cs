using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject instructionsPan;
    public GameObject creditsPan;
    public GameObject startPan;

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Instrctions()
    {
        instructionsPan.SetActive(true);
        startPan.SetActive(false);
    }

    public void Credits()
    {
        creditsPan.SetActive(true);
        startPan.SetActive(false);
    }

    public void Return()
    {
        startPan.SetActive(true);
        instructionsPan.SetActive(false);
        creditsPan.SetActive(false);
    }
}
