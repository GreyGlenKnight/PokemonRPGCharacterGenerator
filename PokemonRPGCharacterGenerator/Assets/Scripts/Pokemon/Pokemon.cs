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

public class Pokemon

{
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
	public SkillTrees _SkillTrees;
	public EnduranceStat NumberOfEnduranceBonuses = new EnduranceStat (0);
	public AttackStat NumberOfAttackBonuses = new AttackStat (0);
	public DefenseStat NumberOfDefenseBonuses = new DefenseStat (0);
	public SpecialAttackStat NumberOfSpecialAttackBonuses = new SpecialAttackStat (0);
	public SpecialDefenseStat NumberOfSpecialDefenseBonuses = new SpecialDefenseStat (0);
	public SpeedStat NumberOfSpeedBonuses = new SpeedStat (0);



//	public PokemonSheetDisplay _PokemonSheetDisplay;
	public String HeldItem = "";

	public List <Technique> _TechniquesKnown = new List <Technique> ();
	public List <Technique> _TechniquesActive = new List <Technique> ();

	public List <LevelUpBonus> LevelUpBonuses = new List <LevelUpBonus> ();
	public List <MaturityBonus> MaturityBonuses = new List <MaturityBonus> ();
	public List <SkillTreeData> _SkillTreeData = new List<SkillTreeData>();

	public List <SkillTreeData> _SkillTreeDataTier1 = new List<SkillTreeData>();
	public List <SkillTreeData> _SkillTreeDataTier2 = new List<SkillTreeData>();
	public List <SkillTreeData> _SkillTreeDataTier3 = new List<SkillTreeData>();

//	public List <SkillTreeBonusesAcquired> _BonusesRemaining = new List <SkillTreeBonusesAcquired>();

	public int TotalBaseStats = 20;
//	{get {return (MyStat)  }}

	public event EventHandler BreakTree;

	public event EventHandler ActivateTree;

	public event EventHandler TradeSkill;

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
//			Debug.Log (_Breed.Type1); 
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

	public Pokemon (Pokemon.Breed breed)
	{
		_Breed = breed;
		ShinyRNG = UnityEngine.Random.Range (0, 4096);
		Debug.Log (ShinyRNG);

		if (ShinyRNG == 0) 
		{
			IsShiny = true;
			Debug.Log ("Holy Shit, a Shiny!");
		}
//		_SkillTreeData.Add(new SkillTreeData("Imp", SkillTreeTier.Tier0));
//		_SkillTreeData.Add(new SkillTreeData("Drake", SkillTreeTier.Tier1));
//		_SkillTreeData.Add(new SkillTreeData("Fire Body 1", SkillTreeTier.Tier1));
//		_SkillTreeData.Add(new SkillTreeData("Claw 1", SkillTreeTier.Tier1));
//		_SkillTreeData.Add(new SkillTreeData("Pyromancer 1", SkillTreeTier.Tier1));
//		_SkillTreeData.Add(new SkillTreeData("Beast", SkillTreeTier.Tier1));
//		_SkillTreeData.Add(new SkillTreeData("Claw 2", SkillTreeTier.Tier2));
//		_SkillTreeData.Add(new SkillTreeData("Fire Body 2", SkillTreeTier.Tier2));
//		_SkillTreeData.Add(new SkillTreeData("Pureblood 2", SkillTreeTier.Tier2));
//		_SkillTreeData.Add(new SkillTreeData("Acrobatics 1", SkillTreeTier.Tier1));
//		_SkillTreeData.Add(new SkillTreeData("Pureblood 3", SkillTreeTier.Tier3));
//		_SkillTreeData.Add(new SkillTreeData("Fire Body 3", SkillTreeTier.Tier3));

		_SkillTreeDataTier1.Add (new SkillTreeData("Imp", SkillTreeTier.Tier0));
		_SkillTreeDataTier1.Add (new SkillTreeData("Drake", SkillTreeTier.Tier1));
		_SkillTreeDataTier1.Add (new SkillTreeData("Fire Body 1", SkillTreeTier.Tier1));
		_SkillTreeDataTier1.Add (new SkillTreeData("Claw 1", SkillTreeTier.Tier1));
		_SkillTreeDataTier1.Add (new SkillTreeData("Beast", SkillTreeTier.Tier1));
		_SkillTreeDataTier1.Add (new SkillTreeData("Pyromancer 1", SkillTreeTier.Tier1));

		_SkillTreeDataTier2.Add (new SkillTreeData("Claw 2", SkillTreeTier.Tier2));
		_SkillTreeDataTier2.Add (new SkillTreeData("Fire Body 2", SkillTreeTier.Tier2));
		_SkillTreeDataTier2.Add (new SkillTreeData("Pureblood 2", SkillTreeTier.Tier2));

		_SkillTreeDataTier3.Add (new SkillTreeData("Pureblood 3", SkillTreeTier.Tier3));
		_SkillTreeDataTier3.Add (new SkillTreeData("Fire Body 3", SkillTreeTier.Tier3));
		_SkillTreeDataTier3.Add (new SkillTreeData("Acrobatics 1", SkillTreeTier.Tier1));

//		_SkillTreeData.Add (new SkillTreeData("Imp", SkillTreeTier.Tier0));

		ApplyMaturityBonus (MaturityStatic.GetMaturityBonuses (0), 0);
//		UnlockTrees (SkillTreeTier.Tier0);
//		_PokemonSheetDisplay.ShowNewPokemon (this, _Breed);
	}
		
	public Pokemon ()
		{
		ShinyRNG = UnityEngine.Random.Range (0, 4096);
		Debug.Log (ShinyRNG);

		if (ShinyRNG == 0) 
		{
			IsShiny = true;
			Debug.Log ("Holy Shit, a Shiny!");
		}
		_Breed = new Breed (ElementTypes.Nothing, ElementTypes.Nothing);
//		_SkillTreeData.Add(new SkillTreeData("Imp", SkillTreeTier.Tier0));
//		_SkillTreeData.Add(new SkillTreeData("Drake", SkillTreeTier.Tier1));
//		_SkillTreeData.Add(new SkillTreeData("Fire Body 1", SkillTreeTier.Tier1));
//		_SkillTreeData.Add(new SkillTreeData("Claw 1", SkillTreeTier.Tier1));
//		_SkillTreeData.Add(new SkillTreeData("Acrobatics 1", SkillTreeTier.Tier1));
//		_SkillTreeData.Add(new SkillTreeData("Pyromancer 1", SkillTreeTier.Tier1));
//		_SkillTreeData.Add(new SkillTreeData("Beast", SkillTreeTier.Tier1));
//		_SkillTreeData.Add(new SkillTreeData("Claw 2", SkillTreeTier.Tier2));
//		_SkillTreeData.Add(new SkillTreeData("Fire Body 2", SkillTreeTier.Tier2));
//		_SkillTreeData.Add(new SkillTreeData("Pureblood 2", SkillTreeTier.Tier2));
//		_SkillTreeData.Add(new SkillTreeData("Pureblood 3", SkillTreeTier.Tier3));
//		_SkillTreeData.Add(new SkillTreeData("Fire Body 3", SkillTreeTier.Tier3));

		_SkillTreeDataTier1.Add (new SkillTreeData("Imp", SkillTreeTier.Tier0));
		_SkillTreeDataTier1.Add (new SkillTreeData("Drake", SkillTreeTier.Tier1));
		_SkillTreeDataTier1.Add (new SkillTreeData("Fire Body 1", SkillTreeTier.Tier1));
		_SkillTreeDataTier1.Add (new SkillTreeData("Claw 1", SkillTreeTier.Tier1));
		_SkillTreeDataTier1.Add (new SkillTreeData("Beast", SkillTreeTier.Tier1));
		_SkillTreeDataTier1.Add (new SkillTreeData("Pyromancer 1", SkillTreeTier.Tier1));

		_SkillTreeDataTier2.Add (new SkillTreeData("Claw 2", SkillTreeTier.Tier2));
		_SkillTreeDataTier2.Add (new SkillTreeData("Fire Body 2", SkillTreeTier.Tier2));
		_SkillTreeDataTier2.Add (new SkillTreeData("Pureblood 2", SkillTreeTier.Tier2));

		_SkillTreeDataTier3.Add (new SkillTreeData("Pureblood 3", SkillTreeTier.Tier3));
		_SkillTreeDataTier3.Add (new SkillTreeData("Fire Body 3", SkillTreeTier.Tier3));
		_SkillTreeDataTier3.Add (new SkillTreeData("Acrobatics 1", SkillTreeTier.Tier1));

//		_SkillTreeData.Add (new SkillTreeData("Imp", SkillTreeTier.Tier0));

		ApplyMaturityBonus (MaturityStatic.GetMaturityBonuses (0), 0);
//		UnlockTrees (SkillTreeTier.Tier0);

		//_PokemonSheetDisplay.ShowNewPokemon (GameManager.instance.CurrentPokemon, GameManager.instance.CurrentPokemon._Breed);
	}

//	public void AssignNameFields ()
//	{
//		
//	}

	private SkillTreeData AutoChooseTree (SkillTreeTier _Tier)
	{
		SkillTreeData Temp;

		switch (_Tier)
		{	
		case SkillTreeTier.Tier0:
			_SkillTreeDataTier1.Shuffle ();
			Temp = _SkillTreeDataTier1 [0];
			_SkillTreeDataTier1.RemoveAt (0);
			Debug.Log (_Tier);
			return Temp;
		case SkillTreeTier.Tier1:
			_SkillTreeDataTier1.Shuffle ();
			Temp = _SkillTreeDataTier1 [0];
			_SkillTreeDataTier1.RemoveAt (0);
			Debug.Log (_Tier);
			return Temp;
//			break;
		case SkillTreeTier.Tier2:
			_SkillTreeDataTier2.Shuffle ();
			Temp = _SkillTreeDataTier2 [0];
			_SkillTreeDataTier2.RemoveAt (0);
			Debug.Log (_Tier);
			return Temp;
//			break;
		case SkillTreeTier.Tier3:
			_SkillTreeDataTier3.Shuffle ();
			Temp = _SkillTreeDataTier3 [0];
			_SkillTreeDataTier3.RemoveAt (0);
			return Temp;
//			break;
		default:
			Debug.Log ("This pokemon has gone Super Saiyan" + _Tier);
			return null;
//			break;
		}
	}



	public void MaturityIncrease ()
	{
		Maturity = ((Level * 2) / Rate);
	}

	public void LevelUp ()
	{
		int TempMaturity = Maturity;
		Level++;
		MaturityIncrease ();
		if (TempMaturity != Maturity) 
		{				
			ApplyMaturityBonus (MaturityStatic.GetMaturityBonuses (Maturity), Maturity);
		} 
		else 
		{
		Debug.Log ("MaturityBonus already gained at that level"+Maturity);
		}
//		Debug.Log ("Bonuses :" + MaturityBonuses.Count + "Maturity :" + Maturity);
	}

	public void ApplyLevelBonus (LevelUpBonus _Bonus)
	{
		if (_Bonus == null)
		{
			return;
		}
		_Bonus.ApplyLevelBonus(this);
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
	        }
	}

	public void SwapTrees (SkillTreeTier Tier)
	{
//		Debug.Log (Tier.ToString());
		_SkillTreeData [0].ChangeState (SkillTreeState.Inactive);
		_SkillTreeData [3].ChangeState (SkillTreeState.Active);
		SkillTreeData TempData2 = _SkillTreeData [3];
		SkillTreeData TempData = _SkillTreeData [0];
		_SkillTreeData [0] = TempData2;
		_SkillTreeData [3] = TempData;
		if (TradeSkill != null) 
		{
			TradeSkill (this, new EventArgs ());
//			Debug.Log ("");
		}			
//		GameManager.instance.Refresh();
	}

	public void GainTechnique ()
	{
		Debug.Log ("Gain Technique: TODO");
	}

	public void GainTechniqueModifier ()
	{
		Debug.Log ("Gain Technique: TODO");
	}

	public void GainAbility ()
	{
		Debug.Log ("Gain Ability: TODO");
	}

	public void GainStatUp ()
	{
		Debug.Log ("Stat Up: TODO");
	}

	public void GainElementTypesSkillUp ()
	{
		Debug.Log ("Skill Up: TODO");
	}

	public void GainMaturityPlusBonus ()
	{
		Debug.Log ("Maturity Up: TODO");
	}
	
	

	public void GainBonusLevel ()
	{
		XP++;
		XP++;
		Debug.Log("Gained Bonus Level :"+Maturity);
	}

	public void GainEnduranceBonus ()
	{
		NumberOfEnduranceBonuses.RawValue++;
	}

	public void GainBreakTree (SkillTreeTier _Tier)
	{
		UnlockTrees (_Tier);
		Debug.Log ("Gained Break Tree :" + Maturity);
	}

	public void GainActiveTreeBonus (int TreeSlot)
	{
		ActivateTrees (TreeSlot);
		Debug.Log ("Gained Active Tree :"+Maturity);
	}

	public void GainNatureBonus ()
	{
		//Need a selection dialog
		Debug.Log ("Gained Nature :"+Maturity);
	}

	public void GainAbilitySlot ()
	{
		//Need poke sheet display
		Debug.Log ("Gained Ability Slot :"+Maturity);
	}

	public void GainSTABBonus ()
	{
		//Need Skills
		Debug.Log ("Gained STAB :"+Maturity);
	}

	public void GainSpecialTrainingBonus ()
	{
		//Need Skills
		Debug.Log ("Gained Special Training :"+Maturity);
	}

	public void GainEnhancerSlotBonus ()
	{
		//Need Skills
		Debug.Log ("Enhancer Slot :"+Maturity);
	}
		
	public void UnlockTrees (SkillTreeTier _Tier)
	{
		SkillTreeData TreeToAdd = AutoChooseTree (_Tier);
		_SkillTreeData.Add (TreeToAdd);

		for (int i = 0; i < _SkillTreeData.Count; i++) 
		{
			if (_SkillTreeData [i].CurrentState == SkillTreeState.Locked) 
			{
				_SkillTreeData [i].ChangeState (SkillTreeState.Inactive);

				if (BreakTree != null) 
				{
					BreakTree (this, new EventArgs ());
					Debug.Log (i);
				}						
				return;
			}
		}
	}

		public void ActivateTrees (int TreeSlot)
		{
		_SkillTreeData [TreeSlot].ChangeState (SkillTreeState.Active);
		if (ActivateTree != null)
		{
			ActivateTree (this, new EventArgs());
		}
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
