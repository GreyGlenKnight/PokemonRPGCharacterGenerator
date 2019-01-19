using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedListNode<T> : IEnumerable<T>
{
    public T ThisData { get; private set; }
    public LinkedListNode<T> Child { get; private set; }

    private class LinkedListEnumerator : IEnumerator <T>
    {
        public LinkedListNode <T> StartingNode { get; private set; }
        public LinkedListNode <T> CurrentNode { get; private set; }
        object IEnumerator.Current { get { return Current;} }

	   public LinkedListEnumerator (LinkedListNode <T> _StartingNode)
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

		public void Dispose()
        {
        	StartingNode = null;
        	CurrentNode = null;
        }

        public bool MoveNext()
        {
        		if (CurrentNode == null)
			{
			CurrentNode = StartingNode;
			return true; 
			}
			if (CurrentNode.Child != null)
			{ 
			CurrentNode = CurrentNode.Child;
			return true;
			}
			return false;
		}

        public void Reset()
        {
        CurrentNode = null;
        }
    }

    public LinkedListNode(T Data)
    {
        ThisData = Data;
    }

    public T FindLast ()
    {
        if (Child == null)
            return ThisData;
        else return Child.FindLast();
    }
    
    
   public bool HasChild(LinkedListNode <T> Node)
    {
        return Node.Child != null;
    }

    public void AddData (T Data)
    { 
        if (Child == null)
        {
            Child = new LinkedListNode<T>(Data);
        }
        else
        Child.AddData(Data);
    }


    public void SetChildNode (T ToSet)
    {
        Child = new LinkedListNode <T> (ToSet);
    }

    public IEnumerator<T> GetEnumerator()
    {
		IEnumerator <T> Temp = new LinkedListEnumerator (this);
		return Temp;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
		IEnumerator <T> Temp = new LinkedListEnumerator (this);
		return Temp;    
	}
    
	
	public List <T> AddToList (List <T> _ListToAppend)
	{
	LinkedListNode <T> Temp = this;
		
	while (HasChild (Temp) == true)
		{ 
		_ListToAppend.Add (Temp.ThisData);
		Temp = Temp.Child;
		}
	
	return _ListToAppend;
	}

	public List <T> AddToListRecursive (List <T> _ListToAppend)
	{
	 	LinkedListNode <T> Temp = this;
	 	
		if (HasChild (Temp) == true)
		{ 
			_ListToAppend.Add (Temp.ThisData);
			return Child.AddToListRecursive (_ListToAppend);
		}
		else
		{ 
			_ListToAppend.Add (Temp.ThisData);
			return _ListToAppend;
		}
	}
}