using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AllSounds : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    public GameObject MusicTick;
    public GameObject UITick;

    void Start()
    {
        StartMaster();
    }
    public void StartMaster()
    {
        if (PlayerPrefs.GetInt(key: "Music", defaultValue: 0) == 0)
        {
            OffMusic();
        }
        else
        {
            OnMusic();
        }

        if (PlayerPrefs.GetInt(key: "Sound", defaultValue: 0) == 0)
        {
            OffUI();
        }
        else
        {
            OnUI();
        }
    }
    public void ChouseMusic()
    {
        Debug.Log("m");
        if (PlayerPrefs.GetInt(key: "Music", defaultValue: 0) == 1)
        {
            OffMusic();
        }
        else
        {
            OnMusic();
        }
    }
    public void ChouseUI()
    {
        Debug.Log("u");
        if (PlayerPrefs.GetInt(key: "Sound", defaultValue: 0) == 1)
        {
            OffUI();
        }
        else
        {
            OnUI();
        }
    }
    private void OnMusic()
    {
        Mixer.audioMixer.SetFloat("Music", 0);
        MusicTick.gameObject.SetActive(true);
        PlayerPrefs.SetInt("Music", 1);
        PlayerPrefs.Save();
    }
    private void OffMusic()
    {
        Mixer.audioMixer.SetFloat("Music", -80);
        MusicTick.gameObject.SetActive(false);
        PlayerPrefs.SetInt("Music", 0);
        PlayerPrefs.Save();
    }
    private void OnUI()
    {
        Mixer.audioMixer.SetFloat("Sound", 0);
        UITick.gameObject.SetActive(true);
        PlayerPrefs.SetInt("Sound", 1);
        PlayerPrefs.Save();
    }
    private void OffUI()
    {
        Mixer.audioMixer.SetFloat("Sound", -80);
        UITick.gameObject.SetActive(false);
        PlayerPrefs.SetInt("Sound", 0);
        PlayerPrefs.Save();
    }
}
