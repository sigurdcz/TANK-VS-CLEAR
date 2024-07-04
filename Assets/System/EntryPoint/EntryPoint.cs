using UnityEngine;
using System.Collections.Generic;

public class EntryPoint : MonoBehaviour
{
    public GameObject panelMainPrefab;
    public GameObject panelAboutPrefab;
    public Transform rootPanelView;
    public SavePanelDataSO saveDataSO; // Reference to the ScriptableObject

    public GameObject textSubPanelPrefab; // Prefab for TextSubPanel
    public GameObject containerSubPanelPrefab; // Prefab for ContainerSubPanel
    public GameObject buttonPrefab; // Prefab for buttons

    private ISaveService saveService;

    void Start()
    {
        saveService = new SaveServiceScriptableObject(saveDataSO);

        // Mock data for subpanels if not already populated
        if (saveDataSO.subPanels.Count == 0)
        {
            List<SaveSubPanelModel> subPanelData = new List<SaveSubPanelModel>
            {
                new SaveSubPanelModel
                {
                    IconPath = "Icons/icon1",
                    Title = "Text Panel 1",
                    TextContent = "This is a text panel"
                },
                new SaveSubPanelModel
                {
                    IconPath = "Icons/icon2",
                    Title = "Text Panel 2",
                    TextContent = "This is another text panel"
                },
                new SaveSubPanelModel
                {
                    IconPath = "Icons/icon3",
                    Title = "Container Panel",
                    PanelItems = new List<PanelItemModel>
                    {
                        new PanelItemModel { IconPath = "Icons/icon4", TextContent = "Panel Item 1" },
                        new PanelItemModel { IconPath = "Icons/icon5", TextContent = "Panel Item 2" }
                    }
                }
            };
            saveService.SaveSubPanelData(subPanelData);
        }

        var mainPanel = Instantiate(panelMainPrefab, rootPanelView).GetComponent<PanelMainView>();
        var aboutPanel = Instantiate(panelAboutPrefab, rootPanelView).GetComponent<PanelAboutView>();

        var mainModel = new SavePanelModel("PanelMain");
        var aboutModel = new SavePanelModel("PanelAbout");

        var mainController = new PanelMainController(mainPanel, saveService, mainModel, aboutPanel);
        var aboutController = new PanelAboutController(aboutPanel, saveService, aboutModel, mainPanel,
            aboutPanel.leftContainer, aboutPanel.rightContainer, textSubPanelPrefab, containerSubPanelPrefab, buttonPrefab);

        // Set initial visibility
        mainPanel.Show();
        aboutPanel.Hide();
    }
}
