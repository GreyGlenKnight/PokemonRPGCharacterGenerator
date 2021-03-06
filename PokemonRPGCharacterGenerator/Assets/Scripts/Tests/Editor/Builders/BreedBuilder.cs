﻿using System;

public class BreedBuilder: TestDataBuilder<Pokemon.Breed>

{
	public int EnduranceToUse;
	public int AttackToUse;
	public int DefenseToUse;
	public int SpecialAttackToUse;
	public int SpecialDefenseToUse;
	public int SpeedToUse;
	public ElementTypes Type1ToUse;
	public ElementTypes Type2ToUse;

	public override Pokemon.Breed Build ()
	{
		Pokemon.Breed ToReturn;
//		if (BreedToUse != null) 
//		{
//			ToReturn = new Pokemon.Breed (BreedToUse);
//		} 
//		else
//		{
		ToReturn = new Pokemon.Breed ();
//		}

		ToReturn.BreedStatBlock.Endurance.RawValue = EnduranceToUse;
		ToReturn.BreedStatBlock.Attack.RawValue = AttackToUse;
		ToReturn.BreedStatBlock.Defense.RawValue = DefenseToUse;
		ToReturn.BreedStatBlock.SpecialAttack.RawValue = SpecialAttackToUse;
		ToReturn.BreedStatBlock.SpecialDefense.RawValue = SpecialDefenseToUse;
		ToReturn.BreedStatBlock.Speed.RawValue = SpeedToUse;
		ToReturn.Type1 = Type1ToUse;
		ToReturn.Type2 = Type2ToUse;

		return ToReturn;
	}

		public BreedBuilder ()
		{
		}

	public BreedBuilder W_Endurance (int Endurance)
	{
		EnduranceToUse = Endurance;
		return this;
	}

	public BreedBuilder W_Attack (int Attack)
	{
		AttackToUse = Attack;
		return this;
	}

	public BreedBuilder W_Defense (int Defense)
	{
		DefenseToUse = Defense;
		return this;
	}

	public BreedBuilder W_SpecialAttack (int SpecialAttack)
	{
		SpecialAttackToUse = SpecialAttack;
		return this;
	}

	public BreedBuilder W_SpecialDefense (int SpecialDefense)
	{
		SpecialDefenseToUse = SpecialDefense;
		return this;
	}

	public BreedBuilder W_Speed (int Speed)
	{
		SpeedToUse = Speed;
		return this;
	}

	public BreedBuilder W_Type1 (ElementTypes Type1)
	{
		Type1ToUse = Type1;
		return this;
	}

	public BreedBuilder W_Type2 (ElementTypes Type2)
	{
		Type2ToUse = Type2;
		return this;
	}

	public BreedBuilder W_Types (ElementTypes Type1, ElementTypes Type2)
	{
		Type1ToUse = Type1;
		Type2ToUse = Type2;
		return this;
	}
}