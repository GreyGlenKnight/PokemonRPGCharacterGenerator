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
        public AbilitySlot ()
        {
				Description = this.ToString();
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
        public BreakTree (int breakLevel)
        {
           BreakLevel = breakLevel;
           Description = this.ToString()+BreakLevel;

        }
        public override void ApplyBonus(PokemonClass Pokemon)
        {
            Pokemon.BreakTree();
        }
    }

    public class TradeSkill : MaturityBonus
    {

        public TradeSkill()
        {
            Description = this.ToString();
        }
        public override void ApplyBonus(PokemonClass Pokemon)
        {
            Pokemon.PokemonTreeSwap();
        }
    }

    public class STABBonus : MaturityBonus
    {

        public STABBonus()
        {
            Description = this.ToString();
        }
        public override void ApplyBonus(PokemonClass Pokemon)
        {
            Pokemon.GainSTABBonus();
        }
    }

    public class NatureBonus : MaturityBonus
    {
        public NatureBonus()
        {
            Description = this.ToString();
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
			Description = this.ToString() + Maturity;
        }

        public override void ApplyBonus(PokemonClass Pokemon)
        {
            Pokemon.LevelUp();
//			Description = Description+(Pokemon.Maturity);
        }
    }

    public class ActiveSkill : MaturityBonus
    {

        public ActiveSkill()
        {
            Description = this.ToString();
        }

        public override void ApplyBonus(PokemonClass Pokemon)
        {
            Pokemon.GainActiveTreeBonus();
        }
    }

    public class EnhancerSlot : MaturityBonus
    {
        public EnhancerSlot()
        {
            Description = this.ToString();
        }

        public override void ApplyBonus(PokemonClass Pokemon)
        {
            
        }
    }

    public class SpecialTraining : MaturityBonus
    {
        public SpecialTraining()
        {
            Description = this.ToString();
        }

        public override void ApplyBonus(PokemonClass Pokemon)
        {

        }
    }

}
