using UnityEngine;

public class Boostrap : MonoBehaviour
{
    [SerializeField] PlayerView ExampleViewPrefab;
    [SerializeField] Transform ViewRoot;

    SaveService saveService;

    private void Awake()
    {
        saveService = new SaveService();
        InitExampleModule();
    }

    private void InitExampleModule()
    {
        PlayerModel playerModel = new PlayerModel(saveService);
        PlayerPresenter playerPresenter = new PlayerPresenter(playerModel);
        PlayerView playerView = Instantiate(ExampleViewPrefab, ViewRoot);
        playerView.Construct(playerModel, playerPresenter);
        playerView.enabled = true;

        playerModel.LoadData();
    }
}
