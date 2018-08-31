using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public abstract class PokemonStat

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

//	public abstract T AddValues ()
//	{
//		
//	}

	public PokemonStat (int _RawValue)
	{
		RawValue = _RawValue;
	}

	public PokemonStat RollForStat (int _Roll)
	{
		switch (_Roll) 
		{
		case 0:
			return new AttackStat (1);
//			break;
		case 1:
			return new DefenseStat (1);
//			break;
		case 2:
			return new SpecialAttackStat (1);
//			break;
		case 3:
			return new SpecialDefenseStat (1);
//			break;
		case 4:
			return new SpeedStat (1);		
//			break;
		default:
			return null;
//			break;
		}
	}
		

	public static implicit operator int (PokemonStat ThisStat)
	{
		return ThisStat.RawValue;
	}

	public void SetRawValue (int NewValue)
	{
		RawValue = NewValue;
	}

	public T AddValues <T> (T Other) where T : PokemonStat
	{
		if (this.GetType ().Equals (Other.GetType ())) 
		{
			return (T) this.Create (RawValue + Other.RawValue);
		} 

		else 
		{
			Debug.Log ("Trying To Add Incompatible Stats");
			return null;		
		}	
	}

	public PokemonStat AddValues (PokemonStat Other)
	{
		if (this.GetType ().Equals (Other.GetType ())) 
		{
			return this.Create (RawValue + Other.RawValue);
		} 

		else 
		{
			Debug.Log ("Trying To Add Incompatible Stats");
			return null;		
		}	
	}

	protected abstract PokemonStat Create (int RawValue);
}

public class EnduranceStat: PokemonStatGeneric <EnduranceStat>
{
	protected override PokemonStat Create (int RawValue)
	{
		return new EnduranceStat (RawValue);
	}

	protected override int GetRoundedValue ()
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

	public EnduranceStat AddValues (EnduranceStat Other)
	{
		return (EnduranceStat)this.Create (RawValue + Other.RawValue);
	}
}

public class AttackStat: PokemonStatGeneric <AttackStat>
{

	protected override PokemonStat Create (int RawValue)
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

	public AttackStat AddValues (AttackStat Other)
	{
		return (AttackStat)this.Create (RawValue + Other.RawValue);
	}
}

public class DefenseStat: PokemonStatGeneric <DefenseStat>
{

	protected override PokemonStat Create (int RawValue)
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

	public DefenseStat AddValues (DefenseStat Other)
	{
		return (DefenseStat)this.Create (RawValue + Other.RawValue);
	}
}

public class SpecialAttackStat: PokemonStatGeneric <SpecialAttackStat>
{

	protected override PokemonStat Create (int RawValue)
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

	public SpecialAttackStat AddValues (SpecialAttackStat Other)
	{
		return (SpecialAttackStat)this.Create (RawValue + Other.RawValue);
	}
}

public class SpecialDefenseStat: PokemonStatGeneric <SpecialDefenseStat>
{
	protected override PokemonStat Create (int RawValue)
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

	public SpecialDefenseStat AddValues (SpecialDefenseStat Other)
	{
		return (SpecialDefenseStat) this.Create (RawValue + Other.RawValue);
	}
}

public class SpeedStat: PokemonStatGeneric <SpeedStat>
{
	protected override PokemonStat Create (int RawValue)
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

	public SpeedStat AddValues (SpeedStat Other)
	{
		return (SpeedStat) this.Create (RawValue + Other.RawValue);
	}
}

//public class TempStat: PokemonStatGeneric <TempStat>
//{
//
//	protected override PokemonStat Create (int RawValue)
//	{
//		return new TempStat (RawValue);
//	}
//	public TempStat (int RawValue) : base (RawValue)
//	{
//
//	}
//		
//}
	