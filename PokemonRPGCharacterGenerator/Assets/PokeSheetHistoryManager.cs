using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;


public class PokeSheetHistoryManager: MonoBehaviour
{
	
	public List <BonusDisplay> _BonusHistory = new List <BonusDisplay>();

	public PokeSheetHistoryManager ()
	{
	}
		
	public void ChangeDisplay (List <IHistoryItem> _History)
	{
		for (int i = 0; i < _History.Count; i++) 
		{
			_BonusHistory [i].ChangeDisplay (_History [i]);
		}
	}



}