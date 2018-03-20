using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Text myTextBox;

    public Toggle[] options = new Toggle[12];

    string testFileName = "Assets/TestOutput.txt";
    TextWriter testFile;

    void Awake()
    {


        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);


        testFile = new TextWriter();

    }

    public void GetNumber()
    {

        int intRandNumber = UnityEngine.Random.Range(1, 13);
        string randomNumber = intRandNumber.ToString();

        options[intRandNumber - 1].isOn = true;

        //testFile.Append(randomNumber);
        //testFile.Append(randomNumber);





        myTextBox.text = randomNumber;
    }

    private void Update()
    {
        // DO game stuff!!!


    }

}

