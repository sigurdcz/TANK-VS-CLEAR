using System;
using UnityEngine;
using UnityEngine.UI;

public class PanelAboutView : MonoBehaviour, IPanelView
{
    [SerializeField] private Button backButton;
    [SerializeField] private Transform leftContainer;
    [SerializeField] private Transform rightContainer;

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

    public Transform GetRightContainer()
    {
        return rightContainer;
    }

    public Transform GetLeftContainer()
    {
        return leftContainer; 
    }
}
