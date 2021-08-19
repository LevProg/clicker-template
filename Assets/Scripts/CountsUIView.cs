using System;
using UnityEngine;
using UnityEngine.UI;

public class CountsUIView : MonoBehaviour
{
    [SerializeField] private Text _microchipsText;
    [SerializeField] private Text _microchipsPerSecondText;

    void Start()
    {
        MainLoop.updateCounts += UpdateCounts;
        UpdateCounts();
    }
    private void UpdateCounts()
    {
        _microchipsText.text = $"  Score: {TransforCount(MainLoop.CheckMicrochips())}";
        _microchipsPerSecondText.text = $"  Score per second: {TransforCount(MainLoop.CheckMicrochipsPerSecond()*MainLoop._incomeCoefficient)}";

    }
    public static string TransforCount(float count) 
    {
        string PreText = "";
        string PreTextEnd = "";
        string Figures = "";
        long allMoneyText = 0;
        if (count < 1000)
        {
            return ((float)Math.Round(count, 1)).ToString();
        }
        else
        {
            if (count >= 1000)
            { 
                PreTextEnd = (((long)count % 1000) / 10).ToString();

                allMoneyText = (long)count / 1000;

                PreText = "K";
            }
            if (count > 1000000)
            {
                PreTextEnd = (((long)count % 1000000) / 10000).ToString();

                allMoneyText = (long)count / 1000000;

                PreText = "M";
            }
            if (count > 1000000000)
            {
                PreTextEnd = (((long)count % 1000000000) / 10000000).ToString();

                allMoneyText = (long)count / 1000000000;

                PreText = "B";
            }

            if (count > 1000000000000)
            {
                PreTextEnd = (((long)count % 1000000000000) / 10000000000).ToString();

                allMoneyText = (long)count / 1000000000000;

                PreText = "a";
            }


            if (count > 1000000000000000)
            {
                PreTextEnd = (((long)count % 1000000000000000) / 10000000000000).ToString();

                allMoneyText = (long)count / 1000000000000000;

                PreText = "b";
            }
            if (PreTextEnd == "") { Figures = ""; }
            else { Figures = ","; }
            return (allMoneyText.ToString() + Figures + PreTextEnd + PreText);
        }
    }
    public static string TransforCount(int count)
    {
        string PreText = "";
        string PreTextEnd = "";
        string Figures = "";
        long allMoneyText = 0;
        if (count < 1000)
        {
            return count.ToString();
        }
        else
        {
            if (count > 1000000000)
            {
                PreTextEnd = ((count % 1000000000) / 10000000).ToString();

                allMoneyText = count / 1000000000;

                PreText = "B";
            }
            else if (count > 1000000)
            {
                PreTextEnd = ((count % 1000000) / 10000).ToString();

                allMoneyText = count / 1000000;

                PreText = "M";
            }
            else if (count >= 1000)
            {
                PreTextEnd = ((count % 1000) / 10).ToString();

                allMoneyText = count / 1000;

                PreText = "K";
            }
            if (PreTextEnd == "") { Figures = ""; }
            else { Figures = ","; }
            return (allMoneyText.ToString() + Figures + PreTextEnd + PreText);
        }
    }
}

