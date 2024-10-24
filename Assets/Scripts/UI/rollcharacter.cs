using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class rollcharacter : MonoBehaviour
{
    [SerializeField] bool IfFinish = false;
    [SerializeField] bool IfJump = false;
    public int Dialog_index;

    public TextAsset peibiao;
    public TMP_Text textComponent;
    public float delayBetweenChars = 0.1f;
    public string[] dialog_All;
    public string[][] dialog_Tail;
    public int index;

    private string TempString = "";
    public GameObject GameStory;

    public List<string> characterNames = new List<string>();             //角色名
    public List<Sprite> characterImages = new List<Sprite>();            //角色图片

    // 新增：SpriteRenderer组件，用于显示角色图片
    public SpriteRenderer characterSpriteRenderer;

    private Dictionary<string, Sprite> CharacterName_Sprites;

    // Start is called before the first frame update
    void Start()
    {
        dialog_All = peibiao.text.Split('#');


        dialog_Tail = new string[dialog_All.Length][];
        for (int i = 0; i < dialog_All.Length; i++)
        {
            // 使用 Split 方法分割每个对话字符串，并将结果赋给 dialog_Tail 的相应位置
            dialog_Tail[i] = dialog_All[i].Split('\n');
        }
        CharacterName_Sprites = new Dictionary<string, Sprite>();
        for (int i = 0; i < characterNames.Count; i++)
        {
            if (!CharacterName_Sprites.ContainsKey(characterNames[i]))
            {
                CharacterName_Sprites.Add(characterNames[i], characterImages[i]);
            }
        }
    }

    private void Update()
    {
        Talking_Begin(Dialog_index);
    }

    IEnumerator ShowText(int i)
    {
        IfFinish = false;
        textComponent.text = TempString;
        int letter = 0;

        // 新增：从对话中提取角色名，假设对话格式为 "角色名: 对话内容"
        string characterName = dialog_Tail[i][index].Split('：')[0].Trim();
        // 显示对应的角色图片
        if (CharacterName_Sprites.ContainsKey(characterName))
        {
            characterSpriteRenderer.sprite = CharacterName_Sprites[characterName];
        }

        while (!IfJump && letter < dialog_Tail[i][index].Length)
        {
            textComponent.text += dialog_Tail[i][index][letter];
            letter++;
            yield return new WaitForSeconds(delayBetweenChars);
        }
        IfJump = false;
        textComponent.text = dialog_Tail[i][index].Substring(characterName.Length + 1).Trim(); // 显示对话内容，去掉角色名
        IfFinish = true;
    }


    public void Talking_Begin(int i)    
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IfFinish)
            {
                index++;
                if (index >= dialog_Tail[i].Length - 1)
                {
                    index = 0;
                    GameStory.SetActive(false);
                }
                StartCoroutine(ShowText(i));
            }
            else if (!IfJump && !IfFinish)
            {
                IfJump = true;
            }
        }
    }
}
