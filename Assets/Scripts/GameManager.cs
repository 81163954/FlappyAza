using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float score=99;
    public Text scoreText;
    public bgControl bgControl;
    public bgControl bgControl2;
    public bgControl bgControl3;
    public bgControl bgControl4;
    public bgControl bgControl5;
    public SetEnemySpeed SetEnemySpeed;
    public AudioSource BGsound;

    public static GameManager _instance;
    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        /*Time.timeScale = 0;*/
        if (PlayerPrefs.HasKey("globalVolume"))
        {
            BGsound.volume = PlayerPrefs.GetFloat("globalVolume");
        }
    }

    private void Update()
    {
        
    }

    public void setScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void setSpeedToZero()
    {
        bgControl.speed = 0;
        bgControl2.speed = 0;
        bgControl3.speed = 0;
        bgControl4.speed = 0;
        bgControl5.speed = 0;
        //Enemy.speed = 0;
        SetEnemySpeed.SetSpeed();

    }

    public void TimeScaleOne()
    {
        Time.timeScale = 1;
    }

    public void TimeScaleZero()
    {
        Time.timeScale = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
