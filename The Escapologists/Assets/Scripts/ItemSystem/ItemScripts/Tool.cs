using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : Item
{
	public int Duriability = 100;
	public int DuriablityLoss = 10;
	public ToolType toolType;

	public void Select()
	{
		PlayerToolUsage.CurrentSelectedTool = this;
	}
}
