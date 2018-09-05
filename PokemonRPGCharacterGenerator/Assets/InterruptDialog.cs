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

	public void DisplayOptionsList (List <ILevelUpOption> _Bonuses)
	{
		if (_Bonuses == null) 
		{
			Debug.Log ("_Bonuses null, probably XP fail");
			return;
		}

		if (_Bonuses.Count == 0) 
		{
			Debug.Log ("Bonuses are 0");
		}

		for (int i = 0; i < _Bonuses.Count; i++)
		{
//			Debug.Log ("Line 28");
			if (_Bonuses [i] == null) 
			{
				Debug.Log ("Null Bonus");
				OptionDisplays [i].gameObject.SetActive (false);
				return;
			}
			OptionDisplays [i].DisplayLevelUpOption (_Bonuses [i]);
		}
	}

    public void DisplayOptionsList (List <IChoosable> _Choices)
    {
        if (_Choices == null)
        {
            Debug.Log("_Choices Null");
            return;
        }

        if (_Choices.Count == 0)
        {
            Debug.Log("Choices are 0");
        }

        for (int i = 0; i < _Choices.Count; i++)
        {
            //          Debug.Log ("Line 28");
            if (_Choices [i] == null)
            {
                Debug.Log("Null Choice");
                OptionDisplays[i].gameObject.SetActive(false);
                return;
            }
            OptionDisplays[i].DisplayLevelUpOption(_Choices[i]);
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