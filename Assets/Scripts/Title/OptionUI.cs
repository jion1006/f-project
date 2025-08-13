using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public Button bgmButton;
    public Slider bgmSlider;
    private float prevbV = 0f;
    private bool isbClk = false;

    public Button sfxButton;
    public Slider sfxSlider;
    private float prevsV = 0f;
    private bool issClk = false;

    public Sprite ableSprite;
    public Sprite unableSprite;

    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        bgmSlider.value = AudioManager.Instance.bgmV;
        sfxSlider.value = AudioManager.Instance.sfxV;

        bgmSlider.onValueChanged.AddListener(AudioManager.Instance.SetBgmV);
        sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSFXV);

        bgmButton.onClick.AddListener(bgmClick);
        bgmButton.image.sprite = ableSprite;
        sfxButton.onClick.AddListener(sfxClick);
        sfxButton.image.sprite= ableSprite;

        exitButton.onClick.AddListener(exit);
    }

    


    private void bgmClick()
    {
        if (!isbClk)
        {
            prevbV = bgmSlider.value;
            bgmSlider.value = 0f;
            bgmButton.image.sprite = unableSprite;
            isbClk = true;
        }
        else
        {
            bgmSlider.value = prevbV;
            bgmButton.image.sprite = ableSprite;
            isbClk = false;
        }
    }

    private void sfxClick()
    {
        if (!issClk)
        {
            prevsV = sfxSlider.value;
            sfxSlider.value = 0f;
            sfxButton.image.sprite = unableSprite;
            issClk = true;
        }
        else
        {
            sfxSlider.value = prevsV;
            sfxButton.image.sprite = ableSprite;
            issClk = false;
        }
    }

    private void exit()
    {
        this.gameObject.SetActive(false);
    }
}
