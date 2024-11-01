using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvent_Ya : MonoBehaviour
{
    public float speed = 2f; // �ړ����x
    public float changeTime = 1f; // �ړ�������ς��鎞��

    private Vector2 targetPosition;

    void Start()
    {
        SetRandomTargetPosition();
        StartCoroutine(MoveToTarget());
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
    }
}
