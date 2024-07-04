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

        PanelMainView mainPanelClone = Instantiate(panelMainPrefab, rootPanelView).GetComponent<PanelMainView>();
        PanelAboutView aboutPanelClone = Instantiate(panelAboutPrefab, rootPanelView).GetComponent<PanelAboutView>();

        SavePanelModel mainModel = new SavePanelModel("PanelMain");
        SavePanelModel aboutModel = new SavePanelModel("PanelAbout");

        PanelMainController mainController = new PanelMainController(mainPanelClone, saveService, mainModel, aboutPanelClone);
        PanelAboutController aboutController = new PanelAboutController(aboutPanelClone, saveService, aboutModel, mainPanelClone,
            aboutPanelClone.GetLeftContainer(), aboutPanelClone.GetRightContainer(), textSubPanelPrefab, containerSubPanelPrefab, buttonPrefab);

        mainPanelClone.Show();
        aboutPanelClone.Hide();
    }
}
