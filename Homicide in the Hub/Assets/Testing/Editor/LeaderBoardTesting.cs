using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using UnityTest;

public class LeaderBoardTesting
{
    private Leaderboard lb;


    [Test]
    public void TestLeaderBoard()
    {

        const string filename = "leaderboard.txt";
        List<string> nameList = new List<string>();
        List<int> scoreList = new List<int>();
        Boolean isFileEmpty = false;
        int length = File.ReadAllLines(filename).Length;
        Debug.Log("length of scores = " + length);

        lb = new Leaderboard();
        StreamReader sr = new StreamReader(filename);


        //make sure file is an even number of lines
        //File is setup as:
        /////////////
        //"Name" /n
        //score /n
        /////////////
        //so we need to make sure the file has the right data in it
        Assert.AreEqual(0, length % 2);
        if (length == 0)
        {
            isFileEmpty = true;
        }

        //load any contents of the leaderboard to ensure they are not lost
        while (!sr.EndOfStream)
        {
            nameList.Add(sr.ReadLine());
            scoreList.Add(int.Parse(sr.ReadLine()));
        }
        sr.Close();

        //clear the file
        File.WriteAllText(filename,string.Empty);
        //initialise the leaderboard
        lb = new Leaderboard();


        //file should be empty so the leaderboard should also be empty
        Assert.AreEqual(0, lb.GetScoreCount());
        Assert.IsEmpty(lb.GetScores());
        Assert.IsEmpty(lb.GetScoreNames());

        //now load data back to file and re initialise

        /*
        StreamWriter sw = new StreamWriter(filename);
        if (!isFileEmpty)
        {
            for (int x = 0; x < length - 2; x++)
            {
                Debug.Log(x);
                sw.WriteLine(nameList[x]);
                sw.WriteLine(scoreList[x]);
            }
        }
        else
        {
            sw.WriteLine("TestName");
            sw.WriteLine("999");
        }

        sw.Close();
        //now re-initialise the leaderboard
        Leaderboard lb1 = new Leaderboard();

        //repeat checks to make sure it is not empty
        Assert.IsNotEmpty(lb1.GetScoreNames());
        Assert.IsNotEmpty(lb1.GetScores());
        Assert.AreNotEqual(0,lb1.GetScoreCount());


        //if file was empty and default values had to be added in then remove them now
        File.WriteAllText(filename,string.Empty);
        */
    }

}
