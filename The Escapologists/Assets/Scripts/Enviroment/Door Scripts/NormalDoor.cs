using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDoor : Door
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Open();
	}
}
