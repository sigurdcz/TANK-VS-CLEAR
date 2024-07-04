public class TextSubPanelController
{
    private TextSubPanelView view;

    public TextSubPanelController(TextSubPanelView view)
    {
        this.view = view;
    }

    public void Initialize(SubPanelModel model)
    {
        view.Initialize(model);
    }
}
