using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject controlScreen;

    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToTitleScreen()
    {
        SceneManager.LoadScene("Title");
    }

    public void ShowControls()
    {
        controlScreen.SetActive(true);
    }
    public void HideControls()
    {
        controlScreen.SetActive(false);
    }
}
