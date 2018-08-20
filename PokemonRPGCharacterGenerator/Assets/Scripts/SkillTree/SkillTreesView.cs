using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreesView : MonoBehaviour 
{
	public const int NUMBER_OF_TREES = 4;
	public SkillTreePaneDisplay [] ActiveRolls = new SkillTreePaneDisplay[NUMBER_OF_TREES]; 
	public SkillTree [] ActiveTreeData = new SkillTree [NUMBER_OF_TREES];

}