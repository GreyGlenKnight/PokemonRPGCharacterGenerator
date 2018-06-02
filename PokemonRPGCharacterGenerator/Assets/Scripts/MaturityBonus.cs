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

	public string Name {
		get {return _Name;}
	}

	public string Description {
		get {return _Description;}
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
	private string _Name = "Maturity Bonus";
	private int _MaturityLevel;
	private int _Level;

    public class AbilitySlot : MaturityBonus
    {

		public AbilitySlot (int Maturity)
        {
			_Description = "Ability Slot: Ability Name";
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
			_Description = "Break Tree: "+GetTierString(_Tier)+" Tree Name";
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
			_Description = "Trade Skill: "+" Tree Name 1 For Tree Name 2";
			_Tier = Tier;
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
//			_Type = ElementTypes.Fire;
        }
        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
			_MaturityLevel = _Pokemon.Maturity;

            _Pokemon.GainSTABBonus();
			_Level = _Pokemon.Level;
			_Description = "Type Bonus: +1 "+TypeColors.GetStringForType(_Pokemon.Type1);

			if (_Pokemon.Type2 != ElementTypes.Nothing) 
			{
				_Description = "Type Bonus: +1 " + TypeColors.GetStringForType (_Pokemon.Type1)+", "+ TypeColors.GetStringForType (_Pokemon.Type2);
			}
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class NatureBonus : MaturityBonus
    {
		public NatureBonus(int Maturity, MyStat Stat)
        {
			_Description = "Nature Bonus: "+Stat.ToString();
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
			_Description = "Bonus Level: ";
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
		public ActiveSkill(int Maturity, int TreeSlot)
        {
			_TreeSlot = TreeSlot;

			_Description = "Active Skill Slot: "+(_TreeSlot+1).ToString();
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
			_Description = "Enhancer Slot: ";
//			_Name = "";

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
		public SpecialTraining(int Maturity)
        {
			_Description = "Special Training Slot: ";
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
