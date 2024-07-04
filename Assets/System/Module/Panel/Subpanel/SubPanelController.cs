public class SubPanelController
{
    private SubPanelView view;

    public SubPanelController(SubPanelView view)
    {
        this.view = view;
    }

    public void Initialize(SubPanelModel model)
    {
        view.Initialize(model);
    }
}
