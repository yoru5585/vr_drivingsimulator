using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class GameManager : MonoBehaviour
{
    //�S�̗̂�����Ǘ�����
    [SerializeField] GameObject goalObj;
    [SerializeField] GameObject myCar;
    PointManager pointManager;
    ResultManager resultManager;

    bool IsGameEnd = false;
    bool IsGamePause = false;

    // Start is called before the first frame update
    void Start()
    {
        pointManager = GetComponent<PointManager>();
        resultManager = GetComponent<ResultManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameEnd)
        {
            return;
        }

        GamePause();

        //�|�C���g�����ׂĒʉ߂�����
        if (pointManager.GetLength() >= pointManager.GetMaxLen())
        {
            //�S�[���ɐG�ꂽ��
            if (goalObj.GetComponent<Goal>().GetIsHit())
            {
                resultManager.ShowResult();
                IsGameEnd = true;
                IsGamePause = true;
                GamePause();
                
            }
        }
    }

    void GamePause()
    {
        //�Ԃ̓����Ȃǂ��~�߂�
        myCar.GetComponent<Rigidbody>().isKinematic = IsGamePause;
    }
}
