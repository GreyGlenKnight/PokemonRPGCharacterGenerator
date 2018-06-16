using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public interface IOption
{
	string TreeName { get;}
	string OptionName { get;}
	string OptionDescription { get;}
	string OptionTutorial { get;}
	BonusAtIndex TypeOfBonus { get;}
	Sprite GetSymbolSprite { get;}
}

public abstract class LevelUpBonus : IHistoryItem, IOption
{
	#region IOption implementation

	public string TreeName {
		get {return _TreeName;}
	}

	public string OptionName {
		get {return _Title;}
	}

	public string OptionDescription {
		get {return _OptionDescription;}
	}

	public string OptionTutorial {
		get {return _TutorialDescription;}
	}

	public BonusAtIndex TypeOfBonus {
		get {return _TypeOfBonus;}
	}

	public Sprite GetSymbolSprite {
		get {
			throw new NotImplementedException ();
		}
	}

	#endregion
	
	#region IHistoryItem implementation

	public int LevelGained {
		get {return _Level;}
	}

	public int MaturityLevel {
		get {return _MaturityLevel;}
	}

	public string Title {
		get {return _Title;}
	}

	public string Name {
		get {return _BonusName;}
	}

	public string Description {
		get {return _HistoryDescription;}
	}
		
	public string TutorialDescription {
		get {return _TutorialDescription;}
	}

	public BonusType Type {
		get {return BonusType.LevelUp;}
	}

	public Sprite GetRepresentedSprite {
		get {throw new NotImplementedException ();}
	}

	#endregion


	public abstract void ApplyLevelBonus (Pokemon _Pokemon);

	private string _HistoryDescription;
	private string _OptionDescription;
	private string _TutorialDescription;
	private string _BonusName;
	private BonusAtIndex _TypeOfBonus;
	private string _Title = "Level Up: ";
	private int _Level;
	private int _MaturityLevel;
	private string _TreeName;

	public class TechniqueGain : LevelUpBonus
	{
		public TechniqueGain (SkillTreeData _Tree,
			Technique _TechniqueToAdd)
		{
//			_Name = "Learned: "+_TechniqueToAdd.Name;
			_BonusName = _TechniqueToAdd.Name+": ";
			int Temp = _Tree.TechniquesOnTree.IndexOf (_TechniqueToAdd);
			_TypeOfBonus = (BonusAtIndex) Temp;
			Debug.Log ("The above is a hack, fix.");
			_OptionDescription = _TechniqueToAdd.Description+"";
			_TutorialDescription = "A Pokemon May Prepare Up to 5 Active Moves For Battle.";
			_TreeName = _Tree.Name;
			_HistoryDescription = "Gained Technique "+_TechniqueToAdd.Name+" On "+_TreeName;
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
			_TreeName = _Tree.Name;
			_BonusName = "Move Modifier: ";
			_TypeOfBonus = BonusAtIndex.MoveMod;
			_OptionDescription = "Move Modifier Description Here.";
			_TutorialDescription = "Move Modifiers Can Be Applied to Certain Moves to Augment Their Effects.";

			string ModName = "";
			_HistoryDescription = "Gained Technique Modifier "+ModName+" On "+_TreeName;
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
			_TreeName = _Tree.Name;
			_BonusName = "Ability: ";
			_TypeOfBonus = BonusAtIndex.Ability;
			_OptionDescription = "Ability Description Here.";
			_TutorialDescription = "Abilities Are Passive Bonuses or Special Actions Available to a Pokemon.";

			string AbilityName = "";
			_HistoryDescription = "Gained Ability "+AbilityName+" On "+_TreeName;
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
			_TreeName = _Tree.Name;
			_BonusName = "Stat Up: ";
			_TypeOfBonus = BonusAtIndex.StatUp;
			_OptionDescription = _Stat.ToString();
			_TutorialDescription = "Gain a Bonus of +.5 to a Stat, Excluding Endurance. Roll 2d6, Default to the Tree's Favored Stat on a 6, and Choose from the Results.";

//			_Name = "Gained Stat Up: "+_Stat.ToString();
			_HistoryDescription = "Gained Stat Bonus To "+_Stat.ToString()+" On "+_TreeName;
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
			List <ElementTypes> _Types)
		{
//			string SkillName = _Type.ToString();
			_TreeName = _Tree.Name;
			_BonusName = "Skill Up: ";
			_TypeOfBonus = BonusAtIndex.SkillUp;
			Debug.Log ("I made the quick change to a list of types rather than one, needs fixing");
			_OptionDescription = _Types.ToString();
			_TutorialDescription = "Pokemon Gains Incremental Ranks in the Indicated Elemental Skills. Increases Accuracy and Effectiveness for Moves of that Type.";

			_HistoryDescription = "Gained Skill Bonus To "+ _Types.ToString()+" On "+_TreeName;
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
			_TreeName = _Tree.Name;
			_BonusName = "Maturity Up: ";
			_TypeOfBonus = BonusAtIndex.Maturity;
			_OptionDescription = "Gain Maturity +1";
			_TutorialDescription = "Pokemon Gains a Maturity Rank. Hastens Evolution and Grants Access to Advanced Trees.";
			_HistoryDescription = "Gained Maturity Bonus On "+_TreeName;
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

