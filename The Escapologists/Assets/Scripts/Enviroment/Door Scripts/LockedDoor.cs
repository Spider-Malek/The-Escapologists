using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Door
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.TryGetComponent(out PlayerInventory inventory))
		{
			foreach (Item item in inventory.GetItems())
			{
				if (item is Key key)
					if (key.KeyType == Type)
						Open();
			}
		}
	}
}
