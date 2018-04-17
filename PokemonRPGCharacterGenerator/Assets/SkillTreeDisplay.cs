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
	public Image TreeBG;
	public Color Tier0Color = Color.gray;
	public Color Tier1Color = Color.cyan;
	public Color Tier2Color = Color.green;
	public Color Tier3Color = Color.yellow;
	public Color LockTreeColor = Color.clear;




	public void TreeColorUpdate ()
	{
		Debug.Log ("Color Update on Tree");
		TreeBG.color = LockTreeColor;
//					TreeBG.color = Tier3Color;

//		{
//			TreeBG.color = Tier0Color;
//		}
//
//		{
//			TreeBG.color = Tier1Color;
//		}
//
//		{
//			TreeBG.color = Tier2Color;
//		}
//
//		{
//			TreeBG.color = Tier3Color;
//		}
	}

	public void CheckSelectedBonus (int BonusIndex)
	{
		options [BonusIndex].isOn = true;
	}

	public void DisplayBonusString (string ToDisplay)
	{
		Tree_text.text = ToDisplay;
	}

	void Awake ()
	{
//		TreeColorUpdate ();
	}
}
