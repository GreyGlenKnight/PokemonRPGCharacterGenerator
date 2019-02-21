using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileIO_Tests {

    private static string CLASS_NAME = "FileIO_Tests";
    private static string START_RUNNING_TESTS = "Starting test: {0} - {1}";
    private static int RUN_NUMBER = 2;

    public static void RunAllTests()
    {
        Debug.Log(string.Format(START_RUNNING_TESTS, CLASS_NAME,RUN_NUMBER));

        WriteAndReadTextFileTest();
        XMLReadAndWriteTest();
        BinaryReadAndWriteTest();
    }

    private static void BinaryReadAndWriteTest()
    {
        TestSerializedObject testObj
            = new TestSerializedObject(1, "TestObjStr");

        string fileName = "Assets/Temp/TestOutput.bin";

        SerializationWriter<TestSerializedObject>.SerializeBinary(
            testObj, typeof(TestSerializedObject), fileName);

        object objectFromFile =
            SerializationReader<TestSerializedObject>.DeserializeBinary(fileName);

        Debug.Assert(testObj.Equals(objectFromFile));

        // Cleanup
        System.IO.File.Delete(fileName);
    }

    private static void XMLReadAndWriteTest()
    {
        TestSerializedObject testObj
            = new TestSerializedObject(1, "TestObjStr");

        string fileName = "Assets/Temp/TestOutput.xml";

        SerializationWriter<TestSerializedObject>.SerializeXML(
            testObj, typeof(TestSerializedObject),fileName);

        object objectFromFile =
            SerializationReader<TestSerializedObject>.DeserializeXML(typeof(TestSerializedObject), fileName);

        Debug.Assert(testObj.Equals(objectFromFile));

        // Cleanup
        System.IO.File.Delete(fileName);
    }

    private static void WriteAndReadTextFileTest()
    {
        string testFileName = "Assets/Temp/TestOutput.txt";
        TextWriter testFile = new TextWriter();
        testFile.Open(testFileName);
        testFile.Append("Hello1");
        testFile.Append("Hello2");
        testFile.Dispose();

        TextReader readFile = new TextReader();
        readFile.Open(testFileName);
        Debug.Assert(readFile.NextLine().Equals("Hello1"));
        Debug.Assert(readFile.NextLine().Equals("Hello2"));
        readFile.Close();

        // Cleanup
        System.IO.File.Delete(testFileName);
    }


}
