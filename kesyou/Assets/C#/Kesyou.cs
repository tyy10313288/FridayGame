using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Kesyou : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int A;
    private AudioSource audioSource;
    Branch branch;
    Setting setting;
    private void Start()
    {
        branch = GameObject.Find("branch").GetComponent<Branch>();
        setting = GameObject.Find("Setting").GetComponent<Setting>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!setting._setting)
        {
            for(int i = 0; i <= A; i++)
            {
                if (branch.a == i)
                {
                    branch.a = A;
                }
            }
            audioSource.Play();
            branch.destroy();
            branch.branch();
        }
    }
}
