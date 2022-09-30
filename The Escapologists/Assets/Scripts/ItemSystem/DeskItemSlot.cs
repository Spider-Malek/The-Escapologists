using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeskItemSlot : MonoBehaviour, IPointerClickHandler
{
    public Desk currentOpenDesk;
    private Image icon;
    private CanvasGroup group;
    private Item heldItem;

    private void Awake()
    {
        icon = GetComponent<Image>();
        group = GetComponent<CanvasGroup>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (heldItem != null || !FindObjectOfType<PlayerInventory>().IsFull())
		{
			FindObjectOfType<PlayerInventory>().AddItem(heldItem);
			currentOpenDesk.RemoveItem(heldItem);
            Clear();
        }
    }

    public void Init(Item item)
    {
        icon.sprite = item.Icon;
        heldItem = item;
        group.alpha = 1;
    }

    public void Clear()
	{
		heldItem = null;
		group.alpha = 0;
	}
}
