using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BadgeLevelDisplay : MonoBehaviour {

	public Dropdown BLDropDown;
	public string BadgeLevelString;
	public Text BadgeLevelText;
	public Text CurrentLevelText;
	public Text XPText;


	public void UpdateText ()
	{
		BadgeLevelText.text = BadgeLevelString;
	}

	public void UpdateDisplay (Pokemon ToDisplay)
	{
		CurrentLevelText.text = ToDisplay.Level.ToString ();
		XPText.text = ToDisplay.XP.ToString ();
	}
}
