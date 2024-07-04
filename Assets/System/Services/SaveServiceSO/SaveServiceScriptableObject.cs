using System.Collections.Generic;
using UnityEngine;

public class SaveServiceScriptableObject : ISaveService
{
    private SavePanelDataSO saveData;

    public SaveServiceScriptableObject(SavePanelDataSO saveData)
    {
        this.saveData = saveData;
    }

    public SavePanelModel GetPanelData(string panelName)
    {
        var panelSave = saveData.panels.Find(panel => panel.Name == panelName);
        if (panelSave == null)
        {
            return new SavePanelModel(panelName);
        }
        return new SavePanelModel(panelSave.Name)
        {
            ClickCount = panelSave.ClickCount,
            IsShown = panelSave.IsShown
        };
    }

    public void SavePanelData(SavePanelModel panelModel)
    {
        var panelSave = saveData.panels.Find(panel => panel.Name == panelModel.Name);
        if (panelSave != null)
        {
            panelSave.ClickCount = panelModel.ClickCount;
            panelSave.IsShown = panelModel.IsShown;
        }
        else
        {
            saveData.panels.Add(new SavePanelSave
            {
                Name = panelModel.Name,
                ClickCount = panelModel.ClickCount,
                IsShown = panelModel.IsShown
            });
        }
    }

    public List<SaveSubPanelModel> GetSubPanelData()
    {
        var subPanelModels = new List<SaveSubPanelModel>();
        foreach (var subPanelSave in saveData.subPanels)
        {
            subPanelModels.Add(new SaveSubPanelModel
            {
                IconPath = subPanelSave.IconPath,
                Title = subPanelSave.Title,
                TextContent = subPanelSave.TextContent,
                PanelItems = subPanelSave.PanelItems
            });
        }
        return subPanelModels;
    }

    public void SaveSubPanelData(List<SaveSubPanelModel> subPanels)
    {
        saveData.subPanels.Clear();
        foreach (var subPanelModel in subPanels)
        {
            saveData.subPanels.Add(new SaveSubPanelModel
            {
                IconPath = subPanelModel.IconPath,
                Title = subPanelModel.Title,
                TextContent = subPanelModel.TextContent,
                PanelItems = subPanelModel.PanelItems
            });
        }
    }
}
