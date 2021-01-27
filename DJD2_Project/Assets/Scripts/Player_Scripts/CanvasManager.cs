using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that manages the canvas of the player.
/// </summary>
public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject interactionPanel = default;
    [SerializeField] private Text interactionText = default;
    [SerializeField] private RawImage[] inventoryIcons = default;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        HideInteractionPanel();
    }

    /// <summary>
    /// Public method that desactivates the interaction panel.
    /// </summary>
    public void HideInteractionPanel()
    {
        interactionPanel.SetActive(false);
    }

    /// <summary>
    /// Public method that activates the interaction panel with the interactive
    /// text.
    /// </summary>
    /// <param name="message">The interactive text in string.</param>
    public void ShowInteractionPanel(string message)
    {
        interactionText.text = message;
        interactionPanel.SetActive(true);
    }

    /// <summary>
    /// Public method thats sets the inventory icon of the collected item.
    /// </summary>
    /// <param name="i">The int location for the inventory.</param>
    /// <param name="icon">The Texture for the object in the inventory.</param>
    public void SetInventoryIcon(int i, Texture icon)
    {
        inventoryIcons[i].texture   = icon;
        inventoryIcons[i].color     = Color.white;
    }

    /// <summary>
    /// Public method that removes an used object from the inventory.
    /// </summary>
    public void ClearInventoryIcons()
    {
        for (int i = 0; i < inventoryIcons.Length; ++i)
        {
            inventoryIcons[i].texture   = null;
            inventoryIcons[i].color     = Color.clear;
        }
    }

}
