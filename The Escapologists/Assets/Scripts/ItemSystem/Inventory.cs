using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    protected List<Item> items;
    [SerializeField]
    private int Capacity;
    public Action<Item> OnAdd;
    public Action<int> OnRemove;

    public Inventory()
    {
        items = new List<Item>();
    }

	public void AddItem(Item item)
	{
        if (items.Count == Capacity)
        {
            Debug.LogWarning("Capacity Reached!");
            return;
        }
		items.Add(item);
        OnAdd.Invoke(item);
	}

    public void RemoveItem(Item item)
    {
        if (Contains(item))
		{
            int index = items.FindIndex(x => x.Equals(item));
            if (index >= 1)
                OnRemove.Invoke(index);
			items.Remove(item);
        }
    }

	public Item GetItem(string name) => items.Find(x => x.name == name);

    public Item[] GetItems() => items.ToArray();

    public bool Contains(Item item) => items.Contains(item);

    public int Count() => items.Count;

    public bool IsFull() => items.Count == Capacity;

}
