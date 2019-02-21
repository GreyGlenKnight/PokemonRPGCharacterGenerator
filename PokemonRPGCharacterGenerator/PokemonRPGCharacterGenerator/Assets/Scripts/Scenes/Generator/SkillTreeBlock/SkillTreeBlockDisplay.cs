using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class SkillTreeBlockDisplay : MonoBehaviour 
{
    private List<SkillTreeDisplay> TreeDisplays = new List<SkillTreeDisplay>();
    [SerializeField] private SkillTreeDisplay SkillTreeDisplayPrefab;


    public SkillTreeDisplay AddTree()
    {
        SkillTreeDisplay Temp = GameObject.Instantiate(SkillTreeDisplayPrefab);
        TreeDisplays.Add(Temp);
        Temp.transform.SetParent(this.transform,false);
        return Temp;
    }

    public void Clear ()
    {
        foreach (SkillTreeDisplay _CurrentDisplay in TreeDisplays)
        {
            if (_CurrentDisplay == null)
                continue;
            GameObject.Destroy(_CurrentDisplay.gameObject);
        }
        TreeDisplays = new List<SkillTreeDisplay>();
    }
}
