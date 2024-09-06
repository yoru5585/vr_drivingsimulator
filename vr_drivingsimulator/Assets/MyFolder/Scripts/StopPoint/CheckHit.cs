using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit : MonoBehaviour
{
    //�ꎞ��~�ɂ�����A�n�_�i��~���̑O�j�AB�n�_�i���n����ʒu�j��
    //��~���Ă��邩���肷��
    //�ԑ̑O��ɃR���C�_�[��ݒu����
    //���̃X�N���v�g�͈�̒�~�ӏ��łS�g�p����
    bool isHit = false;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{gameObject.name}:{other.name}");
        if (other.gameObject.tag == "Player")
        {
            isHit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isHit = false;
        }
    }

    public bool GetIsHit()
    {
        //Debug.Log($"{gameObject.name}:{isHit}");
        return isHit;
    }
}
