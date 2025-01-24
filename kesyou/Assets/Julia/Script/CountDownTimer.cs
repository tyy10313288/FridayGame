using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    public Text resultText;
    public Text timerText;
    private float startTime;
    public float countdownTime = 60;
    public static bool canClick = true;

    public AudioClip failSE;
    public AudioClip successSE;
    public AudioSource audioSource;    

    void Start()
    {
        startTime = Time.time;
        BeginCountdown();
        audioSource = GetComponent<AudioSource>();
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
            SceneManager.LoadScene("bunki");
            audioSource.PlayOneShot(successSE);
        }
        else
        {
            SceneManager.LoadScene("GameOver");
            audioSource.PlayOneShot(failSE);
        }
    }
    void CheckObjectsDestroyed()
{
    GameObject[] objects = GameObject.FindGameObjectsWithTag("ke");
    if (objects.Length == 0)
    {
        canClick = false;
        SceneManager.LoadScene("bunki");
        audioSource.PlayOneShot(successSE);
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