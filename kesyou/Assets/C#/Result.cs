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
            GameObject amra = (GameObject)Resources.Load("�A�����[");
            GameObject amrabackground = (GameObject)Resources.Load("�A�����[�@�w�i�@�ڂ���");

            Instantiate(amra, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(amrabackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if(result == 9)
        {
            GameObject shrek = (GameObject)Resources.Load("�V�����b�N");
            GameObject shrekbackground = (GameObject)Resources.Load("�V�����b�N�@�w�i�@�ڂ���");

            Instantiate(shrek, new Vector2(-3, -0.66f), Quaternion.identity);
            Instantiate(shrekbackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if(result == 10)
        {
            GameObject piccolo = (GameObject)Resources.Load("�s�b�R��");
            GameObject piccolobackground = (GameObject)Resources.Load("�s�b�R���@�w�i�@�ڂ���");

            Instantiate(piccolo, new Vector2(-3, -0.66f), Quaternion.identity);
            Instantiate(piccolobackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
    }
}
