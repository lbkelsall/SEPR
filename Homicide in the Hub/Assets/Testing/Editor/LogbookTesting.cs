using JetBrains.Annotations;
using NUnit.Framework;

public class LogbookTesting{

    private Logbook logbook;
    private VerbalClue verbalClue;

    [TestFixtureSetUp]
    public void TestSetup()
    {
        logbook = new Logbook();
        verbalClue = new VerbalClue(null,null);
        logbook.AddVerbalClueToLogbook (verbalClue);
    }

	[Test]
	public void AddVerbalClueToLogbookTest()
	{
		//Assert
		//The logbook contains the the verbalClue
		Assert.IsTrue (logbook.GetLogbook ().Contains (verbalClue));
	}

	[Test]
	public void ResetLogbookTest()
	{
	    logbook.Reset();
		//Assert
		//The logbook is empty
		Assert.IsEmpty (logbook.GetLogbook ());
	}

	[Test]
	public void GetLengthOfLogbookTest()
	{
        //Assert
		//The logbook is has length one
		Assert.AreEqual (logbook.GetListLength (),1);
	}

    //Added cleanup so that the variables are reset properly after each test
    [TestFixtureTearDown]
    public void TestCleanup()
    {
        logbook.Reset();
    }

}
