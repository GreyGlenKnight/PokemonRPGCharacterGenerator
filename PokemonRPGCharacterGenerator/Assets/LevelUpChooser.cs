using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpChooser : MonoBehaviour 
{

	List <LevelUpBonus> BonusesToDisplay = new List <LevelUpBonus>();
	//May not need new list?
	//Need references to the UI resources


	public void DisplayBonuses (List <LevelUpBonus> _LevelUpBonuses)
	{
		BonusesToDisplay = _LevelUpBonuses;

	}
}
