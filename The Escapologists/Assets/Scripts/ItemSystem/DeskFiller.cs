using UnityEngine;
using UnityEngine.InputSystem;

public class DeskFiller : MonoBehaviour
{
    [SerializeField]
    private DeskItemSlot[] slots;

    private void Start()
	{
		transform.parent.gameObject.SetActive(false);
	}

    public void Fill(Item[] items,Desk desk)
	{
		for (int i = 0; i < items.Length; i++)
        {
            slots[i].Clear();
            slots[i].currentOpenDesk = desk;
            slots[i].Init(items[i]);
        }
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            transform.parent.gameObject.SetActive(false);
            Time.timeScale = 1;
            PlayerInventory.currentDesk = null;
        }
    }
}
