using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public interface IStat 

{
//	private int RawValue;
////	private int XPCost;
//	private string StatName;
//	//private DicePool Dice;
//
//
//	protected int _RawValue
//	{ get { return RawValue; } }
//
//	void SetRawValue (int _RawValue);
//	{
//		RawValue = _RawValue;	
//	}
}


public abstract class PokemonStatGeneric <T> : PokemonStat where T : PokemonStat
{

	public PokemonStatGeneric (T Stat1, 
		T Stat2) : base (Stat1.ThisRawValue + Stat2.ThisRawValue)
	{
	}

	public PokemonStatGeneric (T Stat) : base (Stat.ThisRawValue)
	{
	}
		
}


public class ElementTypesSkill
{
	public ElementTypes Type;

	public ElementTypesSkill ()
	{
	}

	public ElementTypesSkill (ElementTypes _Type)
	{
		_Type = Type;
	}
}


