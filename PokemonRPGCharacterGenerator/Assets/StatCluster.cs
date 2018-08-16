using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;


public class StatCluster
{
	public TrainerStat FavoredStat;
	public List <TrainerSkill> Skills = new List <TrainerSkill> ();

	public void AddSkill (string Name)
	{
		Skills.Add (new TrainerSkill (Name, this.FavoredStat));
	}

	public StatCluster ()
	{
//		FavoredStat = new TrainerStat ("Athletics");
//		Skills.Add (new TrainerSkill ("Endurance", FavoredStat));
		
	}
}