using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public Camera cameraToCapture; // 指定要捕获的相机
    public string savePath = "Screenshot.png"; // 保存路径

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            CaptureAndSave();
        }
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

        // 读取渲染纹理到Texture2D
        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        // 重置相机目标纹理
        cameraToCapture.targetTexture = null;
        RenderTexture.active = null; // 注意释放 RenderTexture

        // 保存Texture2D为PNG文件
        byte[] bytes = texture2D.EncodeToPNG();
        System.IO.File.WriteAllBytes(savePath, bytes);

        // 清理Texture2D
        Destroy(texture2D);
    }
}

