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
    private bool gameStarted = false; // �Q�[���J�n�t���O

    void Start()
    {
        // �ŏ��ɃJ�E���g�_�E�����J�n
        StartCoroutine(ShowCountdownAndStartGame());
    }

    void Update()
    {
        // �Q�[�����n�܂��Ă��Ȃ��ꍇ�͏������X�L�b�v
        if (!gameStarted) return;

        if (!isTimerEnded)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0;
                isTimerEnded = true;

                // �G���c���Ă���ꍇ�́u����˂�I�v�ƕ\��
                if (spawnedEnemies.Count > 0)
                {
                    ShowResult("����˂�I");
                }
            }

            UpdateTimerUI();
        }

        // �G�����ׂē|���ꂽ�ꍇ
        if (!isTimerEnded && spawnedEnemies.Count == 0)
        {
            isTimerEnded = true;
            ShowResult("�����ˁI");
        }
    }

    void UpdateTimerUI()
    {
        timerText.text = "�^�C�}�[: " + Mathf.FloorToInt(timer).ToString() + "�b";
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
        return new Vector3(x, y, 0); // z���Œ�
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

        // �J�E���g�_�E����\��
        while (countdown > 0)
        {
            startCountdownText.text = "�J�n�܂�: " + Mathf.CeilToInt(countdown).ToString() + "�b\n�ۂ̒��ɏo�Ă���Ԃ��Z���N���b�N���āI";
            yield return new WaitForSeconds(1.0f);
            countdown -= 1.0f;
        }

        // �J�E���g�_�E��UI���\��
        startCountdownText.gameObject.SetActive(false);

        // �G���X�|�[�����ăQ�[�����J�n
        SpawnEnemies();
        gameStarted = true; // �Q�[���J�n�t���O��L����

        // �^�C�}�[��\��
        timerText.gameObject.SetActive(true);
    }
}