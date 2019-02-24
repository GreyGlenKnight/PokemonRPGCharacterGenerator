using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;

public enum AttackRange
{
	Self,
	Melee,
	Charge,
	Ranged,
	Sniper,
	Environmental,
	Ally
}

public class Technique : IChoosable
{
    #region IChoosable implementation

    public string Name { get { return TechniqueName; } }
    public string Description { get { return TechniqueDescription; } }
    public void Choose () { return; }

    #endregion

    public string DisplayRange = "";
    public string TechniqueDescription = "";

    public string TechniqueName;
    public int BaseStrain;
    public SkillTreeTier Tier;
    public List<PokemonStat> StatsUsed = new List<PokemonStat>();

    public int BaseDamage;
    public ElementTypes Type;
    public AttackRange Range;
    public int BaseAccuracy;
    //		public list of effects

	public Technique ()
	{

	}

    public Technique (TechniqueStringParams Tokens)
    {
        Tokens.GetTechnique();
    }

public static Technique Fire_Blast ()
	{
		Technique Temp = new Technique ();
		Temp.BaseAccuracy = -1;
		Temp.BaseDamage = 11;
		Temp.BaseStrain = 4;
		Temp.TechniqueDescription = "A fiery runic symbol strikes the foe, inflicting heavy damage and burn.";
		Temp.DisplayRange = "Ranged";
		Temp.TechniqueName = "Fire Blast";
		Temp.StatsUsed.Add (new SpecialAttackStat (0));
		Temp.Type = ElementTypes.Fire;
		return Temp;
	}

	public static Technique Dragon_Claw ()
	{
		Technique Dragon_Claw = new Technique ();
		Dragon_Claw.BaseAccuracy = 1;
		Dragon_Claw.BaseDamage = 8;
		Dragon_Claw.BaseStrain = 3;
		Dragon_Claw.TechniqueDescription = "The foe is ravaged by a mighty swipe of the pokemon’s claws.";
		Dragon_Claw.DisplayRange = "Melee";
		Dragon_Claw.TechniqueName = "Dragon Claw";
		Dragon_Claw.StatsUsed.Add (new AttackStat (0));
		Dragon_Claw.Type = ElementTypes.Dragon;
		return Dragon_Claw;
	}

	public static Technique Metal_Claw ()
	{
		Technique Metal_Claw = new Technique ();
		Metal_Claw.BaseAccuracy = 0;
		Metal_Claw.BaseDamage = 5;
		Metal_Claw.BaseStrain = 2;
		Metal_Claw.TechniqueDescription = "The pokemon gouges the opponent with a set of merciless claws. May raise Attack.";
		Metal_Claw.DisplayRange = "Melee";
		Metal_Claw.TechniqueName = "Metal Claw";
		Metal_Claw.StatsUsed.Add (new AttackStat (0));
		Metal_Claw.Type = ElementTypes.Steel;
		return Metal_Claw;
	}

	public static Technique Sand_Attack ()
	{
		Technique Sand_Attack = new Technique ();
		Sand_Attack.BaseAccuracy = 1;
		Sand_Attack.BaseStrain = 3;
		Sand_Attack.TechniqueDescription = "Norris always teaches his pokemon to be prepared for snakes.";
		Sand_Attack.DisplayRange = "Ranged";
		Sand_Attack.TechniqueName = "Sand Attack";
		Sand_Attack.StatsUsed.Add (new DefenseStat (0));
		Sand_Attack.StatsUsed.Add (new SpeedStat (0));
		Sand_Attack.Type = ElementTypes.Ground;
		return Sand_Attack;
	}

	public static List <Technique> ExampleTechniquesOnTree ()
	{
		List <Technique> _TechniquesOnTree = new List <Technique> ();
		_TechniquesOnTree.Add (Fire_Blast ());
		_TechniquesOnTree.Add (Dragon_Claw ());
		_TechniquesOnTree.Add (Metal_Claw ());
		_TechniquesOnTree.Add (Sand_Attack ());
		return _TechniquesOnTree;
	}


    //public void SetTechniqueDescription(string Value) { TechniqueDescription = Value; }
    public void SetDisplayRange (string Value) { DisplayRange = Value; }
    public void SetTechniqueName (string Value) { TechniqueName = Value; }
    public void SetBaseStrain (string Value) { BaseStrain = Int32.Parse(Value); }
    public void SetSkillTreeTier (string Value) { Tier = (SkillTreeTier) Int32.Parse (Value); }
   // public void SetStatsUsed(string Value) { StatsUsed = Int32.Parse (Value); }

    public void SetBaseDamage (string Value) { BaseDamage = Int32.Parse (Value); }

    public void SetType (string Value) { Type = (ElementTypes) Enum.Parse (typeof (ElementTypes), Value); }
    public void SetRange (string Value) { Range = (AttackRange) Enum.Parse (typeof (AttackRange), Value); DisplayRange = Value;}
    public void SetBaseAccuracy (string Value) { BaseAccuracy = Int32.Parse (Value); }
    }

    public class TechniqueStringParams
    {
        public Technique Target = new Technique();
        public string [] Tokens;

        public TechniqueStringParams (string [] tokens)
        {
            //if (Tokens.Length != 35)
            //{ throw new Exception(); }
            //else
            {
                Tokens = tokens;
            Target.SetTechniqueName(Tokens[0]);
            Target.SetBaseStrain(Tokens[1]);
            Target.SetSkillTreeTier(Tokens[2]);
           // Target.SetStatsUsed(Tokens[3]);
            Target.SetBaseDamage(Tokens[4]);
            Target.SetType(Tokens[5]);
            Target.SetRange(Tokens[6]);
            Target.SetBaseAccuracy(Tokens[7]);
            }
        }

        public Technique GetTechnique()
        { return Target; }

    }


