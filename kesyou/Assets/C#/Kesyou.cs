using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Kesyou : MonoBehaviour, IPointerClickHandler
{
    //各化粧品に番号を振り分け
    [SerializeField] private int A;

    private AudioSource audioSource;
    Branch branch;
    Setting setting;
    private void Start()
    {
        //別スクリプトの取得
        branch = GameObject.Find("branch").GetComponent<Branch>();
        setting = GameObject.Find("Setting").GetComponent<Setting>();

        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //設定画面が開かれていないとき
        if (!setting._setting)
        {
            //与えられた化粧の番号になるまでループ
            for(int i = 0; i <= A; i++)
            {
                //同じ値になったら別スクリプトにその値を出力
                if (branch.a == i)
                {
                    branch.a = A;
                }
            }
            audioSource.Play();
            branch.destroy();
            //名前差別化しやすくするべきだった（反省点）
            branch.branch();
        }
    }
}
