using System;
using UnityEngine;
public class PlayerModel
{
    private Vector2 position;
    private Vector2 zero;
    private float speed = 5;

    public event Action OnPositionUpdate;

    public Vector2 Position
    {
        get { return position; }
        set { position = value; OnPositionUpdate?.Invoke(); }
    }

    public float Speed { 
        get => speed; 
        set => speed = value; 
    }
}
