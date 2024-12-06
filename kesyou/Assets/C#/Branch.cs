using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Branch : MonoBehaviour
{
    public int a;

    void Start()
    {
        GameObject fand = (GameObject)Resources.Load("ファンデーション");
        Instantiate(fand, new Vector2(0, 0), Quaternion.identity);
    }

    public void branch()
    {
        switch (a)
        {
            case 0:
                Invoke("Fand", 0.1f);
                break;
            case 1:
                Invoke("Usually", 0.1F);
                break;
            case 2:
                Invoke("White", 0.1f);
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
        }
    }

    public void destroy()
    {
        GameObject des= (GameObject)Resources.Load("Destroy");
        Instantiate(des, new Vector2(0, 0), Quaternion.identity);


    }
    void Fand()
    {
        GameObject usuallay = (GameObject)Resources.Load("普通の色");
        GameObject white = (GameObject)Resources.Load("白");
        GameObject green = (GameObject)Resources.Load("緑");
        GameObject black = (GameObject)Resources.Load("黒1");

        Instantiate(usuallay, new Vector2(-3, 3), Quaternion.identity);
        Instantiate(white, new Vector2(-3, -3), Quaternion.identity);
        Instantiate(green, new Vector2(3, 3), Quaternion.identity);
        Instantiate(black, new Vector2(3, -3), Quaternion.identity);
    }
    public void Usually()
    {
    }
    public void White()
    {
        GameObject black1 = (GameObject)Resources.Load("黒2");
        GameObject red = (GameObject)Resources.Load("赤");

        Instantiate(black1, new Vector2(3, 0), Quaternion.identity);
        Instantiate(red, new Vector2(-3, 0), Quaternion.identity);
    }
    public void Green()
    {

    }
    public void Black()
    {

    }


}
