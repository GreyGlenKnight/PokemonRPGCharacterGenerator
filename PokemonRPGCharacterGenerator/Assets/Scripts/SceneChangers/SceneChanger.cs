using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public PokeSheetSceneManager _PokeSheetSceneManager;
    public PokeSheetTreeManager _PokeSheetTreeManager;

    public void SwitchToTree()
    {
        _PokeSheetSceneManager.gameObject.SetActive(false);
        _PokeSheetTreeManager.gameObject.SetActive(true);
    }

    public void SwitchToSheet()
    {
        _PokeSheetTreeManager.gameObject.SetActive(false);
        _PokeSheetSceneManager.gameObject.SetActive(true);

    }

}
