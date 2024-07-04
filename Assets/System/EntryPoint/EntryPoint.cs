using UnityEngine;
using System.Collections.Generic;

public class EntryPoint : MonoBehaviour
{
    public GameObject panelMainPrefab;
    public GameObject panelAboutPrefab;
    public Transform rootPanelView;
    public SavePanelDataSO saveDataSO; // Reference to the ScriptableObject

    public GameObject textSubPanelPrefab; // Prefab for TextSubPanelView
    public GameObject containerSubPanelPrefab; // Prefab for ContainerSubPanelView
    public GameObject buttonPrefab; // Prefab for buttons

    private ISaveService saveService;

    void Start()
    {
        saveService = new SaveServiceScriptableObject(saveDataSO);

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
