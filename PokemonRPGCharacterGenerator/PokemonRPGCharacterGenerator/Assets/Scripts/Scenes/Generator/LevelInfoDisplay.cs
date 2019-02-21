using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoDisplay : MonoBehaviour
{
    [SerializeField] private Text XPField;
    [SerializeField] private Text LevelField;
    [SerializeField] private Text BadgeLevelField;

    public void UpdateFields(int xp, int level, int badgeLevel)
    {
        XPField.text = xp.ToString();
        LevelField.text = level.ToString();
        BadgeLevelField.text = badgeLevel.ToString();
    }

}
