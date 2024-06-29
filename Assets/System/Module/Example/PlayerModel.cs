using System;
using UnityEngine;
public class PlayerModel
{
    private Vector2 position;
    private Vector2 zero;
    private float speed = 5;
    private SaveService saveService;
    private const string SaveKeyPosition = "Position";

    public PlayerModel(SaveService saveService)
    {
        this.saveService = saveService;
    }

    public void LoadData()
    {
        Position = saveService.LoadVector2(SaveKeyPosition, Position);
    }

    public void SaveData()
    {
        saveService.SaveVector2(SaveKeyPosition, Position);
    }

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
