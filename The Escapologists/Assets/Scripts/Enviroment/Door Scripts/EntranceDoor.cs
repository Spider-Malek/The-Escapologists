using UnityEngine;

public class EntranceDoor : Door
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (timeSystem.CurrentHour >= 10 && timeSystem.CurrentHour <= 22)
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
