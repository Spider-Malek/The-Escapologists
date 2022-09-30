using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Door : MonoBehaviour
{
    [SerializeField]
	protected DoorType Type;
    private SpriteRenderer sr;
    private BoxCollider2D bcol;
	protected TimeSystem timeSystem;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bcol = GetComponent<BoxCollider2D>();
        timeSystem = FindObjectOfType<TimeSystem>();
    }

	protected void Open()
	{
		bcol.isTrigger = true;
		sr.enabled = false;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		bcol.isTrigger = false;
		sr.enabled = true;
	}
}
