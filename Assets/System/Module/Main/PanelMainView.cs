using UnityEngine;
using UnityEngine.UI;

public class PanelMainView : MonoBehaviour, IPanelView
{
    public Button aboutButton;
    public Button quitButton;
    private IPanelController controller;

    void Start()
    {
        aboutButton.onClick.AddListener(OnAboutButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    public void SetController(IPanelController controller)
    {
        this.controller = controller;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnAboutButtonClicked()
    {
        controller.OnPanelInteraction("AboutButtonClicked");
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
