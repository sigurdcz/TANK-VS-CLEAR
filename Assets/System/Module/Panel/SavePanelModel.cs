public class SavePanelModel
{
    public string Name { get; set; }
    public int ClickCount { get; set; }
    public bool IsShown { get; set; }

    public SavePanelModel(string name)
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
