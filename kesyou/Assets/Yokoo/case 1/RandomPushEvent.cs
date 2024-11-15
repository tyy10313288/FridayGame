using UnityEngine;
using UnityEngine.UI;

public class RandomPushEvent : MonoBehaviour
{
    private int clickCount = 0; // クリック回数をカウント
    private const int maxClicks = 10; // クリック回数の最大値（10回）
    public float timeLimit = 10f; // 時間制限（10秒）
    private bool isTimeUp = false; // 時間制限が切れたかどうかを管理
    public Text clickCountText; // クリック数を表示するText
    public Text resultText; // 結果を表示するテキスト

    // 時間制限のカウントダウンを開始
    private void Start()
    {
        // タイマーを開始する
        Invoke("TimeUp", timeLimit); // 10秒後にTimeUpメソッドを呼び出し

        // 最初のクリック数を表示
        UpdateClickCountText();
    }

    // クリックされた時に呼ばれるメソッド
    void OnMouseDown()
    {
        if (isTimeUp) return; // 時間制限が過ぎた場合はクリックを無効にする

        clickCount++; // クリック回数を1増加
        Debug.Log("クリック回数: " + clickCount);
        UpdateClickCountText(); // 表示を更新

        // クリック回数がmaxClicksに達したら敵を消す
        if (clickCount >= maxClicks)
        {
            HideObject(); // 敵キャラクターとテキストを非表示にする
        }
    }

    // 時間制限が切れたときに呼ばれるメソッド
    private void TimeUp()
    {
        isTimeUp = true; // 時間切れフラグを立てる
        Debug.Log("時間切れです！敵が消えます！");
        HideObject(); // 敵キャラクターとテキストを非表示にする
        resultText.text = "Nooo";
    }

    // クリック数を表示するテキストを更新するメソッド
    private void UpdateClickCountText()
    {
        if (clickCountText != null)
        {
            clickCountText.text = "クリック回数: " + clickCount;
        }
    }

    // 敵キャラクターとテキストを非表示にするメソッド
    private void HideObject()
    {
        if (clickCountText != null)
        {
            clickCountText.enabled = false; // テキストを非表示にする
        }
        gameObject.SetActive(false); // 敵キャラクターを非表示にする

        resultText.text = "OK!";
    }
}
