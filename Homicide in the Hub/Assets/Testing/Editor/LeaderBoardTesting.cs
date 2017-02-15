using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class LeaderBoardTesting
{
    private Leaderboard lb;

    [TestFixtureSetUp]
    public void TestSetup()
    {

    }

    [Test]
    public void TestLeaderBoard()
    {

        const string filename = "leaderboard.txt";
        List<string> nameList = new List<string>();
        List<int> scoreList = new List<int>();
        int length = File.ReadAllLines(filename).Count();
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

        StreamWriter sw = new StreamWriter(filename);
        for (int x = 0; x < length; x++)
        {
            sw.WriteLine(nameList[x]);
            sw.WriteLine(scoreList[x]);
        }

        sw.Close();
        //now re-initialise the leaderboard
        lb = new Leaderboard();

        //repeat checks to make sure it is not empty
        Assert.IsNotEmpty(lb.GetScoreNames());
        Assert.IsNotEmpty(lb.GetScores());
        Assert.AreNotEqual(0,lb.GetScoreCount());


    }

}
