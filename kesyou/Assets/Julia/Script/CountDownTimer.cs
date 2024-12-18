using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public Text resultText;
    public Text timerText;
    private float startTime;
    public float countdownTime = 60;
    public static bool canClick = true;
    

    void Start()
    {
        startTime = Time.time;
        BeginCountdown();
    }

    void Update()
    {
        if (!canClick)
        return;

        float t = countdownTime - (Time.time - startTime);
        if (t <= 0)
        {
            timerText.text = "Time Out";
            canClick = false;
            CheckGameResult();
            return;
        }

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timerText.text = seconds;
        CheckObjectsDestroyed();
    }
    void CheckGameResult()
    {
        GameObject[] remainingKes = GameObject.FindGameObjectsWithTag("ke");
        if (remainingKes.Length == 0)
        {
            resultText.text = "Win";
        }
        else
        {
            resultText.text = "Lose";
        }
    }
    void CheckObjectsDestroyed()
{
    GameObject[] objects = GameObject.FindGameObjectsWithTag("ke");
    if (objects.Length == 0)
    {
        canClick = false;
        resultText.text = "Win";
    }
}

  void Awake()
{
    enabled = false;
}

public void BeginCountdown()
{
    startTime = Time.time;
    enabled = true;
}

}