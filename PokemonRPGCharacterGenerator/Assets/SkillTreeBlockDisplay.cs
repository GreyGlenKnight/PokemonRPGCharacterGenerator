using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class SkillTreeBlockDisplay : MonoBehaviour 
{
    public List<SkillTreeDisplay> TreeDisplays = new List<SkillTreeDisplay>();
    public SkillTreeDisplay SkillTreeDisplayPrefab;


    public void AddNewSkillTree (SkillTreeController _Controller)
    {
        SkillTreeDisplay Temp = GameObject.Instantiate (SkillTreeDisplayPrefab);
        TreeDisplays.Add (Temp);
        _Controller.AssignDisplay (Temp);
        Temp.transform.SetParent (this.transform, 
                                  true);
    }

    public void Clear ()
    {
        foreach (SkillTreeDisplay _CurrentDisplay in TreeDisplays)
        {
            _CurrentDisplay.transform.SetParent(null);
            GameObject.Destroy(_CurrentDisplay);
        }

        TreeDisplays.Clear ();
    }
}
