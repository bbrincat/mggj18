using System;
using UnityEngine;

public class Player
{
    public GameObject zoomer;
    public KeyCode key;
    public Guid id;
    public bool hasBall;
    public int index;

    public Player()
    {
        id = Guid.NewGuid();
    }
    public Player(KeyCode key)
    {
        id = Guid.NewGuid();
        this.key = key;
    }

    public void TakeBall()
    {
        hasBall = true;
        zoomer.GetComponent<Rotation>().TakeBall();
    }

    public void ReleaseBall()
    {
        hasBall = false;
        zoomer.GetComponent<Rotation>().ReleaseBall();

    }
}
	
