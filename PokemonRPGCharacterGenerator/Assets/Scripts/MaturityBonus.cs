using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MaturityBonus
{
    public abstract void ApplyBonus (PokemonClass Pokemon);

    public string Description;
//	public int BonusCounter;

    public class AbilitySlot : MaturityBonus
    {
		public AbilitySlot (int Maturity)
        {
			Description = this.ToString()+Maturity;
//			Debug.Log (BonusCounter);
        }
        public override void ApplyBonus(PokemonClass Pokemon)
        {
            Pokemon.GainAbilitySlot();
        }
    }

    public class BreakTree : MaturityBonus
    {
        public int BreakLevel;
		public BreakTree (int Maturity, int breakLevel)
        {
           BreakLevel = breakLevel;
			Description = this.ToString()+BreakLevel+Maturity;

        }
        public override void ApplyBonus(PokemonClass Pokemon)
        {
            Pokemon.BreakTree();
        }
    }

    public class TradeSkill : MaturityBonus
    {

		public TradeSkill (int Maturity)
        {
//			int treeLevel;
//			if (Maturity < 3)
//			{treeLevel = 1;}
//			if (Maturity == 3)
//			{treeLevel = 2;}
//			if (Maturity == 4)
//			{treeLevel = 2;}
//			if (Maturity > 4)
//			{treeLevel = 3;}
			Description = this.ToString()+Maturity;
        }
        public override void ApplyBonus(PokemonClass Pokemon)
        {
			Pokemon.PokemonTreeSwap();
        }
    }

    public class STABBonus : MaturityBonus
    {

		public STABBonus (int Maturity)
        {
			Description = this.ToString()+Maturity;
        }
        public override void ApplyBonus(PokemonClass Pokemon)
        {
            Pokemon.GainSTABBonus();
        }
    }

    public class NatureBonus : MaturityBonus
    {
		public NatureBonus(int Maturity)
        {
			Description = this.ToString() +Maturity;
        }

        public override void ApplyBonus(PokemonClass Pokemon)
        {
            Pokemon.GainNatureBonus();
        }
    }

    public class BonusLevel : MaturityBonus
    {

		public BonusLevel (int Maturity)
        {
			Description = this.ToString() +Maturity;
        }

        public override void ApplyBonus(PokemonClass Pokemon)
        {
            Pokemon.LevelUp();
//			Description = Description+(Pokemon.Maturity);
        }
    }

    public class ActiveSkill : MaturityBonus
    {

		public ActiveSkill(int Maturity)
        {
			Description = this.ToString() +Maturity;
        }

        public override void ApplyBonus(PokemonClass Pokemon)
        {
            Pokemon.GainActiveTreeBonus();
        }
    }

    public class EnhancerSlot : MaturityBonus
    {
		public EnhancerSlot(int Maturity)
        {
			Description = this.ToString() +Maturity;
        }

        public override void ApplyBonus(PokemonClass Pokemon)
        {
            
        }
    }

    public class SpecialTraining : MaturityBonus
    {
		public SpecialTraining(int Maturity)
        {
			Description = this.ToString() +Maturity;
        }

        public override void ApplyBonus(PokemonClass Pokemon)
        {

        }
    }

}
