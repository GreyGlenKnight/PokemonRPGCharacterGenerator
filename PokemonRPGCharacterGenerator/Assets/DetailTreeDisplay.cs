using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class DetailTreeDisplay : MonoBehaviour 

{
	public List <TechniqueDisplay> TechniqueDisplays = new List <TechniqueDisplay> ();
	public List <Technique> TechniquesOnTree = new List <Technique> ();
	public Text TreeName;
	public Text CrossTreeName;
	public Text NextTreeName;
	public List <Image> TreeItemBackGrounds = new List <Image> ();
	//we want to be able to use the attained bonuses on the _Data to grey out
	//the already attained bonuses. This would be the panels/canvas on each item.
	public Image MainBG;


//	public void DisplayNewTree ()
//	{
//		
//	}

	public void DisplayNewTree (SkillTree _Tree)
	{
		MainBG.color = TypeColors.GetColorForTier(_Tree.Tier);
		TreeName.text = _Tree.Name;


		for (int i = 0; i < 4; i++) 
		{
			TechniquesOnTree.Add (_Tree._TechniquesOnTree [i]);
			TechniqueDisplays [i].ChangeTechniqueDisplay (TechniquesOnTree [i]);
		}
	}

	void Awake ()
	{
		SkillTree Temp = new SkillTree ("Fire Body 3" , SkillTreeTier.Tier3);
		DisplayNewTree (Temp);

//		for (int i = 0; i < TechniqueDisplays.Count; i++)
//		{
//			TechniqueDisplays [i]._BackGround.color = TypeColors.GetColorForTier (Temp.Tier);
//		}

		CrossTreeName.text = "Pyromancer 3";
		NextTreeName.text = "Super Wild";

		for (int i = 0; i < TreeItemBackGrounds.Count; i++) 
		{TreeItemBackGrounds[i].color = TypeColors.GetColorForTier (Temp.Tier);}

	}


}
