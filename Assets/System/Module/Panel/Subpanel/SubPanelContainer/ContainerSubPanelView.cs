using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContainerSubPanelView : BaseSubPanelView
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text title;
    [SerializeField] private Transform container;
    [SerializeField] private PanelItemView panelPrefab;

    public override void Initialize(SubPanelModel model)
    {
        // Load icon from resources
        Sprite iconSprite = Resources.Load<Sprite>(model.IconPath);
        icon.sprite = iconSprite;
        title.text = model.Title;

        foreach (var panelItemModel in model.PanelItems)
        {
            PanelItemView panelItem = Instantiate(panelPrefab, container);
            panelItem.Initialize(panelItemModel);
        }
    }
}
