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
	public List <MyStat> StatsUsed = new List <MyStat> ();
//		public list of effects

	public Technique ()
		{


		}
	}


