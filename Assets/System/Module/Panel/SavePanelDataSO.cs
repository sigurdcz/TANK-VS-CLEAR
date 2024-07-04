using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SavePanelDataSO", menuName = "SaveData/PanelData")]
public class SavePanelDataSO : ScriptableObject
{
    public List<SavePanelSave> panels = new List<SavePanelSave>();
    public List<SaveSubPanelModel> subPanels = new List<SaveSubPanelModel>();
}
