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
	Sniper
}

public class Technique : IChoosable
{
    #region IChoosable implementation

    public string Name { get { return TechniqueName; } }
    public string Description { get { return TechniqueDescription; } }
    public void Choose() { return; }

    #endregion

    public string DisplayRange = "";
    public string TechniqueDescription = "";

    public string TechniqueName;
    public int BaseStrain;
    public SkillTreeTier Tier;
    public List<PokemonStat> StatsUsed = new List<PokemonStat>();

    public int BaseDamage;
    public List<ElementTypes> Types = new List<ElementTypes>();
    public AttackRange Range;
    public int BaseAccuracy;
    //		public list of effects

    public string Effect1;
    public string Modifier1;
    public string Modifier2;
    public string Trigger1Func;
    public string Trigger1Mod1;
    public string Trigger1Mod2;
    public string Trigger2Func;
    public string Trigger2Mod1;
    public string Trigger2Mod2;
    public string Effect2;
    public string Modifier2;
    public string Modifier2;
    public string Trigger1Func;
    public string Trigger1Mod1;
    public string Trigger1Mod1;
    public string Trigger2;
    public string Trigger2Mod;
    public string Trigger2Mod2;
    public string Effect3;
    public string Modifier3;
    public string Modifier2;
    public string Trigger1;
    public string Trigger1Mod;
    public string Trigger2Mod2;
    public string Trigger2;
    public string Trigger2Mod2;
    public string Trigger2Mod;

    //public void SetTechniqueDescription(string Value) { TechniqueDescription = Value; }
    public void SetDisplayRange(string Value) { DisplayRange = Value; }
    public void SetTechniqueName(string Value) { TechniqueName = Value; }
    public void SetBaseStrain(string Value) { BaseStrain = Value; }
    public void SetSkillTreeTier(string Value) { SkillTreeTier = Value; }
    public void SetStatsUsed(string Value) { StatsUsed = Value; }

    public void SetBaseDamage(string Value) { BaseDamage = Value; }
    public void SetTypes(string Value) { Types = Value; }
    public void SetRange(string Value) { Range = Value; }
    public void SetBaseAccuracy(string Value) { BaseAccuracy = Value; }
    public void SetEffect1(string Value) {
        if ((Value == null) == true)
        {
            throw new Exception();
        }
        else Effect1 = Value; }
    public void SetModifier1(string Value) {
        if ((Value == null) == true)
        {
            throw new Exception();
        }
        else Modifier1 = Value; }
    public void SetModifier2(string Value) {
        if ((Value == null) == true)
        {
            throw new Exception();
        }
        else Modifier2 = Value; }
    public void SetTrigger1Func(string Value) {
        if ((Value == null) == true)
        {
            throw new Exception();
        }
        else Trigger1Func = Value; }
    public void SetTrigger1Mod1(string Value) {
        if ((Value == null) == true)
        {
            throw new Exception();
        }
        else Trigger1Mod1 = Value; }
    public void SetTrigger1Mod2(string Value) {
        if ((Value == null) == true)
        {
            throw new Exception();
        }
        else Trigger1Mod2 = Value; }
    public void SetTrigger2Func(string Value) {
        if ((Value == null) == true)
        {
            throw new Exception();
        }
        else Trigger2Func = Value; }
    public void SetTrigger2Mod1(string Value) {
        if ((Value == null) == true)
        {
            throw new Exception();
        }
        else Trigger2Mod1 = Value; }
    public void SetTrigger2Mod2(string Value) {
        if ((Value == null) == true)
        {
            throw new Exception();
        }
        else Trigger2Mod2 = Value; }
    public void SetEffect2(string Value) {
        if ((Value == null) == true)
        { throw new Exception();
        }
        else { Modifier2 = Value; }
    public void SetTrigger1Func(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Trigger1Func = Value; }
    public void SetTrigger1Mod1(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Trigger1Mod1 = Value; }
    public void SetTrigger1Mod1(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Trigger1Mod1 = Value; }
    public void SetTrigger2(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Trigger2 = Value; }
    public void SetTrigger2Mod(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Trigger2Mod = Value; }
    public void SetTrigger2Mod2(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Trigger2Mod2 = Value; }
    public void SetEffect3(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Effect3 = Value; }
    public void SetModifier3(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Modifier3 = Value; }
    public void SetModifier2(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Modifier2 = Value; }
    public void SetTrigger1(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Trigger1 = Value; }
    public void SetTrigger1Mod(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Trigger1Mod = Value; }
    public void SetTrigger2Mod2(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Trigger2Mod2 = Value; }
    public void SetTrigger2(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Trigger2 = Value; }
    public void SetTrigger2Mod2(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Trigger2Mod2 = Value; }
    public void SetTrigger2Mod(string Value) {
            if ((Value == null) == true)
            { throw new Exception();
            }
            else Trigger2Mod = Value; }

    public Technique ()
	{
	}

    public Technique (TechniqueStringParams Tokens)
    {
            return Tokens.GetTechnique();
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
		Temp.Types.Add (ElementTypes.Fire);
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
		Dragon_Claw.Types.Add (ElementTypes.Dragon);
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
		Metal_Claw.Types.Add (ElementTypes.Steel);
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
		Sand_Attack.Types.Add (ElementTypes.Ground);
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
}

    public class TechniqueStringParams
    {
        public Technique Target = new Technique();
        public string [] Tokens;

        public TechniqueStringParams (string [] tokens)
        {


            if (Tokens.Length != 35)
            { throw new Exception(); }
            else
            {
                Tokens = tokens;
                Target.SetTechniqueName(Tokens[0])
                Target.SetBaseStrain(Tokens[1])
                Target.SetSkillTreeTier(Tokens[2])
                Target.SetStatsUsed(Tokens[3])
                Target.SetBaseDamage(Tokens[4])
                Target.SetTypes(Tokens[5])
                Target.SetRange(Tokens[6])
                Target.SetBaseAccuracy(Tokens[7])
                Target.SetEffect1(Tokens[8];
                Target.SetModifier1(Tokens[9];
                Target.SetModifier2(Tokens[10];
                Target.SetTrigger1Func(Tokens[11];
                Target.SetTrigger1Mod1(Tokens[12];
                Target.SetTrigger1Mod2(Tokens[13];
                Target.SetTrigger2Func(Tokens[14];
                Target.SetTrigger2Mod1(Tokens[15];
                Target.SetTrigger2Mod2(Tokens[16];
                Target.SetEffect2(Tokens[17];
                Target.SetModifier2(Tokens[18];
                Target.SetModifier2(Tokens[19];
                Target.SetTrigger1Func(Tokens[20];
                Target.SetTrigger1Mod1(Tokens[21];
                Target.SetTrigger1Mod1(Tokens[22];
                Target.SetTrigger2(Tokens[23];
                Target.SetTrigger2Mod(Tokens[24];
                Target.SetTrigger2Mod2(Tokens[25];
                Target.SetEffect3(Tokens[26];
                Target.SetModifier3(Tokens[27];
                Target.SetModifier2(Tokens[28];
                Target.SetTrigger1(Tokens[29];
                Target.SetTrigger1Mod(Tokens[30];
                Target.SetTrigger2Mod2(Tokens[31];
                Target.SetTrigger2(Tokens[32];
                Target.SetTrigger2Mod2(Tokens[33];
                Target.SetTrigger2Mod(Tokens[34];
            }
        }

        public Technique GetTechnique()
        { return Target; }

    }
}


