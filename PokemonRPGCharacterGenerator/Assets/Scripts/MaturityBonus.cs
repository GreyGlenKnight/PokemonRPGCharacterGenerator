using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MaturityBonus
{
    public abstract void ApplyBonus (Pokemon _Pokemon);

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
        public override void ApplyBonus(Pokemon _Pokemon)
        {
            _Pokemon.GainAbilitySlot();
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class BreakTree : MaturityBonus
    {
        public int BreakLevel;
		public BreakTree (int Maturity, int breakLevel)
        {
        	BreakLevel = breakLevel;
			LevelGained = Maturity;
			Description = this.ToString()+BreakLevel+LevelGained;
        }
        public override void ApplyBonus(Pokemon _Pokemon)
        {
//			Debug.Log (LevelGained+Description);
			_Pokemon.GainBreakTree ();
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

    public class TradeSkill : MaturityBonus
    {

		public TradeSkill (int Maturity)
        {
			Description = this.ToString()+Maturity;
			LevelGained = Maturity;
        }
        public override void ApplyBonus(Pokemon _Pokemon)
        {
			_Pokemon.SwitchTrees();
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
        public override void ApplyBonus(Pokemon _Pokemon)
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

        public override void ApplyBonus(Pokemon _Pokemon)
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

        public override void ApplyBonus(Pokemon _Pokemon)
        {
			_Pokemon.GainBonusLevel ();
			_Pokemon.MaturityBonuses.Add (this);
//			Description = Description+(Pokemon.Maturity);
        }
    }

    public class ActiveSkill : MaturityBonus
    {

		public ActiveSkill(int Maturity)
        {
			Description = this.ToString() +Maturity;
			LevelGained = Maturity;
        }

        public override void ApplyBonus(Pokemon _Pokemon)
        {
			_Pokemon.GainActiveTreeBonus ();
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

        public override void ApplyBonus(Pokemon _Pokemon)
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

        public override void ApplyBonus(Pokemon _Pokemon)
        {
			_Pokemon.GainSpecialTrainingBonus ();
			_Pokemon.MaturityBonuses.Add (this);
        }
    }

}
