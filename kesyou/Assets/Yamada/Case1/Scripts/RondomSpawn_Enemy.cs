using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RondomSpawn_Enemy : MonoBehaviour
{
    public GameObject enemyPrefab; // 生成するEnemyのプレハブ
    public float minSpawnTime = 1f; // 最小生成時間
    public float maxSpawnTime = 3f; // 最大生成時間

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // ランダムな生成時間を設定
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            // Enemyを生成
            Vector2 spawnPosition = new Vector2(
                Random.Range(-8f, 8f), // X座標の範囲
                Random.Range(-4f, 4f)  // Y座標の範囲
            );
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
