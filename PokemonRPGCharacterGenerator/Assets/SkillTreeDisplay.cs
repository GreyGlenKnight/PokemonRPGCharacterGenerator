using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class SkillTreeDisplay : MonoBehaviour 
{
	public Toggle[] options = new Toggle[12];
	public Text Tree_text;

	public void CheckSelectedBonus (int BonusIndex)
	{
		options [BonusIndex].isOn = true;
	}

	public void DisplayBonusString (string ToDisplay)
	{
//		if (LBonus.Count == 0) 
//		{
////			Debug.Log ("LBONUS 0");
//			return;
//		}
		Tree_text.text = ToDisplay;
	}

}
