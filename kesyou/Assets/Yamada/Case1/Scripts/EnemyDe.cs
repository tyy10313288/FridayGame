using UnityEngine;

public class EnemyDe : MonoBehaviour
{
    // 敵が破壊されたときに呼ばれるコールバック
    public System.Action<GameObject> OnEnemyDestroyed;

    void OnMouseDown()
    {
        // マウスクリックで破壊
        Destroy(gameObject);

        // コールバックを呼び出す
        OnEnemyDestroyed?.Invoke(gameObject);
    }
}
