using System;
using System.IO;
using UnityEngine;

public class CaptureScreenshot : MonoBehaviour
{
    [SerializeField] Camera Camera;
    void Start()
    {
        
    }

    private void Update()
    {
        // 360���X�N���[���V���b�g���L���v�`��
        byte[] screenshotBytes = I360Render.Capture(2048, true, Camera, true);

        // �ۑ���̃p�X��ݒ�
        string filePath = "Assets/MyFolder/screenshot.jpg";

        // �o�C�g�z����t�@�C���ɏ�������
        File.WriteAllBytes(filePath, screenshotBytes);

        Debug.Log("360���X�N���[���V���b�g���ۑ�����܂���: " + filePath);

    }
}
