using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PanelMainView panelMainPrefab;
    [SerializeField] private PanelAboutView panelAboutPrefab;
    [SerializeField] private Transform rootPanelView;
    [SerializeField] private SavePanelDataSO saveDataSO;
    [SerializeField] private TextSubPanelView textSubPanelPrefab;
    [SerializeField] private ContainerSubPanelView containerSubPanelPrefab;  
    [SerializeField] private ButtonView buttonPrefab;  

    private ISaveService saveService;

    void Start()
    {
        saveService = new SaveServiceScriptableObject(saveDataSO);

        PanelMainView mainPanel = Instantiate(panelMainPrefab, rootPanelView).GetComponent<PanelMainView>();
        PanelAboutView aboutPanel = Instantiate(panelAboutPrefab, rootPanelView).GetComponent<PanelAboutView>();

        SavePanelModel mainModel = new SavePanelModel("PanelMain");
        SavePanelModel aboutModel = new SavePanelModel("PanelAbout");

        PanelMainController mainController = new PanelMainController(mainPanel, saveService, mainModel, aboutPanel);
        PanelAboutController aboutController = new PanelAboutController(aboutPanel, saveService, aboutModel, mainPanel,
            aboutPanel.GetLeftContainer(), aboutPanel.GetRightContainer(), textSubPanelPrefab, containerSubPanelPrefab, buttonPrefab);

        mainPanel.Show();
        aboutPanel.Hide();
    }
}
