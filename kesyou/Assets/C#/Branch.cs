using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Branch : MonoBehaviour
{
    public int a;
    bool w;
    bool u;



    void Start()
    {
        GameObject foundation = (GameObject)Resources.Load("�t�@���f�[�V����");
        Instantiate(foundation, new Vector2(0, 0), Quaternion.identity);
    }

    void Update()
    {
        switch (a)
        {
            case 1:
                if (!u)
                {
                    Des();
                    Invoke(nameof(Usually), 0.2f);
                    u = true;
                }

                break;
            case 2:
                if (!w)
                {
                    Des();
                    Invoke(nameof(White), 0.2f);
                    w = true;
                }
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }
    public void Des()
    {
        GameObject des = (GameObject)Resources.Load("Destroy");
        Instantiate(des, new Vector2(0, 0), Quaternion.identity);
    }
    public void Found()
    {
        Des();
        Invoke(nameof(Foundation), 0.2f);
    }
    public void Foundation()
    {
        GameObject usuallay = (GameObject)Resources.Load("���ʂ̐F");
        GameObject white = (GameObject)Resources.Load("��");
        GameObject green = (GameObject)Resources.Load("��");
        GameObject black = (GameObject)Resources.Load("��1");

        Instantiate(usuallay, new Vector2(-3, 3), Quaternion.identity);
        Instantiate(white, new Vector2(-3, -3), Quaternion.identity);
        Instantiate(green, new Vector2(3, 3), Quaternion.identity);
        Instantiate(black, new Vector2(3, -3), Quaternion.identity);
    }
    public void Usually()
    {
        GameObject eye = (GameObject)Resources.Load("�A�C�V���h�E");
        Instantiate(eye, new Vector2(0, 0), Quaternion.identity);
    }
    public void White()
    {
        GameObject black1 = (GameObject)Resources.Load("��2");
        GameObject red = (GameObject)Resources.Load("��");

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
