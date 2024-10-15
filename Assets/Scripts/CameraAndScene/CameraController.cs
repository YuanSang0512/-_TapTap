using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���������������Լ�ʵ�ֳ������뽥��Ч��
/// </summary>

public class CameraController : MonoBehaviour
{
    public static CameraController instance { get; private set; }
    private CinemachineVirtualCamera virtualCamera;
    public Animator animator;
    public GameObject screenFader;
    private Player player;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(this);
        screenFader = GameObject.Find("ScreenFader");
        animator = screenFader.GetComponent<Animator>();
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        //player = FindObjectOfType<Player>();

    }

    private void Start()
    {
        player = Player.instance;
        virtualCamera.Follow = player.transform;
    }

    public IEnumerator LoadScene(string _sceneName)
    {

        animator.SetBool("In", false);
        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(_sceneName);
        async.completed += OnLoadScene;

    }

    private void OnLoadScene(AsyncOperation operation)
    {
        animator.SetBool("In", true);
    }
}
