using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Kesyou : MonoBehaviour, IPointerClickHandler
{
    //�e���ϕi�ɔԍ���U�蕪��
    [SerializeField] private int A;

    private AudioSource audioSource;
    Branch branch;
    Setting setting;
    private void Start()
    {
        //�ʃX�N���v�g�̎擾
        branch = GameObject.Find("branch").GetComponent<Branch>();
        setting = GameObject.Find("Setting").GetComponent<Setting>();

        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //�ݒ��ʂ��J����Ă��Ȃ��Ƃ�
        if (!setting._setting)
        {
            //�^����ꂽ���ς̔ԍ��ɂȂ�܂Ń��[�v
            for(int i = 0; i <= A; i++)
            {
                //�����l�ɂȂ�����ʃX�N���v�g�ɂ��̒l���o��
                if (branch.a == i)
                {
                    branch.a = A;
                }
            }
            audioSource.Play();
            branch.destroy();
            //���O���ʉ����₷������ׂ��������i���ȓ_�j
            branch.branch();
        }
    }
}
