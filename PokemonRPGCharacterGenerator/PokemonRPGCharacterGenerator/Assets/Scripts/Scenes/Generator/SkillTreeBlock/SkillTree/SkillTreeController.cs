using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class SkillTreeController
{
    public SkillTree TreeData;
    public SkillTreeDisplay Display;
    public List<SkillTreeLineController> Lines;

    public SkillTreeController(
        SkillTreeDisplay display,
        SkillTree treeData)
    {
        Display = display;
        Lines = new List<SkillTreeLineController>();
        ChangeDisplayData(treeData);
    }

    public void ChangeDisplayData(SkillTree treeData)
    {
        Display.ClearDisplayLines();
        TreeData = treeData;
        if (TreeData == null)
        {
            Display.CreateDefaultDisplay();
            Display.LockTree();
            return;
        }
        Display.DisplayName(TreeData.Name);
        Display.DisplayTier(TreeData.Tier);
        Display.SetState(TreeData.CurrentState);
        for (int i = 0; i < TreeData.Bonuses.Count; i++)
        {
            Lines.Add(new SkillTreeLineController(
                Display.AddLine(), 
                TreeData.Bonuses[i]));
        }
    }

}

