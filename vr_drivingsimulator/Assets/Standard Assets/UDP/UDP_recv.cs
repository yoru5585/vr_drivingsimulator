using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;//for UDP
using System.Net.Sockets; //for UDP
using System.Threading;
using System.Diagnostics;//for Interlocked

namespace ForUDP
{
    public class UDP_recv
    {
        private UdpClient udpForReceive; //��M�p�N���C�A���g

        private System.Threading.Thread rcvThread; //��M�p�X���b�h

        public float[] rcv_float_arr = new float[10];

        public UDP_recv()
        {
        }

        public bool init(int port_rcv) //UDP�ݒ�i��M�p�X���b�h�𐶐��j
        {
            try
            {
                udpForReceive = new UdpClient(port_rcv); //��M�p�|�[�g
                rcvThread = new System.Threading.Thread(new System.Threading.ThreadStart(receive_xyz)); //��M�X���b�h����
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void receive_xyz() //��M�X���b�h�Ŏ��s�����֐�
        {
            IPEndPoint remoteEP = null;//�C�ӂ̑��M������̃f�[�^����M
            while (true)
            {
                try
                {
                    byte[] rcvBytes = udpForReceive.Receive(ref remoteEP);
                    UnityEngine.Debug.Log(remoteEP.Address);
                    UnityEngine.Debug.Log(remoteEP.Port);
                    for (int i = 0; i < rcvBytes.Length; i++)
                    {
                        var a = BitConverter.ToSingle(rcvBytes, i * 4);
                        rcv_float_arr[i] = a;
                    }
                }
                catch { }

            }
        }

        public void start_receive() //��M�X���b�h�J�n
        {
            try
            {
                rcvThread.Start();
            }
            catch { }
        }

        public void stop_receive() //��M�X���b�h���~
        {
            try
            {

                rcvThread.Interrupt();
            }
            catch { }
        }

        public void end() //����M�p�|�[�g�����M�p�X���b�h���p�~
        {
            try
            {
                udpForReceive.Close();
                rcvThread.Abort();
            }
            catch { }
        }
    }
}
