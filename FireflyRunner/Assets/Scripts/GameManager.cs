using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI scoreValue;
    public TextMeshProUGUI timeValue;
    private PlayerController playerControllerScript;
    private float timer;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        score = 000000;
        scoreValue.text = "" + score;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //first number is delay, second (f) is rate of points of given
        InvokeRepeating("Timer", 0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreValue.text = "" + score;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void Timer()
    {
        if (!playerControllerScript.gameOver)
        {
            UpdateScore(1);
        }
    }

    public void StartGame()
    {
        titleScreen.SetActive(false);
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
