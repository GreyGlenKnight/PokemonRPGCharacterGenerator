using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillTreeState
{
	Active, Inactive, Locked
}

public enum SkillTreeTier
{
	Tier0, Tier1, Tier2, Tier3,
}

public class SkillTreeData 

{

	public SkillTreeData (string lname, SkillTreeTier _lTier)

	{
		Name = lname;
		Tier = _lTier;

		Technique Fire_Blast = new Technique ();
		Fire_Blast.BaseAccuracy = -1;
		Fire_Blast.BaseDamage = 11;
		Fire_Blast.BaseStrain = 4;
		Fire_Blast.Description = "A fiery runic symbol strikes the foe, inflicting heavy damage and burn.";
		Fire_Blast.DisplayRange = "Ranged";
		Fire_Blast.Name = "Fire Blast";
		Fire_Blast.StatsUsed.Add (new SpecialAttackStat(0));
		Fire_Blast.Types.Add (ElementTypes.Fire);

		Technique Dragon_Claw = new Technique ();
		Dragon_Claw.BaseAccuracy = 1;
		Dragon_Claw.BaseDamage = 8;
		Dragon_Claw.BaseStrain = 3;
		Dragon_Claw.Description = "The foe is ravaged by a mighty swipe of the pokemon’s claws.";
		Dragon_Claw.DisplayRange = "Melee";
		Dragon_Claw.Name = "Dragon Claw";
		Dragon_Claw.StatsUsed.Add (new AttackStat(0));
		Dragon_Claw.Types.Add (ElementTypes.Dragon);

		Technique Metal_Claw = new Technique ();
		Metal_Claw.BaseAccuracy = 0;
		Metal_Claw.BaseDamage = 5;
		Metal_Claw.BaseStrain = 2;
		Metal_Claw.Description = "The pokemon gouges the opponent with a set of merciless claws. May raise Attack.";
		Metal_Claw.DisplayRange = "Melee";
		Metal_Claw.Name = "Metal Claw";
		Metal_Claw.StatsUsed.Add (new AttackStat(0));
		Metal_Claw.Types.Add (ElementTypes.Steel);

		Technique Sand_Attack = new Technique ();
		Sand_Attack.BaseAccuracy = 1;
		Sand_Attack.BaseStrain = 3;
		Sand_Attack.Description = "Norris always teaches his pokemon to be prepared for snakes.";
		Sand_Attack.DisplayRange = "Ranged";
		Sand_Attack.Name = "Sand Attack";
		Sand_Attack.StatsUsed.Add (new DefenseStat(0));
		Sand_Attack.StatsUsed.Add (new SpeedStat(0));
		Sand_Attack.Types.Add (ElementTypes.Ground);

		_TechniquesOnTree.Add (Fire_Blast);
		_TechniquesOnTree.Add (Dragon_Claw);
		_TechniquesOnTree.Add (Metal_Claw);
		_TechniquesOnTree.Add (Sand_Attack);


		_ElementTypesOnTree.Add (ElementTypes.Fire);
	}

//	public List <BonusAtIndex> _BonusesRemaining = new List <BonusAtIndex> ();
	public SkillTreeBonusesAcquired _BonusesAcquired = new SkillTreeBonusesAcquired ();
	private List <ElementTypes> _ElementTypesOnTree = new List <ElementTypes>();
	private MyStat _FavoredStatOnTree = new AttackStat (1);
	private SkillTreeState _State = SkillTreeState.Locked;
	private List <Technique> _TechniquesOnTree = new List <Technique> ();


	string _name;
	public string Name {private set {_name = value;} get {return _name;}}



	SkillTreeTier _Tier;

	public SkillTreeTier Tier {private set {_Tier = value;} get {return _Tier;}}

	public SkillTreeState CurrentState 
	{		
		get {return (SkillTreeState) _State;}
	}

	public List <Technique> TechniquesOnTree 
	{		
		get {return _TechniquesOnTree;}
	}

	public List <ElementTypes> ElementTypesOnTree 
	{		
		get {return _ElementTypesOnTree;}
	}

	public MyStat FavoredStatOnTree 
	{		
		get {return _FavoredStatOnTree;}
	}

	public void ChangeState (SkillTreeState NewState)
	{
		_State = NewState;

	}

}
