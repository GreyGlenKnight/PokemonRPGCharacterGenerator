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



public class Pokemon : IChoosable

{

    #region IChoosable implementation

    public string Name { get { return NickName; } }
    public string Description { get { return ThisBreed.BreedName + " Lv. " + Level.ToString(); } }

    #endregion

    //Skills + HM abilities
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
	public PokemonStatBlock _StatBlock;
	public SkillTreeBlock _SkillTreeBlock;

	public List <Technique> _TechniquesKnown = new List <Technique> ();
	public List <Technique> _TechniquesActive = new List <Technique> ();
	public List <TechniqueModifier> _TechniqueModifiersKnown = new List <TechniqueModifier> ();
	public List <Ability> _AbilitiesKnown = new List <Ability> ();

	public List <IHistoryItem> BonusHistory = new List <IHistoryItem> ();
	public List <LevelUpBonus> LevelUpBonuses = new List <LevelUpBonus> ();
	public List <MaturityBonus> MaturityBonuses = new List <MaturityBonus> ();
//	public List <SkillTree> _SkillTrees = new List <SkillTree>();

	public List <ElementTypesSkill> _ElementTypesSkill = new List <ElementTypesSkill> ();
	public String HeldItem = "";

	public int TotalBaseStats = 20;

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
		
	public ElementTypes Type1
	{
		get {return _Breed.Type1;}
	}

	public ElementTypes Type2
	{
		get {return _Breed.Type2;}
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
		_SkillTreeBlock = new SkillTreeBlock (this);
		_StatBlock = new PokemonStatBlock (this);

		ApplyMaturityBonus (MaturityStatic.GetMaturityBonuses (0), 0);
	}
		
	public void AssignNameFields ()
	{
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
			OnIncreaseLevel (this, 
				new PokemonEventArgs (this));
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
		_SkillTreeBlock.SwapTrees (Tier);

		if (OnTradeSkill != null) 
		{
			OnTradeSkill (this, 
				new PokemonEventArgs (this));
		}			
	}

	public void GainTechnique (Technique _Technique)
	{
		Debug.Log ("Gain Technique: TODO");

		_TechniquesKnown.Add (_Technique);

		if (OnGainTechnique != null) 
		{
			OnGainTechnique (this, 
				new PokemonEventArgs (this));
		}
	}

	public void GainTechniqueModifier (TechniqueModifier _TechniqueModifier)
	{
		_TechniqueModifiersKnown.Add (_TechniqueModifier);

		if (OnGainTechniqueModifier != null) 
		{
			OnGainTechniqueModifier (this, 
				new PokemonEventArgs (this));
		}
	}

	public void GainAbility (Ability _Ability)
	{
		_AbilitiesKnown.Add (_Ability);

		if (OnGainAbility != null) 
		{
			OnGainAbility (this, 
				new PokemonEventArgs (this));
		}	
	}

	public void GainStatUp (PokemonStat _Stat)
	{
		_StatBlock.GainStatUp (_Stat);

		if (OnGainStatUp != null) 
		{
			OnGainStatUp (this, 
				new PokemonEventArgs (this));
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
			OnGainElementTypesSkillUp (this, 
				new PokemonEventArgs (this));
		}	
	}

	public void GainMaturityPlusBonus ()
	{
		MaturityBonusCheck ();
		Maturity++;

		if (OnGainMaturityPlusBonus != null) 
		{
			OnGainMaturityPlusBonus (this, 
				new PokemonEventArgs (this));
		}	
	}

	public void GainBonusLevel ()
	{
		AddXP ();
		//AddXP will throw event itself
		Debug.Log("Gained Bonus Level :"+Maturity);
	}

	public void GainEnduranceBonus (PokemonStat _Stat)
	{
		_StatBlock.GainStatUp (_Stat);

		if (OnGainEnduranceBonus != null) 
		{
			OnGainEnduranceBonus (this, 
				new PokemonEventArgs (this));
		}	
	}

	public void GainBreakTree (SkillTreeTier _Tier)
	{
		UnlockTrees (_Tier);

		if (OnBreakTree != null) 
		{
			OnBreakTree (this, 
				new PokemonEventArgs (this));
		}
	}

	public void GainActiveTreeBonus (int TreeSlot)
	{
		ActivateTrees (TreeSlot);

		if (OnActivateTree != null)
		{
			OnActivateTree (this, 
				new PokemonEventArgs (this));
		}
	}

	public void GainNatureBonus ()
	{
		Debug.Log ("Gained Nature :"+Maturity);
		if (OnGainNatureBonus != null) 
		{
			OnGainNatureBonus (this, 
				new PokemonEventArgs (this));
		}	
	}

	public void GainAbilitySlot ()
	{
		Debug.Log ("Gained Ability Slot :"+Maturity);
		if (OnGainAbilitySlot != null) 
		{
			OnGainAbilitySlot (this, 
				new PokemonEventArgs (this));
		}	
	}

	public void GainSTABBonus ()
	{
		Debug.Log ("Gained STAB :"+Maturity);
		if (OnGainSTABBonus != null) 
		{
			OnGainSTABBonus (this, 
				new PokemonEventArgs (this));
		}	
	}

	public void GainSpecialTrainingBonus ()
	{
		Debug.Log ("Gained Special Training :"+Maturity);
		if (OnGainSpecialTrainingBonus != null) 
		{
			OnGainSpecialTrainingBonus (this, 
				new PokemonEventArgs (this));
		}	
	}

	public void GainEnhancerSlotBonus ()
	{
		Debug.Log ("Enhancer Slot :"+Maturity);
		if (OnGainEnhancerSlotBonus != null) 
		{
			OnGainEnhancerSlotBonus (this, 
				new PokemonEventArgs (this));
		}	
	}
		
	public void UnlockTrees (SkillTreeTier _Tier)
	{
		_SkillTreeBlock.UnlockTrees (_Tier);

		if (OnBreakTree != null) 
		{
			OnBreakTree (this, 
				new PokemonEventArgs (this));
		}						
		return;
	}


	public void ActivateTrees (int TreeSlot)
	{
		_SkillTreeBlock.ActivateTrees (TreeSlot);

		if (OnActivateTree != null)
		{
			OnActivateTree (this, 
				new PokemonEventArgs(this));
		}
	}



	public class Breed 
	{
		public virtual ElementTypes Type1 {get {return _Type1;} set {_Type1 = value; }}
		public virtual ElementTypes Type2 {get {return _Type2;} set {_Type2 = value; }}
		public string BreedName; // May be unnecessary

		public BreedStatBlock BreedStatBlock = new BreedStatBlock ();

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
