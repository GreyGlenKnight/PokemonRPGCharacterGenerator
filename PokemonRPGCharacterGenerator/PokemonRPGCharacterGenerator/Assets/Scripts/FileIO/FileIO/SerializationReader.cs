using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SerializationReader<T>
{

    public static T DeserializeBinary(string filename)
    {
        T objectToRead;

        Stream stream = File.Open(filename, FileMode.Open);
        BinaryFormatter bformatter = new BinaryFormatter();
        try
        {
            objectToRead = (T)bformatter.Deserialize(stream);
            //Thread.Sleep(500);
        }
        catch (SerializationException ex)
        {
            Debug.Log("Exception for Deserialize data : " + ex.Message);
            throw;
        }
        finally
        {
            stream.Close();
        }
        if (objectToRead != null)
        {
            //Debug.Log(objectToRead);
        }
        else
        {
            Debug.Log("Deserialize Employee null value");
        }
        return objectToRead;
    }


    public static T DeserializeXML(Type classType, string filename)
    {
        T mp;
        XmlSerializer mySerializer = new XmlSerializer(classType);
        FileStream myFileStream = new FileStream(filename, FileMode.Open);
        try
        {
            mp = (T) mySerializer.Deserialize(myFileStream);
            //Thread.Sleep(500);
        }
        catch (SerializationException ex)
        {
            Debug.Log("Exception for Deserialize data : " + ex.Message);
            throw;
        }
        finally
        {
            myFileStream.Close();
        }
        if (mp != null)
        {

        }
        else
        {
            Debug.Log("Deserialize object null value");
        }
        return mp;
    }

}
