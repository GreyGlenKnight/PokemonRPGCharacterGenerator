using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GeneratorDisplay : MonoBehaviour
{
    // Tree block to create when the generator scene is created
    [SerializeField] private SkillTreeBlockDisplay TreeBlockPrefab;
    private SkillTreeBlockDisplay TreeBlockInstance;

    // 
    //public LevelInfoDisplay XPPrefab;
    [SerializeField] private LevelInfoDisplay XPInstance;

    public SkillTreeBlockDisplay Load()
    {
        SkillTreeBlockDisplay TreeBlockInstance = GameObject.Instantiate(TreeBlockPrefab);
        TreeBlockInstance.transform.SetParent(this.transform, false);
        return TreeBlockInstance;
    }

    public void UpdateXPDisplay(int xp, int level, int badgeLevel)
    {
        XPInstance.UpdateFields(xp,level,badgeLevel);
    }


    [SerializeField] private Button ToggleBlock;
    private Action ToggleBlockAction;

    [SerializeField] private Button AddXP;
    private Action AddXPAction;

    [SerializeField] private Button LevelUp;
    private Action LevelUpAction;

    [SerializeField] private Button Generate;
    private Action GenerateAction;

    [SerializeField] private Button Return;
    private Action ReturnAction;

    [SerializeField] private Dropdown Dropdown;
    private Action<int> DropdownAction;

    public void SetDropdownAction(Action<int> action)
    {
        DropdownAction = action;
    }

    public void DropdownValueChanged(int value)
    {
        if (DropdownAction == null)
            throw new Exception("Dropdown action not set");
        DropdownAction(value);
    }

    private void Awake()
    {
        ToggleBlock.onClick.RemoveAllListeners();
        ToggleBlock.onClick.AddListener(OnToggleBlockClick);
        AddXP.onClick.RemoveAllListeners();
        AddXP.onClick.AddListener(OnAddXPClick);
        LevelUp.onClick.RemoveAllListeners();
        LevelUp.onClick.AddListener(OnLevelUpClick);
        Generate.onClick.RemoveAllListeners();
        Generate.onClick.AddListener(OnGenerateClick);
        Return.onClick.RemoveAllListeners();
        Return.onClick.AddListener(OnReturnClick);
        Dropdown.onValueChanged.RemoveAllListeners();
        Dropdown.onValueChanged.AddListener(DropdownValueChanged);
    }

    private void OnReturnClick()
    {
        if (ReturnAction == null)
            throw new Exception("ReturnAction function not set!");
        ReturnAction();
    }

    public void SetReturnAction(Action toAdd)
    {
        ReturnAction = toAdd;
    }

    private void OnGenerateClick()
    {
        if (GenerateAction == null)
            throw new Exception("GenerateAction function not set!");
        GenerateAction();
    }

    public void SetGenerateAction(Action toAdd)
    {
        GenerateAction = toAdd;
    }

    private void OnToggleBlockClick()
    {
        if (ToggleBlockAction == null)
            throw new Exception("ToggleBlockAction function not set!");
        ToggleBlockAction();
    }

    public void SetToggleBlockAction(Action toAdd)
    {
        ToggleBlockAction = toAdd;
    }

    private void OnLevelUpClick()
    {
        if (LevelUpAction == null)
            throw new Exception("LevelUpAction function not set!");
        LevelUpAction();
    }

    public void SetLevelupAction(Action toAdd)
    {
        LevelUpAction = toAdd;
    }

    private void OnAddXPClick()
    {
        if (AddXPAction == null)
            throw new Exception("addXPAction function not set!");
        AddXPAction();
    }

    public void SetXPAction(Action toAdd)
    {
        AddXPAction = toAdd;
    }

    // Buttons

}
