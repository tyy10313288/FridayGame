using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // SceneManagerのインポート
using System.Collections;
using System.Collections.Generic;

public class TimeUpText : MonoBehaviour
{
    public float timer = 10.0f;
    public Text timerText;
    public Text resultText;
    public Image startCountdownImage;

    public GameObject enemyPrefab;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    public int enemyCount = 6;
    public Vector2 spawnRange = new Vector2(-10, 10);
    public Text countdownText;

    private bool isTimerEnded = false;
    private bool enemiesSpawned = false;
    private bool gameStarted = false; // ゲーム開始フラグ

    public Sprite gameStartImage;  // ゲーム開始前に表示する画像

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

                // 敵が残っている場合は「GameOver」シーンに遷移
                if (spawnedEnemies.Count > 0)
                {
                    StartCoroutine(GoToGameOverScene());
                }
            }

            UpdateTimerUI();
        }

        // 敵がすべて倒された場合
        if (!isTimerEnded && spawnedEnemies.Count == 0)
        {
            isTimerEnded = true;
            StartCoroutine(GoToBunkiScene());
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
        float countdown = 5.0f; // 3秒間のカウントダウン

        // 最初に画像を表示
        startCountdownImage.sprite = gameStartImage;
        startCountdownImage.gameObject.SetActive(true);

        // カウントダウン中にテキストを更新
        while (countdown > 0)
        {
            countdownText.text = "ゲーム開始まで: " + Mathf.CeilToInt(countdown).ToString() + "秒";
            yield return new WaitForSeconds(1.0f);  // 1秒待機
            countdown -= 1.0f;
        }

        // カウントダウンが終わったら、画像とテキストを非表示
        countdownText.gameObject.SetActive(false);  // カウントダウンテキストを非表示
        startCountdownImage.gameObject.SetActive(false);  // ゲーム開始前の画像を非表示

        // ゲーム開始
        SpawnEnemies();  // 敵をスポーン
        gameStarted = true;  // ゲーム開始フラグをセット

        // タイマーを表示
        timerText.gameObject.SetActive(true);
    }

    // 敵が残っている場合にGameOverシーンに遷移
    IEnumerator GoToGameOverScene()
    {
        ShowResult("Game Over");
        yield return new WaitForSeconds(1); // 結果テキストを表示するために3秒待機
        SceneManager.LoadScene("GameOver"); // GameOverシーンに遷移
    }

    // 敵が残っていなければBunkiシーンに遷移
    IEnumerator GoToBunkiScene()
    {
        ShowResult("いいね！");
        yield return new WaitForSeconds(1); // 結果テキストを表示するために3秒待機
        SceneManager.LoadScene("bunki"); // bunkiシーンに遷移
    }
}