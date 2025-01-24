using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInfo : MonoBehaviour
{
    public GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InfoOn()
    {
        gameObject.SetActive(true);
    }
    public void InfoOff()
    {
        gameObject.SetActive(false);
    }   
}
