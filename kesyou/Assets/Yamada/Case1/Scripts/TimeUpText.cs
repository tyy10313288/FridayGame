using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TimeUpText : MonoBehaviour
{
    public float timer = 10.0f;
    public Text timerText;
    public Text resultText;
    public Text startCountdownText;

    public GameObject enemyPrefab;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    public int enemyCount = 6;
    public Vector2 spawnRange = new Vector2(-10, 10);

    private bool isTimerEnded = false;
    private bool enemiesSpawned = false;
    private bool gameStarted = false; // ゲーム開始フラグ

    void Start()
    {
        // 最初にカウントダウンを開始
        StartCoroutine(ShowCountdownAndStartGame());
    }

    void Update()
    {
        // ゲームが始まっていない場合は処理をスキップ
        if (!gameStarted) return;

        if (!isTimerEnded)
        {
            timer -= Time.deltaTime;

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

            UpdateTimerUI();
        }

        // 敵がすべて倒された場合
        if (!isTimerEnded && spawnedEnemies.Count == 0)
        {
            isTimerEnded = true;
            ShowResult("いいね！");
        }
    }

    void UpdateTimerUI()
    {
        timerText.text = "タイマー: " + Mathf.FloorToInt(timer).ToString() + "秒";
    }

    void ShowResult(string message)
    {
        resultText.text = message;
        resultText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = GenerateRandomPositionInCircle();
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.AddComponent<EnemyDe>().OnEnemyDestroyed = OnEnemyDestroyed;
            spawnedEnemies.Add(enemy);
        }
        enemiesSpawned = true;
    }

    Vector3 GenerateRandomPositionInCircle()
    {
        float radius = Mathf.Abs(spawnRange.y - spawnRange.x) / 2;
        Vector3 center = Vector3.zero;
        float angle = Random.Range(0f, 2f * Mathf.PI);
        float distance = Mathf.Sqrt(Random.Range(0f, 1f)) * radius;
        float x = center.x + distance * Mathf.Cos(angle);
        float y = center.y + distance * Mathf.Sin(angle);
        return new Vector3(x, y, 0); // zを固定
    }

    void OnEnemyDestroyed(GameObject enemy)
    {
        if (spawnedEnemies.Contains(enemy))
        {
            spawnedEnemies.Remove(enemy);
        }
    }

    IEnumerator ShowCountdownAndStartGame()
    {
        float countdown = 5.0f;

        // カウントダウンを表示
        while (countdown > 0)
        {
            startCountdownText.text = "開始まで: " + Mathf.CeilToInt(countdown).ToString() + "秒\n丸の中に出てくる赤い〇をクリックして！";
            yield return new WaitForSeconds(1.0f);
            countdown -= 1.0f;
        }

        // カウントダウンUIを非表示
        startCountdownText.gameObject.SetActive(false);

        // 敵をスポーンしてゲームを開始
        SpawnEnemies();
        gameStarted = true; // ゲーム開始フラグを有効化

        // タイマーを表示
        timerText.gameObject.SetActive(true);
    }
}