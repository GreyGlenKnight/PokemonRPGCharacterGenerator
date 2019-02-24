using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

public class TechniqueFileReaderTests
{

    [Test]
    public void Example ()
    {
        TechniqueFileReader Temp = new TechniqueFileReader ();

		Technique TechExample = Temp.GetItemByID(3);
        Debug.Log (TechExample.DisplayRange+TechExample.BaseDamage+" "+TechExample.TechniqueName);
    }

//	[Test]
//	public void  ()
//{}
	
//	[Test]
//	public void  ()
//{}	
//	[Test]
//	public void  ()
//{}
}
