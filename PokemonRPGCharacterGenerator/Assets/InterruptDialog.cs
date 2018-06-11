using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class InterruptDialog : MonoBehaviour 
{
	
	public List <LevelUpOptionDisplay> OptionDisplays = new List <LevelUpOptionDisplay> ();
//	public List <GameObject> LevelUpDisplayObjects = new List <GameObject> ();

	public void DisplayOptions (List <LevelUpBonus> _Bonuses)
	{
		for (int i = 0; i < OptionDisplays.Count; i++)
		{
			OptionDisplays [i].DisplayLevelUpOption (_Bonuses [i]);
			if (_Bonuses [i] == null) 
			{
				OptionDisplays [i].gameObject.SetActive (false);
			}
		}
	}


}
