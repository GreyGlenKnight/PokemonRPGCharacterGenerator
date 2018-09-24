using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public interface ILevelUpOption : IChoosable
{
    SkillTree Tree { get;}
    string OptionName { get;}
	string BonusName { get;}
	string OptionDescription { get;}
	string OptionTutorial { get;}
	BonusAtIndex TypeOfBonus { get;}
	Sprite GetSymbolSprite { get;}
    Pokemon ThisPokemon { get; }
    LevelUpBonus BonusToApply { get; }
}

public abstract class LevelUpBonus : IHistoryItem, ILevelUpOption
{
    #region IOption implementation

    private SkillTree tree;
    public string Name { get { return _BonusName; } }
    public string Description { get { return OptionDescription; } }

    public SkillTree Tree {
		get { return tree;}
	}

	public string TreeName {
		get {return tree.Name;}
	}

	public string OptionName {
		get {return _Title;}
	}

	public string BonusName {
		get {return _BonusName;}
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

    public Pokemon ThisPokemon {
        get { return Tree.ThisPokemon; } 
    }

    public LevelUpBonus BonusToApply { get { return this; } }

    public void Choose () 
    {
        ThisPokemon.ApplyLevelBonus (BonusToApply);
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

	public string ItemName {
		get {return _BonusName;}
	}

	public string ItemDescription {
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

    public enum BonusState
	{
		Remaining,
		Acquired
	}

	public void SetBonusStateAcquired ()
	{
		State = BonusState.Acquired;
	}


	public abstract void ApplyLevelBonus ();

	public BonusState State = BonusState.Remaining;
    public Pokemon _Pokemon;
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
		private Technique _Technique;

		public TechniqueGain (SkillTree _Tree,
			Technique _TechniqueToAdd)
		{
			tree = _Tree;
			_Technique = _TechniqueToAdd;
//			_Name = "Learned: "+_TechniqueToAdd.Name;
			_BonusName = _TechniqueToAdd.Name+": ";
//			int Temp = _Tree.TechniquesOnTree.IndexOf (_TechniqueToAdd);
			_TypeOfBonus = BonusAtIndex.Technique;
//			Debug.Log ("The above is a hack, fix.");
			_OptionDescription = _TechniqueToAdd.Description+"";
			_TutorialDescription = "A Pokemon May Prepare Up to 5 Active Moves For Battle.";
			_TreeName = _Tree.Name;
			_HistoryDescription = "Gained Technique "+_TechniqueToAdd.Name+" On "+_TreeName;
		}
		public override void ApplyLevelBonus ()
		{
			SetBonusStateAcquired ();
			_Level = ThisPokemon.Level;
			_MaturityLevel = ThisPokemon.Maturity;
            ThisPokemon.GainTechnique(_Technique);
            ThisPokemon._HistoryBlock.LevelUpBonuses.Add (this);
		}
	}

	public class TechniqueModifierGain : LevelUpBonus
	{
		private TechniqueModifier _TechniqueModifier;
		
		public TechniqueModifierGain (SkillTree _Tree)
		{
			tree = _Tree;
			_TechniqueModifier = new TechniqueModifier ();
			//			_Name = "Learned: "+"";
			_TreeName = _Tree.Name;
			_BonusName = "Move Modifier: ";
			_TypeOfBonus = BonusAtIndex.MoveMod;
			_OptionDescription = "Move Modifier Description Here.";
			_TutorialDescription = "Move Modifiers Can Be Applied to Certain Moves to Augment Their Effects.";

			string ModName = "";
			_HistoryDescription = "Gained Technique Modifier "+ModName+" On "+_TreeName;
		}
		public override void ApplyLevelBonus()
		{
			SetBonusStateAcquired ();
			_Level = ThisPokemon.Level;
			_MaturityLevel = ThisPokemon.Maturity;
            ThisPokemon.GainTechniqueModifier (_TechniqueModifier);
            ThisPokemon._HistoryBlock.LevelUpBonuses.Add (this);
		}
	}

	public class AbilityGain : LevelUpBonus
	{
		private Ability _Ability;

		public AbilityGain (SkillTree _Tree)
		{
			tree = _Tree;
			_Ability = new Ability ();
			//			_Name = "Learned: "+"";
			_TreeName = _Tree.Name;
			_BonusName = "Ability: ";
			_TypeOfBonus = BonusAtIndex.Ability;
			_OptionDescription = "Ability Description Here.";
			_TutorialDescription = "Abilities Are Passive Bonuses or Special Actions Available to a Pokemon.";

			string AbilityName = "";
			_HistoryDescription = "Gained Ability "+AbilityName+" On "+_TreeName;
		}
		public override void ApplyLevelBonus()
		{
			SetBonusStateAcquired ();
			_Level = ThisPokemon.Level;
			_MaturityLevel = ThisPokemon.Maturity;

            ThisPokemon.GainAbility (_Ability);
            ThisPokemon._HistoryBlock.LevelUpBonuses.Add (this);
		}
	}

	public class StatGain : LevelUpBonus
	{
		private PokemonStat _Stat;

		public StatGain (SkillTree _Tree, 
			PokemonStat _StatToAdd)
		{
			tree = _Tree;
			_Stat = _StatToAdd;
//			string StatName = _Stat.ToString();
			_TreeName = _Tree.Name;
			_BonusName = "Stat Up: ";
			_TypeOfBonus = BonusAtIndex.StatUp;
			_OptionDescription = _Stat.ToString ();
			_TutorialDescription = "Gain a Bonus of +.5 to a Stat, Excluding Endurance. Roll 2d6, Default to the Tree's Favored Stat on a 6, and Choose from the Results.";

//			_Name = "Gained Stat Up: "+_Stat.ToString();
			_HistoryDescription = "Gained Stat Bonus To "+_Stat.ToString()+" On "+_TreeName;
		}
		public override void ApplyLevelBonus()
		{	
			SetBonusStateAcquired ();
			_Level = ThisPokemon.Level;
			_MaturityLevel = ThisPokemon.Maturity;

            ThisPokemon.GainStatUp (_Stat);
            ThisPokemon._HistoryBlock.LevelUpBonuses.Add (this);
		}
	}

	public class ElementTypesSkillGain : LevelUpBonus
	{
		private List <ElementTypesSkill> _ElementTypesSkills = new List <ElementTypesSkill> ();

		public ElementTypesSkillGain (SkillTree _Tree,
			List <ElementTypesSkill> _Types)
		{
			tree = _Tree;
			_ElementTypesSkills = _Types;
//			string SkillName = _Type.ToString();
			_TreeName = _Tree.Name;
			_BonusName = "Skill Up: ";
			_TypeOfBonus = BonusAtIndex.SkillUp;
			_OptionDescription = _Types [0].ToString();
			if (_Types.Count > 1)
			{
				_OptionDescription = _Types [0].ToString ()+", "+_Types [1].ToString ();
			}
			_TutorialDescription = "Pokemon Gains Incremental Ranks in the Indicated Elemental Skills. Increases Accuracy and Effectiveness for Moves of that Type.";

			_HistoryDescription = "Gained Skill Bonus To "+ _Types.ToString()+" On "+_TreeName;
		}
		public override void ApplyLevelBonus()
		{
			SetBonusStateAcquired ();
            _Level = ThisPokemon.Level;
			_MaturityLevel = ThisPokemon.Maturity;
            ThisPokemon.GainElementTypesSkillUp (_ElementTypesSkills);
            ThisPokemon._HistoryBlock.LevelUpBonuses.Add (this);
		}
	}

	public class MaturityBonusGain : LevelUpBonus
	{

		public MaturityBonusGain (SkillTree _Tree)
		{
			tree = _Tree;
			_TreeName = _Tree.Name;
			_BonusName = "Maturity Up: ";
			_TypeOfBonus = BonusAtIndex.Maturity;
			_OptionDescription = "Gain Maturity +1";
			_TutorialDescription = "Pokemon Gains a Maturity Rank. Hastens Evolution and Grants Access to Advanced Trees.";
			_HistoryDescription = "Gained Maturity Bonus On "+_TreeName;
		}
		public override void ApplyLevelBonus ()
		{
			SetBonusStateAcquired ();
			_Level = ThisPokemon.Level;
			_MaturityLevel = ThisPokemon.Maturity;

            ThisPokemon.GainMaturityPlusBonus ();
            ThisPokemon._HistoryBlock.LevelUpBonuses.Add (this);
		}
	}

	public class CrossTree : LevelUpBonus
	{
		public CrossTree (SkillTree _Tree)
		{
			tree = _Tree;
			//_Name = "Learned: "+_TechniqueToAdd.Name;
			_BonusName = "CrossTree"+": ";
			_TypeOfBonus = BonusAtIndex.CrossTree;
			_OptionDescription = "";
			_TutorialDescription = "If the Linked Cross Tree is Unlocked, Roll On It Instead For This Level.";
			_TreeName = _Tree.Name;
			_HistoryDescription = "";
		}
		public override void ApplyLevelBonus ()
		{
			_Level = ThisPokemon.Level;
			_MaturityLevel = ThisPokemon.Maturity;
		}
	}


	public class TreeUp : LevelUpBonus
	{
		public TreeUp (SkillTree _Tree)
		{
			tree = _Tree;
			//_Name = "Learned: "+_TechniqueToAdd.Name;
			_BonusName = "TreeUp"+": ";
			_TypeOfBonus = BonusAtIndex.TreeUp;
			_OptionDescription = "";
			_TutorialDescription = "If the Next Tier of This Tree is Unlocked, Roll On It Instead For This Level.";
			_TreeName = _Tree.Name;
			_HistoryDescription = "";
		}
		public override void ApplyLevelBonus ()
		{
			_Level = ThisPokemon.Level;
			_MaturityLevel = ThisPokemon.Maturity;
		}
	}
}

