using UnityEngine;
using UnityEngine.UI;

public class PanelAboutView : MonoBehaviour, IPanelView
{
    public Button backButton;
    public Transform leftContainer;
    public Transform rightContainer;
    public GameObject subPanelPrefab;
    public GameObject buttonPrefab;
    private IPanelController controller;

    void Start()
    {
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    public void SetController(IPanelController controller)
    {
        this.controller = controller;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        controller.OnPanelInteraction("LoadSubPanels");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnBackButtonClicked()
    {
        controller.OnPanelInteraction("BackButtonClicked");
    }
}
