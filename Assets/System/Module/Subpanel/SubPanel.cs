using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubPanel : MonoBehaviour
{
    public Image icon;
    public TMP_Text title;
    public TMP_Text textContent;
    public string panelName;

    public void Initialize(string iconPath, string titleText, string contentText)
    {
        // Load icon from resources
        Sprite iconSprite = Resources.Load<Sprite>(iconPath);
        icon.sprite = iconSprite;
        title.text = titleText;
        textContent.text = contentText;
    }
}
