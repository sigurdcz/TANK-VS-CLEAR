using System.Collections.Generic;

public interface ISaveService
{
    SavePanelModel GetPanelData(string panelName);
    void SavePanelData(SavePanelModel panelModel);
    List<SubPanelModel> GetSubPanelData();
    void SaveSubPanelData(List<SubPanelModel> subPanels);
}
