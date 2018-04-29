using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;


public class TreeSwapper : MonoBehaviour 
{
	public SkillTree TreeGoingOut;
	public SkillTree TreeGoingIn;
//	public SkillTree TempSkillTree;
//	public SkillTree TempSkillTree2;

	//	public SkillTree [] Row1 = new SkillTree [4];
	//	public SkillTree [] Row2 = new SkillTree [4];
	//	public SkillTree [] Row3 = new SkillTree [4];

	public void TreeSwap ()
	{
		GameManager.instance.SkillTrees [0] = TreeGoingOut;
		GameManager.instance.SkillTrees [4] = TreeGoingIn;


	}

	//This class should be incorporated into the others?
	//Maturity Manager has the tree switching trigger list.
	//MenuSceneChanger knows the 3 canvases, not the trees.
}
