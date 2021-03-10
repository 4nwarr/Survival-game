using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text text;
    private int hour = 0;
    private int seconds = 0;
    
    void Start()
    {
        InvokeHour();
    }

    private void InvokeHour()
    {
        Invoke("IncreaseHour", 1);
    }

    private void IncreaseHour()
    {
        if(hour < 8)
        {
            seconds += 1;

            if(seconds < 10)
            {
                text.text = "0" + hour.ToString() + ": 0" + seconds.ToString();
            }
            else
            {
                text.text = "0" + hour.ToString() + ": " + seconds.ToString();
            }

            if(seconds == 60)
            {
                seconds = 0;
                hour += 1;
            }

            if(hour >= 3 && hour < 6)
            {
                text.color = Color.yellow;
            }
            else if(hour >= 6 && hour < 8)
            {
                text.color = Color.red;
            }

            InvokeHour();
        }
    }
}