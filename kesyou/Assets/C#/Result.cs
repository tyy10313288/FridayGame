using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    int result;
    void Start()
    {
        result = PlayerPrefs.GetInt("RESULT", 0);
        //���U���g�̒l���擾���Ή������ŏI�G�A�w�i��\���A�������ꕔ�Ƃ�ł���̂͂��̎d����S�����Ă����O���t�B�b�N�̐l�ƘA�������Ȃ��Ȃ������߁A
        //�ꕔ���򂪂Ȃ��Ȃ��Ă��邩��

        if (result == 0)
        {
            GameObject sirone = (GameObject)Resources.Load("�����");

            Instantiate(sirone, new Vector2(-3, -0.67f), Quaternion.identity);
        }
        if (result == 1)
        {
            GameObject ordinarygirl = (GameObject)Resources.Load("���ʂ̏��̎q");
            GameObject ordinarybackground = (GameObject)Resources.Load("���^�n�@�w�i�@�ڂ���");

            Instantiate(ordinarygirl, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(ordinarybackground, new Vector3(-3, -0.5f,1), Quaternion.identity);
        }
        if (result == 2)
        {
            GameObject ordinarygirl = (GameObject)Resources.Load("���M����");
            GameObject ordinarybackground = (GameObject)Resources.Load("�M�����n�@�w�i�@�ڂ���");

            Instantiate(ordinarygirl, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(ordinarybackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 3)
        {
            GameObject ordinarygirl = (GameObject)Resources.Load("����m��");
            GameObject ordinarybackground = (GameObject)Resources.Load("����m���@�w�i�@�ڂ���");

            Instantiate(ordinarygirl, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(ordinarybackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 4)
        {
            GameObject amra = (GameObject)Resources.Load("�A�����[");
            GameObject amrabackground = (GameObject)Resources.Load("�A�����[�@�w�i�@�ڂ���");

            Instantiate(amra, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(amrabackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 5)
        {
            GameObject punkband = (GameObject)Resources.Load("�p���N�o���h");
            GameObject punkbandbackground = (GameObject)Resources.Load("�p���N�o���h�@�w�i");

            Instantiate(punkband, new Vector2(-3, 0), Quaternion.identity);
            Instantiate(punkbandbackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 6)
        {
            GameObject punkband = (GameObject)Resources.Load("�t���[�U");
            GameObject amrabackground = (GameObject)Resources.Load("�Q�[�����w�i");

            Instantiate(punkband, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(amrabackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 9)
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
        if (result == 11)
        {
            GameObject blackgal = (GameObject)Resources.Load("���M����");
            GameObject blackgalbackground = (GameObject)Resources.Load("�M�����n�@�w�i�@�ڂ���");

            Instantiate(blackgal, new Vector2(-3, -0.66f), Quaternion.identity);
            Instantiate(blackgalbackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 12)
        {
            GameObject piccolo = (GameObject)Resources.Load("���}���o");
            GameObject piccolobackground = (GameObject)Resources.Load("�M�����n�@�w�i�@�ڂ���");

            Instantiate(piccolo, new Vector2(-3, -0.66f), Quaternion.identity);
            Instantiate(piccolobackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
    }
}
