using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

	string _name;
	public string Name {private set {_name = value;} get {return _name;}}
	SkillTreeTier _Tier;
	public SkillTreeTier Tier {private set {_Tier = value;} get {return _Tier;}}

}
