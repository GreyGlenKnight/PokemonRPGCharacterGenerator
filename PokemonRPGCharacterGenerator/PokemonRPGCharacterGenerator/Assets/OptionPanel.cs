using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class OptionPanel : MonoBehaviour
{
    public Text _Header;
    public Text _Description;
    public Image _Symbol;
    public Image _BackGround;
    private IChoosable ThisChoice;
    public event EventHandler <EventArgs> OnChoiceMade;



    public void DisplayOption(IChoosable _Choice)
    {
        //Debug.Log("Being called");
        if (_Choice == null)
        { throw new ArgumentNullException("IChoosable _Choice"); }
        ThisChoice = _Choice;
        _BackGround.color = TypeColors.NormalColor;
        _Header.text = _Choice.Name;
        _Description.text = _Choice.Description;
    }

    public void ChooseThis()
    {
        ThisChoice.Choose();

        if (OnChoiceMade != null)
        {
            EventArgs args = new EventArgs ();
            OnChoiceMade (this, args);
        }
    }
}