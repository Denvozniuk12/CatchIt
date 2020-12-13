using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int miliSecond;
    public int second;
    public int minute;

    public Text text;

    public void FixedUpdate()
    {
        if (!Player.lose)
        {
            miliSecond += 2;
            if (miliSecond >= 100)
            {
                second += 100;
                miliSecond = 0;
            }
            if (second >= 6000)
            {
                minute += 100;
                second = 0;
            }
            text.text = "Timer: " + $"{minute / 100} : {second / 100} : {miliSecond}";
        }
    }
}
