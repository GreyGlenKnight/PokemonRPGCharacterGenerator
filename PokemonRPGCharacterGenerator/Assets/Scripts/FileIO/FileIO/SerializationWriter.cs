using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System;
using System.IO;
using System.Runtime.Serialization;
using UnityThreading;
using System.Runtime.Serialization.Formatters.Binary;

public enum SerilizationType
{
    Binary,
    XML
}

public class SerializationWriter<T> : IOWriter
{
    List<T> mData;
    SerilizationType mSerilizationType;

    public SerializationWriter(
        SerilizationType lSerilizationType) 
    {
        mData = new List<T>();
        mSerilizationType = lSerilizationType;
    }

    public void Open(string lFileName)
    {
        OpenFile(lFileName);
    }

    public void Append(T lData)
    {
        mData.Add(lData);
    }

    protected override void Flush()
    {
        switch (mSerilizationType)
        {
            case SerilizationType.Binary:
                SerializeBinary(mData, typeof(List<T>), mFileName);
                break;
            case SerilizationType.XML:
                SerializeXML(mData, typeof(List<T>), mFileName);
                break;
            default:
                Debug.LogError("Serilization Type not defined");
                break;
        }
        
    }

    protected override void Close()
    {
        mData.Clear();
    }

    protected override void ThreadAction(ActionThread thread)
    {
        return; // end the thread
    }

    public static void SerializeXML(object obj, Type classType, string lFilePath)
    {
        XmlSerializer mySerializer = new XmlSerializer(typeof(T));

        BackupOldFile(lFilePath);
        StreamWriter stream = new StreamWriter(lFilePath);

        try
        {
            mySerializer.Serialize(stream, obj);
        }
        catch (SerializationException ex)
        {
            Debug.Log("Exception for Serialization data : " + ex.Message);
            throw;
        }
        finally
        {
            stream.Close();
        }
    }


    public static void SerializeBinary(object obj, Type classType, string lFilePath)
    {
        Stream stream = File.Open(lFilePath, FileMode.Create);
        BinaryFormatter bformatter = new BinaryFormatter();
        Console.WriteLine("Writing Information");
        try
        {
            bformatter.Serialize(stream, obj);
        }
        catch (SerializationException ex)
        {
            Console.WriteLine("Exception for Serialization data : " + ex.Message);
            throw;
        }
        finally
        {
            stream.Close();
            Console.WriteLine("successfully wrote Employee information");
        }
    }

}
