using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedListNode<T> : IEnumerable<T>
{
    public T ThisData { get; private set; }
    public LinkedListNode<T> Child { get; private set; }

    private class LinkedListEnumerator : IEnumerator<T>
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
			if (CurrentNode.Child != null)
			{ 
			CurrentNode = CurrentNode.Child;
			return true;
			}
			return false;
		}

        public void Reset()
        {
            throw new System.NotImplementedException();
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

    public void AddData (T Data)
    { 
        if (Child == null)
        {
            Child = new LinkedListNode<T>(Data);
        }
        Child.AddData(Data);
    }


    public void SetChildNode (T ToSet)
    {
        Child = new LinkedListNode <T> (ToSet);
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}

