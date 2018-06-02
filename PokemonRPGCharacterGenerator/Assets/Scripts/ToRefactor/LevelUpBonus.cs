using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;


public abstract class LevelUpBonus : IHistoryItem
{
	#region IHistoryItem implementation

	public int LevelGained {
		get {return _Level;}
	}

	public int MaturityLevel {
		get {return _MaturityLevel;}
	}

	public string Name {
		get {return _Name;}
	}

	public string Description {
		get {return _Description;}
	}

	public BonusType Type {
		get {return BonusType.LevelUp;}
	}

	public Sprite GetRepresentedSprite {
		get {throw new NotImplementedException ();}
	}

	#endregion

	public static LevelUpBonus GetTreeBonus (SkillTreeData _Tree, 
		BonusAtIndex _Bonus)
	{
		switch (_Bonus) 
		{
		case BonusAtIndex.Skill1:
			return new TechniqueGain (_Tree, _Tree.Tech1);
		case BonusAtIndex.Skill2:
			return new TechniqueGain (_Tree, _Tree.Tech2);
		case BonusAtIndex.Skill3:
			return new TechniqueGain (_Tree, _Tree.Tech3);
		case BonusAtIndex.Skill4:
			return new TechniqueGain (_Tree, _Tree.Tech4);
		case BonusAtIndex.MoveMod:
			return new TechniqueModifierGain (_Tree);	
		case BonusAtIndex.Ability:
			return new AbilityGain (_Tree);
		case BonusAtIndex.StatUp:
			return new StatGain (_Tree, _Tree.FavoredStat);
		case BonusAtIndex.SkillUp:
			return new ElementTypesSkillGain (_Tree, _Tree.FavoredType1, _Tree.FavoredType2);
		case BonusAtIndex.Endurance:
			return new StatGain (_Tree, new EnduranceStat(1));
		case BonusAtIndex.Maturity:
			return new MaturityBonusGain (_Tree);
		case BonusAtIndex.CrossTree:
			return new CrossTree (_Tree);
		case BonusAtIndex.TreeUp:
			return new TreeUp (_Tree);
		default:
			Debug.Log ("Shouldn't be Generating bonus for that index");
			return null;
		}
	}

	public abstract void ApplyLevelBonus (Pokemon _Pokemon);

	private string _Description;
	private string _Name = "Level Up: ";
	private int _Level;
	private int _MaturityLevel;


	public class TechniqueGain : LevelUpBonus
	{
		public TechniqueGain (SkillTreeData _Tree,
			Technique _TechniqueToAdd)
		{
//			_Name = "Learned: "+_TechniqueToAdd.Name;
			if (_TechniqueToAdd != null)
			{
			_Description = "Gained Technique "+_TechniqueToAdd.Name+" On "+_Tree.Name;
			}
			else {_Description = "Gained Technique On: "+_Tree.Name;}
		}

		public override void ApplyLevelBonus(Pokemon _Pokemon)
		{
			_Level = _Pokemon.Level;
			_MaturityLevel = _Pokemon.Maturity;
			_Pokemon.GainTechnique();
			_Pokemon.LevelUpBonuses.Add (this);
		}
	}

	public class TechniqueModifierGain : LevelUpBonus
	{
		public TechniqueModifierGain (SkillTreeData _Tree)
		{
			Debug.Log ("Need structure for move mods");
//			_Name = "Learned: "+"";
			string ModName = "";
			_Description = "Gained Technique Modifier "+ModName+" On "+_Tree.Name;
		}
		public override void ApplyLevelBonus(Pokemon _Pokemon)
		{
			_Level = _Pokemon.Level;
			_MaturityLevel = _Pokemon.Maturity;

			_Pokemon.GainTechniqueModifier ();
			_Pokemon.LevelUpBonuses.Add (this);
		}
	}

	public class AbilityGain : LevelUpBonus
	{
		public AbilityGain (SkillTreeData _Tree)
		{
			Debug.Log ("Need structure for move mods");
//			_Name = "Learned: "+"";
			string AbilityName = "";
			_Description = "Gained Ability "+AbilityName+" On "+_Tree.Name;
		}
		public override void ApplyLevelBonus(Pokemon _Pokemon)
		{
			_Level = _Pokemon.Level;
			_MaturityLevel = _Pokemon.Maturity;

			_Pokemon.GainAbility ();
			_Pokemon.LevelUpBonuses.Add (this);
		}
	}

	public class StatGain : LevelUpBonus
	{
		public StatGain (SkillTreeData _Tree,
			MyStat _Stat)
		{
//			string StatName = _Stat.ToString();
//			_Name = "Gained Stat Up: "+_Stat.ToString();
			if (_Stat == null)
			{_Stat = new AttackStat (1);}
			_Description = "Gained Stat Bonus To "+_Stat.ToString()+" On "+_Tree.Name;
		}
		public override void ApplyLevelBonus(Pokemon _Pokemon)
		{	
			_Level = _Pokemon.Level;
			_MaturityLevel = _Pokemon.Maturity;

			_Pokemon.GainStatUp ();
			_Pokemon.LevelUpBonuses.Add (this);
		}
	}

	public class ElementTypesSkillGain : LevelUpBonus
	{
		public ElementTypesSkillGain (SkillTreeData _Tree,
			ElementTypes _Type1,
			ElementTypes _Type2)
		{
//			string SkillName = _Type.ToString();
			if (_Type1 != ElementTypes.Nothing)
			{
			_Description = "Gained Skill Bonus To "+ _Type1.ToString()+" On "+_Tree.Name;
			}
			else
			{
				_Description =	"Gained Skill Bonus To Fire On "+_Tree.Name;
			}
			if (_Type2 != ElementTypes.Nothing)
			{			
				_Description = "Gained Skill Bonus To "+ _Type1.ToString()+" And "+ _Type2.ToString()+" On "+_Tree.Name;
			}
		}
		public override void ApplyLevelBonus(Pokemon _Pokemon)
		{
			_Level = _Pokemon.Level;
			_MaturityLevel = _Pokemon.Maturity;

			_Pokemon.GainElementTypesSkillUp ();
			_Pokemon.LevelUpBonuses.Add (this);
		}
	}

	public class MaturityBonusGain : LevelUpBonus
	{
		public MaturityBonusGain (SkillTreeData _Tree)
		{
			_Description = "Gained Maturity Bonus On "+_Tree.Name;
		}
		public override void ApplyLevelBonus(Pokemon _Pokemon)
		{
			_Level = _Pokemon.Level;
			_MaturityLevel = _Pokemon.Maturity;

			_Pokemon.GainMaturityPlusBonus ();
			_Pokemon.LevelUpBonuses.Add (this);
		}
	}

	public class CrossTree : LevelUpBonus
	{
		public CrossTree (SkillTreeData _Tree)
		{
//			_Description = "This shouldn't be here";
		}
		public override void ApplyLevelBonus(Pokemon _Pokemon)
		{
			_Pokemon.CrossTreeBonus ();
		}
	}

	public class TreeUp : LevelUpBonus
	{
		public TreeUp (SkillTreeData _Tree)
		{
//			_Description = "This shouldn't be here";

		}
		public override void ApplyLevelBonus(Pokemon _Pokemon)
		{
			_Pokemon.TreeUpBonus ();
		}
	}

}

