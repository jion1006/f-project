using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public TextMeshProUGUI dmgText;

    public Vector3 offset = new Vector3(0, 3f, 0);

    public void SetTransform(Vector3 _positon, int dmg)
    {
        transform.position = _positon + offset;
        dmgText.text = dmg.ToString();
        StartCoroutine(DmgCoroutine(2f));
    }

    IEnumerator DmgCoroutine(float duration)
    {
        float tTime = 0f;

        Vector3 startpostion = transform.position;
        Vector3 endposstion = transform.position + new Vector3(0, 1f, 0);
        while (tTime < duration)
        {
            tTime += Time.deltaTime;
            float ratio = tTime / duration;
            transform.position= Vector3.Lerp(startpostion, endposstion, ratio);
            yield return null;
        }


        PoolManager.Instance.ReturnDText(this.gameObject);
    }
}
