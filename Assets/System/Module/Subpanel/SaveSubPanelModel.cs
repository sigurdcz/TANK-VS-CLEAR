using System.Collections.Generic;

[System.Serializable]
public class SaveSubPanelModel
{
    public string IconPath;
    public string Title;
    public string TextContent;
    public List<PanelItemModel> PanelItems;
}

[System.Serializable]
public class PanelItemModel
{
    public string IconPath;
    public string TextContent;
}
