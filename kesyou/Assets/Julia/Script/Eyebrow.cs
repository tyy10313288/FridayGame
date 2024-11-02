using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyebrow : MonoBehaviour
{
    void OnMouseDown()
    {        
    if (CountDownTimer.canClick)
        {
            // 執行點擊後的操作
            Destroy(gameObject);
        }
        else
        {
            
        }
    }
}
