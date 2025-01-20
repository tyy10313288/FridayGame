using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;
using UnityEngine.SceneManagement;

public class Branch : MonoBehaviour
{
    public int a;
    public int _event;

    void Start()
    {
        _event = PlayerPrefs.GetInt("EVENT", 0);

        if(_event == 1)
        {
            Invoke("Eyeshadow", 0);
        }
        else
        {
            Invoke("_Start", 0);
        }
    }
    public void branch()
    {
        switch (a)
        {
            case 0:
                Invoke("Fand", 0.1f);
                break;
            case 1:
                Invoke("Usually", 0.1F);
                break;
            case 2:
                Invoke("White", 0.1f);
                break;
            case 3:
                Invoke("Green", 0.1f);
                break;
            case 4:
                Invoke("Black1", 0.1f);
                break;  
            case 5:
                PlayerPrefs.SetInt("EVENT",1);  
                SceneManager.LoadScene("EyeShadow");
                break;
            case 6:
                Invoke("Black2", 0.1f);
                break;
            case 7:
                Invoke("Red", 0.1f);
                break;
            case 8:
                Invoke("Ear", 0.1f);
                break;
            case 9:
                Invoke("Tactilesense", 0.1f);
                break;
            case 10:
                break;
            case 11:
                Invoke("Pink", 0.1f);
                break;
            case 12:
                break;
            case 13:
                Invoke("Lip", 0.1f);
                break;
            case 14:
                break;
            case 15:
                Invoke("Falseeyelashes", 0.1f);
                break;
            case 18:
                Invoke("Purple2", 0.1f);
                break;
            case 19:
                Invoke("Thinfalseeyelashes", 0.1f);
                break;
            case 20:
                Invoke("Bassavasa", 0.1f);
                break;
        }
    }
    public void _Start()
    {
        GameObject fand = (GameObject)Resources.Load("�t�@���f�[�V����");
        Instantiate(fand, new Vector2(0, 0), Quaternion.identity);
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

        Instantiate(usuallay, new Vector2(-3, 3), Quaternion.identity);
        Instantiate(white, new Vector2(-3, -3), Quaternion.identity);
        Instantiate(green, new Vector2(3, 3), Quaternion.identity);
        Instantiate(black, new Vector2(3, -3), Quaternion.identity);
    }
    public void Usually()
    {
        GameObject eyeshadow = (GameObject)Resources.Load("�A�C�V���h�E");

        Instantiate(eyeshadow, new Vector2(0, 0), Quaternion.identity);
    }
    public void White()
    {
        GameObject black1 = (GameObject)Resources.Load("��2");
        GameObject red = (GameObject)Resources.Load("��");

        Instantiate(black1, new Vector2(-3, 0), Quaternion.identity);
        Instantiate(red, new Vector2(3, 0), Quaternion.identity);
    }
    public void Green()
    {
        GameObject ear = (GameObject)Resources.Load("��");
        GameObject tactilesense = (GameObject)Resources.Load("�G�o");

        Instantiate(ear, new Vector2(3, 0), Quaternion.identity);
        Instantiate(tactilesense, new Vector2(-3, 0), Quaternion.identity);
    }
    public void Black1()
    {
        GameObject eyelashes = (GameObject)Resources.Load("�܂�");

        Instantiate(eyelashes, new Vector2(0, 0), Quaternion.identity);
    }
    public void Black2()
    {
        GameObject lip = (GameObject)Resources.Load("���b�v");

        Instantiate(lip, new Vector2(0, 0), Quaternion.identity);
    }
    public void Eyeshadow()
    {
        GameObject pink = (GameObject)Resources.Load("�s���N");
        GameObject purple1 = (GameObject)Resources.Load("��1");

        Instantiate(pink, new Vector2(-3, 0), Quaternion.identity);
        Instantiate(purple1, new Vector2(3, 0), Quaternion.identity);
    }
    public void Tactilesense() 
    {
        GameObject piccolo = (GameObject)Resources.Load("�s�b�R��");

        Instantiate(piccolo, new Vector2(0, 0), Quaternion.identity);
    }
    public void Ear()
    {
        GameObject shrek = (GameObject)Resources.Load("�V�����b�N");

        Instantiate(shrek, new Vector2(0, 0), Quaternion.identity);
    }
    public void Lip()
    {
        GameObject black3 = (GameObject)Resources.Load("��3");
        GameObject purple2 = (GameObject)Resources.Load("��2");

        Instantiate(black3, new Vector2(-3, 0), Quaternion.identity);
        Instantiate(purple2, new Vector2(3, 0), Quaternion.identity);
    }
    public void Purple2()
    {
        GameObject frieza = (GameObject)Resources.Load("�t���[�U");

        Instantiate(frieza, new Vector2(0, 0), Quaternion.identity);
    }
    public void Pink()
    {
        GameObject falseeyelashes = (GameObject)Resources.Load("����");

        Instantiate(falseeyelashes, new Vector2(0, 0), Quaternion.identity);
    }
    public void Falseeyelashes()
    {
        GameObject thinfalseeyelashes = (GameObject)Resources.Load("�׍��ǂ�����");
        GameObject bassavasa = (GameObject)Resources.Load("�o�b�T�o�T");

        Instantiate(thinfalseeyelashes, new Vector2(-3, 0), Quaternion.identity);
        Instantiate(bassavasa, new Vector2(3, 0), Quaternion.identity);
    }
    public void Thinfalseeyelashes()
    {
        GameObject ordinarygirl = (GameObject)Resources.Load("���ʂ̏��̎q");

        Instantiate(ordinarygirl, new Vector2(0, 0), Quaternion.identity);
    }
    public void Bassavasa()
    {
        GameObject whitegal = (GameObject)Resources.Load("���M����");

        Instantiate(whitegal, new Vector2(0, 0), Quaternion.identity);
    }
}
