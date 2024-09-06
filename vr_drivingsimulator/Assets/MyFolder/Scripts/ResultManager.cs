using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    //�]�����ʂ�\������
    [SerializeField] TMP_Text text;
    PointManager pointManager;
    private void Start()
    {
        pointManager = GetComponent<PointManager>();
    }

    public void ShowResult()
    {
        text.text = "";
        int num = 1;
        foreach (Evaluation[] evaArray in pointManager.GetList())
        {
            text.text += $"���|�C���g{num}�F\n";
            text.text += $"A����F{evaArray[0].isSuccess}�@�b���F{evaArray[0].stopTime}\n" +
                $"B����F{evaArray[1].isSuccess}�@�b���F{evaArray[1].stopTime}\n";
            num++;
        }
        
    }
}
