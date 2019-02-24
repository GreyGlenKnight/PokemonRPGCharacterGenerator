using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;

public class SortedLinkedListNode <T>
{
	public SortedLinkedListNode <T> Child;
	public T ThisData;
	public int Value { get; private set; }

	public SortedLinkedListNode ()
    {
		
    }

	 //public void SetChildNode(SortedLinkedListNode <T> ToSet)
     //{
     //   Child = ToSet;
     //}
	
	public SortedLinkedListNode(T _Data, int _Value)
    {
    	ThisData = _Data;
        Value = _Value;
    }

    public bool IsSmallerThan (int _Value)
    {
        return _Value >= this.Value;
    }


    public void AddData (T DataToAdd, int _Value)
    { 
    	if (ThisData.Equals(default (T)))
    	{ 
			ThisData = DataToAdd;
			Value = _Value;
			return;
		}
		else
		{
			if (Child == null)
			{
			if (this.IsSmallerThan (_Value) == true)
				{
				Child = new SortedLinkedListNode<T> (ThisData, Value);
				ThisData = DataToAdd;
				Value = _Value;
				return;
				}
				else 
				{
				Child = new SortedLinkedListNode<T> (DataToAdd, _Value);
				return;
				}
			}
			else
			{
			if (this.IsSmallerThan (_Value) == true)
				{
				SortedLinkedListNode <T> Temp = new SortedLinkedListNode <T> (ThisData, Value);
	
				ThisData = DataToAdd;
				Value = _Value;
				Temp.Child = Child;
				Child = Temp;
				return;
				}
				else
				{
				Child.AddData (DataToAdd, _Value);
				}
			}
		}
	}
	
public List <T> AddToList (List <T> _ListToAppend)
	{
	SortedLinkedListNode <T> Temp = this;
	//_ListToAppend.Add (Temp.ThisData);
	//This line is wrong!!! it needs to be after the loop!!!
		
	while (Temp.Child != null)
		{ 
		_ListToAppend.Add (Temp.ThisData);
		Temp = Temp.Child;
		}
	
	_ListToAppend.Add (Temp.ThisData);
	
	return _ListToAppend;
	}	
}
