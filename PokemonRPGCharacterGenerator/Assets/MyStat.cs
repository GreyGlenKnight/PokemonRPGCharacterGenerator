using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public abstract class MyStat 

{
	public int RawValue;
	protected virtual int GetRoundedValue ()
	{
		return (RawValue / 2);  
	}

	public int RoundedValue 
	{
		get {return (RawValue / 2);}
	}

	public MyStat (int _RawValue)
	{
		RawValue = _RawValue;
	}
		

	public static implicit operator int (MyStat ThisStat)
	{
		return ThisStat.RawValue;
	}

	public MyStat AddValues (MyStat Other)
	{
		if (this.GetType ().Equals (Other.GetType ())) 
		{
//			Debug.Log (RawValue+":"+Other.RawValue);

			return this.Create (RawValue + Other.RawValue);
		} 

		else 
		{
			Debug.Log ("Trying To Add Incompatible Stats");

			return new TempStat (0);
		}	

	}

	protected abstract MyStat Create (int RawValue);


}

public class EnduranceStat: MyStat
{
	protected override MyStat Create (int RawValue)

	{
		return new EnduranceStat (RawValue);
	}

	protected override int GetRoundedValue()

	{
		return RawValue;	
	}

	public override string ToString ()
	{
		return "Endurance";
	}

	public EnduranceStat (int RawValue) : base (RawValue)
	{

	}

	public static implicit operator EnduranceStat (int NewValue)
	{
		return new EnduranceStat (NewValue);
	}
}

public class AttackStat: MyStat
{

	protected override MyStat Create (int RawValue)
	{
		return new AttackStat (RawValue);
	}

	public override string ToString ()
	{
		return "Attack";
	}

	public AttackStat (int RawValue) : base (RawValue)
	{
		
	}

	public static implicit operator AttackStat (int NewValue)
	{
		return new AttackStat (NewValue);
	}
}

public class DefenseStat: MyStat
{

	protected override MyStat Create (int RawValue)
	{
		return new DefenseStat (RawValue);
	}

	public override string ToString ()
	{
		return "Defense";
	}

	public DefenseStat (int RawValue) : base (RawValue)
	{

	}

	public static implicit operator DefenseStat (int NewValue)
	{
		return new DefenseStat (NewValue);
	}
}

public class SpecialAttackStat: MyStat
{

	protected override MyStat Create (int RawValue)
	{
		return new SpecialAttackStat (RawValue);
	}

	public override string ToString ()
	{
		return "Special Attack";
	}

	public SpecialAttackStat (int RawValue) : base (RawValue)
	{

	}

	public static implicit operator SpecialAttackStat (int NewValue)
	{
		return new SpecialAttackStat (NewValue);
	}
}

public class SpecialDefenseStat: MyStat
{
	protected override MyStat Create (int RawValue)
	{
		return new SpecialDefenseStat (RawValue);
	}

//	public override int GetHashCode ()
//	{
//		return 5;
//	}

//	public override bool Equals (object Other)
//	{
//		SpecialDefenseStat Temp = Other as SpecialDefenseStat;
//		if (Temp == null) 
//		{return false;}
//		return true;
//	}

	public override string ToString ()
	{
		return "Special Defense";
	}

	public SpecialDefenseStat (int RawValue) : base (RawValue)
	{

	}

	public static implicit operator SpecialDefenseStat (int NewValue)
	{
		return new SpecialDefenseStat (NewValue);
	}
}

public class SpeedStat: MyStat
{
	protected override MyStat Create (int RawValue)
	{
		return new SpeedStat (RawValue);
	}

	public override string ToString ()
	{
		return "Speed";
	}

	public SpeedStat (int RawValue) : base (RawValue)
	{

	}

	public static implicit operator SpeedStat (int NewValue)
	{
		return new SpeedStat (NewValue);
	}
}

public class TempStat: MyStat
{
	protected override MyStat Create (int RawValue)
	{
		return new TempStat (RawValue);
	}
	public TempStat (int RawValue) : base (RawValue)
	{

	}
}
	