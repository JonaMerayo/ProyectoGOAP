using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;
    private static Queue<GameObject> monsters;
    private static Queue<GameObject> citizens;
    private static Queue<GameObject> offices;
    private static Queue<GameObject> rooms;
    private static Queue<GameObject> puddles;


    static GWorld()
    {
        world = new WorldStates();
        monsters = new Queue<GameObject>();
        citizens = new Queue<GameObject>();
        rooms = new Queue<GameObject>();
        offices = new Queue<GameObject>();
        puddles = new Queue<GameObject>();


        GameObject[] rms = GameObject.FindGameObjectsWithTag("Room");
        foreach (GameObject t in rms)
            rooms.Enqueue(t);
        if (rms.Length > 0)
            world.ModifyState("freeRoom", rms.Length);


        Time.timeScale = 5;

    }

    private GWorld()
    {
    }

    public void AddMonster(GameObject p)
    {
        monsters.Enqueue(p);
    }
    public GameObject RemoveMonster()
    {
        if (monsters.Count == 0) return null;
        return monsters.Dequeue();
    }
    public void AddCitizen(GameObject p)
    {
        citizens.Enqueue(p);
    }
    public GameObject RemoveCitizen()
    {
        if (citizens.Count == 0) return null;
        return citizens.Dequeue();
    }
    public void AddRoom(GameObject p)
    {
        rooms.Enqueue(p);
    }
    public GameObject RemoveRoom()
    {
        if (rooms.Count == 0) return null;
        return rooms.Dequeue();
    }

    public static GWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}
