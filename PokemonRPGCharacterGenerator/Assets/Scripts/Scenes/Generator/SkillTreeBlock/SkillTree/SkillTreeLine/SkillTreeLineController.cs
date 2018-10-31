using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeLineController
{
    SkillTreeLineDisplay Display;
    LevelUpBonus Data;

    public SkillTreeLineController(
        SkillTreeLineDisplay display,
        LevelUpBonus levelUpBonus)
    {
        Display = display;
        ChangeDisplayData(levelUpBonus);
    }

    public void ChangeDisplayData(LevelUpBonus NewBonus)
    {
        if (NewBonus == null)
        {
            return;
        }
        Data = NewBonus;
        Display.DisplayBonusName(Data.BonusName);

        if (Data.State == LevelUpBonus.BonusState.Acquired)
        {
            Display.SetToggle(true);
        } else
        {
            Display.SetToggle(false);
        }
    }

}
