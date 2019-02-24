using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public enum FileReadFailureType
{
    NoError = 0,
    InvalidFileName,
    FileNameNull,
    FileNotFound,
}

public class TextReader
{

    public string mFileName { get; private set; }
    public int mCurrentLineIndex { get; private set; }
    public FileReadFailureType mFailedToOpenErrorFlag { get; private set; }
    StreamReader mStreamReader;
    public bool _IsClosed { get; private set; }

    public TextReader()
    {

    }

    public void Open(string lFileName)
    {
        if (lFileName == null)
        {
            ArgumentNullException e
                = new ArgumentNullException("File name can not be null");
            Debug.LogException(e);
            mFailedToOpenErrorFlag = FileReadFailureType.FileNameNull;
            return;
        }

        FileStream fileStream;
        try
        {
            fileStream = new FileStream(
               lFileName,
               FileMode.Open, // Will not create a file if the file does not already exist
               FileAccess.Read, // Request Read permission only (can not write)
               FileShare.Read); // Other programs may have the file open but can not write
        }
        catch (FileNotFoundException e)
        {
            Debug.LogException(e);
            mFailedToOpenErrorFlag = FileReadFailureType.FileNotFound;
            return;
        }
        catch (ArgumentException e) // lFileName containes invalid characters or is empty
        {
            Debug.LogException(e);
            mFailedToOpenErrorFlag = FileReadFailureType.InvalidFileName;
            return;
        }
        mFailedToOpenErrorFlag = FileReadFailureType.NoError;
        _IsClosed = false;
        mFileName = lFileName;
        mStreamReader = new StreamReader(fileStream);
        mCurrentLineIndex = 0;
    }

    public String NextLine()
    {
        if (_IsClosed == true)
        {
            Debug.LogWarning("trying to read from closed file");
            return "";
        }

        mCurrentLineIndex++;
        string nextLine = mStreamReader.ReadLine();
        if (nextLine != null)
        {
            return nextLine;
        }
        else
        {
            _IsClosed = true;
            mStreamReader.Close();
            return null;
        }
    }

    public void Close()
    {
        _IsClosed = true;
        mStreamReader.Close();
    }
}
    //public String[] NextLine(string lDelim)
    //{
    //    //using (theReader) {
    //    mCurrentLineIndex++;
    //    mCurrentBuffer = mStreamReader.ReadLine();
    //    if (mCurrentBuffer != null)
    //    {
    //        string[] entries = mCurrentBuffer.Split(',');
    //        if (entries.Length > 0)
    //            return entries;
    //        else
    //            mStreamReader.Close();
    //        return null;
    //    }
    //    else
    //    {
    //        mStreamReader.Close();
    //        return null;
    //    }
    //}

    //// Return a list of arrays each with size length x Width
    //public List<int[,]> GetIntLineCommaDelim(int width, int height)
    //{
    //    List<int[,]> returnVal = new List<int[,]>();

    //    int[] currentLine;

    //    currentLine = getIntLineCommaDelim();

    //    int widthDivisions = 0;

    //    // Find the number of arrays 
    //    for (int i = 0; i < currentLine.Length; i += width)
    //    {
    //        returnVal.Add(new int[width, height]);
    //        widthDivisions++;
    //    }

    //    Debug.Log("widthDivisions 2 : " + widthDivisions);

    //    int currentHeight = 0;
    //    int currentWidth = 0;
    //    int currentDivision = 0;

    //    int[,] currentArray;

    //    //currentLine = getIntLineCommaDelim();
    //    if (currentLine == null)
    //    {
    //        Debug.Log("found no lines left, returning null");
    //        return null;
    //    }

    //    while (currentLine != null)
    //    {
    //        currentWidth = -1;
    //        Debug.Log("current Divisions: " + currentDivision);
    //        // Process current line
    //        for (int j = 0; j < currentLine.Length; j++)
    //        {
    //            currentWidth++;

    //            if (currentWidth == width)
    //            {
    //                currentDivision++;
    //                currentWidth = 0;
    //            }
    //            // Trouble Line 
    //            Debug.Log("current Divisions: " + currentDivision);

    //            if (currentDivision < widthDivisions)
    //            {
    //                currentArray = returnVal[currentDivision];

    //                currentArray[currentWidth, currentHeight] = currentLine[j];
    //                Debug.Log(currentDivision + ":" + currentWidth + "," + currentHeight + " = " + currentLine[j]);
    //            }
    //            else
    //            {
    //                Debug.Log("Discarding: " + currentLine[j]);
    //            }
    //        }

    //        currentDivision = 0;
    //        Debug.Log("reset Division: " + currentDivision);

    //        currentHeight++;
    //        if (currentHeight == height)
    //            break;

    //        currentLine = getIntLineCommaDelim();
    //        if (currentLine == null)
    //        {
    //            currentLine = new int[width * widthDivisions];
    //            Debug.Log("Creating blank lines");
    //        }
    //    }
    //    return returnVal;
    //}

    ////public int[,] getIntLineCommaDelim(int length, int width)
    ////{
    ////    return new int[1,1];
    ////}

    //public int[] getIntLineCommaDelim()
    //{
    //    mCurrentBuffer = mStreamReader.ReadLine();
    //    mCurrentLineIndex++;

    //    if (mCurrentBuffer != null)
    //    {
    //        string[] entries = mCurrentBuffer.Split(',');
    //        int[] intEntries = new int[entries.Length];

    //        for (int i = 0; i < entries.Length; i++)
    //        {
    //            try
    //            {
    //                intEntries[i] = Convert.ToInt32(entries[i]);
    //            }
    //            catch (Exception e)
    //            {
    //                intEntries[i] = 0;
    //            }
    //        }

    //        if (entries.Length > 0)
    //            return intEntries;
    //        else
    //            mStreamReader.Close();

    //        return null;
    //    }
    //    else
    //    {
    //        mStreamReader.Close();
    //        return null;
    //    }
    //}


