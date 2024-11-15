using UnityEngine;
using UnityEngine.UI;

public class RandomPushEvent : MonoBehaviour
{
    private int clickCount = 0; // �N���b�N�񐔂��J�E���g
    private const int maxClicks = 10; // �N���b�N�񐔂̍ő�l�i10��j
    public float timeLimit = 10f; // ���Ԑ����i10�b�j
    private bool isTimeUp = false; // ���Ԑ������؂ꂽ���ǂ������Ǘ�
    public Text clickCountText; // �N���b�N����\������Text
    public Text resultText; // ���ʂ�\������e�L�X�g

    // ���Ԑ����̃J�E���g�_�E�����J�n
    private void Start()
    {
        // �^�C�}�[���J�n����
        Invoke("TimeUp", timeLimit); // 10�b���TimeUp���\�b�h���Ăяo��

        // �ŏ��̃N���b�N����\��
        UpdateClickCountText();
    }

    // �N���b�N���ꂽ���ɌĂ΂�郁�\�b�h
    void OnMouseDown()
    {
        if (isTimeUp) return; // ���Ԑ������߂����ꍇ�̓N���b�N�𖳌��ɂ���

        clickCount++; // �N���b�N�񐔂�1����
        Debug.Log("�N���b�N��: " + clickCount);
        UpdateClickCountText(); // �\�����X�V

        // �N���b�N�񐔂�maxClicks�ɒB������G������
        if (clickCount >= maxClicks)
        {
            HideObject(); // �G�L�����N�^�[�ƃe�L�X�g���\���ɂ���
        }
    }

    // ���Ԑ������؂ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
    private void TimeUp()
    {
        isTimeUp = true; // ���Ԑ؂�t���O�𗧂Ă�
        Debug.Log("���Ԑ؂�ł��I�G�������܂��I");
        HideObject(); // �G�L�����N�^�[�ƃe�L�X�g���\���ɂ���
        resultText.text = "Nooo";
    }

    // �N���b�N����\������e�L�X�g���X�V���郁�\�b�h
    private void UpdateClickCountText()
    {
        if (clickCountText != null)
        {
            clickCountText.text = "�N���b�N��: " + clickCount;
        }
    }

    // �G�L�����N�^�[�ƃe�L�X�g���\���ɂ��郁�\�b�h
    private void HideObject()
    {
        if (clickCountText != null)
        {
            clickCountText.enabled = false; // �e�L�X�g���\���ɂ���
        }
        gameObject.SetActive(false); // �G�L�����N�^�[���\���ɂ���

        resultText.text = "OK!";
    }
}
