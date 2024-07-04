using UnityEngine;

public abstract class BaseSubPanelView : MonoBehaviour
{
    public string PanelName { get; set; }

    public abstract void Initialize(SubPanelModel model);
}
