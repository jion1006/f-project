using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor.Build.Player;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Image fade;

    public float duration = 0.7f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);


    }


    void PlaySceneBGM(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeInScreen());
        AudioManager.Instance.PlayBGM(scene.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += PlaySceneBGM;

        PlaySceneBGM(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene(string _sceneName)
    {

        StartCoroutine(ChangeSce(_sceneName));
    }

    private IEnumerator ChangeSce(string _sceneName)
    {
        Coroutine bgmFade = StartCoroutine(AudioManager.Instance.FadeOutBgm());
        Coroutine fadeScreen = StartCoroutine(FadeOutScreen());

        yield return bgmFade;
        yield return fadeScreen;

        SceneManager.LoadScene(_sceneName);
        if (PlayerController.Instance != null)
        {
            if (_sceneName == "DungenSelect")
                PlayerController.Instance.gameObject.SetActive(false);
            else if (_sceneName == "StartScene")
            {
                Destroy(PlayerController.Instance.gameObject);
            }
            else
            {
                PlayerController.Instance.gameObject.SetActive(true);
                PlayerController.Instance.animator.SetFloat("DirX", 1);
            }

        }

    }

    public IEnumerator FadeInScreen()
    {
        bool isEnd = false;
        fade.DOFade(0f, duration).OnComplete(() => isEnd = true);
        fade.raycastTarget = false;
        yield return new WaitUntil(() => isEnd);
    }

    public IEnumerator FadeOutScreen()
    {
        bool isEnd = false;
        fade.DOFade(1f, duration).OnComplete(() => isEnd = true);
        fade.raycastTarget = true;
        yield return new WaitUntil(() => isEnd);
    }


}
