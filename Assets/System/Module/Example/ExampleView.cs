using UnityEngine;
using UnityEngine.UI;

public class ExampleView : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text realPositionText;
    [SerializeField] private TMPro.TMP_Text modelPositionText;
    [SerializeField] private Transform player;
    [SerializeField] private Button buttonUp;
    [SerializeField] private Button buttonDown;

    [SerializeField] private ExamplePresenter presenter;
    private void Start()
    {
        presenter.GetModel().Position = player.transform.position;
        realPositionText.text = $"Real position: {player.transform.position}";
        modelPositionText.text = $"Model position: {presenter.GetModel().Position}";
    }

    private void OnEnable()
    {
        buttonUp.onClick.AddListener(MoveUp);
        buttonDown.onClick.AddListener(MoveDown);
    }

    private void OnDisable()
    {
        buttonUp.onClick.RemoveListener(MoveUp);
        buttonDown.onClick.RemoveListener(MoveDown);
    }

    private void MoveUp()
    {
        presenter.Move(Vector2.up);
        player.transform.position += (Vector3)Vector2.up;
        realPositionText.text = $"Real position: {player.transform.position}";
        modelPositionText.text = $"Model position: {presenter.GetModel().Position}";
    }

    private void MoveDown()
    {
        presenter.Move(Vector2.down);
        player.transform.position += (Vector3)Vector2.down;
        realPositionText.text = $"Real position: {player.transform.position}";
        modelPositionText.text = $"Model position: {presenter.GetModel().Position}";
    }
}
