using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Branch : MonoBehaviour
{
    public int a;


    void Start()
    {
        GameObject usuallay = (GameObject)Resources.Load("ïÅí ÇÃêF");
        GameObject white = (GameObject)Resources.Load("îí");
        GameObject green = (GameObject)Resources.Load("óŒ");
        GameObject black = (GameObject)Resources.Load("çï1");

        Instantiate(usuallay, new Vector2(-3, 3), Quaternion.identity);
        Instantiate(white, new Vector2(-3, -3), Quaternion.identity);
        Instantiate(green, new Vector2(3, 3), Quaternion.identity);
        Instantiate(black, new Vector2(3, -3), Quaternion.identity);
    }

    void Update()
    {
        switch (a)
        {
            case 1:
                Usually();
                break;
            case 2:
                White();    
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }
    public void Usually()
    {
        Debug.Log("a");
    }
    public void White()
    {
        GameObject black1 = (GameObject)Resources.Load("çï2");
        GameObject red = (GameObject)Resources.Load("ê‘");

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
