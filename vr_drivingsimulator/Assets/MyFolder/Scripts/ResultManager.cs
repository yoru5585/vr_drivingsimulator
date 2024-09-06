using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    //評価結果を表示する
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
            text.text += $"◆ポイント{num}：\n";
            text.text += $"A判定：{evaArray[0].isSuccess}　秒数：{evaArray[0].stopTime}\n" +
                $"B判定：{evaArray[1].isSuccess}　秒数：{evaArray[1].stopTime}\n";
            num++;
        }
        
    }
}
