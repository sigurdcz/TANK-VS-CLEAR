using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelItemView : MonoBehaviour
{
    public Image icon;
    public TMP_Text text;

    public void Initialize(PanelItemModel model)
    {
        // Load icon from resources
        Sprite iconSprite = Resources.Load<Sprite>(model.IconPath);
        icon.sprite = iconSprite;
        text.text = model.TextContent;
    }
}
