using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class SkillTreeController
{
    public SkillTree _SkillTree;
    public SkillTreeDisplay _SkillTreeDisplay;

    public SkillTreeController (SkillTree _Tree)
    {
        _SkillTree = _Tree;
    }

    public void AssignDisplay (SkillTreeDisplay _Display)
    {
        _SkillTreeDisplay = _Display;
        _SkillTreeDisplay.ChangeDisplayData (_SkillTree);
    }

}