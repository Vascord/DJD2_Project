using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject   interactionPanel;
    public Text         interactionText;
    public RawImage[]   inventoryIcons;

    void Start()
    {
        HideInteractionPanel();
    }

    public void HideInteractionPanel()
    {
        interactionPanel.SetActive(false);
    }

    public void ShowInteractionPanel(string message)
    {
        interactionText.text = message;
        interactionPanel.SetActive(true);
    }

    public void SetInventoryIcon(int i, Texture icon)
    {
        inventoryIcons[i].texture   = icon;
        inventoryIcons[i].color     = Color.white;
    }

    public void ClearInventoryIcons()
    {
        for (int i = 0; i < inventoryIcons.Length; ++i)
        {
            inventoryIcons[i].texture   = null;
            inventoryIcons[i].color     = Color.clear;
        }
    }

}
