using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlotMaturityBonus : IMaturityBonus

{
	#region implemented abstract members of MaturityBonus
	public void ApplyBonus (PokemonClass Pokemon)
	{
		Pokemon.GainAbilitySlot ();
	}
	#endregion
}

