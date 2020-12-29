using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance; 
    public int miliSecond;
    public int second;
    public int minute;
    public Text timer, currentTime, bestTime;
    public GameObject currentText, bestTimeText;
    int min, sec, msec;
    int bestMinute, bestSecond, bestMiliSecond; 

    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("SaveMinute")) {

            bestMinute = PlayerPrefs.GetInt("SaveMinute");
        }
        if (PlayerPrefs.HasKey("SaveSecond"))
        {
            bestSecond = PlayerPrefs.GetInt("SaveSecond");
        }
        if (PlayerPrefs.HasKey("SaveMiliSecond"))
        {
            bestMiliSecond = PlayerPrefs.GetInt("SaveMiliSecond");
        }
    }

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
            timer.text = "Timer: " + $"{minute / 100}:{second / 100},{miliSecond}";
            instance.AddTime();
            //currentTime.text = "Your time: " + $"{minute / 100} : {second / 100} : {miliSecond}";
        }
        if (Player.lose)
        {
            currentText.SetActive(true);
            bestTimeText.SetActive(true);
        }
    }

    public void AddTime()
    {
        min = minute / 100;
        sec = second / 100;
        msec = miliSecond;
        currentTime.text = "Your time: " + $"{min}:{sec},{msec}";
        BestTime();
    }

    public void BestTime()
    {
        if (msec > bestMiliSecond && sec <= bestMiliSecond && min <= bestMinute)
        {
            bestMiliSecond = msec;
        }
        else if (sec > bestSecond && min <= bestMinute)
        {
            bestMiliSecond = msec;
            bestSecond = sec;
        }
        else if (min > bestMinute)
        {
            bestMiliSecond = msec;
            bestSecond = sec;
            bestMinute = min;
        }
        bestTime.text = "The best time: " + $"{bestMinute}:{bestSecond}";
        PlayerPrefs.SetInt("SaveMinute", bestMinute);
        PlayerPrefs.SetInt("SaveSecond", bestSecond);
        PlayerPrefs.SetInt("SaveMiliSecond", bestMiliSecond);
    }
}
