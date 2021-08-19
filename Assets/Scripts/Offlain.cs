using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Offlain : MonoBehaviour
{
    [SerializeField] private GameObject offlainPanel;
    [SerializeField] private Text timePassedText;
    [SerializeField] private Text offlainIncomeText;
    private int Value_of_Passed_Seconds;
    void Start()
    {
        OfflainGame();
        offlainPanel.SetActive(false);
        if (PlayerPrefs.GetInt("IsFirs", 0)==0 || Value_of_Passed_Seconds<10)
        {
            PlayerPrefs.SetInt("IsFirs", 1);
        }
        else
        {
            offlainPanel.SetActive(true);
            timePassedText.text = $"You were gone for {CountsUIView.TransforCount(Value_of_Passed_Seconds)} seconds";
            offlainIncomeText.text = $"During this time, you received {CountsUIView.TransforCount(Value_of_Passed_Seconds * MainLoop.CheckMicrochipsPerSecond()*MainLoop._incomeCoefficient * MainLoop._oflainCoefficient)} Score";
        }
    }

    private void OfflainGame()//Function for getting time spent outside the game
    {
        DateTime lastSaveTime = Utils.GetDateTime(key: "LastSaveTime", DateTime.UtcNow);
        TimeSpan timePassed = DateTime.UtcNow - lastSaveTime;
        int secondsPassed = (int)timePassed.TotalSeconds;
        secondsPassed = Mathf.Clamp(value: secondsPassed, min: 0, max: 7 * 24 * 60 * 60);
        Value_of_Passed_Seconds = secondsPassed;
    }
    public void Offlain_x1()
    {
        offlainPanel.SetActive(false);
        MainLoop.AddMicrochips(Value_of_Passed_Seconds * MainLoop.CheckMicrochipsPerSecond() * MainLoop._oflainCoefficient);
    }
}
