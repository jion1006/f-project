using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    [SerializeField]
    private Key key;
    
    [SerializeField]
    private Image coolImage;
    private Vector2 size;
    // Start is called before the first frame update
    void Start()
    {
        size = coolImage.rectTransform.sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        size.y = 100f * SkillManager.Instance.GetCoolRate(key);
        coolImage.rectTransform.sizeDelta = size;
    }
}
