using System.IO;
using UnityEngine;

public static class SaveSystem
{
    //Save Data
    public static void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.WriteAllText(path, json);
            Debug.Log("Save Succeed");
        }
        catch(System.Exception e)
        {
            #if UNITY_EDITOR
            Debug.Log(e.ToString());
            #endif
        }
    }

    //Load Data
    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
            Debug.Log("Load Succeed");
            return data;
        }
        catch (System.Exception e)
        {
            ClearData();
            Debug.Log(e.ToString());
            return default;
        }

    }

    //Delete Data
    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.Delete(path);
            Debug.Log("Delete Succeed");
        }
        catch (System.Exception e)
        {
            #if UNITY_EDITOR
            Debug.Log(e.ToString());
            #endif
        }
    }
    //退出游戏调用
    public static void SaveCurrentSceene(string _currentScene)
    {
        //var json = JsonUtility.ToJson(_currentScene);
        var path = Path.Combine(Application.persistentDataPath, "CurrentScene.data");

        File.WriteAllText(path, _currentScene);
        Debug.Log("Save CurrentScene Succeed");
    }

    //继续游戏调用
    public static string GetCurrentScene()
    {
        var path = Path.Combine(Application.persistentDataPath, "CurrentScene.data");


        return File.ReadAllText(path);
    }


    //Clear Data
    public static void ClearData()
    {
        SaveSystem.SaveByJson("CityEvent.data", null);
        SaveSystem.SaveByJson("CliffEvent.data", null);
        SaveSystem.SaveByJson("ForestEvent.data", null);
        SaveSystem.SaveByJson("Hos_306Event.data", null);
        SaveSystem.SaveByJson("HospitalEvent.data", null);
        SaveSystem.SaveByJson("ICUEvent.data", null);
        SaveSystem.SaveByJson("Sch_210Event.data", null);
        SaveSystem.SaveByJson("Sch_OfficeEvent.data", null);
        SaveSystem.SaveByJson("Sch_RoofTopEvent.data", null);
        SaveSystem.SaveByJson("SchoolEvent.data", null);
        SaveSystem.SaveByJson("Train_123Event.data", null);
    }
}
