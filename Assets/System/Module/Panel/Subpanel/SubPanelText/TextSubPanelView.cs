using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextSubPanelView : BaseSubPanelView
{
    public Image icon;
    public TMP_Text title;
    public TMP_Text textContent;

    public override void Initialize(SubPanelModel model)
    {
        // Load icon from resources
        Sprite iconSprite = Resources.Load<Sprite>(model.IconPath);
        icon.sprite = iconSprite;
        title.text = model.Title;
        textContent.text = model.TextContent;
    }
}
