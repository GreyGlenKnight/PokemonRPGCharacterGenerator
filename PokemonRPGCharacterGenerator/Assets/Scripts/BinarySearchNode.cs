using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;

public class BinarySearchNode <T> : IEnumerable <T>
{
    public BinarySearchNode <T> Parent { get; private set; }

    public T ThisData { get; private set; }

    public BinarySearchNode <T> ChildLower { get; private set; }

	public BinarySearchNode <T> ChildEqual {get; private set; }

	public BinarySearchNode <T> ChildHigher { get; private set; }
    
    public int Value { get; private set; }

	private class BinarySearchNodeEnumerator : IEnumerator <T>
	{
		public BinarySearchNode <T> StartingNode { get; private set; }
		public BinarySearchNode <T> CurrentNode { get; private set; }
		object IEnumerator.Current { get { return Current; } }
	
		public BinarySearchNodeEnumerator (BinarySearchNode <T> _StartingNode)
		{
		 	StartingNode = _StartingNode;
		}

		public T Current
		{
			get
			{
				return CurrentNode.ThisData;
			}
		}
		
		public void Dispose ()
		{
        	StartingNode = null;
        	CurrentNode = null;
        }

		public bool MoveNext ()
		{			  
   //			if (CurrentNode == null)
			//{
			//CurrentNode = StartingNode;
			//return true; 
			//}
			//if (CurrentNode.Child != null)
			//{ 
			//CurrentNode = CurrentNode.Child;
			//return true;
			//}
			return false;
		}

		public void Reset()
		{
			CurrentNode = null;
		}
	}
	
			
	public IEnumerator <T> GetEnumerator ()
	{
		IEnumerator <T> Temp = new BinarySearchNodeEnumerator (this);
		return Temp;		
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		IEnumerator <T> Temp = new BinarySearchNodeEnumerator (this);
			return Temp;
	}


	public BinarySearchNode (T Data, int _Value)
    {
        ThisData = Data;
		Value = _Value;	
    }
    
	//public T FindLast ()
    //{
    //    if (Child == null)
    //        return ThisData;
    //    else return Child.FindLast();
    //}

    public bool IsSmallerThan (int _Value)
    {
        return Value >= _Value;
    }

    public void SetParentNode (BinarySearchNode <T> ParentNode)
    {
        Parent = ParentNode;
    }

    public void SetLesserChildNode (BinarySearchNode <T> LesserChildNode)
    {
		ChildLower = LesserChildNode;
    }

	public void SetEqualChildNode (BinarySearchNode <T> EqualChildNode)
	{
		ChildEqual = EqualChildNode;
	}

	public void SetGreaterChildNode (BinarySearchNode <T> GreaterChildNode)
    {
		ChildHigher = GreaterChildNode;
    }

	public void TryLower (BinarySearchNode <T> _Node,
							T DataToAdd, 
								int _Value)
	{
		if (_Node.ChildLower == null)
		{
			BinarySearchNode <T> Temp = new BinarySearchNode <T> (DataToAdd, _Value);
			Debug.Log ("X Lower than Y"+Temp.Value.ToString()+_Node.Value.ToString());
			_Node.SetLesserChildNode (Temp);
			Temp.SetParentNode (_Node);
		}
		else
		{
			_Node.ChildLower.AddData (DataToAdd, _Value);
		}
	}

	public void TryEqual (BinarySearchNode <T> _Node, 
							T DataToAdd, 
								int _Value)
	{
		if (_Node.ChildEqual == null)
		{
			BinarySearchNode <T> Temp = new BinarySearchNode <T> (DataToAdd, _Value);
			Debug.Log ("X Equals Y"+Temp.Value.ToString()+_Node.Value.ToString());
			_Node.SetEqualChildNode (Temp);
			Temp.SetParentNode (_Node);
		}
		else
		{
			_Node.ChildEqual.AddData (DataToAdd, _Value);
		}
	}

	public void TryHigher (BinarySearchNode <T> _Node, 
							T DataToAdd, 
								int _Value)
	{
		if (_Node.ChildHigher == null)
		{
			BinarySearchNode <T> Temp = new BinarySearchNode <T> (DataToAdd, _Value);
			Debug.Log ("X Higher than Y"+Temp.Value.ToString()+_Node.Value.ToString());

			_Node.SetGreaterChildNode (Temp);
			Temp.SetParentNode (_Node);
		}
		else
		{
			_Node.ChildHigher.AddData (DataToAdd, _Value);
		}
	}

	public void AddData (T DataToAdd, int _Value)
    { 
  //  	if (Parent == null && ChildLower == null && ChildHigher == null)
  //  	{
		//	ThisData = DataToAdd;
		//	Value = _Value;
		//	return;
		//}
		if (Value == _Value)
		{
			TryEqual (this, DataToAdd, _Value);
		}
		else 
		{ 
		if (IsSmallerThan (_Value) == true)
		{
			TryLower (this, DataToAdd, _Value);
			//return;
		}
		else
		{ 
			TryHigher (this, DataToAdd, _Value);
			//return;
		}
		}
	}
	

public List <T> GetList ()
	{ 
		List <T> Temp = new List <T>();
 		
		if (ChildLower != null)
		{
			Temp.AddRange(ChildLower.GetList());
		}

		Temp.AddRange (this.GetEqualChildren());

		if (ChildHigher != null)
		{
			Temp.AddRange(ChildHigher.GetList());
		}
		return Temp;
	}


public List <T> GetEqualChildren ()
	{
		if (ThisData.Equals (default (T)))
		{return new List <T>();}

		List<T> Temp = new List<T>	{ThisData};
		
		if (ChildEqual != null)
		{
			Temp.AddRange(ChildEqual.GetEqualChildren ());
		}
		return Temp;
	}




}