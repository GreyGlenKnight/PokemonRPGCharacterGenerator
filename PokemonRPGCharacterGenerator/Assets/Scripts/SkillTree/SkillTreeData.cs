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
	}

//	public List <BonusAtIndex> _BonusesRemaining = new List <BonusAtIndex> ();
	public SkillTreeBonusesAcquired _BonusesAcquired = new SkillTreeBonusesAcquired ();
	private SkillTreeState _State = SkillTreeState.Locked;
	string _name;
	public Technique Tech1;
	public Technique Tech2;
	public Technique Tech3;
	public Technique Tech4;
	public MyStat FavoredStat;
	public ElementTypes FavoredType1;
	public ElementTypes FavoredType2;


	public string Name {private set {_name = value;} get {return _name;}}

	SkillTreeTier _Tier;

	public SkillTreeTier Tier {private set {_Tier = value;} get {return _Tier;}}

	public SkillTreeState CurrentState 
	{		
		get {return (SkillTreeState) _State;}
	}

	public void ChangeState (SkillTreeState NewState)
	{
		_State = NewState;

	}

}
