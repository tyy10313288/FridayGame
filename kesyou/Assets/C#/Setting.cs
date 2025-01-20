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
        settingsscreen.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        settingsscreen.SetActive(true);
        _setting = true;
    }
}
