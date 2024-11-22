using UnityEngine;

public class EnemyDe : MonoBehaviour
{
    // �G���j�󂳂ꂽ�Ƃ��ɌĂ΂��R�[���o�b�N
    public System.Action<GameObject> OnEnemyDestroyed;

    void OnMouseDown()
    {
        // �}�E�X�N���b�N�Ŕj��
        Destroy(gameObject);

        // �R�[���o�b�N���Ăяo��
        OnEnemyDestroyed?.Invoke(gameObject);
    }
}
