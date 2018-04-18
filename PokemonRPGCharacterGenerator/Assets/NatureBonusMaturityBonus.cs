using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureBonusMaturityBonus : MaturityBonus

{
	#region implemented abstract members of MaturityBonus

	public override void ApplyBonus (PokemonClass Pokemon)
	{
		Pokemon.GainNatureBonus ();	
	}

	#endregion



}
