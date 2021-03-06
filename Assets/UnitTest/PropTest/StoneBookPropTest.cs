using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StoneBookPropTest
{
    GameObject go;
    StoneBookProp prop;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        go = new GameObject();
        var player = go.AddComponent<PlayerDataMgr>();
        go.AddComponent<SoundManager>();
        go.AddComponent<MusicManager>();
        go.AddComponent<AudioListener>();
        go.AddComponent<GameControl>();
        yield return new WaitForFixedUpdate();
        prop = new StoneBookProp();
        player.Init();
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        GameObject.Destroy(go);
        prop = null;    
        yield return null;
    }
    [Test]
    public void StoneBookPropTestSimplePasses1()
    {
        Treasure treasure = TreasurePool.GetTreasure(TreasureID.MinStone).GetComponent<Treasure>();
        int score1 = PlayerDataMgr.Instance.Score;
        prop.OnGrab(treasure);
        int score2 = PlayerDataMgr.Instance.Score;
        Assert.AreEqual(score1 + treasure.Score, score2);
    }

    [Test]
    public void StoneBookPropTestSimplePasses2()
    {
        Treasure treasure = TreasurePool.GetTreasure(TreasureID.BigStone).GetComponent<Treasure>();
        int score1 = PlayerDataMgr.Instance.Score;
        prop.OnGrab(treasure);
        int score2 = PlayerDataMgr.Instance.Score;
        Assert.AreEqual(score1 + treasure.Score, score2);
    }
    [Test]
    public void StoneBookPropTestSimplePasses3()
    {
        Treasure treasure = TreasurePool.GetTreasure(TreasureID.Mouse).GetComponent<Treasure>();
        int score1 = PlayerDataMgr.Instance.Score;
        prop.OnGrab(treasure);
        int score2 = PlayerDataMgr.Instance.Score;
        Assert.AreEqual(score1, score2);
    }
}
