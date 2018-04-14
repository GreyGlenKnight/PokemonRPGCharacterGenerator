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

	public void SelectMe (int intrandnumber1)
	{
		options [intrandnumber1].isOn = true;
	}

	public void RollTheList (List <int> LBonus, int intrandnumber1)
	{
		if (LBonus.Count == 0) 
		{
			Debug.Log ("LBONUS 0");
			return;
		}
		String randomnumber1 = intrandnumber1.ToString ();
		Tree_text.text = randomnumber1;
	}

}
