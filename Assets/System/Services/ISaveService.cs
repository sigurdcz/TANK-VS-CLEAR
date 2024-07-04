using System.Collections.Generic;

public interface ISaveService
{
    SavePanelModel GetPanelData(string panelName);
    void SavePanelData(SavePanelModel panelModel);
    List<SaveSubPanelModel> GetSubPanelData();
    void SaveSubPanelData(List<SaveSubPanelModel> subPanels);
}
