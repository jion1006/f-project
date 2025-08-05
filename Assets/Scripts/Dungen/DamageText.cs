using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public TextMeshProUGUI dmgText;

    public Vector3 offset = new Vector3(0, 3f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetTransform(Vector3 _positon, int dmg)
    {
        transform.position = _positon+offset;
        dmgText.text = dmg.ToString();
    }
}
