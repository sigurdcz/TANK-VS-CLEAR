using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text realPositionText;
    [SerializeField] private TMPro.TMP_Text modelPositionText;
    [SerializeField] private Transform player;
    [SerializeField] private Button buttonUp;
    [SerializeField] private Button buttonDown;

    private PlayerPresenter presenter;
    private PlayerModel model;

    public void Construct(PlayerModel exampleModel, PlayerPresenter examplePresenter)
    {
        model = exampleModel;
        presenter = examplePresenter;
    }

    private void OnEnable()
    {
        buttonUp.onClick.AddListener(MoveUp);
        buttonDown.onClick.AddListener(MoveDown);
        model.OnPositionUpdate += RerenderView;

        RerenderView();
    }

    private void OnDisable()
    {
        buttonUp.onClick.RemoveListener(MoveUp);
        buttonDown.onClick.RemoveListener(MoveDown);
        model.OnPositionUpdate += RerenderView;
    }

    private void MoveUp()
    {
        presenter.Move(Vector2.up);
    }

    private void MoveDown()
    {
        presenter.Move(Vector2.down);
    }

    private void RerenderView()
    {
        player.transform.localPosition = model.Position;
        realPositionText.text = $"Real position: {player.transform.localPosition}";
        modelPositionText.text = $"Model position: {model.Position}";
    }
}
