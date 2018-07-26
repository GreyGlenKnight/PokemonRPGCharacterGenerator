using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public enum ElementTypes
{
	Nothing,
	Normal,
	Fire,
	Water,
	Electric,
	Grass,
	Ice,
	Fighting,
	Poison,
	Ground,
	Flying,
	Psychic,
	Bug,
	Rock,
	Ghost,
	Dragon,
	Dark,
	Steel,
	Fairy
}

public enum Gender
{
	Genderless,
	Male,
	Female
}

public class PokemonEventArgs : EventArgs
{
	public Pokemon _Pokemon;

	public PokemonEventArgs (Pokemon _ThisPokemon)
	{
		_Pokemon = _ThisPokemon;	
	}
}

public class LevelUpEventArgs : PokemonEventArgs
{
	public ILevelUpOption _Option;

	public LevelUpEventArgs (Pokemon _ThisPokemon, ILevelUpOption ThisOption) : base (_ThisPokemon)
	{
		_Option = ThisOption;
	}
}

// Typecast notes

//		LevelUpBonus bonus = (LevelUpBonus)_Option;
//		LevelUpBonus bonus2 = _Option as LevelUpBonus;
//		if (bonus2 != null) 
//		{	
//		}
//
//		if (_Option is LevelUpBonus) 
//		{
//		}
//
//		object o = _Option;
//		LevelUpBonus bonus4 = (LevelUpBonus)o;



public class Pokemon

{

	//Skills + HM abilities
	//Affection
	public string NickName;
	public string TrainerName;
	public int Level = 0;
	public int Maturity; //This represents the relevant total maturity
	public int Rate; //Rate int is essentially doubled
	public int XP;
	public int CurrentDamage;
	public int CurrentStrainLost;
	public int ShinyRNG;
	public bool IsShiny;
	public Gender _Gender;
	private Breed _Breed;
	public EnduranceStat NumberOfEnduranceBonuses = new EnduranceStat (0);
	public AttackStat NumberOfAttackBonuses = new AttackStat (0);
	public DefenseStat NumberOfDefenseBonuses = new DefenseStat (0);
	public SpecialAttackStat NumberOfSpecialAttackBonuses = new SpecialAttackStat (0);
	public SpecialDefenseStat NumberOfSpecialDefenseBonuses = new SpecialDefenseStat (0);
	public SpeedStat NumberOfSpeedBonuses = new SpeedStat (0);


	public String HeldItem = "";

	public List <Technique> _TechniquesKnown = new List <Technique> ();
	public List <Technique> _TechniquesActive = new List <Technique> ();
	public List <TechniqueModifier> _TechniqueModifiersKnown = new List <TechniqueModifier> ();
	public List <Ability> _AbilitiesKnown = new List <Ability> ();

	public List <IHistoryItem> BonusHistory = new List <IHistoryItem> ();
	public List <LevelUpBonus> LevelUpBonuses = new List <LevelUpBonus> ();
	public List <MaturityBonus> MaturityBonuses = new List <MaturityBonus> ();
	public List <SkillTree> _SkillTrees = new List <SkillTree>();

	public List <ElementTypesSkill> _ElementTypesSkill = new List <ElementTypesSkill> ();



//	public List <SkillTree> _Tier1SkillTrees 
//
//	public List <SkillTree> _Tier2SkillTrees 
//	public List <SkillTree> _Tier3SkillTrees 

//	public List <SkillTreeBonusesAcquired> _BonusesRemaining = new List <SkillTreeBonusesAcquired>();

	public int TotalBaseStats = 20;
//	{get {return (MyStat)  }}

	public event EventHandler <LevelUpEventArgs> OnChooseLevelUpBonus;
	public event EventHandler <PokemonEventArgs> OnBreakTree;
	public event EventHandler <PokemonEventArgs> OnActivateTree;
	public event EventHandler <PokemonEventArgs> OnTradeSkill;
	public event EventHandler <PokemonEventArgs> OnAddXP;
	public event EventHandler <PokemonEventArgs> OnSpendXP;
	public event EventHandler <PokemonEventArgs> OnIncreaseLevel;
	public event EventHandler <PokemonEventArgs> OnGainTechnique;
	public event EventHandler <PokemonEventArgs> OnGainTechniqueModifier;
	public event EventHandler <PokemonEventArgs> OnGainAbility;
	public event EventHandler <PokemonEventArgs> OnGainStatUp;
	public event EventHandler <PokemonEventArgs> OnGainElementTypesSkillUp;
	public event EventHandler <PokemonEventArgs> OnGainMaturityPlusBonus;
	public event EventHandler <PokemonEventArgs> OnGainEnduranceBonus;
	public event EventHandler <PokemonEventArgs> OnGainNatureBonus;
	public event EventHandler <PokemonEventArgs> OnGainAbilitySlot;
	public event EventHandler <PokemonEventArgs> OnGainSTABBonus;
	public event EventHandler <PokemonEventArgs> OnGainSpecialTrainingBonus;
	public event EventHandler <PokemonEventArgs> OnGainEnhancerSlotBonus;


	public Breed ThisBreed 
	{		
		get {return _Breed;}
	}

	public EnduranceStat Endurance 
	{		
		get {return (EnduranceStat) NumberOfEnduranceBonuses.AddValues (_Breed.BaseEndurance);}
	}

	public AttackStat Attack 
	{		
		get {return (AttackStat) NumberOfAttackBonuses.AddValues (_Breed.BaseAttack);}
	}

	public DefenseStat Defense 
	{		
		get {return (DefenseStat) NumberOfDefenseBonuses.AddValues (_Breed.BaseDefense);}
	}
		
	public SpecialAttackStat SpecialAttack 
	{		
		get {return (SpecialAttackStat) NumberOfSpecialAttackBonuses.AddValues (_Breed.BaseSpecialAttack);}
	}

	public SpecialDefenseStat SpecialDefense 
	{		
		get {return (SpecialDefenseStat) NumberOfSpecialDefenseBonuses.AddValues (_Breed.BaseSpecialDefense);}
	}

	public SpeedStat Speed 
	{		
		get {return (SpeedStat) NumberOfSpeedBonuses.AddValues (_Breed.BaseSpeed);}
	}

	public int MaxHP 
	{		
		get {return ((Endurance.RawValue + Defense.RoundedValue) * 2);}
	}

	public int MaxStrain 
	{		
		get {return ((Endurance.RawValue + SpecialDefense.RoundedValue) * 2);}
	}
		
	public ElementTypes Type1
	{
		get 
		{
			return _Breed.Type1;
		}
	}
	public ElementTypes Type2
	{
		get 
		{
			return _Breed.Type2;
		}
	}

	public List <SkillTree> GetSkillTreesForTier (SkillTreeTier _Tier)
	{
		List <SkillTree> Temp = new List <SkillTree> ();

		for (int i = 0; i < _SkillTrees.Count; i++) 
		{
			if (_SkillTrees [i].Tier == _Tier) 
			{
				Temp.Add (_SkillTrees [i]);
			}
		}
		return Temp;
	}

	public Pokemon ()
	{
		_Breed = new Breed (ElementTypes.Nothing, ElementTypes.Nothing);
		InitPokemon ();
	}

	public Pokemon (Pokemon.Breed breed)
	{
		_Breed = breed;
		InitPokemon ();
	}
		
	public Pokemon (Pokemon _Pokemon)
	{
		_Breed = new Breed (ElementTypes.Nothing, ElementTypes.Nothing);
		InitPokemon ();
	}

	private void InitPokemon ()
	{
		ShinyRNG = UnityEngine.Random.Range (0, 4096);
		Debug.Log (ShinyRNG);

		if (ShinyRNG == 0) 
		{
			IsShiny = true;
			Debug.Log ("Holy Shit, a Shiny!");
		}

		_SkillTrees.Add (new SkillTree("Imp", SkillTreeTier.Tier0));
		_SkillTrees.Add (new SkillTree("Drake", SkillTreeTier.Tier1));
		_SkillTrees.Add (new SkillTree("Fire Body 1", SkillTreeTier.Tier1));
		_SkillTrees.Add (new SkillTree("Claw 1", SkillTreeTier.Tier1));
		_SkillTrees.Add (new SkillTree("Beast", SkillTreeTier.Tier1));
		_SkillTrees.Add (new SkillTree("Pyromancer 1", SkillTreeTier.Tier1));

		_SkillTrees.Add (new SkillTree("Claw 2", SkillTreeTier.Tier2));
		_SkillTrees.Add (new SkillTree("Fire Body 2", SkillTreeTier.Tier2));
		_SkillTrees.Add (new SkillTree("Pureblood 2", SkillTreeTier.Tier2));

		_SkillTrees.Add (new SkillTree("Pureblood 3", SkillTreeTier.Tier3));
		_SkillTrees.Add (new SkillTree("Fire Body 3", SkillTreeTier.Tier3));
		_SkillTrees.Add (new SkillTree("Acrobatics 1", SkillTreeTier.Tier1));

		ApplyMaturityBonus (MaturityStatic.GetMaturityBonuses (0), 0);
	}

//	private 

	public void AssignNameFields ()
	{
	}


	private SkillTree AutoChooseTree (SkillTreeTier _Tier)
	{
		List <SkillTree> Temp = new List <SkillTree> ();
		SkillTree ToReturn;

		switch (_Tier)
		{	
		case SkillTreeTier.Tier0 | SkillTreeTier.Tier1:
			Temp.Concat (GetSkillTreesForTier (SkillTreeTier.Tier0));
			Temp.Concat (GetSkillTreesForTier (SkillTreeTier.Tier1));
			Temp.Shuffle ();
			ToReturn = Temp [0];
			return ToReturn;
		case SkillTreeTier.Tier2:
			Temp.Concat (GetSkillTreesForTier (SkillTreeTier.Tier2));
			Temp.Shuffle ();
			ToReturn = Temp [0];
			return ToReturn;
		case SkillTreeTier.Tier3:
			Temp.Concat (GetSkillTreesForTier (SkillTreeTier.Tier3));
			Temp.Shuffle ();
			ToReturn = Temp [0];
			return ToReturn;
		default:
			Debug.Log ("This pokemon has gone Super Saiyan" + _Tier);
			return null;
		}
	}

	public void AddXP()
	{
		if (XP < 200) 
		{
			XP++;
			XP++;
			if (OnAddXP != null) 
			{
				OnAddXP (this, new PokemonEventArgs (this));
			}		
		}
	}

	public void SpendXP ()
	{
		XP--;
		XP--;
		if (OnSpendXP != null) 
		{
			OnSpendXP (this, 
				new PokemonEventArgs (this));
		}	
	}


	public void MaturityIncrease ()
	{
		Maturity = ((Level * 2) / Rate);
	}

	public void MaturityBonusCheck ()
	{
		int TempMaturity = Maturity;
		IncreaseLevel ();
		MaturityIncrease ();
		if (TempMaturity != Maturity) 
		{				
			ApplyMaturityBonus (MaturityStatic.GetMaturityBonuses (Maturity), Maturity);
		} 
	}

	public void IncreaseLevel ()
	{
		Level++;
		if (OnIncreaseLevel != null) 
		{
			OnIncreaseLevel (this, new PokemonEventArgs (this));
		}	
	}

	public void LevelUp (LevelUpBonus _LevelUpBonus)
	{
		if (OnChooseLevelUpBonus != null) 
		{
			LevelUpEventArgs args = new LevelUpEventArgs (this, 
				_LevelUpBonus);
			OnChooseLevelUpBonus (this, args); 
		}

		ApplyLevelBonus (_LevelUpBonus);
		MaturityBonusCheck ();
	}

	public void ApplyLevelBonus (LevelUpBonus _Bonus)
	{
		if (_Bonus == null)
		{
			return;
		}
		_Bonus.ApplyLevelBonus(this);
		BonusHistory.Add (_Bonus);
	}

	public void ApplyMaturityBonus (List<MaturityBonus> MBonus, int maturity)
	{
	     if (MBonus == null)
	     {
			return;
	     }

	     for (int i = 0; i < MBonus.Count; i++)
	     {
			MBonus[i].ApplyMaturityBonus(this);
			BonusHistory.Add (MBonus[i]);
	     }
	}

	public void SwapTrees (SkillTreeTier Tier)
	{
//		Debug.Log (Tier.ToString());
		_SkillTrees [0].ChangeTreeState (SkillTreeState.Inactive);
		_SkillTrees [3].ChangeTreeState (SkillTreeState.Active);
		SkillTree TempData2 = _SkillTrees [3];
		SkillTree TempData = _SkillTrees [0];
		_SkillTrees [0] = TempData2;
		_SkillTrees [3] = TempData;
		if (OnTradeSkill != null) 
		{
			OnTradeSkill (this, new PokemonEventArgs (this));
//			Debug.Log ("");
		}			
//		GameManager.instance.Refresh();
	}

	public void GainTechnique (Technique _Technique)
	{
		Debug.Log ("Gain Technique: TODO");

		_TechniquesKnown.Add (_Technique);

		if (OnGainTechnique != null) 
		{
			OnGainTechnique (this, new PokemonEventArgs (this));
		}
	}

	public void GainTechniqueModifier (TechniqueModifier _TechniqueModifier)
	{
		_TechniqueModifiersKnown.Add (_TechniqueModifier);

		if (OnGainTechniqueModifier != null) 
		{
			OnGainTechniqueModifier (this, new PokemonEventArgs (this));
		}
	}

	public void GainAbility (Ability _Ability)
	{
		_AbilitiesKnown.Add (_Ability);

		if (OnGainAbility != null) 
		{
			OnGainAbility (this, new PokemonEventArgs (this));
		}	
	}

	public void GainStatUp (MyStat _Stat)
	{
		if (_Stat is AttackStat) 
		{
			NumberOfAttackBonuses.RawValue++;
		}
		if (_Stat is DefenseStat) 
		{
			NumberOfDefenseBonuses.RawValue++;
		}
		if (_Stat is SpecialAttackStat) 
		{
			NumberOfSpecialAttackBonuses.RawValue++;
		}
		if (_Stat is SpecialDefenseStat) 
		{
			NumberOfSpecialDefenseBonuses.RawValue++;
		}
		if (_Stat is SpeedStat) 
		{
			NumberOfSpeedBonuses.RawValue++;
		}
		if (OnGainStatUp != null) 
		{
			OnGainStatUp (this, new PokemonEventArgs (this));
		}	
	}

	public void GainElementTypesSkillUp (List <ElementTypesSkill> _SkillsToAdd)
	{
		for (int i = 0; i < _SkillsToAdd.Count; i++) 
		{
			_ElementTypesSkill.Add (_SkillsToAdd [i]);
		}

		if (OnGainElementTypesSkillUp != null) 
		{
			OnGainElementTypesSkillUp (this, new PokemonEventArgs (this));
		}	
	}

	public void GainMaturityPlusBonus ()
	{
		MaturityBonusCheck ();
		Maturity++;

		if (OnGainMaturityPlusBonus != null) 
		{
			OnGainMaturityPlusBonus (this, new PokemonEventArgs (this));
		}	
	}

	public void GainBonusLevel ()
	{
		AddXP ();
		//AddXP will throw event itself
		Debug.Log("Gained Bonus Level :"+Maturity);
	}

	public void GainEnduranceBonus (MyStat _Stat)
	{
		NumberOfEnduranceBonuses.RawValue++;
		if (OnGainEnduranceBonus != null) 
		{
			OnGainEnduranceBonus (this, new PokemonEventArgs (this));
		}	
	}

	public void GainBreakTree (SkillTreeTier _Tier)
	{
		UnlockTrees (_Tier);
		//UnlockTrees will throw event
		Debug.Log ("Gained Break Tree :" + Maturity);
	}

	public void GainActiveTreeBonus (int TreeSlot)
	{
		ActivateTrees (TreeSlot);
		//ActivateTrees will throw event
		Debug.Log ("Gained Active Tree :"+Maturity);
	}

	public void GainNatureBonus ()
	{
		//Need a selection dialog
		Debug.Log ("Gained Nature :"+Maturity);
		if (OnGainNatureBonus != null) 
		{
			OnGainNatureBonus (this, new PokemonEventArgs (this));
		}	
	}

	public void GainAbilitySlot ()
	{
		//Need poke sheet display
		Debug.Log ("Gained Ability Slot :"+Maturity);
		if (OnGainAbilitySlot != null) 
		{
			OnGainAbilitySlot (this, new PokemonEventArgs (this));
		}	
	}

	public void GainSTABBonus ()
	{
		//Need Skills
		Debug.Log ("Gained STAB :"+Maturity);
		if (OnGainSTABBonus != null) 
		{
			OnGainSTABBonus (this, new PokemonEventArgs (this));
		}	
	}

	public void GainSpecialTrainingBonus ()
	{
		//Need Skills
		Debug.Log ("Gained Special Training :"+Maturity);
		if (OnGainSpecialTrainingBonus != null) 
		{
			OnGainSpecialTrainingBonus (this, new PokemonEventArgs (this));
		}	
	}

	public void GainEnhancerSlotBonus ()
	{
		//Need Skills
		Debug.Log ("Enhancer Slot :"+Maturity);
		if (OnGainEnhancerSlotBonus != null) 
		{
			OnGainEnhancerSlotBonus (this, new PokemonEventArgs (this));
		}	
	}
		
	public void UnlockTrees (SkillTreeTier _Tier)
	{
//		SkillTree TreeToAdd = AutoChooseTree (_Tier);
//		_SkillTrees.Add (TreeToAdd);

		for (int i = 0; i < _SkillTrees.Count; i++) 
		{
			if (_SkillTrees [i].CurrentState == SkillTreeState.Locked) 
			{
				_SkillTrees [i].ChangeTreeState (SkillTreeState.Inactive);

				if (OnBreakTree != null) 
				{
					OnBreakTree (this, new PokemonEventArgs (this));
//					Debug.Log (i);
				}						
				return;
			}
		}
	}

		public void ActivateTrees (int TreeSlot)
		{
		_SkillTrees [TreeSlot].ChangeTreeState (SkillTreeState.Active);
		if (OnActivateTree != null)
		{
			OnActivateTree (this, new PokemonEventArgs(this));
		}
	}

	public List <ILevelUpOption> RollOnTrees ()
	{
		if (XP < 2) 
		{
			Debug.Log ("XP Spend Fail");
			return null;
		}

		if (GameManager.instance._SelectionState == SelectionState.Select) 
		{
			Debug.Log ("Selection State is Select");
			return null;
		}

		SpendXP ();
		GameManager.instance._SelectionState = SelectionState.Select;

		List <SkillTree> TreesToRoll = new List <SkillTree> ();

		for (int i = 0; i < _SkillTrees.Count; i++) 
		{
			SkillTree Temp = _SkillTrees [i].GetTreeIfActive ();
			if (Temp != null) 
			{
				TreesToRoll.Add (_SkillTrees [i].GetTreeIfActive ());
			}
		}

		List <ILevelUpOption> TempOptions = new List <ILevelUpOption> ();

		for (int i = 0; i < TreesToRoll.Count; i++) 
		{
			if (TreesToRoll [i].GetRemainingBonuses ().Count > 0) 
			{
				TempOptions.Add (TreesToRoll [i].GetRandomAvailableBonus ());
			}
		}
		Debug.Log (TempOptions.Count());
//		Debug.Log (TempOptions [0].ToString());

		return TempOptions;
	}

	public class Breed 
	{
		public virtual ElementTypes Type1 {get{return _Type1;}set {_Type1 = value; }}
		public virtual ElementTypes Type2 {get{return _Type2;}set {_Type2 = value; }}
		public string BreedName; // May be unnecessary
		public EnduranceStat BaseEndurance = new EnduranceStat (0);
		public AttackStat BaseAttack = new AttackStat (0);
		public DefenseStat BaseDefense = new DefenseStat (0);
		public SpecialAttackStat BaseSpecialAttack = new SpecialAttackStat (0);
		public SpecialDefenseStat BaseSpecialDefense = new SpecialDefenseStat (0);
		public SpeedStat BaseSpeed = new SpeedStat (0);

		private ElementTypes _Type1 = ElementTypes.Nothing;
		private ElementTypes _Type2 = ElementTypes.Nothing;

		public Breed ()
		{
		}

		public Breed (ElementTypes type1, ElementTypes type2)
	
		{
			_Type1 = type1;
			_Type2 = type2;
		}
	}
}
