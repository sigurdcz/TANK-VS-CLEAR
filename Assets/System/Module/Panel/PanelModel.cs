public class PanelModel : IPanelModel
{
    public string Name { get; private set; }
    public int ClickCount { get; private set; }
    public bool IsShown { get; private set; }

    public PanelModel(string name)
    {
        Name = name;
        ClickCount = 0;
        IsShown = false;
    }

    public void IncrementClickCount()
    {
        ClickCount++;
    }

    public void SetShown(bool isShown)
    {
        IsShown = isShown;
    }
}
