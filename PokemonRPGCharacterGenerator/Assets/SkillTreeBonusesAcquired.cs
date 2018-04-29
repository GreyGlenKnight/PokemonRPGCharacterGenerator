using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeBonusesAcquired 

{
	public List <BonusAtIndex> BonusesRemaining = new List <BonusAtIndex> ();

	public SkillTreeBonusesAcquired ()
	{
		for (int i = 0; i < 12; i++)
		{
			BonusesRemaining.Add ((BonusAtIndex) i);
		}

	}



}
