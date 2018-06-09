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
			_Description = "Gained Technique "+_TechniqueToAdd.Name+" On "+_Tree.Name;
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
			ElementTypes _Type)
		{
//			string SkillName = _Type.ToString();
			_Description = "Gained Skill Bonus To "+ _Type.ToString()+" On "+_Tree.Name;
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


}

