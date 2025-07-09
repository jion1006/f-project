using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungenSelectUI : MonoBehaviour
{

    [SerializeField]
    private int selectDungen = 0;
    public float selectScale = 1.2f;
    public List<DungenSlot> dungenSlots;


    // Start is called before the first frame update
    void Start()
    {
        RefrashDungenUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectDungen = (selectDungen - 1 + dungenSlots.Count) % dungenSlots.Count;
            RefrashDungenUI();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectDungen = (selectDungen + 1) % dungenSlots.Count;
            RefrashDungenUI();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadDungen();
        }
    }


    private void LoadDungen()
    {
        GameManager.Instance.ChangeScene(dungenSlots[selectDungen].dungenName);
    }

    private void RefrashDungenUI()
    {
        for (int i = 0; i < dungenSlots.Count; ++i)
        {
            var slot = dungenSlots[i];
            slot.transform.localScale = (i == selectDungen) ? Vector2.one * selectScale : Vector2.one;
            slot.isSelected = (i == selectDungen) ? true : false;
        }
    }

    public void ReturnTown()
    {
        GameManager.Instance.ChangeScene("TownScene");
    }
}
