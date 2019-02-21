using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityThreading;
using System.IO;
using System;

public abstract class IOWriter : IDisposable
{
    public string mFileName { get; protected set; }
    protected Queue mToWriteQueue;
    protected ActionThread mWriteAction;

    Dispatcher thisDispacher;

    protected void OpenFile(string lFilePath)
    {
        BackupOldFile(lFilePath);
        mToWriteQueue = new Queue();
        mFileName = lFilePath;

        // Setup the Action Thread
        if(thisDispacher == null)
            thisDispacher = new Dispatcher();
        mWriteAction = new ActionThread(ThreadAction);
    }

    protected abstract void ThreadAction(ActionThread thread);
    protected abstract void Flush();
    protected abstract void Close();


    public void FlushAndClose()
    {
        // Abort thread
        if (mWriteAction.IsAlive)
            mWriteAction.AbortWaitForSeconds(5000);

        Flush();
        Close();
    }

    public void Dispose()
    {
        FlushAndClose();
    }

    protected static string BackupOldFile(string lOldFilePath)
    {
        if (!File.Exists(lOldFilePath))
        {
            // No need to backup file
            return null;
        }

        int fileBackupNumber = 0;
        
        string extension = lOldFilePath.Substring(lOldFilePath.IndexOf('.'));

        string baseName = lOldFilePath.Substring(
            lOldFilePath.LastIndexOf('/'),
            lOldFilePath.IndexOf('.') - lOldFilePath.LastIndexOf('/'));

        string path = lOldFilePath.Substring(0, lOldFilePath.LastIndexOf('/'));


        string[] namesTried = new string[20];

        Debug.Log(path +","+ baseName +","+ extension);

        // See if the file basename000.extension already exists
        string newFileName = path + "/BU" + baseName +
            fileBackupNumber.ToString().PadLeft(2, '0') +
            extension;

        while (File.Exists(newFileName))
        {
            namesTried[fileBackupNumber] = newFileName;
            fileBackupNumber++;

            newFileName = path + "/BU" + baseName +
                fileBackupNumber.ToString().PadLeft(2, '0') +
                extension;

            if (fileBackupNumber >= 50)
                Debug.LogWarning("over 10 backup files, please cleanup old data");

            if (fileBackupNumber >= 100)
            {
                Debug.LogWarning("Automatic cleanup moving old data");
                for (int i = 0; i < 10; i++)
                {
                    File.Delete(namesTried[i]);
                    File.Move(namesTried[i + 10], namesTried[i]);
                }
                newFileName = namesTried[10];
            }
        }
        File.Move(lOldFilePath, newFileName);

        return newFileName;
    }

}
