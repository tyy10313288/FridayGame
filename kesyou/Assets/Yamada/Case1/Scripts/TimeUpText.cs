using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TimeUpText : MonoBehaviour
{
    // �^�C�}�[�̏����l�i�b�j
    public float timer = 10.0f;

    // �^�C�}�[��\������UI Text
    public Text timerText;

    // ���ʂ�\������UI Text
    public Text resultText;

    // �^�C�}�[���I���������̃t���O
    private bool isTimerEnded = false;

    // Enemy��Prefab
    public GameObject enemyPrefab;

    // �X�|�[���ς݂̓G���Ǘ����郊�X�g
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    // Enemy���X�|�[�������鐔
    public int enemyCount = 6;

    // �X�|�[���ʒu�͈̔�
    public Vector2 spawnRange = new Vector2(-10, 10);

    // �X�|�[���ς݂��ǂ����̃t���O
    private bool enemiesSpawned = false;

    void Start()
    {
        // �V�[���J�n����Enemy���X�|�[��
        if (!enemiesSpawned)
        {
            SpawnEnemies();
            enemiesSpawned = true;
        }

    }

    void Update()
    {
        // �^�C�}�[���I�����Ă��Ȃ��ꍇ�A����������
        if (!isTimerEnded)
        {
            timer -= Time.deltaTime;

            // �^�C�}�[��0�ȉ��ɂ��Ȃ�
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

            // �^�C�}�[��UI�ɔ��f
            UpdateTimerUI();
        }

        // �G�����ׂē|���ꂽ�ꍇ
        if (!isTimerEnded && spawnedEnemies.Count == 0)
        {
            isTimerEnded = true;
            ShowResult("�����ˁI");
        }
    }

    // UI�̃e�L�X�g���X�V
    void UpdateTimerUI()
    {
        timerText.text = "�^�C�}�[: " + Mathf.FloorToInt(timer).ToString() + "�b";
    }

    // ���ʂ�\�����ă^�C�}�[���\���ɂ���
    void ShowResult(string message)
    {
        // ���ʃe�L�X�g��\��
        resultText.text = message;
        resultText.gameObject.SetActive(true);

        // �^�C�}�[���\��
        timerText.gameObject.SetActive(false);
    }

    // Enemy���X�|�[��������
    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnRange.x, spawnRange.y),
                0,
                Random.Range(spawnRange.x, spawnRange.y)
            );

            // Enemy�𐶐����ă��X�g�ɒǉ�
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Enemy�Ƀq�b�g���̃R�[���o�b�N��ݒ肷��X�N���v�g���A�^�b�`
            enemy.AddComponent<EnemyDe>().OnEnemyDestroyed = OnEnemyDestroyed;

            spawnedEnemies.Add(enemy);
        }
    }

    // �G���j�󂳂ꂽ�Ƃ��̏���
    void OnEnemyDestroyed(GameObject enemy)
    {
        // ���X�g����폜
        if (spawnedEnemies.Contains(enemy))
        {
            spawnedEnemies.Remove(enemy);
        }
    }
}