using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class Branch : MonoBehaviour
{
    public int a;

    void Start()
    {
        GameObject fand = (GameObject)Resources.Load("�t�@���f�[�V����");
        Instantiate(fand, new Vector2(0, 0), Quaternion.identity);
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
                break;  
            case 5:
                Invoke("Eyeshadow", 0.1f);
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                Invoke("Tactilesense", 0.1f);
                break;
        }
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

        Instantiate(black1, new Vector2(3, 0), Quaternion.identity);
        Instantiate(red, new Vector2(-3, 0), Quaternion.identity);
    }
    public void Green()
    {
        GameObject ear = (GameObject)Resources.Load("��");
        GameObject tactilesense = (GameObject)Resources.Load("�G�o");

        Instantiate(ear, new Vector2(3, 0), Quaternion.identity);
        Instantiate(tactilesense, new Vector2(-3, 0), Quaternion.identity);
    }
    public void Black()
    {

    }
    public void Eyeshadow()
    {
        GameObject pink = (GameObject)Resources.Load("�s���N");
        GameObject purple = (GameObject)Resources.Load("��");

        Instantiate(pink, new Vector2(3, 0), Quaternion.identity);
        Instantiate(purple, new Vector2(-3, 0), Quaternion.identity);
    }
    public void Tactilesense() 
    {
        GameObject piccolo = (GameObject)Resources.Load("�s�b�R��");

        Instantiate(piccolo, new Vector2(0, 0), Quaternion.identity);
    }


}
