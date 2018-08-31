using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class GenericStatBlock
{
//	public List <>();
	public Dictionary <Type, PokemonStat> StatDictionary;

	public GenericStatBlock ()
	{
	}

	public virtual void Add <T> (T StatToAdd) where T : PokemonStat
	{
		StatDictionary.Add (typeof (T), StatToAdd);
	}

	public virtual T Find <T> () where T : PokemonStat
	{
		if (StatDictionary.ContainsKey (typeof (T)))
			{
			return (T) StatDictionary [typeof (T)];
			}
		else return default (T);
	}

	public virtual GenericStatBlock Combine (GenericStatBlock Other)
	{
		return new CombinedStatBlock (this, Other);
	}
}

public class CombinedStatBlock : GenericStatBlock
{
	public GenericStatBlock Other;
	public GenericStatBlock CombinedTwo;

	public CombinedStatBlock (GenericStatBlock Block1, 
		GenericStatBlock Block2)
	{
		Other = Block1;
		CombinedTwo = Block2;
	}

	public override void Add <T> (T StatToAdd)
	{
//		StatDictionary.Add (typeof (T), StatToAdd);
		throw new Exception ("Don't add to the Combined Statblocks, you jerk! " +
			"Instead, add to the composite stat blocks.");
	}

	public override T Find <T> () 
	{
		T FoundValue1 = Other.Find <T> ();
		T FoundValue2 = CombinedTwo.Find <T> ();

		if (FoundValue1 == null &&
			FoundValue2 == null) 
		{return default (T);}

		if (FoundValue1 == null)
		{return FoundValue2;}

		if (FoundValue2 == null)
		{return FoundValue1;}

		if (FoundValue1 != null &&
		    FoundValue2 != null) 
		{return FoundValue1.AddValues (FoundValue2);}

		throw new Exception ("Somehow, you've done the impossible.");
	}

}

//public abstract class StatBlock
//{

//	public StatBlock ()
//	{
//	}

//}

public class PokemonStatBlock : GenericStatBlock
{
	private Pokemon _Pokemon;
	private AttackStat _Attack = new AttackStat (0);
	private DefenseStat _Defense = new DefenseStat (0);
	private SpecialAttackStat _SpecialAttack = new SpecialAttackStat (0);
	private SpecialDefenseStat _SpecialDefense = new SpecialDefenseStat (0);
	private SpeedStat _Speed = new SpeedStat (0);
	private EnduranceStat _Endurance = new EnduranceStat (0);

	public AttackStat Attack
	{get 
        {return _Attack.AddValues (_Pokemon.ThisBreed.BreedStatBlock.Attack);}}

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

//	private List <ElementTypesSkill> ElementTypesSkills = new List <ElementTypesSkill> ();


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
			_Attack.SetRawValue (_Attack.ThisRawValue + _Stat.ThisRawValue);
		}
		if (_Stat is DefenseStat) {
			_Defense.SetRawValue (_Defense.ThisRawValue + _Stat.ThisRawValue);
		}
		if (_Stat is SpecialAttackStat) {
			_SpecialAttack.SetRawValue (_SpecialAttack.ThisRawValue + _Stat.ThisRawValue);
		}
		if (_Stat is SpecialDefenseStat) {
			_SpecialDefense.SetRawValue (_SpecialDefense.ThisRawValue + _Stat.ThisRawValue);
		}
		if (_Stat is SpeedStat) {
			_Speed.SetRawValue (_Speed.ThisRawValue + _Stat.ThisRawValue);
		}
		if (_Stat is EnduranceStat) {
			_Endurance.SetRawValue (_Endurance.ThisRawValue + _Stat.ThisRawValue);
		}
	}

	public PokemonStatBlock (Pokemon PokemonToUse)
	{
		_Pokemon = PokemonToUse;
	}
}

public class BreedStatBlock : GenericStatBlock
{

	//	private List <RoundedStat> Stats = new List <RoundedStat> ();
	private AttackStat _attack;
    private DefenseStat _defense;
    private SpecialAttackStat _specialattack;
    private SpecialDefenseStat _specialdefense;
	private SpeedStat _speed;
    private EnduranceStat _endurance;

	public AttackStat Attack
	{get {return _attack;}}

	public DefenseStat Defense
	{get {return _defense;}}

	public SpecialAttackStat SpecialAttack
	{get {return _specialattack;}}

	public SpecialDefenseStat SpecialDefense
	{get {return _specialdefense;}}

	public SpeedStat Speed
	{get {return _speed;}}

	public EnduranceStat Endurance 
	{get {return _endurance;}}


	//	private List <ValueStat> Talents = new List <ValueStat> ();
//	private List <ElementTypesSkill> ElementTypesSkills = new List <ElementTypesSkill> ();

	public BreedStatBlock ()
	{
        _attack = new AttackStat (0);
        _defense = new DefenseStat(0);
        _specialattack = new SpecialAttackStat(0);
        _specialdefense = new SpecialDefenseStat(0);
        _speed = new SpeedStat(0);
        _endurance = new EnduranceStat(0);

    }
}


//public class TrainerStatBlock : StatBlock
//{
////	private ElementTypesSkill Affinity;
//	//private TrainerClass Job;
//	//Stat state should contain the class stats?
//	//Ranks should be limited to 6.
//	public List <StatCluster> AllStats 
//	{ get
//		{
//			List <StatCluster> Temp = new List <StatCluster> ();
//			Temp.Add (Athletics);
//			Temp.Add (Social);
//			Temp.Add (Wit);
//			Temp.Add (Knowledge);
//			//Add other stat clusters here such as elemental
//			return Temp;
//		}
//	}
//
//	private StatCluster Athletics;
//	private StatCluster Social;
//	private StatCluster Wit;
//	private StatCluster Knowledge;
//
//	private List <TrainerPerk> Perks = new List <TrainerPerk> ();
//	//Should make an XP management object as well as level object
//
//
//	public TrainerStatBlock ()
//	{
//		Athletics.FavoredStat = new TrainerStat ("Athletics");
//		Social.FavoredStat = new TrainerStat ("Social");
//		Wit.FavoredStat = new TrainerStat ("Wit");
//		Knowledge.FavoredStat = new TrainerStat ("Knowledge");
//
//		Athletics.AddSkill ("Reflexes");
//		Athletics.AddSkill ("Brawling");
//		Athletics.AddSkill ("Sprinting");
//		Athletics.AddSkill ("Strength");
//		Athletics.AddSkill ("Coordination");
//		Athletics.AddSkill ("Endurance");
//
//		Social.AddSkill ("Negotiation");
//		Social.AddSkill ("Charm");
//		Social.AddSkill ("Leadership");
//		Social.AddSkill ("Intuition");
//		Social.AddSkill ("Poke-Intuition");
//		Social.AddSkill ("Willpower");
//
//		Wit.AddSkill ("Streetwise");
//		Wit.AddSkill ("Deception");
//		Wit.AddSkill ("Stealth");
//		Wit.AddSkill ("Vigilance");
//		Wit.AddSkill ("Perception");
//		Wit.AddSkill ("Mechanical");
//
//		Knowledge.AddSkill ("Human Lore");
//		Knowledge.AddSkill ("Pokemon Lore");
//		Knowledge.AddSkill ("Wilderness Lore");
//		Knowledge.AddSkill ("Computer Lore");
//		Knowledge.AddSkill ("Academic Lore");
//		Knowledge.AddSkill ("Medical Lore");
//
//	}
//}
//	
//
//public class ObjectStatBlock : StatBlock
//{
//
//	public ObjectStatBlock ()
//	{
////		Stats.Add (ObjectStat ("Durability"));
//	}
//}