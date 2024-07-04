public class PanelMainController : IPanelController
{
    private IPanelView view;
    private ISaveService saveService;
    private SavePanelModel model;
    private IPanelView aboutView;

    public PanelMainController(IPanelView view, ISaveService saveService, SavePanelModel model, IPanelView aboutView)
    {
        this.view = view;
        this.saveService = saveService;
        this.model = model;
        this.aboutView = aboutView;

        view.SetController(this);
    }

    public void OnPanelInteraction(string interaction)
    {
        switch (interaction)
        {
            case "AboutButtonClicked":
                model.IncrementClickCount();
                SavePanelData();
                view.Hide();
                aboutView.Show();
                break;
        }
    }

    private void SavePanelData()
    {
        saveService.SavePanelData(model);
    }
}
