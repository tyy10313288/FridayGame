using System.Collections;
using UnityEngine;

public class RandomLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool isErasing = false;

    private void Start()
    {
        // LineRenderer�R���|�[�l���g��ǉ�
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;

        // �����_���Ȉʒu�ɐ���`��
        Vector3 startPos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
        Vector3 endPos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);

        // 10�b��Ɏ�����������R���[�`�����J�n
        StartCoroutine(AutoDestroyAfterTime(10f));
    }

    private void OnMouseOver()
    {
        // ���N���b�N�������Ȃ��������Ȃ������ꍇ�ɏ���
        if (Input.GetMouseButton(0) && !isErasing)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            // ����̊e�_����̋������`�F�b�N���āA���͈͓��Ȃ����
            if (Vector3.Distance(lineRenderer.GetPosition(0), mousePos) < 0.5f ||
                Vector3.Distance(lineRenderer.GetPosition(1), mousePos) < 0.5f)
            {
                isErasing = true;
                Destroy(gameObject);
                Debug.Log("Crick");
            }
        }
    }

    private IEnumerator AutoDestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        Debug.Log("time");
    }
}