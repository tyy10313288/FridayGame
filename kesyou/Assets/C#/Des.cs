using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des : MonoBehaviour
{
    //�s�K�v�ɂȂ����I�u�W�F�N�g�̔j��
    public void OnTriggerStay2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
