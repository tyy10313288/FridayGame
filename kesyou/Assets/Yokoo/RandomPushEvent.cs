using UnityEngine;

public class RandomPushEvent : MonoBehaviour
{
    private int clickCount = 0; // クリック回数をカウント
    private const int maxClicks = 10; // クリック回数の最大値（10回）
    private float timeLimit = 10f; // 時間制限（10秒）
    private bool isTimeUp = false; // 時間制限が切れたかどうかを管理

    // 時間制限のカウントダウンを開始
    private void Start()
    {
        // タイマーを開始する
        Invoke("TimeUp", timeLimit); // 10秒後にTimeUpメソッドを呼び出し
    }

    // クリックされた時に呼ばれるメソッド
    void OnMouseDown()
    {
        if (isTimeUp) return; // 時間制限が過ぎた場合はクリックを無効にする

        clickCount++; // クリック回数を1増加
        Debug.Log("クリック回数: " + clickCount);

        // クリック回数がmaxClicksに達したら敵を消す
        if (clickCount >= maxClicks)
        {
            Destroy(gameObject); // 敵キャラクターを消す
            Debug.Log("敵が消えました！");
        }
    }

    // 時間制限が切れたときに呼ばれるメソッド
    private void TimeUp()
    {
        isTimeUp = true; // 時間切れフラグを立てる
        Debug.Log("時間切れです！敵が消えます！");
        Destroy(gameObject); // 敵キャラクターを消す
    }
}
