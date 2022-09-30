using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    [SerializeField]
    private ItemSlot[] slots;
    [SerializeField]
    private Item testItem;
    public static Desk currentDesk;

    private void Start()
    {
        OnAdd += OnItemAdd;
        OnRemove += OnItemRemove;

		AddItem(testItem);
	}

    private void OnItemAdd(Item item)
    {
        slots[Count() - 1].SetItem(item);
    }

    private void OnItemRemove(int index)
    {
        slots[index].Clear();
    }
}
