using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Kesyou : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int A;
    [SerializeField] private int B;
    Branch script;
    private void Start()
    {
        script = GameObject.Find("branch").GetComponent<Branch>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (A)
        {
            case 1:
                script.a = 1;
                if(B == 2)
                {
                    script.a = 1;
                }
                break;
            case 2:
                script.a = 2;
                break;
            case 3:
                script.a = 3;
                break;
            case 4:
                script.a = 4;
                break;

            case 5:
                script.Found();
                break;
        }
    }
}
