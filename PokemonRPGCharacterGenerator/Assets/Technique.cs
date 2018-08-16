using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public enum AttackRange
{
	Self,
	Melee,
	Charge,
	Ranged,
	Sniper
}

	public class Technique
{
	public AttackRange Range;
	public string DisplayRange;
	public string Name;
	public string Description;
	public List <ElementTypes> Types = new List <ElementTypes> ();
	public int BaseDamage;
	public int BaseStrain;
	public int BaseAccuracy;
	public List <PokemonStat> StatsUsed = new List <PokemonStat> ();
	public SkillTreeTier Tier;

//		public list of effects

	public Technique ()
	{
	}

	public static Technique Fire_Blast ()
	{
		Technique Temp = new Technique ();
		Temp.BaseAccuracy = -1;
		Temp.BaseDamage = 11;
		Temp.BaseStrain = 4;
		Temp.Description = "A fiery runic symbol strikes the foe, inflicting heavy damage and burn.";
		Temp.DisplayRange = "Ranged";
		Temp.Name = "Fire Blast";
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
		Dragon_Claw.Description = "The foe is ravaged by a mighty swipe of the pokemon’s claws.";
		Dragon_Claw.DisplayRange = "Melee";
		Dragon_Claw.Name = "Dragon Claw";
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
		Metal_Claw.Description = "The pokemon gouges the opponent with a set of merciless claws. May raise Attack.";
		Metal_Claw.DisplayRange = "Melee";
		Metal_Claw.Name = "Metal Claw";
		Metal_Claw.StatsUsed.Add (new AttackStat (0));
		Metal_Claw.Types.Add (ElementTypes.Steel);
		return Metal_Claw;
	}

	public static Technique Sand_Attack ()
	{
		Technique Sand_Attack = new Technique ();
		Sand_Attack.BaseAccuracy = 1;
		Sand_Attack.BaseStrain = 3;
		Sand_Attack.Description = "Norris always teaches his pokemon to be prepared for snakes.";
		Sand_Attack.DisplayRange = "Ranged";
		Sand_Attack.Name = "Sand Attack";
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


