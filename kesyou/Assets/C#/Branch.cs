using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Branch : MonoBehaviour
{
    public int a;
    public int _event;
    float delaytime = 0.1f;
    int _result;

    void Start()
    {
        _event = PlayerPrefs.GetInt("EVENT", 0);
        PlayerPrefs.SetInt("RESULT", 0);

        if(_event == 0)
            Invoke("_Start", 0);

        if (_event == 1)
            Invoke("Eyeshadow", 0);

        if(_event == 2)
            Invoke("Eyebrows", 0);

        if (_event == 3)
            Invoke("Lip", 0);
    }
    public void branch()
    {
        switch (a)
        {
            case 0:
                Invoke("Fand", delaytime);
                break;
            case 1:
                Invoke("Usually", delaytime);
                break;
            case 2:
                Invoke("White", delaytime);
                break;
            case 3:
                Invoke("Green", delaytime);
                break;
            case 4:
                Invoke("Black1", delaytime);
                break;  
            case 5:
                PlayerPrefs.SetInt("EVENT",1);
                Invoke("Event", 0);
                Invoke("EventLoad", 3);
                break;
            case 6:
                Invoke("Black2", delaytime);
                break;
            case 7:
                Invoke("Red", delaytime);
                break;
            case 8:
                _result = 9;
                Invoke("Result", delaytime);
                break;
            case 9:
                _result = 10;
                Invoke("Result", delaytime);
                break;
            case 10:
                break;
            case 11:
                Invoke("Pink", delaytime);
                break;
            case 12:
                Invoke("Purple1", delaytime);
                break;
            case 13:
                PlayerPrefs.SetInt("EVENT", 2);
                Invoke("Event", 0);
                Invoke("EventLoad", 2.5f);
                break;
            case 14:
                break;
            case 15:
                Invoke("Falseeyelashes", delaytime);
                break;
            case 16:
                PlayerPrefs.SetInt("EVENT", 2);
                Invoke("Event", 0);
                Invoke("EventLoad", 2.5f);
                break;
            case 18:
                Invoke("Purple2", delaytime);
                break;
            case 19:
                _result = 1;    
                Invoke("Result", delaytime);
                break;
            case 20:
                Invoke("Bassavasa", delaytime);
                break;
            case 21:
                _result = 3;
                Invoke("Result", delaytime);
                break;
            case 22:
                _result = 4;
                Invoke("Result", delaytime);
                break;
        }
        PlayerPrefs.Save();
    }
    public void _Start()
    {
        GameObject fand = (GameObject)Resources.Load("�t�@���f�[�V����");
        Instantiate(fand, new Vector2(5, 0), Quaternion.identity);
    }

    public void destroy()
    {
        GameObject des= (GameObject)Resources.Load("Destroy");
        Instantiate(des, new Vector2(0, 0), Quaternion.identity);
    }
    void Fand()
    {
        GameObject usuallay = (GameObject)Resources.Load("���ʂ̐F");
        GameObject white = (GameObject)Resources.Load("��");
        GameObject green = (GameObject)Resources.Load("��");
        GameObject black = (GameObject)Resources.Load("��1");

        Instantiate(usuallay, new Vector2(-5, 3), Quaternion.identity);
        Instantiate(white, new Vector2(-5, -3), Quaternion.identity);
        Instantiate(green, new Vector2(5, 3), Quaternion.identity);
        Instantiate(black, new Vector2(5, -3), Quaternion.identity);
    }
    public void Usually()
    {
        GameObject eyeshadow = (GameObject)Resources.Load("�A�C�V���h�E");

        Instantiate(eyeshadow, new Vector2(5, 0), Quaternion.identity);
    }
    public void White()
    {
        GameObject black1 = (GameObject)Resources.Load("��2");
        GameObject red = (GameObject)Resources.Load("��");

        Instantiate(black1, new Vector2(-5, 0), Quaternion.identity);
        Instantiate(red, new Vector2(5, 0), Quaternion.identity);
    }
    public void Green()
    {
        GameObject ear = (GameObject)Resources.Load("��");
        GameObject tactilesense = (GameObject)Resources.Load("�G�o");

        Instantiate(ear, new Vector2(5, 0), Quaternion.identity);
        Instantiate(tactilesense, new Vector2(-5, 0), Quaternion.identity);
    }
    public void Black1()
    {
        GameObject eyelashes = (GameObject)Resources.Load("�܂�");

        Instantiate(eyelashes, new Vector2(5, 0), Quaternion.identity);
    }
    public void Black2()
    {
        GameObject lip = (GameObject)Resources.Load("���b�v");

        Instantiate(lip, new Vector2(5, 0), Quaternion.identity);
    }
    public void Eyeshadow()
    {
        GameObject pink = (GameObject)Resources.Load("�s���N");
        GameObject purple1 = (GameObject)Resources.Load("��1");

        Instantiate(pink, new Vector2(-5, 0), Quaternion.identity);
        Instantiate(purple1, new Vector2(5, 0), Quaternion.identity);
    }
    public void Lip()
    {
        GameObject black3 = (GameObject)Resources.Load("��3");
        GameObject purple2 = (GameObject)Resources.Load("��2");

        Instantiate(black3, new Vector2(-5, 0), Quaternion.identity);
        Instantiate(purple2, new Vector2(5, 0), Quaternion.identity);
    }
    public void Purple1()
    {
        GameObject eyebrows = (GameObject)Resources.Load("�܂��");

        Instantiate(eyebrows, new Vector2(5, 0), Quaternion.identity);
    }
    public void Purple2()
    {
        GameObject frieza = (GameObject)Resources.Load("�t���[�U");

        Instantiate(frieza, new Vector2(5, 0), Quaternion.identity);
    }
    public void Pink()
    {
        GameObject falseeyelashes = (GameObject)Resources.Load("����");

        Instantiate(falseeyelashes, new Vector2(5, 0), Quaternion.identity);
    }
    public void Falseeyelashes()
    {
        GameObject thinfalseeyelashes = (GameObject)Resources.Load("�׍��ǂ�����");
        GameObject bassavasa = (GameObject)Resources.Load("�o�b�T�o�T");

        Instantiate(thinfalseeyelashes, new Vector2(-5, 0), Quaternion.identity);
        Instantiate(bassavasa, new Vector2(5, 0), Quaternion.identity);
    }
    public void Bassavasa()
    {
        GameObject whitegal = (GameObject)Resources.Load("���M����");

        Instantiate(whitegal, new Vector2(0, 0), Quaternion.identity);
    }
    public void Result()
    {
        PlayerPrefs.SetInt("RESULT", _result);
        SceneManager.LoadScene("Result");
    }
    public void Eyebrows()
    {
        GameObject thick = (GameObject)Resources.Load("��");
        GameObject thin = (GameObject)Resources.Load("��");

        Instantiate(thick, new Vector2(-5, 0), Quaternion.identity);
        Instantiate(thin, new Vector2(5, 0), Quaternion.identity);
    }
    public void Event()
    {
        GameObject _event = (GameObject)Resources.Load("�C�x���g����");

        Instantiate(_event, new Vector2(15, 3), Quaternion.identity);
    }
    public void EventLoad()
    {
        _event = PlayerPrefs.GetInt("EVENT", 0);

        if (_event == 1)
            SceneManager.LoadScene("EyeShadow");

        if (_event == 2)
            SceneManager.LoadScene("EyebrowEvent");
    }
}
