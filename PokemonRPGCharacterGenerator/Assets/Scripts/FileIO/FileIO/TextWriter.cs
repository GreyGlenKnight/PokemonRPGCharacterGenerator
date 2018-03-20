using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityThreading;

public class TextWriter : IOWriter{

    protected StreamWriter mFileWriter;
    public bool _IsOpen { get; private set; }

    public TextWriter() 
    {
        
    }

    public void Open(string lFilePath)
    {
        if(_IsOpen == true)
        {
            Debug.LogWarning("Try again later");
        }
        OpenFile(lFilePath);

        try
        {
            mFileWriter = new StreamWriter(lFilePath, false);
        }
        catch (ArgumentException e)
        {
            Debug.LogException(e);
            return;
        }
        _IsOpen = true;
    }

    public void Append(string ToAdd)
    {
        Queue.Synchronized(mToWriteQueue).Enqueue(ToAdd);
    }

    protected override void ThreadAction(ActionThread thread)
    {
        while (true)
        {
            if (thread.ShouldStop == true)
            {
                Debug.Log("Ending thread");
                Flush();
                return;
            }
            Flush();
            System.Threading.Thread.Sleep(1000);
        }
    }

    protected override void Flush()
    {
        while (Queue.Synchronized(mToWriteQueue).Count > 0)
        {
            mFileWriter.WriteLine(
                Queue.Synchronized(mToWriteQueue).Dequeue().ToString());
        }
        mFileWriter.Flush();
    }


    protected override void Close()
    {
        if (mFileWriter != null)
        {
            _IsOpen = false;
            mFileWriter.Close();
        }
    }


}
