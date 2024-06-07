using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private RecvManager m_recvManager;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            m_recvManager = GameObject.Find("Scripts").GetComponent<RecvManager>();
        }


        private void FixedUpdate()
        {
            //元々はここでコントローラの入力を取得
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            //float v = CrossPlatformInputManager.GetAxis("Vertical");

            //UDPで受け取ったデータを代入
            float h = m_recvManager.GetStsteerAxis();
            float a = (1 - m_recvManager.GetStapedalAxis());
            float b = (1 - m_recvManager.GetStbpedalAxis());
            float v = b - a;

#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
