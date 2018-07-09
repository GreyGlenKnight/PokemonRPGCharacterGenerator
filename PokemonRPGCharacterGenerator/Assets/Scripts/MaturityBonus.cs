using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public abstract class MaturityBonus : IHistoryItem
{
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
		get {return _Description;}
	}

	public string TutorialDescription {
		get {return _TutorialDescription;}
	}

	public BonusType Type {
		get {return BonusType.MaturityBonus;}
	}

	public Sprite GetRepresentedSprite {
		get {throw new NotImplementedException ();}
	}

	#endregion

	public string GetTierString (SkillTreeTier _Tier)
	{
		switch (_Tier) 
		{	
		case SkillTreeTier.Tier0:
			return "Tier 0";
		case SkillTreeTier.Tier1:
			return "Tier 1";
		case SkillTreeTier.Tier2:
			return "Tier 2";
		case SkillTreeTier.Tier3:
			return "Tier 3";
		default:
			Debug.Log ("What Tier?");
			return "";
		}
	}

    public abstract void ApplyMaturityBonus (Pokemon _Pokemon);

	private string _Description;
	private string _Title = "Maturity Bonus";
	private string _BonusName;
	private string _TutorialDescription;
	private int _MaturityLevel;
	private int _Level;

    public class AbilitySlot : MaturityBonus
    {

		public AbilitySlot (int Maturity)
        {
			_BonusName = "Ability Slot:";
			_Description = "Ability Name";
			_TutorialDescription = "A Pokemon Can Have up to 3 Active Abilities. These Abilities Stack, and May Be Reassigned as New Abilities are Learned.";
//			_Name = "Maturity Bonus";
        }
			
        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
			_MaturityLevel = _Pokemon.Maturity;
            _Pokemon.GainAbilitySlot();
			_Level = _Pokemon.Level;
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class BreakTree : MaturityBonus
    {
		public SkillTreeTier _Tier;
		public BreakTree (int Maturity, SkillTreeTier _Tier)
        {
			this._Tier = _Tier;
			_BonusName = "Break Tree:";
			_Description = GetTierString(_Tier)+" Tree Name";
			_TutorialDescription = "A Break Tree Allows a Pokemon to Gain Level Up Bonuses on a Particular Tree, However it Does Not Mark the Tree as Active. Rolling An 11 or 12 on an Active Tree May Allow Access to a Specific Unlocked Tree.";
//			_Name = "Maturity Bonus";
        }
        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
//			Debug.Log (_Tier.ToString());
			_MaturityLevel = _Pokemon.Maturity;
			_Pokemon.GainBreakTree (_Tier);
			_Level = _Pokemon.Level;
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class TradeSkill : MaturityBonus
    {
		public SkillTreeTier _Tier;
		public TradeSkill (int Maturity, SkillTreeTier Tier)
        {
			_BonusName = "Trade Skill:";
			_Description = " Tree Name 1 For Tree Name 2";
			_Tier = Tier;
			_TutorialDescription = "Trade Skills Allow the Trainer to Choose Another Available Tree of the Indicated Tier or a Lesser Tier to Become Active. This Option May be Deferred for Several Levels, if Desired.";
//			_Name = "";
        }
        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
			_MaturityLevel = _Pokemon.Maturity;
			_Pokemon.SwapTrees(_Tier);
			_Level = _Pokemon.Level;
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class STABBonus : MaturityBonus
    {
		public STABBonus (int Maturity, ElementTypes _Type)
        {
			_BonusName = "Type Bonus:";
			_Description = TypeColors.GetStringForType(_Type)+"+1 ";
			_TutorialDescription = "The Pokemon Gains an Incremental +1 Bonus to Its Native Type or Types. These Bonuses Provide Extra Accuracy Dice When Certain Thresholds are Met.";
//			_Type = ElementTypes.Fire;
        }
        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
			_MaturityLevel = _Pokemon.Maturity;
            _Pokemon.GainSTABBonus();
			_Level = _Pokemon.Level;
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class NatureBonus : MaturityBonus
    {
		public NatureBonus(int Maturity, MyStat Stat)
        {
			_BonusName = "Nature Bonus:";
			_Description = Stat.ToString();
			_TutorialDescription = "This Pokemon Gains a +.5 Bonus to One of Its Stats. Each Stat Has an Equal Chance, and Need Not Match Prior Nature Bonuses.";
//			_Name = "";
        }

        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
			_MaturityLevel = _Pokemon.Maturity;
            _Pokemon.GainNatureBonus();
			_Level = _Pokemon.Level;
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class BonusLevel : MaturityBonus
    {

		public BonusLevel (int Maturity)
        {
			_BonusName = "Bonus Level:";
			_Description = "Level Up!";
			_TutorialDescription = "The Pokemon Gains the Required Experience For Another Level. This Level May Be Applied Immediately, If Desired.";
//			_Name = "";
        }

        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
			_MaturityLevel = _Pokemon.Maturity;
			_Pokemon.GainBonusLevel ();
			_Level = _Pokemon.Level;
			_Pokemon.MaturityBonuses.Add (this);
//			Description = Description+(Pokemon.Maturity);
        }
    }

    public class ActiveSkill : MaturityBonus
    {
		int _TreeSlot;
		public ActiveSkill (int Maturity, int TreeSlot)
        {
			_BonusName = "Active Skill Slot:";
			_TreeSlot = TreeSlot;
			_TutorialDescription = "At Each Level Up, Each of Up to 4 Active Trees are Rolled, and Their Bonuses May be Chosen By the Trainer.";
			_Description = "Tree "+(_TreeSlot+1).ToString();
//			_Name = "";
        }

        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
			_MaturityLevel = _Pokemon.Maturity;
			_Pokemon.GainActiveTreeBonus (_TreeSlot);
			_Level = _Pokemon.Level;
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class EnhancerSlot : MaturityBonus
    {
		public EnhancerSlot(int Maturity)
        {
			_BonusName = "Enhancer Slot:";
			_Description = "Allows One Enhancer Item Use. Gained at Maturity: "+Maturity;
			_TutorialDescription = "Enhancer Slots Allow for the Use of Certain Items on a Pokemon Outside of Battle, Such as Permanent Stat Increasing Supplements. Each Slot Allows One Use, and May Not Be Reassigned.";
        }

        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
			_MaturityLevel = _Pokemon.Maturity;
			_Pokemon.GainEnhancerSlotBonus ();
			_Level = _Pokemon.Level;
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class SpecialTraining : MaturityBonus
    {
		public SpecialTraining (int Maturity)
        {
			_BonusName = "Special Training:";
			_Description = "Allows This Pokemon to Undergo Special Training. Gained at Maturity: "+Maturity;
			_Description = "Allows One Enhancer Item Use. Gained at Maturity: "+Maturity;
			_TutorialDescription = "Special Training May Include the Use of TMs or Move Tutors Outside of Battle, as Well as Potentially Unique Bonuses. Each Slot Allows One Use, and May Not Be Reassigned.";
//			_Name = "";
        }

        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
			_MaturityLevel = _Pokemon.Maturity;
			_Pokemon.GainSpecialTrainingBonus ();
			_Level = _Pokemon.Level;
			_Pokemon.MaturityBonuses.Add (this);
        }
    }
}
