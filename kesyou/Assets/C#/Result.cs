using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    int result;
    void Start()
    {
        result = PlayerPrefs.GetInt("RESULT", 0);

        if (result == 1)
        {
            GameObject ordinarygirl = (GameObject)Resources.Load("普通の女の子");
            GameObject ordinarybackground = (GameObject)Resources.Load("清楚系　背景　ぼかし");

            Instantiate(ordinarygirl, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(ordinarybackground, new Vector3(-3, -0.5f,1), Quaternion.identity);
        }
        if (result == 4)
        {
            GameObject ordinarygirl = (GameObject)Resources.Load("アムラー");
            GameObject ordinarybackground = (GameObject)Resources.Load("アムラー　背景　ぼかし");

            Instantiate(ordinarygirl, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(ordinarybackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
