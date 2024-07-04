using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PanelItem : MonoBehaviour
{
    public Image icon;
    public TMP_Text text;

    public void Initialize(string iconPath, string textContent)
    {
        // Load icon from resources
        Sprite iconSprite = Resources.Load<Sprite>(iconPath);
        icon.sprite = iconSprite;
        text.text = textContent;
    }
}
