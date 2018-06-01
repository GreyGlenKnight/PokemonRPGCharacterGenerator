using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;


	public abstract class LevelUpBonus
{
	public abstract void ApplyLevelBonus (Pokemon _Pokemon);

	public string Description;
	public int LevelGained;

	public class TechniqueGain : LevelUpBonus
	{
		public TechniqueGain (SkillTreeData _Tree,
			Technique _TechniqueToAdd, 
			int _Level)
		{
			Description = "Gained Technique "+_TechniqueToAdd.Name+" On "+_Tree.Name;
				LevelGained = _Level;
		}
		public override void ApplyLevelBonus(Pokemon _Pokemon)
		{
			_Pokemon.GainTechnique();
			_Pokemon.LevelUpBonuses.Add (this);
		}
	}

	public class TechniqueModifierGain : LevelUpBonus
	{
		public TechniqueModifierGain (SkillTreeData _Tree, 
			int _Level)
		{
			Debug.Log ("Need structure for move mods");
			string ModName = "";
			Description = "Gained Technique Modifier "+ModName+" On "+_Tree.Name;
			LevelGained = _Level;
		}
		public override void ApplyLevelBonus(Pokemon _Pokemon)
		{
			_Pokemon.GainTechniqueModifier ();
			_Pokemon.LevelUpBonuses.Add (this);
		}
	}

	public class AbilityGain : LevelUpBonus
	{
		public AbilityGain (SkillTreeData _Tree, 
			int _Level)
		{
			Debug.Log ("Need structure for move mods");
			string AbilityName = "";
			Description = "Gained Ability "+AbilityName+" On "+_Tree.Name;
			LevelGained = _Level;
		}
		public override void ApplyLevelBonus(Pokemon _Pokemon)
		{
			_Pokemon.GainAbility ();
			_Pokemon.LevelUpBonuses.Add (this);
		}
	}

	public class StatGain : LevelUpBonus
	{
		public StatGain (SkillTreeData _Tree,
			MyStat _Stat,
			int _Level)
		{
			string StatName = _Stat.ToString();
			Description = "Gained Stat Bonus To "+StatName+" On "+_Tree.Name;
			LevelGained = _Level;
		}
		public override void ApplyLevelBonus(Pokemon _Pokemon)
		{
			_Pokemon.GainStatUp ();
			_Pokemon.LevelUpBonuses.Add (this);
		}
	}

	public class ElementTypesSkillGain : LevelUpBonus
	{
		public ElementTypesSkillGain (SkillTreeData _Tree,
			ElementTypes _Type,
			int _Level)
		{
			string SkillName = _Type.ToString();
			Description = "Gained Skill Bonus To "+SkillName+" On "+_Tree.Name;
			LevelGained = _Level;
		}
		public override void ApplyLevelBonus(Pokemon _Pokemon)
		{
			_Pokemon.GainElementTypesSkillUp ();
			_Pokemon.LevelUpBonuses.Add (this);
		}
	}

	public class MaturityBonusGain : LevelUpBonus
	{
		public MaturityBonusGain (SkillTreeData _Tree,
			int _Level)
		{
			Description = "Gained Maturity Bonus On "+_Tree.Name;
			LevelGained = _Level;
		}
		public override void ApplyLevelBonus(Pokemon _Pokemon)
		{
			_Pokemon.GainMaturityPlusBonus ();
			_Pokemon.LevelUpBonuses.Add (this);
		}
	}


}

