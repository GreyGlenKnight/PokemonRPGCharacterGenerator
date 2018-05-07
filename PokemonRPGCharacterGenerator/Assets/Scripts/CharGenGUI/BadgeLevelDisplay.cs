using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BadgeLevelDisplay : MonoBehaviour {

	public Dropdown BLDropDown;
	public string BadgeLevelString;
	public string CurrentLevelString;
	public Text BadgeLevelText;
	public Text CurrentLevelText;

	public void UpdateText ()
	{
	BadgeLevelText.text = BadgeLevelString;
//	CurrentLevelString = GameManager.instance.CurrentPokemon.Level.ToString ();
//	CurrentLevelText.text = CurrentLevelString;
	}

	public void UpdateDisplay (int Level, string CurrentLevelString)
	{
	CurrentLevelString = Level.ToString ();
	CurrentLevelText.text = CurrentLevelString;
	}
}
