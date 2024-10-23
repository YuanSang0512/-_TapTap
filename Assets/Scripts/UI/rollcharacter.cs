using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class rollcharacter : MonoBehaviour
{
    [SerializeField] bool IfFinish = false;
    [SerializeField] bool IfJump = false;

    public TextAsset peibiao;
    public TMP_Text textComponent;
    public float delayBetweenChars = 0.1f;
    public string[] dialog;
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
        dialog = peibiao.text.Split('\n');
        // ��Listת��ΪDictionary
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IfFinish)
            {
                index++;
                if (index >= dialog.Length - 1)
                {
                    index = 0;
                    GameStory.SetActive(false);
                }
                StartCoroutine(ShowText());
            }
            else if (!IfJump && !IfFinish)
            {
                IfJump = true;
            }
        }
    }

    IEnumerator ShowText()
    {
        textComponent.color = Color.red;
        IfFinish = false;
        textComponent.text = TempString;
        int letter = 0;

        // �������ӶԻ�����ȡ��ɫ��������Ի���ʽΪ "��ɫ��: �Ի�����"
        string characterName = dialog[index].Split('��')[0].Trim();
        // ��ʾ��Ӧ�Ľ�ɫͼƬ
        if (CharacterName_Sprites.ContainsKey(characterName))
        {
            characterSpriteRenderer.sprite = CharacterName_Sprites[characterName];
        }

        while (!IfJump && letter < dialog[index].Length)
        {
            textComponent.text += dialog[index][letter];
            letter++;
            yield return new WaitForSeconds(delayBetweenChars);
        }
        IfJump = false;
        textComponent.text = dialog[index].Substring(characterName.Length + 1).Trim(); // ��ʾ�Ի����ݣ�ȥ����ɫ��
        IfFinish = true;
    }

    public void NpcStart()
    {
        GameStory.SetActive(true);
        StartCoroutine(ShowText());
    }
}
