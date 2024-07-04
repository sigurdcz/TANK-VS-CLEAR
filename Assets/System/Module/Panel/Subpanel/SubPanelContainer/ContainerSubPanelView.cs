using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ContainerSubPanelView : BaseSubPanelView
{
    public Image icon;
    public TMP_Text title;
    public Transform container; // Container for additional panels
    public GameObject panelPrefab; // Prefab for additional panels

    public override void Initialize(SubPanelModel model)
    {
        // Load icon from resources
        Sprite iconSprite = Resources.Load<Sprite>(model.IconPath);
        icon.sprite = iconSprite;
        title.text = model.Title;

        foreach (var panelItemModel in model.PanelItems)
        {
            GameObject panel = Instantiate(panelPrefab, container);
            PanelItemView panelItem = panel.GetComponent<PanelItemView>();
            panelItem.Initialize(panelItemModel);
        }
    }
}
