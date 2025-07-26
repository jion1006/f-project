using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragManager : MonoBehaviour
{
    public static DragManager Instance;

    public GameObject dragUI;
    public Image dragImage;
    public ItemSlotUI originSlot;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);

        dragImage = dragUI.GetComponent<Image>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void StartDrag(ItemSlotUI prevSlot)
    {
        originSlot = prevSlot;
        dragUI.SetActive(true);
        dragImage.sprite = prevSlot.icon.sprite;
    }

    public void UpdateDrag(Vector2 mousePos)
    {
        dragUI.transform.position = mousePos;
    }

    public void EndDrag()
    {
        dragUI.SetActive(false);
        originSlot = null;
    }

    public void TrySwapSlot(ItemSlotUI targetSlot)
    {
        if (originSlot == null || targetSlot == null || originSlot == targetSlot)
            return;

        var temp = originSlot.currentItem;
        originSlot.SetItem(targetSlot.currentItem);
        targetSlot.SetItem(temp);

    }
}
