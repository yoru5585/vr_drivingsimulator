using System;
using UnityEngine;
using System.IO;
using System.Collections;

public class ContinuousCaptureAndSetTexture : MonoBehaviour
{
    [SerializeField] Camera Camera;
    public float captureInterval = 1.0f; // �L���v�`���Ԋu�i�b�j
    private Texture2D texture;

    void Start()
    {
        // �����e�N�X�`���̐���
        texture = new Texture2D(1024, 512);
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.mainTexture = texture;
        }

        // �L���v�`���̃R���[�`�����J�n
        StartCoroutine(CaptureRoutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            Debug.Log("ssss");
            AnyCapture();
        }
    }

    IEnumerator CaptureRoutine()
    {
        while (true)
        {
            // �L���v�`����񓯊��Ŏ��s
            I360Render.CaptureAsync(OnCaptureComplete, 1024, true, Camera, true);

            // ���̃L���v�`���܂őҋ@
            yield return new WaitForSeconds(captureInterval);
        }
    }

    void OnCaptureComplete(byte[] screenshotBytes)
    {
        /*
        // �ۑ���̃p�X��ݒ�
        string filePath = "Assets/MyFolder/screenshot1.jpg";

        // �o�C�g�z����t�@�C���ɏ�������
        File.WriteAllBytes(filePath, screenshotBytes);
        */

        // �o�C�g�z�񂩂�e�N�X�`�����X�V
        texture.LoadImage(screenshotBytes);

        // �e�N�X�`���𐅕����]
        FlipTextureHorizontally(texture);

        Debug.Log("�}�e���A���̃e�N�X�`�����X�V����܂���");
    }

    void FlipTextureHorizontally(Texture2D original)
    {
        int width = original.width;
        int height = original.height;

        // �������]����
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width / 2; x++)
            {
                // �����̃s�N�Z���ƉE���̃s�N�Z�������ւ�
                Color leftPixel = original.GetPixel(x, y);
                Color rightPixel = original.GetPixel(width - 1 - x, y);

                original.SetPixel(x, y, rightPixel);
                original.SetPixel(width - 1 - x, y, leftPixel);
            }
        }

        // �ύX��K�p
        original.Apply();
    }

    void AnyCapture()
    {
        // 360���X�N���[���V���b�g���L���v�`��
        byte[] screenshotBytes = I360Render.Capture(1024, true, Camera, true);

        // �ۑ���̃p�X��ݒ�
        string filePath = "Assets/MyFolder/screenshot.jpg";

        // �o�C�g�z����t�@�C���ɏ�������
        File.WriteAllBytes(filePath, screenshotBytes);

        Debug.Log("360���X�N���[���V���b�g���ۑ�����܂���: " + filePath);
    }
}
