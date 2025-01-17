using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Kesyou : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int A;
    private AudioSource audioSource;
    Branch script;
    private void Start()
    {
        script = GameObject.Find("branch").GetComponent<Branch>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (A)
        {
            case 0:
                script.a = A;
                break;
            case 1:
                script.a = A;
                break;
            case 2:
                script.a = A;
                break;
            case 3:
                script.a = A;
                break;
            case 4:
                script.a = A;
                break;
            case 5:
                script.a = A;
                break;
            case 6:
                script.a = A;
                break;
            case 7:
                script.a = A;
                break;
            case 8:
                script.a = A;
                break;
            case 9:
                script.a = A;
                break;
            case 10:
                script.a = A;
                break;
            case 11:
                script.a = A;
                break;
            case 12:
                script.a = A;
                break;
            case 13:
                script.a = A;
                break;
            case 14:
                script.a = A;
                break;
            case 15:
                script.a = A;
                break;
            case 18:
                script.a = A;
                break;
            case 19:
                script.a = A;
                break;
            case 20:
                script.a = A;
                break;

        }
        audioSource.Play();
        script.destroy();
        script.branch();
    }
}
