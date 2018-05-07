using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonClass 
{
	public int Maturity;
	public int Level;
	public SkillTrees _SkillTrees;
	//	public List <SkillTree> SkillTrees = new List <SkillTree> (12);
	public bool IsShiny;
	public int ShinyRNG;

	public float Rate = 3.0f;
	public float CurrentMaturity;
	public float TotalBaseStats = 20.0f;
	public int CurrentMaturityInt;
	public int MaturityBonus = 0;

	public PokemonSheetDisplay _PokemonSheetDisplay;
	//_HeldItem;

	public List<SkillTreeData> _SkillTreeData = new List<SkillTreeData>();
	public List <SkillTreeBonusesAcquired> _BonusesRemaining = new List <SkillTreeBonusesAcquired>();

    public PokemonClass ()
    {
			ShinyRNG = Random.Range (0, 4096);
			Debug.Log (ShinyRNG);

			if (ShinyRNG == 0) 
			{
				IsShiny = true;
				Debug.Log ("Holy Shit, a Shiny!");
			//Will there be only one display class?
			//I shouldn't have shiny bool in the display class,
			//Use a function to set that.
			}
		
        Level = 0;
        _SkillTreeData.Add(new SkillTreeData("Imp", SkillTreeTier.Tier0));
        _SkillTreeData.Add(new SkillTreeData("Drake", SkillTreeTier.Tier1));
        _SkillTreeData.Add(new SkillTreeData("Fire Body 1", SkillTreeTier.Tier1));
        _SkillTreeData.Add(new SkillTreeData("Claw 1", SkillTreeTier.Tier1));
        _SkillTreeData.Add(new SkillTreeData("Claw 2", SkillTreeTier.Tier2));
        _SkillTreeData.Add(new SkillTreeData("Beast", SkillTreeTier.Tier1));
        _SkillTreeData.Add(new SkillTreeData("Fire Body 2", SkillTreeTier.Tier2));
        _SkillTreeData.Add(new SkillTreeData("Pyromancer 1", SkillTreeTier.Tier1));
        _SkillTreeData.Add(new SkillTreeData("Pureblood 2", SkillTreeTier.Tier2));
        _SkillTreeData.Add(new SkillTreeData("Pureblood 3", SkillTreeTier.Tier3));
        _SkillTreeData.Add(new SkillTreeData("Fire Body 3", SkillTreeTier.Tier3));
        _SkillTreeData.Add(new SkillTreeData("Acrobatics 1", SkillTreeTier.Tier1));

		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
		_BonusesRemaining.Add (new SkillTreeBonusesAcquired ());
    }

	public void Evolve ()
	{
		if (TotalBaseStats > 6.0f) {Rate = 1.0f;}
		if (TotalBaseStats > 11.0f) {Rate = 1.5f;}
		if (TotalBaseStats > 13.5f) {Rate = 2.0f;}
		if (TotalBaseStats > 16.0f) {Rate = 2.5f;}
		if (TotalBaseStats > 18.5f) {Rate = 3.0f;}
		if (TotalBaseStats > 21.0f) {Rate = 3.5f;}
		if (TotalBaseStats > 23.5f) {Rate = 4.0f;}

		CurrentMaturity = ((Level / Rate) + MaturityBonus);
		CurrentMaturityInt = Mathf.FloorToInt (CurrentMaturity);
	}



    public void LevelUp ()
	{
		Level++;
	}

	public void PokemonTreeSwap ()
	{
		SkillTreeData TempData2 = _SkillTreeData [4];
		SkillTreeData TempData = _SkillTreeData [0];
		SkillTreeBonusesAcquired TempBonuses = _BonusesRemaining [0];
		SkillTreeBonusesAcquired TempBonuses2 = _BonusesRemaining [4];


//		Debug.Log (TempData.Name);
//		Debug.Log (TempData2.Name);
		_SkillTreeData [0] = TempData2;
		_SkillTreeData [4] = TempData;
		_BonusesRemaining [0] = TempBonuses2;
		_BonusesRemaining [4] = TempBonuses;


//		TempData = _SkillTreeData [4];
	}

	public void GainActiveTreeBonus ()
	{
		Debug.Log ("Gained Active Tree :"+Maturity);
	}

	public void GainNatureBonus ()
	{
		Debug.Log ("Gained Nature :"+Maturity);
	}

	public void GainAbilitySlot ()
	{
		Debug.Log ("Gained Ability Slot :"+Maturity);

	}

	public void GainSTABBonus ()
	{
		Debug.Log ("Gained STAB :"+Maturity);
	}

	public void ApplyMaturityBonus (IMaturityBonus MBonus, int maturity)
	{
		Maturity = maturity;
		if (MBonus == null) 
		{
			return;
		}
			MBonus.ApplyBonus (this);	
	}


}
