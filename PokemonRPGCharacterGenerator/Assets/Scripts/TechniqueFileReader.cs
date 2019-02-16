using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;

public class TechniqueFileReader : FileReader <Technique>
{
    public const string path = "";
    public const string FileName = "";

    public TechniqueFileReader () : base (path, FileName, FactoryMethod)
    {
        string[] Lines = File.ReadAllLines(Path.Combine(path, FileName));

        foreach (string Line in Lines)
        {
            string[] Tokens = Line.Split(',');
            DataItems.Add(FactoryMethod(Tokens));
        }
    }


    private static Technique FactoryMethod(string[] Tokens)
    {
        if (Tokens[0].Equals("Move Name"))
        {
            return null;
        }
        else {
        Technique.TechniqueStringParams Temp = new Technique.TechniqueStringParams(Tokens);
        return Temp.GetTechnique();
        }

}