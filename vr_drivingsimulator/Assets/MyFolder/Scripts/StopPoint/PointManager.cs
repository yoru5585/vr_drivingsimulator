using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

//•]‰¿Œ‹‰Ê
public class Evaluation
{
    [System.NonSerialized] public bool isSuccess = false;
    [System.NonSerialized] public float stopTime = 0;
}

public class PointManager : MonoBehaviour
{
    //ˆê’â~‰ÓŠ‚Å‚Ì•]‰¿‚ğ‚Ü‚Æ‚ß‚é
    [SerializeField] private List<Evaluation[]> evaluationList = new List<Evaluation[]>();
    [SerializeField] private int maxLen = 2;
    private int len = 0;

    public void AddList(Evaluation eva_A, Evaluation eva_B)
    {
        Evaluation[] tmp = { eva_A, eva_B };
        evaluationList.Add(tmp);
        len++;
    }

    public List<Evaluation[]> GetList()
    {
        return evaluationList;
    }

    public int GetLength()
    {
        return len;
    }

    public int GetMaxLen()
    {
        return maxLen;
    }
}
