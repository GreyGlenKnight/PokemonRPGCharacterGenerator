using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class InterruptDialog : MonoBehaviour 
{
	
	public List <OptionChooserDisplay> OptionDisplays = new List <OptionChooserDisplay> ();
//	public List <GameObject> LevelUpDisplayObjects = new List <GameObject> ();

	//Use Events, hook Display up to class to drive data, probably non monobehavior
	//NewTreeManager.
	//use the hooks via InterruptDialogue.
	//When Data changes, use event to call changes
	//Pass in Ioption, Tree.
	//use them as input parameters to drive a function
	//Don't use New or Instantiate if possible outside of constructors.
	//Set active or inactive depending on bonus type.

	public void DisplayOptionsList (List <ILevelUpOption> _Bonuses, List <SkillTreeData> _Trees)
	{
		if (_Bonuses.Count == 0 || _Trees.Count == 0) 
		{
			Debug.Log ("Bonuses or trees are 0");
		}

		if (_Bonuses.Count != _Trees.Count) 
		{
			throw new InvalidBonusesException (_Bonuses.Count, _Trees.Count);
		}

		for (int i = 0; i < _Bonuses.Count; i++)
		{
			Debug.Log ("Line 28");

			OptionDisplays [i].DisplayLevelUpOption (_Bonuses [i], _Trees [i]);

			if (_Trees [i] == null) 
			{
				Debug.Log ("Null Tree");
				OptionDisplays [i].gameObject.SetActive (false);
				return;
			}

			if (_Bonuses [i] == null) 
			{
				Debug.Log ("Null Bonus");
				OptionDisplays [i].gameObject.SetActive (false);
				return;
			}
		}
	}
}

public class InvalidBonusesException : Exception
{

	public string BonusesLength;
	public string TreesLength;

	public InvalidBonusesException (): base ("Greg Was Right, Bonuses > Trees, you suck.")
	{
		
	}

	public InvalidBonusesException (int Bonuses, int Trees): base ("Greg Was Right, Bonuses > Trees, you suck.")
	{
		BonusesLength = Bonuses.ToString();
		TreesLength = Trees.ToString();
	}
}