    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void _Start()
    {
        //�C�x���g�̒l�����Z�b�g���A�Q�[���J�n
        PlayerPrefs.SetInt("EVENT", 0);
        SceneManager.LoadScene("Text");    
    }
}
