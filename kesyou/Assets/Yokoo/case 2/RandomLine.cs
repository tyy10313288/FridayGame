using System.Collections;
using UnityEngine;

public class RandomLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool isErasing = false;

    private void Start()
    {
        // LineRendererコンポーネントを追加
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;

        // ランダムな位置に線を描画
        Vector3 startPos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
        Vector3 endPos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);

        // 10秒後に自動消去するコルーチンを開始
        StartCoroutine(AutoDestroyAfterTime(10f));
    }

    private void OnMouseOver()
    {
        // 左クリックを押しながら線上をなぞった場合に消去
        if (Input.GetMouseButton(0) && !isErasing)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            // 線上の各点からの距離をチェックして、一定範囲内なら消去
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