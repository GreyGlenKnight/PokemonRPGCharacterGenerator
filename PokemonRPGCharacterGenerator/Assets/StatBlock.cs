using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public abstract class StatBlock
{

	public StatBlock ()
	{
	}

}

public class PokemonStatBlock : StatBlock
{
//	private List <RoundedStat> Stats = new List <RoundedStat> ();
	private Pokemon _Pokemon;
	private AttackStat _Attack = new AttackStat (0);
	private DefenseStat _Defense = new DefenseStat (0);
	private SpecialAttackStat _SpecialAttack = new SpecialAttackStat (0);
	private SpecialDefenseStat _SpecialDefense = new SpecialDefenseStat (0);
	private SpeedStat _Speed = new SpeedStat (0);
	private EnduranceStat _Endurance = new EnduranceStat (0);
//	public List <PokemonStat> AllStats = new List <PokemonStat>();

	public AttackStat Attack
	{get {return _Attack.AddValues (_Pokemon.ThisBreed.BreedStatBlock.Attack.RawValue);}}

	public DefenseStat Defense
	{get {return _Defense.AddValues (_Pokemon.ThisBreed.BreedStatBlock.Defense);}}

	public SpecialAttackStat SpecialAttack
	{get {return _SpecialAttack.AddValues (_Pokemon.ThisBreed.BreedStatBlock.SpecialAttack);}}

	public SpecialDefenseStat SpecialDefense
	{get {return _SpecialDefense.AddValues (_Pokemon.ThisBreed.BreedStatBlock.SpecialDefense);}}

	public SpeedStat Speed
	{get {return _Speed.AddValues (_Pokemon.ThisBreed.BreedStatBlock.Speed);}}

	public EnduranceStat Endurance 
	{get {return _Endurance.AddValues (_Pokemon.ThisBreed.BreedStatBlock.Endurance);}}

	public AttackStat AttackBonuses
	{get {return _Attack;}}

	public DefenseStat DefenseBonuses
	{get {return _Defense;}}

	public SpecialAttackStat SpecialAttackBonuses
	{get {return _SpecialAttack;}}

	public SpecialDefenseStat SpecialDefenseBonuses
	{get {return _SpecialDefense;}}

	public SpeedStat SpeedBonuses
	{get {return _Speed;}}

	public EnduranceStat EnduranceBonuses 
	{get {return _Endurance;}}

//	private List <ValueStat> Talents = new List <ValueStat> ();
	private List <ElementTypesSkill> ElementTypesSkills = new List <ElementTypesSkill> ();


	public int MaxHP
	{		
		get {return ((Endurance + Defense) * 2);}
	}

	public int MaxStrain 
	{		
		get {return ((Endurance + SpecialDefense) * 2);}
	}

	public void GainStatUp (PokemonStat _Stat)
	{
		if (_Stat is AttackStat) {
			_Attack.SetRawValue (_Attack.RawValue + _Stat.RawValue);
		}
		if (_Stat is DefenseStat) {
			_Defense.SetRawValue (_Defense.RawValue + _Stat.RawValue);
		}
		if (_Stat is SpecialAttackStat) {
			_SpecialAttack.SetRawValue (_SpecialAttack.RawValue + _Stat.RawValue);
		}
		if (_Stat is SpecialDefenseStat) {
			_SpecialDefense.SetRawValue (_SpecialDefense.RawValue + _Stat.RawValue);
		}
		if (_Stat is SpeedStat) {
			_Speed.SetRawValue (_Speed.RawValue + _Stat.RawValue);
		}
		if (_Stat is EnduranceStat) {
			_Endurance.SetRawValue (_Endurance.RawValue + _Stat.RawValue);
		}
	}

	public PokemonStatBlock (Pokemon PokemonToUse)
	{
		_Pokemon = PokemonToUse;
	}
}

public class BreedStatBlock : StatBlock
{

	//	private List <RoundedStat> Stats = new List <RoundedStat> ();
	private AttackStat _Attack = new AttackStat (0);
	private DefenseStat _Defense = new DefenseStat (0);
	private SpecialAttackStat _SpecialAttack = new SpecialAttackStat (0);
	private SpecialDefenseStat _SpecialDefense = new SpecialDefenseStat (0);
	private SpeedStat _Speed = new SpeedStat (0);
	private EnduranceStat _Endurance = new EnduranceStat (0);

	public AttackStat Attack
	{get {return _Attack;}}

	public DefenseStat Defense
	{get {return _Defense;}}

	public SpecialAttackStat SpecialAttack
	{get {return _SpecialAttack;}}

	public SpecialDefenseStat SpecialDefense
	{get {return _SpecialDefense;}}

	public SpeedStat Speed
	{get {return _Speed;}}

	public EnduranceStat Endurance 
	{get {return _Endurance;}}


	//	private List <ValueStat> Talents = new List <ValueStat> ();
	private List <ElementTypesSkill> ElementTypesSkills = new List <ElementTypesSkill> ();

	public BreedStatBlock ()
	{

	}
}


public class TrainerStatBlock : StatBlock
{
	private ElementTypesSkill Affinity;
	//private TrainerClass Job;
	//Stat state should contain the class stats?
	//Ranks should be limited to 6.
	public List <StatCluster> AllStats 
	{ get
		{
			List <StatCluster> Temp = new List <StatCluster> ();
			Temp.Add (Athletics);
			Temp.Add (Social);
			Temp.Add (Wit);
			Temp.Add (Knowledge);
			//Add other stat clusters here such as elemental
			return Temp;
		}
	}

	private StatCluster Athletics;
	private StatCluster Social;
	private StatCluster Wit;
	private StatCluster Knowledge;

	private List <TrainerPerk> Perks = new List <TrainerPerk> ();
	//Should make an XP management object as well as level object


	public TrainerStatBlock ()
	{
		Athletics.FavoredStat = new TrainerStat ("Athletics");
		Social.FavoredStat = new TrainerStat ("Social");
		Wit.FavoredStat = new TrainerStat ("Wit");
		Knowledge.FavoredStat = new TrainerStat ("Knowledge");

		Athletics.AddSkill ("Reflexes");
		Athletics.AddSkill ("Brawling");
		Athletics.AddSkill ("Sprinting");
		Athletics.AddSkill ("Strength");
		Athletics.AddSkill ("Coordination");
		Athletics.AddSkill ("Endurance");

		Social.AddSkill ("Negotiation");
		Social.AddSkill ("Charm");
		Social.AddSkill ("Leadership");
		Social.AddSkill ("Intuition");
		Social.AddSkill ("Poke-Intuition");
		Social.AddSkill ("Willpower");

		Wit.AddSkill ("Streetwise");
		Wit.AddSkill ("Deception");
		Wit.AddSkill ("Stealth");
		Wit.AddSkill ("Vigilance");
		Wit.AddSkill ("Perception");
		Wit.AddSkill ("Mechanical");

		Knowledge.AddSkill ("Human Lore");
		Knowledge.AddSkill ("Pokemon Lore");
		Knowledge.AddSkill ("Wilderness Lore");
		Knowledge.AddSkill ("Computer Lore");
		Knowledge.AddSkill ("Academic Lore");
		Knowledge.AddSkill ("Medical Lore");

	}
}
	

public class ObjectStatBlock : StatBlock
{

	public ObjectStatBlock ()
	{
//		Stats.Add (ObjectStat ("Durability"));
	}
}

//public class ElementTypesSkill ()
//{
//	public  ElementTypesSkill ()
//	{
//	}
//}


