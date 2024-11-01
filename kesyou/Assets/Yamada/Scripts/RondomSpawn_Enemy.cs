using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RondomSpawn_Enemy : MonoBehaviour
{
    public GameObject enemyPrefab; // ��������Enemy�̃v���n�u
    public float minSpawnTime = 1f; // �ŏ���������
    public float maxSpawnTime = 3f; // �ő吶������

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // �����_���Ȑ������Ԃ�ݒ�
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            // Enemy�𐶐�
            Vector2 spawnPosition = new Vector2(
                Random.Range(-8f, 8f), // X���W�͈̔�
                Random.Range(-4f, 4f)  // Y���W�͈̔�
            );
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
