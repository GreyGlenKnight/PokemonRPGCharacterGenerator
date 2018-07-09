using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public enum SkillTreeState
{
	Active, Inactive, Locked
}

public enum SkillTreeTier
{
	Tier0, Tier1, Tier2, Tier3,
}

public class SkillTreeData 
{
	public SkillTreeData (string lname, SkillTreeTier _lTier)
	{
		Name = lname;
		Tier = _lTier;

		Technique Fire_Blast = new Technique ();
		Fire_Blast.BaseAccuracy = -1;
		Fire_Blast.BaseDamage = 11;
		Fire_Blast.BaseStrain = 4;
		Fire_Blast.Description = "A fiery runic symbol strikes the foe, inflicting heavy damage and burn.";
		Fire_Blast.DisplayRange = "Ranged";
		Fire_Blast.Name = "Fire Blast";
		Fire_Blast.StatsUsed.Add (new SpecialAttackStat(0));
		Fire_Blast.Types.Add (ElementTypes.Fire);

		Technique Dragon_Claw = new Technique ();
		Dragon_Claw.BaseAccuracy = 1;
		Dragon_Claw.BaseDamage = 8;
		Dragon_Claw.BaseStrain = 3;
		Dragon_Claw.Description = "The foe is ravaged by a mighty swipe of the pokemon’s claws.";
		Dragon_Claw.DisplayRange = "Melee";
		Dragon_Claw.Name = "Dragon Claw";
		Dragon_Claw.StatsUsed.Add (new AttackStat(0));
		Dragon_Claw.Types.Add (ElementTypes.Dragon);

		Technique Metal_Claw = new Technique ();
		Metal_Claw.BaseAccuracy = 0;
		Metal_Claw.BaseDamage = 5;
		Metal_Claw.BaseStrain = 2;
		Metal_Claw.Description = "The pokemon gouges the opponent with a set of merciless claws. May raise Attack.";
		Metal_Claw.DisplayRange = "Melee";
		Metal_Claw.Name = "Metal Claw";
		Metal_Claw.StatsUsed.Add (new AttackStat(0));
		Metal_Claw.Types.Add (ElementTypes.Steel);

		Technique Sand_Attack = new Technique ();
		Sand_Attack.BaseAccuracy = 1;
		Sand_Attack.BaseStrain = 3;
		Sand_Attack.Description = "Norris always teaches his pokemon to be prepared for snakes.";
		Sand_Attack.DisplayRange = "Ranged";
		Sand_Attack.Name = "Sand Attack";
		Sand_Attack.StatsUsed.Add (new DefenseStat(0));
		Sand_Attack.StatsUsed.Add (new SpeedStat(0));
		Sand_Attack.Types.Add (ElementTypes.Ground);

		_TechniquesOnTree.Add (Fire_Blast);
		_TechniquesOnTree.Add (Dragon_Claw);
		_TechniquesOnTree.Add (Metal_Claw);
		_TechniquesOnTree.Add (Sand_Attack);
		_TechniqueModifier = new TechniqueModifier();
		_Ability = new Ability ();

		_ElementTypesSkillOnTree.Add (new ElementTypesSkill (ElementTypes.Fire));
		ResetBonuses ();
	}

	public const int BONUSES_ON_TREE = 12;
//	private List<BonusAtIndex> RemainingBonuses = new List<BonusAtIndex> ();
	public bool IsTreeFull = false;
	public bool IsInit = false;

	public SkillTreeBonuses _BonusesAcquired = new SkillTreeBonuses ();
	public SkillTreeBonuses _BonusesRemaining = new SkillTreeBonuses ();

	private TechniqueModifier _TechniqueModifier;
	private Ability _Ability;
	private List <ElementTypesSkill> _ElementTypesSkillOnTree = new List <ElementTypesSkill>();
	private MyStat _FavoredStatOnTree = new AttackStat (1);
	private SkillTreeState _State = SkillTreeState.Locked;
	private List <Technique> _TechniquesOnTree = new List <Technique> ();
	//private SkillTreeData _CrossTree;
	//private SkillTreeData _NextTree;
//	public bool IsTreeFull = false;
	string _Name;


//	public void OnSelectOption (object Caller, EventArgs E)
//	{
//		Refresh ();
//	public event EventHandler OnSelected;

//	}

	public string Name {private set {_Name = value;} get {return _Name;}}

	SkillTreeTier _Tier;

	public SkillTreeTier Tier {private set {_Tier = value;} get {return _Tier;}}

	public SkillTreeState CurrentState 
	{		
		get {return (SkillTreeState) _State;}
	}

	public List <Technique> TechniquesOnTree 
	{		
		get {return _TechniquesOnTree;}
	}

	public TechniqueModifier TechniqueModifierOnTree
	{get {return _TechniqueModifier;}}

	public Ability AbilityOnTree
	{get {return _Ability;}}

	public List <ElementTypesSkill> ElementTypeSkillsOnTree 
	{		
		get {return _ElementTypesSkillOnTree;}
	}

	public MyStat FavoredStatOnTree 
	{		
		get {return _FavoredStatOnTree;}
	}

	public List <BonusAtIndex> GetRemainingBonuses ()
	{
		return _BonusesRemaining.Bonuses;
	}

//	public void OnManualSelectClick (object Caller, EventArgs E)
//	{
//		OnManualSelectClick ();
//	}

	public SkillTreeData GetTreeIfActive ()
	{
		if (this.CurrentState == SkillTreeState.Active) 
		{return this;} 
		else 
		{return null;}
	}

	//private SkillTreeData _CrossTree
	//
	//private SkillTreeData _NextTree;
	//


	public void ChangeState (SkillTreeState NewState)
	{
		_State = NewState;
	}

	public BonusAtIndex GetCurrentSelectedBonus ()
	{
		if (CurrentState != SkillTreeState.Active) 
		{
			return BonusAtIndex.None;
		}

		if (_BonusesRemaining.Bonuses.Count == 0) 
		{
			return BonusAtIndex.None;
		}
		return _BonusesRemaining.Bonuses [0];
	}


	public void RollTheList ()
	{
		if (CurrentState != SkillTreeState.Active)
		{
			return;
		}
			
		if (_BonusesRemaining.Bonuses.Count > 0) 
		{
			_BonusesRemaining.Bonuses.Shuffle ();
		} 
	}

	public void OnSelected ()
	{
		if (GameManager.instance._SelectionState == SelectionState.Roll) 
		{
			return;
		}
//		if (CurrentState != SkillTreeState.Active) 
//		{
//			Debug.Log ("Selected Tree Inactive!");
//			return;
//		}
		if (_BonusesRemaining.Bonuses.Count == 0) 
		{
			return;
		}
		_BonusesAcquired.Bonuses.Add (_BonusesRemaining.Bonuses [0]);
		GameManager.instance.CurrentPokemon.LevelUp (GetBonusForIndex (_BonusesRemaining.Bonuses [0]));
//		GameManager.instance.CurrentPokemon.ApplyLevelBonus (GetBonusForIndex (_BonusesRemaining.Bonuses [0]));
		GameManager.instance._SelectionState = SelectionState.Roll;
		_BonusesRemaining.Bonuses.RemoveAt (0);
	}

	public void OnManualSelectClick ()
	{
//		this += OnManualSelectClick;

		if (GameManager.instance._SelectionState == SelectionState.Select)
		{
			OnSelected ();
//			GameManager.instance.CurrentPokemon.LevelUp ();
		}
	}

	public void ResetBonuses ()
	{ 
		for (int i = 0; i < BONUSES_ON_TREE; i++) 
		{
			_BonusesRemaining.Bonuses.Add ((BonusAtIndex)i);
			_BonusesAcquired.Bonuses.Clear ();
		}
		IsInit = true;
	}


	public LevelUpBonus GetBonusForIndex (BonusAtIndex _Index)
	{
		switch (_Index) 
		{
		case BonusAtIndex.Skill1:
			return new LevelUpBonus.TechniqueGain (this, 
				_TechniquesOnTree [(int) _Index]);
		case BonusAtIndex.Skill2:	
			return new LevelUpBonus.TechniqueGain (this, 
				_TechniquesOnTree [(int) _Index]);
		case BonusAtIndex.Skill3:
			return new LevelUpBonus.TechniqueGain (this, 
				_TechniquesOnTree [(int) _Index]);			
		case BonusAtIndex.Skill4:
			return new LevelUpBonus.TechniqueGain (this, 
				_TechniquesOnTree [(int) _Index]);			
		case BonusAtIndex.MoveMod:
			return new LevelUpBonus.TechniqueModifierGain (this);
		case BonusAtIndex.Ability:
			return new LevelUpBonus.AbilityGain (this);
		case BonusAtIndex.StatUp:
			return new LevelUpBonus.StatGain (this, 
				_FavoredStatOnTree);
		case BonusAtIndex.SkillUp:
			return new LevelUpBonus.ElementTypesSkillGain (this, 
				_ElementTypesSkillOnTree);
		case BonusAtIndex.Endurance:
			return new LevelUpBonus.StatGain (this, new EnduranceStat (1));
		case BonusAtIndex.Maturity:
			return new LevelUpBonus.MaturityBonusGain (this);
		case BonusAtIndex.CrossTree:
			return new LevelUpBonus.CrossTree (this);
		case BonusAtIndex.TreeUp:
			return new LevelUpBonus.TreeUp (this);
		default:
			return null;
		}
	}
}