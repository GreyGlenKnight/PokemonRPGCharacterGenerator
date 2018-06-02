using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;


public class PokeSheetHistoryManager: MonoBehaviour
{
	
	public List <BonusDisplay> _BonusHistory = new List <BonusDisplay>();
	public BonusDisplay DisplayPrefab;

	public PokeSheetHistoryManager ()
	{
	}
		
	public void ChangeDisplay (Pokemon _Pokemon)
	{
		for (int i = 0; i < _BonusHistory.Count; i++) 
		{Destroy (_BonusHistory [i].gameObject);}

		_BonusHistory.Clear ();

		for (int i = 0; i < _Pokemon.BonusHistory.Count; i++) 
		{
			BonusDisplay _Display = (BonusDisplay) Instantiate (DisplayPrefab, this.transform);
			_BonusHistory.Add (_Display);
			_Display.ChangeDisplay (_Pokemon.BonusHistory [i]);
//s			Debug.Log ("");
		}
	}



}