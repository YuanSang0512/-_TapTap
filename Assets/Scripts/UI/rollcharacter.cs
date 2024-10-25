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

        Talking_Begin(Dialog_index - 1 );
    }

    IEnumerator ShowText(int i)
    {
        IfFinish = false;
        textComponent.text = ""; // ��ʼ���ı��������
        int letter = 0;

        // �ӶԻ�����ȡ��ɫ��������Ի���ʽΪ "��ɫ��: �Ի�����"
        string fullDialog = dialog_Tail[i][index];
        string characterName = fullDialog.Split('��')[0].Trim();
        string dialogWithoutName = fullDialog.Substring(characterName.Length + 1).Trim(); // �Ƴ���ɫ����ð��

        // ��ʾ��Ӧ�Ľ�ɫͼƬ
        if (CharacterName_Sprites.ContainsKey(characterName))
        {
            characterSpriteRenderer.sprite = CharacterName_Sprites[characterName];
        }

        // ���ַ���ʾ�Ի�����
        while (!IfJump && letter < dialogWithoutName.Length)
        {
            textComponent.text += dialogWithoutName[letter];
            letter++;
            yield return new WaitForSeconds(delayBetweenChars);
        }

        IfJump = false;
        textComponent.text = dialogWithoutName;
        IfFinish = true;
    }



    public void Talking_Begin(int i)    
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (IfFinish)
            {
                index++;
                if (index >= dialog_Tail[i].Length - 1)
                {
                    index = 0;
                    GameStory.SetActive(false);
                    Entity.isBusy= false;
                }
                else
                {
                    textComponent.text = "";
                    StartCoroutine(ShowText(i));
                }

            }
            else if (!IfJump && !IfFinish)
            {
                IfJump = true;
            }
        }
    }
}
