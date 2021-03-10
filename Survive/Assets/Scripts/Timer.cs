using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text text;
    private int hour = 0;
    void Start()
    {
        InvokeHour();
    }

    private void InvokeHour()
    {
        Invoke("IncreaseHour", 60);
    }
    private void IncreaseHour()
    {
        if(hour < 8)
        {
            hour += 1;
            text.text = "0" + hour.ToString() + ":00";
            InvokeHour();
        }
    }
}