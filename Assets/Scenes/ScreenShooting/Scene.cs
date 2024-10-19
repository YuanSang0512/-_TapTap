using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public Camera cameraToCapture; // ָ��Ҫ��������
    public string savePath = "Screenshot.png"; // ����·��

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            CaptureAndSave();
        }
    }

    public void CaptureAndSave()
    {
        // ����һ��RenderTexture������ֱ�����ͬ
        RenderTexture renderTexture = new RenderTexture(cameraToCapture.pixelWidth, cameraToCapture.pixelHeight, 24);
        cameraToCapture.targetTexture = renderTexture;

        // ִ�������Ⱦ
        cameraToCapture.Render();

        // ����Texture2D�Ա���ͼ��
        Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);

        // ��ȡ��Ⱦ����Texture2D
        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        // �������Ŀ������
        cameraToCapture.targetTexture = null;
        RenderTexture.active = null; // ע���ͷ� RenderTexture

        // ����Texture2DΪPNG�ļ�
        byte[] bytes = texture2D.EncodeToPNG();
        System.IO.File.WriteAllBytes(savePath, bytes);

        // ����Texture2D
        Destroy(texture2D);
    }
}

