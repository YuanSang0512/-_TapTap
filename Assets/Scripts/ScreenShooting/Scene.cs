using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Scene : MonoBehaviour
{
    public Camera cameraToCapture; // 指定要捕获的相机
    string savePath = "Assets/Resources/SceneShooting/Screenshot.png"; // 保存路径
    public SpriteRenderer spriteRenderer;          //截屏展示的画板
    [SerializeField]GameObject UI_toshow;                  //使用照相功能对应的UI; 
    [SerializeField]GameObject UI_Image;                  //使用照相功能对应的图片; 

    private void Awake()
    {

    }

    private void Update()
    {

    }
    public void CaptureAndSave()
    {
        // 创建一个RenderTexture与相机分辨率相同
        RenderTexture renderTexture = new RenderTexture(cameraToCapture.pixelWidth, cameraToCapture.pixelHeight, 24);
        cameraToCapture.targetTexture = renderTexture;

        // 执行相机渲染
        cameraToCapture.Render();

        // 创建Texture2D以保存图像
        Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);

        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        cameraToCapture.targetTexture = null;
        RenderTexture.active = null; 

        // 保存Texture2D为PNG文件
        byte[] bytes = texture2D.EncodeToPNG();
        System.IO.File.WriteAllBytes(savePath, bytes);

        Texture2D texture2D1 = LoadTexture(savePath);

        if (texture2D1 != null)
        {
            // 创建Sprite
            Sprite sprite = Sprite.Create(texture2D1, new Rect(0.0f, 0.0f, texture2D1.width, texture2D1.height), new Vector2(0.5f, 0.5f), 100.0f);
            spriteRenderer.sprite = sprite;


            UI_toshow.SetActive(true);
            UI_Image.SetActive(true);


            // 清理Texture2D
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

        // 读取文件数据
        byte[] fileData = File.ReadAllBytes(filePath);
        // 创建Texture2D并加载图片数据
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

