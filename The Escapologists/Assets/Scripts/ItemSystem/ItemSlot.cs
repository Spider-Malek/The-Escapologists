using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image Icon;
    [SerializeField]
    private CanvasGroup Alpha;
    [SerializeField]
    private string SortingLayer;
    private Item HeldItem;
    private Transform Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SetItem(Item item)
    {
        HeldItem = item;
        Icon.sprite = item.Icon;
        Alpha.alpha = 1;
    }

    public void Clear()
    {
        Alpha.alpha = 0;
        HeldItem = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (Player.TryGetComponent<PlayerInventory>(out PlayerInventory playerInventory) && PlayerInventory.currentDesk != null && !PlayerInventory.currentDesk.IsFull())
			{
				PlayerInventory.currentDesk.AddItem(HeldItem);
				playerInventory.RemoveItem(HeldItem);
                return;
            }
            if (HeldItem is Tool tool)
                tool.Select();
            if (HeldItem is Consumable consumable)
                consumable.Consume();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (HeldItem == null)
                return;
            var droppeditem = new GameObject(HeldItem.name);
            droppeditem.transform.position = Vector3Int.RoundToInt(Player.position);
            droppeditem.AddComponent<DroppedItem>().Init(HeldItem, SortingLayer);
            Player.GetComponent<PlayerInventory>().RemoveItem(HeldItem);
            Clear();
		}
    }
}
