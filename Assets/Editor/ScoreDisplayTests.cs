using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTests {
    [Test]
    public void T01Bowl1()
    {
        int[] rolls = { 1 };
        string result = "1";
        Assert.AreEqual(result, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T02X()
    {
        int[] rolls = { 10 };
        string result = "X ";
        Assert.AreEqual(result, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T03Bowl19()
    {
        int[] rolls = { 1, 9 };
        string result = "1/";
        Assert.AreEqual(result, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T04Bowl191()
    {
        int[] rolls = { 1, 9, 1 };
        string result = "1/1";
        Assert.AreEqual(result, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T05SpareInLastFrame()
    {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9,3 };
        string result = "1111111111111111111/3";
        Assert.AreEqual(result, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T06StrikeInLastFrame()
    {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,1,1 };
        string result = "111111111111111111X11";
        Assert.AreEqual(result, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T07Zero()
    {
        int[] rolls = { 0 };
        string result = "-";
        Assert.AreEqual(result, ScoreDisplay.FormatRolls(rolls.ToList()));
    }
}