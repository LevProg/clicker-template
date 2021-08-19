using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MainLoop : MonoBehaviour
{
    private static float _microchips;
    private static float _microchipsPerSecond;


    public static float _incomeCoefficient=1;
    public static float _oflainCoefficient = .5f;
    public static float _perSecondsCoefficient = 1;

    public delegate void UpdateCounts();
    public static event UpdateCounts updateCounts;
    private void Awake()
    {
        _microchipsPerSecond = 1;
        _oflainCoefficient = .5f + 0.1f * PlayerPrefs.GetInt("UP-51", 0);
        _perSecondsCoefficient = 1 + 0.1f * PlayerPrefs.GetInt("UP-52", 0);
        _incomeCoefficient = 1 + 0.1f*PlayerPrefs.GetInt("UP-53", 0);

        _microchips = PlayerPrefs.GetFloat("_microchips", 0);
        _microchipsPerSecond = PlayerPrefs.GetFloat("_microchipsPerSecond", 1) * _perSecondsCoefficient * _incomeCoefficient;
    }
    void Start()
    {
        updateCounts?.Invoke();
        StartCoroutine(Loop()); 
    }

    IEnumerator Loop()
    {
        while (true)//main game loop
        {
            yield return new WaitForSeconds(1f);
            AddMicrochips(CheckMicrochipsPerSecond());
            Utils.SetDateTime("LastSaveTime", DateTime.UtcNow);
        }
    }

    private static void SavePref()
    {
        PlayerPrefs.SetFloat("_microchips", _microchips);
        PlayerPrefs.SetFloat("_microchipsPerSecond", _microchipsPerSecond);
        PlayerPrefs.Save();
    }
    public static void ResetProgress()
    {
        _microchips = 0;
        _microchipsPerSecond = 1;
        PlayerPrefs.SetFloat("_microchips", 0);
        PlayerPrefs.SetInt("_microchipsPerSecond", 1);
        for (int i=0; i<49; i++)
        {
            PlayerPrefs.SetInt($"UP-{i}", 0);
        }

    }
    public static void AddMicrochipsPerSecond(int add)
    {
        if (add > 0)
        {
            _microchipsPerSecond += add;
            SavePref();
            updateCounts?.Invoke();
        }
        else
        {
            throw new ArgumentException();
        }
    }
    public static float CheckMicrochipsPerSecond()
    {
        return _microchipsPerSecond*_perSecondsCoefficient;
    }
    public static float CheckMicrochips()
    {
        return _microchips;
    }
    public static void AddMicrochips(float add)
    {
        if (add > 0)
        {
            _microchips += add*_incomeCoefficient;
            SavePref();
            updateCounts?.Invoke();
        }
        else
        {
            throw new ArgumentException();
        }
    }
    public static void ReduceMicrochips(float rent)
    {
        if (rent > 0)
        {
            _microchips -= rent;
            SavePref();
            updateCounts?.Invoke();
        }
        else
        {
            throw new ArgumentException();
        }
    }
    public static void ReduceMicrochips(int rent)
    {
        if (rent > 0)
        {
            if (rent >= _microchips)
            {
                _microchips -= rent;
            }
            else 
            {
                _microchips = 0;
            }
            SavePref();
            updateCounts?.Invoke();
        }
        else
        {
            throw new ArgumentException();
        }
    }
}
