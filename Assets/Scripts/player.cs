using System;
using UnityEngine;

public class Player
{
    public GameObject zoomer;
    public KeyCode key;
    public Guid id;
    public bool hasBall; 

    public Player()
    {
        id = Guid.NewGuid();
    }
    public Player(KeyCode key)
    {
        id = Guid.NewGuid();
        this.key = key;
    }
}
	
