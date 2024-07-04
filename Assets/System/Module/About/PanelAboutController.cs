using UnityEngine;

public class PanelAboutController : IPanelController
{
    private IPanelView view;
    private ISaveService saveService;
    private SavePanelModel model;
    private IPanelView mainView;
    private Transform leftContainer;
    private Transform rightContainer;
    private GameObject textSubPanelPrefab;
    private GameObject containerSubPanelPrefab;
    private GameObject buttonPrefab;

    public PanelAboutController(IPanelView view, ISaveService saveService, SavePanelModel model, IPanelView mainView, Transform leftContainer, Transform rightContainer, GameObject textSubPanelPrefab, GameObject containerSubPanelPrefab, GameObject buttonPrefab)
    {
        this.view = view;
        this.saveService = saveService;
        this.model = model;
        this.mainView = mainView;
        this.leftContainer = leftContainer;
        this.rightContainer = rightContainer;
        this.textSubPanelPrefab = textSubPanelPrefab;
        this.containerSubPanelPrefab = containerSubPanelPrefab;
        this.buttonPrefab = buttonPrefab;

        view.SetController(this);
    }

    public void OnPanelInteraction(string interaction)
    {
        switch (interaction)
        {
            case "BackButtonClicked":
                model.IncrementClickCount();
                SavePanelData();
                view.Hide();
                mainView.Show();
                break;

            case "LoadSubPanels":
                ClearOldSubPanels();
                LoadSubPanels();
                break;
        }
    }

    private void ClearOldSubPanels()
    {
        foreach (Transform child in leftContainer)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in rightContainer)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void LoadSubPanels()
    {
        var subPanels = saveService.GetSubPanelData();
        foreach (var subPanelData in subPanels)
        {
            GameObject subPanel;
            BaseSubPanelView subPanelScript;

            if (subPanelData.PanelItems != null && subPanelData.PanelItems.Count > 0)
            {
                subPanel = GameObject.Instantiate(containerSubPanelPrefab, leftContainer);
                subPanelScript = subPanel.GetComponent<ContainerSubPanelView>();
                subPanelScript.Initialize(subPanelData);
            }
            else
            {
                subPanel = GameObject.Instantiate(textSubPanelPrefab, leftContainer);
                subPanelScript = subPanel.GetComponent<TextSubPanelView>();
                subPanelScript.Initialize(subPanelData);
            }

            GameObject button = GameObject.Instantiate(buttonPrefab, rightContainer);
            ButtonView buttonView = button.GetComponent<ButtonView>();
            buttonView.Initialize(subPanel, saveService, leftContainer);
            buttonView.SetButtonDetails(subPanelData.IconPath, subPanelData.Title);
        }
    }

    private void SavePanelData()
    {
        saveService.SavePanelData(model);
    }
}
