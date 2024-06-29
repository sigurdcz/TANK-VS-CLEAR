using System;
using UnityEngine;

public class PlayerPresenter: MonoBehaviour
{
    private PlayerModel model;

    public PlayerPresenter(PlayerModel exampleModel)
    {
        model = exampleModel;
    }

    public void Move(Vector2 direction)
    {
        model.Position += direction;
        model.SaveData();
    }

    private void OnDisable()
    {
        model.SaveData();
    }
}
