using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class LevelUpOptionDisplay : MonoBehaviour 
{
	public Text _Header;
	public Text _Description;
	public Image _Symbol;

	public void DisplayLevelUpOption (LevelUpBonus _Bonus)
	{
		_Header.text = _Bonus.Name;
		_Description.text = _Bonus.Description;
	}

}
