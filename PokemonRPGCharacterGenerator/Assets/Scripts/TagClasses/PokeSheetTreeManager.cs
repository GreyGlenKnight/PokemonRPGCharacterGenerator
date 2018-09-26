using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeSheetTreeManager : MonoBehaviour

{
    public SkillTreeBlockDisplay _SkillTreeBlockDisplayPrefab;
    public SkillTreeBlockDisplay _SkillTreeBlockDisplay;

    public void Load (SkillTreeBlockController _Controller)
    {
        SkillTreeBlockDisplay Temp = GameObject.Instantiate(_SkillTreeBlockDisplayPrefab);
        _Controller.AssignDisplay(Temp);
        Temp.transform.SetParent(this.transform,
                                  true);
    }

    //Clear ()

}
