public interface IPanelModel
{
    string Name { get; }
    int ClickCount { get; }
    bool IsShown { get; }
    void IncrementClickCount();
    void SetShown(bool isShown);
}
