using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppedItem : MonoBehaviour, IPointerClickHandler
{
	private Item droppeditem;

    public void Init(Item item,string SortingLayer)
	{
		droppeditem = item;
		var DISR = gameObject.AddComponent<SpriteRenderer>();
		DISR.sprite = item.Icon;
		DISR.sortingLayerName = SortingLayer;
		DISR.sortingOrder = 2; 
		gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
	}

    public void OnPointerClick(PointerEventData eventData)
    {
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			if (GameObject.FindGameObjectWithTag("Player").TryGetComponent<PlayerInventory>(out PlayerInventory inventory))
			{
				if (!inventory.IsFull())
				{
					inventory.AddItem(droppeditem);
					Destroy(gameObject);
				}
			}
		}
    }
}
