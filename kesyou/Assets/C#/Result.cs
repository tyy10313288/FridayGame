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
            GameObject ordinarygirl = (GameObject)Resources.Load("���ʂ̏��̎q");
            GameObject ordinarybackground = (GameObject)Resources.Load("���^�n�@�w�i�@�ڂ���");

            Instantiate(ordinarygirl, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(ordinarybackground, new Vector3(-3, -0.5f,1), Quaternion.identity);
        }
        if (result == 4)
        {
            GameObject ordinarygirl = (GameObject)Resources.Load("�A�����[");
            GameObject ordinarybackground = (GameObject)Resources.Load("�A�����[�@�w�i�@�ڂ���");

            Instantiate(ordinarygirl, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(ordinarybackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
