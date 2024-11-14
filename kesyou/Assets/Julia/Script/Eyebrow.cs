using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyebrow : MonoBehaviour
{
    void OnMouseDown()
    {
        if (!CountDownTimer.canClick)
        {
           
            return;
        }
       
        Destroy(gameObject);
    }
}
