using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Settingsscreen : MonoBehaviour
{
    public GameObject settingsscreen;
    Setting setting;
    void Start()
    {
        //�ʃX�N���v�g�̎擾
        setting = GameObject.Find("Setting").GetComponent<Setting>();
    }
    
    public void Back()
    {
        //�߂�{�^���������ꂽ��ݒ��ʂ��\���ɂ��A���ς�������悤�ɂ���
        setting._setting = false;
        settingsscreen.SetActive(false);
    }
    public void BackTitle()
    {
        //�^�C�g���ɖ߂�
        SceneManager.LoadScene("Title");
    }
    public void GameEnd()
    {
        //�Q�[���I��
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
