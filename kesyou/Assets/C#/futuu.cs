using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class futuu : MonoBehaviour, IPointerClickHandler
{
    maney script;
    private void Start()
    {
        script = GameObject.Find("mane").GetComponent<maney>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        script.A();
    }
}
