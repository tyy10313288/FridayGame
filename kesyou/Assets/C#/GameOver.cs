using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //�C�x���g�̒l��0�ɂ��ă��X�^�[�g
    public void Retry()
    {
        PlayerPrefs.SetInt("EVENT", 0);
        SceneManager.LoadScene("bunki");
    }
    //�^�C�g���ɖ߂�
    public void BackTitle()
    {
        SceneManager.LoadScene("Title");
    }
    //�Q�[���I��
    public void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
