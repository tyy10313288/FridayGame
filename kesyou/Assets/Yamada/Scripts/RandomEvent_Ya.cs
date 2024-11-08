using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomEvent_Ya : MonoBehaviour
{
    public float speed = 2f; // �ړ����x
    public float changeTime = 1f; // �ړ�������ς��鎞��
    public float timeLimit = 10f; // ���Ԑ����i10�b�j
    public TextMeshProUGUI timerText; // UI��Text�R���|�[�l���g���Q��


    private Vector2 targetPosition;
    private float timer = 0f; // �^�C�}�[

    void Start()
    {
        SetRandomTargetPosition();
        StartCoroutine(MoveToTarget());
    }

    void Update()
    {
        // �^�C�}�[���X�V
        timer += Time.deltaTime;

        // ���Ԑ����𒴂����ꍇ�A�I�u�W�F�N�g��j��
        if (timer >= timeLimit)
        {
            Destroy(gameObject);
            Debug.Log("���Ԑ����𒴂����̂ŃI�u�W�F�N�g�͔j�󂳂�܂���");
        }

        UpdateTimerUI();
    }

    private void SetRandomTargetPosition()
    {
        targetPosition = new Vector2(
            Random.Range(-8f, 8f), // X���W�͈̔͂�ݒ�
            Random.Range(-4f, 4f)  // Y���W�͈̔͂�ݒ�
        );
    }

    private IEnumerator MoveToTarget()
    {
        while (true)
        {
            float step = speed * Time.deltaTime;

            // �ڕW�ʒu�Ɍ������Ĉړ�
            while (Vector2.Distance(transform.position, targetPosition) > step)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
                yield return null; // ���̃t���[���܂őҋ@
            }

            // �ڕW�ʒu�ɓ��B������V�����ڕW�ʒu��ݒ�
            SetRandomTargetPosition();
            yield return new WaitForSeconds(changeTime); // ��莞�ԑҋ@
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Debug.Log("�|����");
    }

    // �c�莞�Ԃ�UI��Text�ɕ\�����郁�\�b�h
    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            float remainingTime = timeLimit - timer;  // �c�莞�Ԃ��v�Z
            timerText.text = "�c�莞��: " + Mathf.Max(0f, remainingTime).ToString("F2") + "�b";  // �����_�ȉ�2���܂ŕ\��
        }
    }
}
