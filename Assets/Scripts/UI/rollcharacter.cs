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

    public List<string> characterNames = new List<string>();             //��ɫ��
    public List<Sprite> characterImages = new List<Sprite>();            //��ɫͼƬ

    // ������SpriteRenderer�����������ʾ��ɫͼƬ
    public SpriteRenderer characterSpriteRenderer;

    private Dictionary<string, Sprite> CharacterName_Sprites;

    // Start is called before the first frame update
    void Start()
    {
        dialog_All = peibiao.text.Split('#');


        dialog_Tail = new string[dialog_All.Length][];
        for (int i = 0; i < dialog_All.Length; i++)
        {
            // ʹ�� Split �����ָ�ÿ���Ի��ַ���������������� dialog_Tail ����Ӧλ��
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

        // �������ӶԻ�����ȡ��ɫ��������Ի���ʽΪ "��ɫ��: �Ի�����"
        string characterName = dialog_Tail[i][index].Split('��')[0].Trim();
        // ��ʾ��Ӧ�Ľ�ɫͼƬ
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
        textComponent.text = dialog_Tail[i][index].Substring(characterName.Length + 1).Trim(); // ��ʾ�Ի����ݣ�ȥ����ɫ��
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
