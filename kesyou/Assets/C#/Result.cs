using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    int result;
    void Start()
    {
        result = PlayerPrefs.GetInt("RESULT", 0);
        //リザルトの値を取得し対応した最終絵、背景を表示、数字が一部とんでいるのはその仕事を担当していたグラフィックの人と連絡が取れなくなったため、
        //一部分岐がなくなっているから

        if (result == 0)
        {
            GameObject sirone = (GameObject)Resources.Load("しろね");

            Instantiate(sirone, new Vector2(-3, -0.67f), Quaternion.identity);
        }
        if (result == 1)
        {
            GameObject ordinarygirl = (GameObject)Resources.Load("普通の女の子");
            GameObject ordinarybackground = (GameObject)Resources.Load("清楚系　背景　ぼかし");

            Instantiate(ordinarygirl, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(ordinarybackground, new Vector3(-3, -0.5f,1), Quaternion.identity);
        }
        if (result == 2)
        {
            GameObject ordinarygirl = (GameObject)Resources.Load("白ギャル");
            GameObject ordinarybackground = (GameObject)Resources.Load("ギャル系　背景　ぼかし");

            Instantiate(ordinarygirl, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(ordinarybackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 3)
        {
            GameObject ordinarygirl = (GameObject)Resources.Load("平野ノラ");
            GameObject ordinarybackground = (GameObject)Resources.Load("平野ノラ　背景　ぼかし");

            Instantiate(ordinarygirl, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(ordinarybackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 4)
        {
            GameObject amra = (GameObject)Resources.Load("アムラー");
            GameObject amrabackground = (GameObject)Resources.Load("アムラー　背景　ぼかし");

            Instantiate(amra, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(amrabackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 5)
        {
            GameObject punkband = (GameObject)Resources.Load("パンクバンド");
            GameObject punkbandbackground = (GameObject)Resources.Load("パンクバンド　背景");

            Instantiate(punkband, new Vector2(-3, 0), Quaternion.identity);
            Instantiate(punkbandbackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 6)
        {
            GameObject punkband = (GameObject)Resources.Load("フリーザ");
            GameObject amrabackground = (GameObject)Resources.Load("ゲーム中背景");

            Instantiate(punkband, new Vector2(-3, -0.67f), Quaternion.identity);
            Instantiate(amrabackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 9)
        {
            GameObject shrek = (GameObject)Resources.Load("シュレック");
            GameObject shrekbackground = (GameObject)Resources.Load("シュレック　背景　ぼかし");

            Instantiate(shrek, new Vector2(-3, -0.66f), Quaternion.identity);
            Instantiate(shrekbackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if(result == 10)
        {
            GameObject piccolo = (GameObject)Resources.Load("ピッコロ");
            GameObject piccolobackground = (GameObject)Resources.Load("ピッコロ　背景　ぼかし");

            Instantiate(piccolo, new Vector2(-3, -0.66f), Quaternion.identity);
            Instantiate(piccolobackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 11)
        {
            GameObject blackgal = (GameObject)Resources.Load("黒ギャル");
            GameObject blackgalbackground = (GameObject)Resources.Load("ギャル系　背景　ぼかし");

            Instantiate(blackgal, new Vector2(-3, -0.66f), Quaternion.identity);
            Instantiate(blackgalbackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
        if (result == 12)
        {
            GameObject piccolo = (GameObject)Resources.Load("ヤマンバ");
            GameObject piccolobackground = (GameObject)Resources.Load("ギャル系　背景　ぼかし");

            Instantiate(piccolo, new Vector2(-3, -0.66f), Quaternion.identity);
            Instantiate(piccolobackground, new Vector3(-3, -0.5f, 1), Quaternion.identity);
        }
    }
}
