using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

[System.Serializable]
class CheckStep
{
    public CheckHit front;
    public CheckHit back;

    public Evaluation eva = new Evaluation();

    public bool GetIsThrough()
    {
        if (front.GetIsHit() && back.GetIsHit())
        {
            return true;
        }

        return false;
    }
}

public class StopSignManager : MonoBehaviour
{
    //�e�ꎞ��~�ӏ��̔���
    //���茋�ʂ��}�l�[�W���[�ɑ���
    [SerializeField] CheckStep A;
    [SerializeField] CheckStep B;

    float time = 0;
    float interval = 3;

    int state = 0;

    void sendDataToManager()
    {
        //�}�l�[�W���[�ɔ���f�[�^�𑗂�
        Debug.Log($"A����F{ A.eva.isSuccess}�@�b���F{A.eva.stopTime}");
        Debug.Log($"B����F{ B.eva.isSuccess}�@�b���F{B.eva.stopTime}");

        GameObject.Find("Scripts").GetComponent<PointManager>().AddList(A.eva, B.eva);
    }

    // Update is called once per frame
    void Update()
    {
        float v = (GameObject.Find("MyCar").GetComponent<Rigidbody>().velocity.magnitude * 60 * 60) / 1000;
        Debug.Log(v);

        switch (state) 
        { 
            case 0:
                //�X�^�[�g A�ҋ@��
                if (A.GetIsThrough())
                {
                    state++;
                }
                break;
            case 1:
                //A�`�F�b�N�� 
                if (v < 1f)
                {
                    //���s���ĂȂ���Ύ��Ԃ��v��
                    time += Time.deltaTime;
                    if (time > interval)
                    {
                        A.eva.isSuccess = true;
                        Debug.Log("A OK");
                    }

                }

                if (A.GetIsThrough() != true)
                {
                    //A�����o��
                    A.eva.stopTime = time;

                    time = 0;
                    interval = 3;
                    state++;
                }
                break;
            case 2:
                //B�ҋ@��
                if (B.GetIsThrough())
                {
                    state++;
                }
                break;
            case 3:
                //B�`�F�b�N��
                if (v < 1f)
                {
                    //���s���ĂȂ���Ύ��Ԃ��v��
                    time += Time.deltaTime;
                    if (time > interval)
                    {
                        B.eva.isSuccess = true;
                        Debug.Log("B OK");
                    }

                }

                if (B.GetIsThrough() != true)
                {
                    //B�����o��
                    B.eva.stopTime = time;
                    state++;
                }
                break;
            case 4:
                //�G���h ���ʂ��}�l�[�W���[�ɑ���
                sendDataToManager();
                state = 99;
                break;
            default:
                //�G���[
                break;
        }
    }
}
