using UnityEngine;
using UnityEngine.UI;

public class PanelAboutController : IPanelController
{
    private IPanelView view;
    private ISaveService saveService;
    private SavePanelModel model;
    private IPanelView mainView;
    private Transform leftContainer;
    private Transform rightContainer;
    [SerializeField] private TextSubPanelView textSubPanelPrefab;
    [SerializeField] private ContainerSubPanelView containerSubPanelPrefab;
    [SerializeField] private ButtonView buttonPrefab;  


    public PanelAboutController(IPanelView view, ISaveService saveService, SavePanelModel model, IPanelView mainView, Transform leftContainer, Transform rightContainer, TextSubPanelView textSubPanelPrefab, ContainerSubPanelView containerSubPanelPrefab, ButtonView buttonPrefab)
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
        BaseSubPanelView subPanel = null;
        foreach (var subPanelData in subPanels)
        {
            
            subPanel = GameObject.Instantiate(containerSubPanelPrefab, leftContainer);

            if (subPanelData.PanelItems != null && subPanelData.PanelItems.Count > 0)
            {
                subPanel = subPanel.GetComponent<ContainerSubPanelView>();
            }
            else
            {
                subPanel = GameObject.Instantiate(textSubPanelPrefab, leftContainer);
            }
            subPanel.Initialize(subPanelData);
            subPanel.gameObject.SetActive(false);

            ButtonView buttonView = GameObject.Instantiate(buttonPrefab, rightContainer);
            buttonView.Initialize(subPanel, saveService, leftContainer);
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
