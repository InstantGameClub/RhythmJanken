using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public InGameController in_game_controller;
    public Button startButton;
    public Button gameOver;
    public Text timer;
    public int minutes;
    public float seconds;
    public float oldSeconds;
    public bool OnGame;


    // Use this for initialization
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        minutes = 0;
        seconds = 0;
        OnGame = false;
        startButton.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        in_game_controller.initialize();
    }

    public void GameStartPush()
    {
        startButton.gameObject.SetActive(false);
        in_game_controller.initializeGameStart();
        OnGame = true;
    }

    public void GameOver()
    {
        OnGame = false;
        in_game_controller.initializeGameOver();
        gameOver.gameObject.SetActive(true);
    }

    public void GameOverPush()
    {
        gameOver.gameObject.SetActive(false);
        Initialize();
    }

    private void TimeWatch()
    {
        if (seconds >= 60f)
        {
            minutes++;
            seconds = seconds - 60;
        }
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            in_game_controller.gageDec();
            timer.text = minutes.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (OnGame)
        {
            seconds += Time.deltaTime;
            TimeWatch();
        }
    }
}
