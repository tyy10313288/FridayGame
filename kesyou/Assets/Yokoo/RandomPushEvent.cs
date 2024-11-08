using UnityEngine;

public class RandomPushEvent : MonoBehaviour
{
    private int clickCount = 0; // �N���b�N�񐔂��J�E���g
    private const int maxClicks = 10; // �N���b�N�񐔂̍ő�l�i10��j
    private float timeLimit = 10f; // ���Ԑ����i10�b�j
    private bool isTimeUp = false; // ���Ԑ������؂ꂽ���ǂ������Ǘ�

    // ���Ԑ����̃J�E���g�_�E�����J�n
    private void Start()
    {
        // �^�C�}�[���J�n����
        Invoke("TimeUp", timeLimit); // 10�b���TimeUp���\�b�h���Ăяo��
    }

    // �N���b�N���ꂽ���ɌĂ΂�郁�\�b�h
    void OnMouseDown()
    {
        if (isTimeUp) return; // ���Ԑ������߂����ꍇ�̓N���b�N�𖳌��ɂ���

        clickCount++; // �N���b�N�񐔂�1����
        Debug.Log("�N���b�N��: " + clickCount);

        // �N���b�N�񐔂�maxClicks�ɒB������G������
        if (clickCount >= maxClicks)
        {
            Destroy(gameObject); // �G�L�����N�^�[������
            Debug.Log("�G�������܂����I");
        }
    }

    // ���Ԑ������؂ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
    private void TimeUp()
    {
        isTimeUp = true; // ���Ԑ؂�t���O�𗧂Ă�
        Debug.Log("���Ԑ؂�ł��I�G�������܂��I");
        Destroy(gameObject); // �G�L�����N�^�[������
    }
}
