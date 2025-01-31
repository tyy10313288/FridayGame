using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // SceneManager�̃C���|�[�g
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
    private bool gameStarted = false; // �Q�[���J�n�t���O

    public Sprite gameStartImage;  // �Q�[���J�n�O�ɕ\������摜

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

                // �G���c���Ă���ꍇ�́uGameOver�v�V�[���ɑJ��
                if (spawnedEnemies.Count > 0)
                {
                    StartCoroutine(GoToGameOverScene());
                }
            }

            UpdateTimerUI();
        }

        // �G�����ׂē|���ꂽ�ꍇ
        if (!isTimerEnded && spawnedEnemies.Count == 0)
        {
            isTimerEnded = true;
            StartCoroutine(GoToBunkiScene());
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
        float countdown = 5.0f; // 3�b�Ԃ̃J�E���g�_�E��

        // �ŏ��ɉ摜��\��
        startCountdownImage.sprite = gameStartImage;
        startCountdownImage.gameObject.SetActive(true);

        // �J�E���g�_�E�����Ƀe�L�X�g���X�V
        while (countdown > 0)
        {
            countdownText.text = "�Q�[���J�n�܂�: " + Mathf.CeilToInt(countdown).ToString() + "�b";
            yield return new WaitForSeconds(1.0f);  // 1�b�ҋ@
            countdown -= 1.0f;
        }

        // �J�E���g�_�E�����I�������A�摜�ƃe�L�X�g���\��
        countdownText.gameObject.SetActive(false);  // �J�E���g�_�E���e�L�X�g���\��
        startCountdownImage.gameObject.SetActive(false);  // �Q�[���J�n�O�̉摜���\��

        // �Q�[���J�n
        SpawnEnemies();  // �G���X�|�[��
        gameStarted = true;  // �Q�[���J�n�t���O���Z�b�g

        // �^�C�}�[��\��
        timerText.gameObject.SetActive(true);
    }

    // �G���c���Ă���ꍇ��GameOver�V�[���ɑJ��
    IEnumerator GoToGameOverScene()
    {
        ShowResult("Game Over");
        yield return new WaitForSeconds(1); // ���ʃe�L�X�g��\�����邽�߂�3�b�ҋ@
        SceneManager.LoadScene("GameOver"); // GameOver�V�[���ɑJ��
    }

    // �G���c���Ă��Ȃ����Bunki�V�[���ɑJ��
    IEnumerator GoToBunkiScene()
    {
        ShowResult("�����ˁI");
        yield return new WaitForSeconds(1); // ���ʃe�L�X�g��\�����邽�߂�3�b�ҋ@
        SceneManager.LoadScene("bunki"); // bunki�V�[���ɑJ��
    }
}