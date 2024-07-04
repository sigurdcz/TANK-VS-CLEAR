using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ContainerSubPanel : BaseSubPanel
{
    public Image icon;
    public TMP_Text title;
    public Transform container; // Container for additional panels
    public GameObject panelPrefab; // Prefab for additional panels

    public override void Initialize(string iconPath, string titleText, string contentText)
    {
        // Load icon from resources
        Sprite iconSprite = Resources.Load<Sprite>(iconPath);
        icon.sprite = iconSprite;
        title.text = titleText;

        // Assume contentText contains data for additional panels
        string[] panelDataArray = contentText.Split(';'); // Example data format: "iconPath1,text1;iconPath2,text2"

        foreach (string panelData in panelDataArray)
        {
            string[] panelFields = panelData.Split(',');
            if (panelFields.Length == 2)
            {
                GameObject panel = Instantiate(panelPrefab, container);
                PanelItem panelItem = panel.GetComponent<PanelItem>();
                panelItem.Initialize(panelFields[0], panelFields[1]);
            }
        }
    }

    public void Initialize(string iconPath, string titleText, List<PanelItemModel> panelItems)
    {
        // Load icon from resources
        Sprite iconSprite = Resources.Load<Sprite>(iconPath);
        icon.sprite = iconSprite;
        title.text = titleText;

        foreach (var panelItemModel in panelItems)
        {
            GameObject panel = Instantiate(panelPrefab, container);
            PanelItem panelItem = panel.GetComponent<PanelItem>();
            panelItem.Initialize(panelItemModel.IconPath, panelItemModel.TextContent);
        }
    }
}
