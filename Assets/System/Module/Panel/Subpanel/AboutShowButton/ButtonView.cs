using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text buttonText;

    private BaseSubPanelView subPanel;
    private ISaveService saveService;
    private Transform parentContainer;

    public void Initialize(BaseSubPanelView subPanel, ISaveService saveService, Transform parentContainer)
    {
        this.subPanel = subPanel;
        this.saveService = saveService;
        this.parentContainer = parentContainer;
        GetComponent<Button>().onClick.AddListener(ToggleSubPanel);
    }

    public void SetButtonDetails(string iconPath, string text)
    {
        // Load icon from resources
        Sprite iconSprite = Resources.Load<Sprite>(iconPath);
        icon.sprite = iconSprite;
        buttonText.text = text;
    }

    void ToggleSubPanel()
    {
        // Hide all subpanels
        foreach (Transform child in parentContainer)
        {
            child.gameObject.SetActive(false);
        }

        // Show the selected subpanel
        subPanel.gameObject.SetActive(true);

        var panelData = saveService.GetPanelData(subPanel.GetComponent<BaseSubPanelView>().PanelName);
        panelData.ClickCount++;
        saveService.SavePanelData(panelData);
    }
}
