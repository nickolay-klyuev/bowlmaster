using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class ActionMasterTest
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private ActionMaster actionMaster;

    [SetUp]
    public void Setup()
    {
        actionMaster = new ActionMaster();
    }

    [Test]
    public void T01OneStrikeReturnEndTurn()
    {
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }
    
    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T03Bowl28SpareReturnsEndTurn()
    {
        actionMaster.Bowl(8);
        Assert.AreEqual(endTurn, actionMaster.Bowl(2));
    }

    [Test]
    public void T05CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }; // 18
        foreach(int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(4);
        Assert.AreEqual(reset, actionMaster.Bowl(6));
    }

    [Test]
    public void T06YouTubeRollsEndInEndGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2 }; // 16
        foreach(int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(9));
    }

    [Test]
    public void T07GameEndsAtBowl20()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }; // 19
        foreach(int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(1));
    }
}
