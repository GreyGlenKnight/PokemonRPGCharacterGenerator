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

	//Use Events, hook Display up to class to drive data, probably non monobehavior
	//NewTreeManager.
	//use the hooks via InterruptDialogue.
	//When Data changes, use event to call changes
	//Pass in Ioption, Tree.
	//use them as input parameters to drive a function
	//Don't use New or Instantiate if possible outside of constructors.
	//Set active or inactive depending on bonus type.

	public void DisplayOptionsList (List <IOption> _Bonuses, List <SkillTreeData> _Trees)
	{

		for (int i = 0; i < OptionDisplays.Count; i++)
		{
			OptionDisplays [i].DisplayLevelUpOption (_Bonuses [i], _Trees [i]);


			if (_Bonuses [i] == null) 
			{
				OptionDisplays [i].gameObject.SetActive (false);
			}
		}
	}


}
