using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Setting : MonoBehaviour, IPointerClickHandler
{
    public GameObject settingsscreen;
    public bool _setting;
    void Start()
    {
        //�Q�[���J�n���ɐݒ��ʂ��\��
        settingsscreen.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //�ݒ�̃A�C�R���������ꂽ��ݒ��ʂ�\��
        settingsscreen.SetActive(true);
        //�ݒ��ʂ��J����Ă���Ƃ��͉��ς������Ȃ��悤�ɂ���
        _setting = true;
    }
}
