using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class SkillTreeDisplay : MonoBehaviour 
{
    public const int DEFAULT_TREELINE_NUMBER = 12;
    [SerializeField] private SkillTreeLineDisplay LinePrefab;
    private List<SkillTreeLineDisplay> LineInstances;

    [SerializeField] private Transform LineHolder;
    [SerializeField] private Image TreeBG;
    [SerializeField] private Text TreeNameText;
    [SerializeField] private SkillTree TreeToDisplay;

	public static Color LockTreeColor = Color.clear;
    private SkillTreeState State;

    private void Awake()
    {
        LineInstances = new List<SkillTreeLineDisplay>();
    }

    public void CreateDefaultDisplay()
    {
        ClearDisplayLines();
        for (int i = 0; i < DEFAULT_TREELINE_NUMBER; i++)
        {
            AddLine();
        }
    }

    public void ClearDisplayLines()
    {
        foreach (SkillTreeLineDisplay child in LineInstances)
        {
            Destroy(child);
        }
        LineInstances = new List<SkillTreeLineDisplay>();
    }

    public SkillTreeLineDisplay AddLine()
    {
        SkillTreeLineDisplay newLine = Instantiate(LinePrefab);
        newLine.transform.SetParent(LineHolder, false);
        LineInstances.Add(newLine);
        return newLine;
    }

    public void DisplayName(string name)
    {
        TreeNameText.text = name;
    }

    public void LockTree()
    {
        TreeBG.color = LockTreeColor;
        DisplayName("");
        CreateDefaultDisplay();
    }

    public void SetState(SkillTreeState state)
    {
        State = state;
        switch(State)
        {
            case SkillTreeState.Active:
                TreeBG.color = ToActive(TreeBG.color);
                break;
            case SkillTreeState.Inactive:
                TreeBG.color = ToInactive(TreeBG.color);
                break;
            case SkillTreeState.Locked:
                TreeBG.color = LockTreeColor;
                break;
            default:
                throw new Exception(string.Format("unknown tree state {0}",State));
        }

    }

    private Color ToActive(Color color)
    {
        return new Color(color.r, color.g, color.b, 1f);
    }

    private Color ToInactive(Color color)
    {
        return new Color(color.r,color.g,color.b,0.5f);
    }

    public void DisplayTier(SkillTreeTier _Tier)
    {
        TreeBG.color = TypeColors.GetColorForTier(_Tier);
        SetState(State);
    }

	

}
