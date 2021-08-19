﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using System;

public class Utils : MonoBehaviour
{
    //Here are the functions to save time
    public static void SetDateTime(string key, DateTime value)
    {
        string convertedToString = value.ToString(format: "u",CultureInfo.InvariantCulture);
        PlayerPrefs.SetString(key, convertedToString);
    }
    public static DateTime GetDateTime(string key, DateTime value)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string stored = PlayerPrefs.GetString(key);
            DateTime result = DateTime.ParseExact(stored, format: "u", CultureInfo.InvariantCulture);
            return result;
        }
        else
        {
            return value;
        }
    }
}
