using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public abstract class NewStat 

{
	private int RawValue;
//	private int XPCost;
	private string StatName;
	//private DicePool Dice;

	public NewStat ()
	{
	}

	public void SetRawValue (int _RawValue)
	{
		RawValue = _RawValue;	
	}


//	public static List <NewStat> RollStatChoices (NewStat _FavoredStat)
//	{
//		List <NewStat> ToReturn = new List <NewStat> ();
//		int _Roll1 = UnityEngine.Random.Range (0, 6);
//		Debug.Log (_Roll1);
//		NewStat StatToAdd = RollForStat (_Roll1);
//
//		if (StatToAdd == null) 
//		{
//			StatToAdd = _FavoredStat;
//		}
//
//		ToReturn.Add (StatToAdd);
//
//		int _Roll2 = UnityEngine.Random.Range (0, 6);
//		Debug.Log (_Roll2);
//		NewStat StatToAdd2 = RollForStat (_Roll2);
//
//		if (StatToAdd2 == null) 
//		{
//			StatToAdd2 = _FavoredStat;
//		}
//
//		ToReturn.Add (StatToAdd2);
//		return ToReturn;
//	}


}

public class ValueStat: NewStat
{
	private int _RawValue;
	private string _StatName;

	public string StatName
	{get {return _StatName;}}

	public int RawValue
	{get {return _RawValue;}}

	public ValueStat (string Name)
	{
		_StatName = Name;
	}


	public void SetValue (int NewValue)
	{
		_RawValue = NewValue;
	} 

	public ValueStat Add (ValueStat Stat1, ValueStat Stat2)
	{
		if (Stat1.StatName == Stat2.StatName)
		{
			ValueStat ToReturn = new ValueStat (Stat1.StatName);
			ToReturn.SetRawValue (Stat1.RawValue + Stat2.RawValue);
			return ToReturn;
		}
		else 
		{
			Debug.Log ("Trying To Add Incompatible Stats");

			return null;		
		}
	}
}



public class ElementTypesSkill: NewStat 
{
	private ElementTypes ElementType;
	private int RawValue;

//	public int RoundedValue
//	{
//		get {
//			return switch statement for triangular numbers;}
//	}

	public string Name 
	{
		get {return TypeColors.GetStringForType (ElementType);}
	}

	public ElementTypesSkill (ElementTypes _Type)
	{
		ElementType = _Type;
	}
}

public class TrainerStat: NewStat
{
	private string Name;
	private int RawValue;

	public TrainerStat (string _Name)
	{
		Name = _Name;
	}
}

public class TrainerSkill: NewStat
{
	private TrainerStat FavoredStat;
	private String Name;
	private int RawValue;

	public TrainerSkill (string _Name, TrainerStat _FavoredStat)
	{
		Name = _Name;
		FavoredStat = _FavoredStat;
	}
}

public class TrainerPerk: NewStat
{
	private String Name;
	private int RawValue;

	public TrainerPerk (string _Name)
	{
		Name = _Name;
	}
}

