using System;
using UnityEngine;

public class ExamplePresenter: MonoBehaviour
{
    private ExampleModel model;

    public ExamplePresenter(ExampleModel exampleModel)
    {
        model = exampleModel;
    }

    private void Awake()
    {
        model = new ExampleModel();
    }

    public void Move(Vector2 direction)
    {
        model.Position += direction;
    }

    public ExampleModel GetModel()
    {
        return model;
    }
}
