using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLevelMaturityBonus : MaturityBonus
{
	#region implemented abstract members of MaturityBonus

	public override void ApplyBonus (PokemonClass Pokemon)
	{
		Pokemon.LevelUp ();
	}

	#endregion



}
