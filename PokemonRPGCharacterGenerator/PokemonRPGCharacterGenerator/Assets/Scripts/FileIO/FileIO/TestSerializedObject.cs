using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TestSerializedObject : IEqualityComparer{

    public int mIntField { get; private set; }
    public string mStringField { get; private set; }
    public TestSerializedObject2 mInner { get; private set; }

    public TestSerializedObject()
    {
        mInner = new TestSerializedObject2();
    }

    public TestSerializedObject(int lIntField, string lStringField)
    {
        mIntField = lIntField;
        mStringField = lStringField;
        mInner = new TestSerializedObject2(lIntField +1, lStringField);
    }

    public override bool Equals(object obj)
    {
        return Equals(this, obj);
    }

    public new bool Equals(object x, object y)
    {
        if (!(x is TestSerializedObject))
        {
            return false;
        }
        if (!(y is TestSerializedObject))
        {
            return false;
        }
        if (((TestSerializedObject)x).mIntField !=
            ((TestSerializedObject)y).mIntField)
        {
            return false;
        }
        if (!((TestSerializedObject)x).mStringField.Equals(
            ((TestSerializedObject)y).mStringField))
        {
            return false;
        }
        if (!((TestSerializedObject)x).mInner.Equals(
            ((TestSerializedObject)y).mInner))
        {
            return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        return mIntField;
    }

    public int GetHashCode(object obj)
    {
        return mIntField;
    }
}

[Serializable]
public class TestSerializedObject2 : IEqualityComparer
{

    public int mIntField { get; private set; }
    public string mStringField { get; private set; }

    public TestSerializedObject2()
    {

    }

    public TestSerializedObject2(int lIntField, string lStringField)
    {
        mIntField = lIntField;
        mStringField = lStringField;
    }

    public override bool Equals(object obj)
    {
        return Equals(this, obj);
    }

    public new bool Equals(object x, object y)
    {
        if(! (x is TestSerializedObject2))
        {
            return false;
        }
        if (!(y is TestSerializedObject2))
        {
            return false;
        }
        if (((TestSerializedObject2)x).mIntField !=
            ((TestSerializedObject2)y).mIntField)
        {
            return false;
        }
        if (!((TestSerializedObject2)x).mStringField.Equals(
            ((TestSerializedObject2)y).mStringField))
        {
            return false;
        }
        return true;

    }

    public override int GetHashCode()
    {
        return mIntField;
    }

    public int GetHashCode(object obj)
    {
        return mIntField;
    }
}