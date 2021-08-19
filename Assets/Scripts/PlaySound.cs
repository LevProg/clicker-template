using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource audio;
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }
    public void StartSound()
    {
        audio.pitch = Random.RandomRange(0.85f,1.15f);
        audio.Play();
    }
}
