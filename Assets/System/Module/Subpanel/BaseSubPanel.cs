using UnityEngine;

public abstract class BaseSubPanel : MonoBehaviour
{
    public string panelName;

    public abstract void Initialize(string iconPath, string titleText, string contentText);
}
