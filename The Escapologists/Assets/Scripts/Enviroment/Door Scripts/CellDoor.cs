using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDoor : Door
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (timeSystem.CurrentHour >= 8 && timeSystem.CurrentHour <= 22)
			Open();
		else
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
}
