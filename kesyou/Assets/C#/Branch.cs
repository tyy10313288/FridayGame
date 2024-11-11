using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Branch : MonoBehaviour
{
    public int a;
    void Start()
    {
        GameObject foundation = (GameObject)Resources.Load("ファンデーション");
        Instantiate(foundation, new Vector2(0, 0), Quaternion.identity);
    }

    void Update()
    {
        switch (a)
        {
            //1分岐目
            case 1:
                 Des();
                Invoke(nameof(Usually), 0.2f);
                a = 100;
                break;
            case 2:
                Des();
                Invoke(nameof(White), 0.2f);
                a = 100;
                break;
            case 3:
                Des();
                Invoke(nameof(Green), 0.2f);
                a = 100;
                break;
            case 4:
                Des();
                Invoke(nameof(Black), 0.2f);
                a = 100;
                break;
            //2分岐目
            case 5:
                Des();
                Invoke(nameof(Eyeshadow), 0.2f);
                a = 100;
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                Des();
                Invoke(nameof(Tactilesense), 0.2f);
                a = 100;
                break;
            case 10:
                break;
                //3分岐目
            case 11:
                Des();
                Invoke(nameof(Pink), 0.2f);
                a = 100;
                break;
        }
    }
    void Des()
    {
        GameObject des = (GameObject)Resources.Load("Destroy");
        Instantiate(des, new Vector2(0, 0), Quaternion.identity);
    }
    public void Found()
    {
        Des();
        Invoke(nameof(Foundation), 0.2f);
    }
    void Foundation()
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
    void Usually()
    {
        GameObject eye = (GameObject)Resources.Load("アイシャドウ");
        Instantiate(eye, new Vector2(0, 0), Quaternion.identity);
    }
    void White()
    {
        GameObject black1 = (GameObject)Resources.Load("黒2");
        GameObject red = (GameObject)Resources.Load("赤");

        Instantiate(black1, new Vector2(-3, 0), Quaternion.identity);
        Instantiate(red, new Vector2(3, 0), Quaternion.identity);
    }
    void Green()
    {
        GameObject ear = (GameObject)Resources.Load("耳");
        GameObject tactilesense = (GameObject)Resources.Load("触覚");

        Instantiate(ear, new Vector2(-3, 0), Quaternion.identity);
        Instantiate(tactilesense, new Vector2(3, 0), Quaternion.identity);
    }
    void Black()
    {

    }
    void Eyeshadow()
    {
        GameObject pink = (GameObject)Resources.Load("ピンク");
        GameObject purple = (GameObject)Resources.Load("紫");

        Instantiate(pink, new Vector2(-3, 0), Quaternion.identity);
        Instantiate(purple, new Vector2(3, 0), Quaternion.identity);
    }
    void Tactilesense()
    {
        GameObject piccolo = (GameObject)Resources.Load("ピッコロ");

        Instantiate(piccolo, new Vector2(0, 0), Quaternion.identity);
    }
    void Pink()
    {
        GameObject falseeyelashes = (GameObject)Resources.Load("つけまつ毛");

        Instantiate(falseeyelashes, new Vector2(0, 0), Quaternion.identity);
    }
}
