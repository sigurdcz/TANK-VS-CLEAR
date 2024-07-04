using UnityEngine;

public class PanelAboutController : IPanelController
{
    private IPanelView viewAbout;
    private ISaveService saveService;
    private SavePanelModel model;
    private IPanelView viewMain;
    private Transform aboutLeftContainer;
    private Transform aboutRightContainer;
    private TextSubPanelView aboutTextSubPanelPrefab;
    private ContainerSubPanelView aboutContainerSubPanelPrefab;
    private ButtonView aboutSubPanelButtonPrefab;


    public PanelAboutController(
        IPanelView viewAbout,
        ISaveService saveService,
        SavePanelModel model,
        IPanelView mainView,
        Transform leftContainer,
        Transform rightContainer,
        TextSubPanelView aboutTextSubPanelPrefab,
        ContainerSubPanelView aboutContainerSubPanelPrefab,
        ButtonView aboutSubPanelButtonPrefab
        )
    {
        this.viewAbout = viewAbout;
        this.saveService = saveService;
        this.model = model;
        this.viewMain = mainView;
        this.aboutLeftContainer = leftContainer;
        this.aboutRightContainer = rightContainer;
        this.aboutTextSubPanelPrefab = aboutTextSubPanelPrefab;
        this.aboutContainerSubPanelPrefab = aboutContainerSubPanelPrefab;
        this.aboutSubPanelButtonPrefab = aboutSubPanelButtonPrefab;

        this.viewAbout.SetController(this);
    }

    public void OnPanelInteraction(string interaction)
    {
        switch (interaction)
        {
            case "BackButtonClicked":
                model.IncrementClickCount();
                SavePanelData();
                viewAbout.Hide();
                viewMain.Show();
                break;

            case "LoadSubPanels":
                ClearOldSubPanels();
                LoadSubPanels();
                break;
        }
    }

    private void ClearOldSubPanels()
    {
        foreach (Transform child in aboutLeftContainer)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in aboutRightContainer)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void LoadSubPanels()
    {
        var subPanels = saveService.GetSubPanelData();
        BaseSubPanelView subPanel = null;
        foreach (var subPanelData in subPanels)
        {

            subPanel = GameObject.Instantiate(aboutContainerSubPanelPrefab, aboutLeftContainer);

            if (subPanelData.PanelItems != null && subPanelData.PanelItems.Count > 0)
            {
                subPanel = subPanel.GetComponent<ContainerSubPanelView>();
            }
            else
            {
                subPanel = GameObject.Instantiate(aboutTextSubPanelPrefab, aboutLeftContainer);
            }
            subPanel.Initialize(subPanelData);
            subPanel.gameObject.SetActive(false);

            ButtonView buttonView = GameObject.Instantiate(aboutSubPanelButtonPrefab, aboutRightContainer);
            buttonView.Initialize(subPanel, saveService, aboutLeftContainer);
            buttonView.SetButtonDetails(subPanelData.IconPath, subPanelData.Title);
        }

        if (subPanel != null)
        {
            subPanel.gameObject.SetActive(true);
        }
    }

    private void SavePanelData()
    {
        saveService.SavePanelData(model);
    }
}