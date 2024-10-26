using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Scene : MonoBehaviour
{
    public Camera cameraToCapture; // ָ��Ҫ��������
    string savePath = "Assets/Resources/SceneShooting/Screenshot.png"; // ����·��
    public SpriteRenderer spriteRenderer;          //����չʾ�Ļ���
    [SerializeField]GameObject UI_toshow;                  //ʹ�����๦�ܶ�Ӧ��UI; 
    [SerializeField]GameObject UI_Image;                  //ʹ�����๦�ܶ�Ӧ��ͼƬ; 

    private void Awake()
    {

    }

    private void Update()
    {

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

        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        cameraToCapture.targetTexture = null;
        RenderTexture.active = null; 

        // ����Texture2DΪPNG�ļ�
        byte[] bytes = texture2D.EncodeToPNG();
        System.IO.File.WriteAllBytes(savePath, bytes);

        Texture2D texture2D1 = LoadTexture(savePath);

        if (texture2D1 != null)
        {
            // ����Sprite
            Sprite sprite = Sprite.Create(texture2D1, new Rect(0.0f, 0.0f, texture2D1.width, texture2D1.height), new Vector2(0.5f, 0.5f), 100.0f);
            spriteRenderer.sprite = sprite;


            UI_toshow.SetActive(true);
            UI_Image.SetActive(true);


            // ����Texture2D
            Destroy(texture2D);
        }
    }



    public Texture2D LoadTexture(string filePath)      
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("File not found: " + filePath);
            return null;
        }

        // ��ȡ�ļ�����
        byte[] fileData = File.ReadAllBytes(filePath);
        // ����Texture2D������ͼƬ����
        Texture2D texture = new Texture2D(2, 2);
        bool isLoaded = texture.LoadImage(fileData);

        if (!isLoaded)
        {
            Debug.LogError("Failed to load image data from " + filePath);
            return null;
        }

        return texture;
    }

}

