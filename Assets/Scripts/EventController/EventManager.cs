using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    [Header("Event info")]
    public int eventNumber;
    public int eventIndex;
    public List<string> events = new List<string>();

    [Header("SaveData info")]
    public string Event_DATA_FILE_NAME;

    public static EventManager instance { get; private set; }

    public class Data
    {
        public int eventIndex;
        public List<string> events;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        SaveSystem.SaveCurrentSceene(SceneManager.GetActiveScene().name);//保存当前场景名称

        InitEventManager();//初始化场景事件

        LoadData();//读取存档加载内容
    }

    private void InitEventManager()
    {
        TraverseEvents();
        eventNumber = events.Count;
    }

    public void CheckEventProgress()
    {
        Debug.Log(eventIndex + "/" +  eventNumber);
    }

    public bool EventIsEnded()
    {
        return eventIndex == eventNumber;
    }

    #region Save
    public void SaveData()
    {
        foreach(var i in events)
        {
            Debug.Log(i);
        }
        SaveSystem.SaveByJson(Event_DATA_FILE_NAME, SavingData());
    }

    private Data SavingData()
    {
        var data = new Data();

        data.eventIndex = eventIndex;
        data.events = TraverseEvents();

        return data;
    }
    #endregion

    #region Load
    public void LoadData()
    {
        var data = SaveSystem.LoadFromJson<Data>(Event_DATA_FILE_NAME);

        if (data == null)
            return;

        var expectedList = events.Except(data.events);
        List<string> temp = expectedList.ToList();
        for (int i = 0; i < temp.Count(); i++)
        {
            for (int j = 0; j < eventNumber; j++)
            {
                if (temp[i] == transform.GetChild(j).gameObject.name)
                {
                    Destroy(transform.GetChild(j).gameObject);
                    events.Remove(temp[i]);
                    break;
                }
            }
        }

        LoadingData(data);
    }

    private void LoadingData(Data _data)
    {
        eventIndex = _data.eventIndex;
    }
    #endregion

    //[UnityEditor.MenuItem("Developer/Delete Event Data Save File")]
    public void DeleteEventDataFile()
    {
        SaveSystem.DeleteSaveFile(Event_DATA_FILE_NAME);
    }

    //Traverse Event And Save Name To events List
    private List<string> TraverseEvents()
    {
        events.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            events.Add(transform.GetChild(i).name);
            Debug.Log("Add" + transform.GetChild(i).name);
        }
        return events;
    }


}
