using System.Collections.Generic;

public class SaveService : ISaveService
{
    private Dictionary<string, SavePanelModel> panelData = new Dictionary<string, SavePanelModel>();
    private List<SaveSubPanelModel> subPanelData = new List<SaveSubPanelModel>();

    public SavePanelModel GetPanelData(string panelName)
    {
        if (!panelData.ContainsKey(panelName))
        {
            panelData[panelName] = new SavePanelModel(panelName);
        }
        return panelData[panelName];
    }

    public void SavePanelData(SavePanelModel panelModel)
    {
        panelData[panelModel.Name] = panelModel;
    }

    public List<SaveSubPanelModel> GetSubPanelData()
    {
        return subPanelData;
    }

    public void SaveSubPanelData(List<SaveSubPanelModel> subPanels)
    {
        subPanelData = subPanels;
    }
}
