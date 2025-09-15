using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;

[Serializable]
public class AudioFile
{
    public string name;
    public AudioClip audioClip;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;


    public List<AudioFile> bgmClips;
    public AudioSource bgmSource;

    public List<AudioFile> sfxClips;
    public AudioSource sfxSource;

    private Dictionary<string, AudioClip> bgmDit;
    private Dictionary<string, AudioClip> sfxDit;

    public float duration = 10f;
    public float sfxV = 0.3f;
    public float bgmV = 0.3f;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
        InitDic();

    }

    void Start()
    {
        bgmSource.volume = bgmV;
        
    }
    public void InitDic()
    {
        bgmDit = new Dictionary<string, AudioClip>();

        foreach (var bgm in bgmClips)
        {
            if (!bgmDit.ContainsKey(bgm.name))
            {
                bgmDit[bgm.name] = bgm.audioClip;
            }
        }

        sfxDit = new Dictionary<string, AudioClip>();
        foreach (var sfx in sfxClips)
        {
            if (!sfxDit.ContainsKey(sfx.name))
            {
                sfxDit[sfx.name] = sfx.audioClip;
            }
        }
    }

    public void PlayBGM(string _name)
    {
        if (bgmDit.TryGetValue(_name, out var clip))
        {
            bgmSource.clip = clip;
            bgmSource.Play();
            StartCoroutine(FadeInBgm());
        }
        else
        {
            Debug.LogWarning("BGM not Setting");
        }

    }

    public void PlaySFX(string _name)
    {
        if (sfxDit.TryGetValue(_name, out var clip))
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("SFX not Setting");
        }
    }


    public void SetBgmV(float _volume)
    {
        bgmV = _volume;
        bgmSource.volume = bgmV;
    }

    public void SetSFXV(float _volume)
    {
        sfxV = _volume;
        sfxSource.volume = sfxV;
        PlaySFX("Setting");
    }

    public IEnumerator FadeInBgm()
    {
        bool isEnd = false;
        bgmSource.DOFade(bgmV, duration).OnComplete(() => isEnd = true);
        yield return new WaitUntil(() => isEnd);
    }


    public IEnumerator FadeOutBgm()
    {
        bool isEnd = false;
        bgmSource.DOFade(0f, duration).OnComplete(() =>
        {
            bgmSource.Stop();
            isEnd = true;
        });

        yield return new WaitUntil(() => isEnd);
    }

}
