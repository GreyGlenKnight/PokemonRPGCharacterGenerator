using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STABBonusMaturityBonus : MaturityBonus

{
	#region implemented abstract members of MaturityBonus
	public override void ApplyBonus (PokemonClass Pokemon)
	{
		Pokemon.GainSTABBonus ();
	}
	#endregion
}