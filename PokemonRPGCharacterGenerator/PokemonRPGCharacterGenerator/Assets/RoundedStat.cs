using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class RoundedStat : IStat
{
	
	private int _RawValue;
	private string _StatName;

	public string StatName
	{get {return _StatName;}}

	public int RawValue 
	{get {return _RawValue;}}

	public int RoundedValue 
	{get {return _RawValue / 2;}}

	public RoundedStat (string Name)
	{
		_StatName = Name;
	}

	public void SetValue (int NewValue)
	{
		_RawValue = NewValue;
	}

	public RoundedStat Add (RoundedStat Stat1, RoundedStat Stat2)
	{
		if (Stat1.StatName == Stat2.StatName)
		{
			RoundedStat ToReturn = new RoundedStat (Stat1.StatName);
			ToReturn.SetValue (Stat1.RawValue + Stat2.RawValue);
			return ToReturn;
		}
		else 
		{
			Debug.Log ("Trying To Add Incompatible Stats");

			return null;		
		}
	}
}

