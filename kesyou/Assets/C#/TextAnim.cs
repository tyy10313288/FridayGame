using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextAnim : MonoBehaviour
{
    void Start()
    {
        //�A�j���[�V�����̍Đ��I���ɃV�[���؂�ւ�
        Invoke("Change", 2);
    }
    private void Change()
    {
        SceneManager.LoadScene("bunki");  
    }
}
