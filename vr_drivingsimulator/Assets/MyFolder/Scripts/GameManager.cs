using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class GameManager : MonoBehaviour
{
    //‘S‘Ì‚Ì—¬‚ê‚ğŠÇ—‚·‚é
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

        //ƒ|ƒCƒ“ƒg‚ğ‚·‚×‚Ä’Ê‰ß‚µ‚½‚©
        if (pointManager.GetLength() >= pointManager.GetMaxLen())
        {
            //ƒS[ƒ‹‚ÉG‚ê‚½‚©
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
        //Ô‚Ì“®‚«‚È‚Ç‚ğ~‚ß‚é
        myCar.GetComponent<Rigidbody>().isKinematic = IsGamePause;
    }
}
