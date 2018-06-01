using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MaturityBonus
{
    public abstract void ApplyMaturityBonus (Pokemon _Pokemon);

    public string Description;
	public int LevelGained;
//	public int BonusCounter;

    public class AbilitySlot : MaturityBonus
    {
		public AbilitySlot (int Maturity)
        {
			Description = this.ToString()+Maturity;
			LevelGained = Maturity;
//			Debug.Log (BonusCounter);
        }
        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
            _Pokemon.GainAbilitySlot();
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class BreakTree : MaturityBonus
    {
		public SkillTreeTier _Tier;
		public BreakTree (int Maturity, SkillTreeTier _Tier)
        {
			LevelGained = Maturity;
			this._Tier = _Tier;
			Description = this.ToString()+_Tier.ToString()+LevelGained;
        }
        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
//			Debug.Log (LevelGained+Description);
			Debug.Log (_Tier.ToString());

			_Pokemon.GainBreakTree (_Tier);
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class TradeSkill : MaturityBonus
    {
		public SkillTreeTier _Tier;
		public TradeSkill (int Maturity, SkillTreeTier Tier)
        {
			Description = this.ToString()+Maturity;
			LevelGained = Maturity;
			_Tier = Tier;
        }
        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
			_Pokemon.SwapTrees(_Tier);
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class STABBonus : MaturityBonus
    {
		public STABBonus (int Maturity)
        {
			Description = this.ToString()+Maturity;
			LevelGained = Maturity;
        }
        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
            _Pokemon.GainSTABBonus();
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class NatureBonus : MaturityBonus
    {
		public NatureBonus(int Maturity)
        {
			Description = this.ToString() +Maturity;
			LevelGained = Maturity;
        }

        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
            _Pokemon.GainNatureBonus();
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class BonusLevel : MaturityBonus
    {

		public BonusLevel (int Maturity)
        {
			Description = this.ToString() +Maturity;
			LevelGained = Maturity;
        }

        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
			_Pokemon.GainBonusLevel ();
			_Pokemon.MaturityBonuses.Add (this);
//			Description = Description+(Pokemon.Maturity);
        }
    }

    public class ActiveSkill : MaturityBonus
    {
		int _TreeSlot;
		public ActiveSkill(int Maturity, int TreeSlot)
        {
			Description = this.ToString() +Maturity;
			LevelGained = Maturity;
			_TreeSlot = TreeSlot;
        }

        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
			_Pokemon.GainActiveTreeBonus (_TreeSlot);
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class EnhancerSlot : MaturityBonus
    {
		public EnhancerSlot(int Maturity)
        {
			Description = this.ToString() +Maturity;
			LevelGained = Maturity;
        }

        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
			_Pokemon.GainEnhancerSlotBonus ();
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class SpecialTraining : MaturityBonus
    {
		public SpecialTraining(int Maturity)
        {
			Description = this.ToString() +Maturity;
			LevelGained = Maturity;
        }

        public override void ApplyMaturityBonus(Pokemon _Pokemon)
        {
			_Pokemon.GainSpecialTrainingBonus ();
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

}
