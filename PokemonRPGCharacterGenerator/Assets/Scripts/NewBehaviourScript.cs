using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeSkillMaturityBonus : IMaturityBonus

{
	#region implemented abstract members of MaturityBonus
	public void ApplyBonus (PokemonClass Pokemon)
	{
		Pokemon.PokemonTreeSwap ();
	}
	#endregion
}
