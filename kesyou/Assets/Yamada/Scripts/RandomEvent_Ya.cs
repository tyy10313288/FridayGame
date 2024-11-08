using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomEvent_Ya : MonoBehaviour
{
    public float speed = 2f; // 移動速度
    public float changeTime = 1f; // 移動方向を変える時間
    public float timeLimit = 10f; // 時間制限（10秒）
    public TextMeshProUGUI timerText; // UIのTextコンポーネントを参照


    private Vector2 targetPosition;
    private float timer = 0f; // タイマー

    void Start()
    {
        SetRandomTargetPosition();
        StartCoroutine(MoveToTarget());
    }

    void Update()
    {
        // タイマーを更新
        timer += Time.deltaTime;

        // 時間制限を超えた場合、オブジェクトを破壊
        if (timer >= timeLimit)
        {
            Destroy(gameObject);
            Debug.Log("時間制限を超えたのでオブジェクトは破壊されました");
        }

        UpdateTimerUI();
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
        Debug.Log("倒した");
    }

    // 残り時間をUIのTextに表示するメソッド
    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            float remainingTime = timeLimit - timer;  // 残り時間を計算
            timerText.text = "残り時間: " + Mathf.Max(0f, remainingTime).ToString("F2") + "秒";  // 小数点以下2桁まで表示
        }
    }
}
