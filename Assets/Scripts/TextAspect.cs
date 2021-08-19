using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAspect : MonoBehaviour
{
    void Start()
    {
        if (Screen.height < 1900)
        {
            gameObject.GetComponent<Text>().fontSize = 130;
        }
        if (Screen.height < 1200)
        {
            gameObject.GetComponent<Text>().fontSize = 75;
        }
    }
}
