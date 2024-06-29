using UnityEngine;

public class Boostrap : MonoBehaviour
{
    [SerializeField] PlayerView ExampleViewPrefab;
    [SerializeField] Transform ViewRoot;

    private void Awake()
    {
        InitExampleModule();
    }

    private void InitExampleModule()
    {
        PlayerModel playerModel = new PlayerModel();
        PlayerPresenter playerPresenter = new PlayerPresenter(playerModel);
        PlayerView playerView = Instantiate(ExampleViewPrefab, ViewRoot);
        playerView.Construct(playerModel, playerPresenter);

        playerModel.Position = new Vector2(400, 230);
    }
}
