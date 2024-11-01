using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvent_Ya : MonoBehaviour
{
    public float speed = 2f; // 移動速度
    public float changeTime = 1f; // 移動方向を変える時間

    private Vector2 targetPosition;

    void Start()
    {
        SetRandomTargetPosition();
        StartCoroutine(MoveToTarget());
    }

    private void SetRandomTargetPosition()
    {
        targetPosition = new Vector2(
            Random.Range(-8f, 8f), // X座標の範囲を設定
            Random.Range(-4f, 4f)  // Y座標の範囲を設定
        );
    }

    private IEnumerator MoveToTarget()
    {
        while (true)
        {
            float step = speed * Time.deltaTime;

            // 目標位置に向かって移動
            while (Vector2.Distance(transform.position, targetPosition) > step)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
                yield return null; // 次のフレームまで待機
            }

            // 目標位置に到達したら新しい目標位置を設定
            SetRandomTargetPosition();
            yield return new WaitForSeconds(changeTime); // 一定時間待機
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
