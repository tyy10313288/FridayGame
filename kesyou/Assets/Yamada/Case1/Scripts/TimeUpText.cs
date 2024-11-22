using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TimeUpText : MonoBehaviour
{
    // タイマーの初期値（秒）
    public float timer = 10.0f;

    // タイマーを表示するUI Text
    public Text timerText;

    // 結果を表示するUI Text
    public Text resultText;

    // タイマーが終了したかのフラグ
    private bool isTimerEnded = false;

    // EnemyのPrefab
    public GameObject enemyPrefab;

    // スポーン済みの敵を管理するリスト
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    // Enemyをスポーンさせる数
    public int enemyCount = 6;

    // スポーン位置の範囲
    public Vector2 spawnRange = new Vector2(-10, 10);

    // スポーン済みかどうかのフラグ
    private bool enemiesSpawned = false;

    void Start()
    {
        // シーン開始時にEnemyをスポーン
        if (!enemiesSpawned)
        {
            SpawnEnemies();
            enemiesSpawned = true;
        }

    }

    void Update()
    {
        // タイマーが終了していない場合、減少させる
        if (!isTimerEnded)
        {
            timer -= Time.deltaTime;

            // タイマーを0以下にしない
            if (timer <= 0)
            {
                timer = 0;
                isTimerEnded = true;

                // 敵が残っている場合は「ざんねん！」と表示
                if (spawnedEnemies.Count > 0)
                {
                    ShowResult("ざんねん！");
                }
            }

            // タイマーをUIに反映
            UpdateTimerUI();
        }

        // 敵がすべて倒された場合
        if (!isTimerEnded && spawnedEnemies.Count == 0)
        {
            isTimerEnded = true;
            ShowResult("いいね！");
        }
    }

    // UIのテキストを更新
    void UpdateTimerUI()
    {
        timerText.text = "タイマー: " + Mathf.FloorToInt(timer).ToString() + "秒";
    }

    // 結果を表示してタイマーを非表示にする
    void ShowResult(string message)
    {
        // 結果テキストを表示
        resultText.text = message;
        resultText.gameObject.SetActive(true);

        // タイマーを非表示
        timerText.gameObject.SetActive(false);
    }

    // Enemyをスポーンさせる
    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnRange.x, spawnRange.y),
                0,
                Random.Range(spawnRange.x, spawnRange.y)
            );

            // Enemyを生成してリストに追加
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Enemyにヒット時のコールバックを設定するスクリプトをアタッチ
            enemy.AddComponent<EnemyDe>().OnEnemyDestroyed = OnEnemyDestroyed;

            spawnedEnemies.Add(enemy);
        }
    }

    // 敵が破壊されたときの処理
    void OnEnemyDestroyed(GameObject enemy)
    {
        // リストから削除
        if (spawnedEnemies.Contains(enemy))
        {
            spawnedEnemies.Remove(enemy);
        }
    }
}