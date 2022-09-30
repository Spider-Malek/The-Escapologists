using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Desk : Inventory, IPointerClickHandler
{
    private DeskFiller filler;
    public Item[] itemstoadd;

    private void Awake()
	{
		foreach (Item item in itemstoadd)
		{
			items.Add(item);
		}
		filler = FindObjectOfType<DeskFiller>();
        OnAdd += OnAddItem;
        OnRemove += OnRemoveItem;
    }

    private void OnAddItem(Item item)
    {
        filler.Fill(items.ToArray(),this);
    }

    private void OnRemoveItem(int index)
	{
		filler.Fill(items.ToArray(), this);
	}


	public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            PlayerInventory.currentDesk = this;
            filler.transform.parent.gameObject.SetActive(true);
			filler.Fill(items.ToArray(), this);
			Time.timeScale = 0;
            Debug.Log("Clicked!", gameObject);
        }
    }
}
