using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Branch : MonoBehaviour
{
    public int a;
    void Start()
    {
        GameObject foundation = (GameObject)Resources.Load("�t�@���f�[�V����");
        Instantiate(foundation, new Vector2(0, 0), Quaternion.identity);
    }

    void Update()
    {
        switch (a)
        {
            //1�����
            case 1:
                 Des();
                Invoke(nameof(Usually), 0.2f);
                a = 100;
                break;
            case 2:
                Des();
                Invoke(nameof(White), 0.2f);
                a = 100;
                break;
            case 3:
                Des();
                Invoke(nameof(Green), 0.2f);
                a = 100;
                break;
            case 4:
                Des();
                Invoke(nameof(Black), 0.2f);
                a = 100;
                break;
            //2�����
            case 5:
                Des();
                Invoke(nameof(Eyeshadow), 0.2f);
                a = 100;
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                Des();
                Invoke(nameof(Tactilesense), 0.2f);
                a = 100;
                break;
            case 10:
                break;
                //3�����
            case 11:
                Des();
                Invoke(nameof(Pink), 0.2f);
                a = 100;
                break;
        }
    }
    void Des()
    {
        GameObject des = (GameObject)Resources.Load("Destroy");
        Instantiate(des, new Vector2(0, 0), Quaternion.identity);
    }
    public void Found()
    {
        Des();
        Invoke(nameof(Foundation), 0.2f);
    }
    void Foundation()
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
    void Usually()
    {
        GameObject eye = (GameObject)Resources.Load("�A�C�V���h�E");
        Instantiate(eye, new Vector2(0, 0), Quaternion.identity);
    }
    void White()
    {
        GameObject black1 = (GameObject)Resources.Load("��2");
        GameObject red = (GameObject)Resources.Load("��");

        Instantiate(black1, new Vector2(-3, 0), Quaternion.identity);
        Instantiate(red, new Vector2(3, 0), Quaternion.identity);
    }
    void Green()
    {
        GameObject ear = (GameObject)Resources.Load("��");
        GameObject tactilesense = (GameObject)Resources.Load("�G�o");

        Instantiate(ear, new Vector2(-3, 0), Quaternion.identity);
        Instantiate(tactilesense, new Vector2(3, 0), Quaternion.identity);
    }
    void Black()
    {

    }
    void Eyeshadow()
    {
        GameObject pink = (GameObject)Resources.Load("�s���N");
        GameObject purple = (GameObject)Resources.Load("��");

        Instantiate(pink, new Vector2(-3, 0), Quaternion.identity);
        Instantiate(purple, new Vector2(3, 0), Quaternion.identity);
    }
    void Tactilesense()
    {
        GameObject piccolo = (GameObject)Resources.Load("�s�b�R��");

        Instantiate(piccolo, new Vector2(0, 0), Quaternion.identity);
    }
    void Pink()
    {
        GameObject falseeyelashes = (GameObject)Resources.Load("���܂�");

        Instantiate(falseeyelashes, new Vector2(0, 0), Quaternion.identity);
    }
}
