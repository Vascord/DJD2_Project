using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private const float MAX_INTERACTION_DISTANCE = 2f;
    public CanvasManager canvasManager;
    private Transform           _cameraTransform;
    private Interactive         _currentInteractive;
    private bool                _requirementsInInventory;
    private List<Interactive>   _inventory;

    void Start()
    {
        _cameraTransform            = GetComponentInChildren<Camera>().transform;
        _requirementsInInventory    = false;
        _inventory                  = new List<Interactive>();
    }

    void Update()
    {
        CheckForInteractive();
        CheckForInteraction();
    }

    private void CheckForInteractive()
    {
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hitInfo, MAX_INTERACTION_DISTANCE))
        {
            Interactive interactive = hitInfo.transform.GetComponent<Interactive>();

            if (interactive == null)
                ClearCurrentInteractive();
            else if (interactive != _currentInteractive)
                SetCurrentInteractive(interactive);
        }
        else
        {
            ClearCurrentInteractive();
        }
    }

    private void SetCurrentInteractive(Interactive interactive)
    {
        _currentInteractive = interactive;

        if (PlayerHasInteractionRequirements())
        {
            _requirementsInInventory = true;
            canvasManager.ShowInteractionPanel(interactive.GetInteractionText());
        }
        else
        {
            _requirementsInInventory = false;
            canvasManager.ShowInteractionPanel(interactive.requirementText);
        }
    }

    private bool PlayerHasInteractionRequirements()
    {
        if (_currentInteractive.requirements == null)
            return true;

        for (int i = 0; i < _currentInteractive.requirements.Length; ++i)
            if (!IsInInventory(_currentInteractive.requirements[i]))
                return false;

        return true;
    }

    private void ClearCurrentInteractive()
    {
        _currentInteractive = null;
        canvasManager.HideInteractionPanel();
    }

    private void CheckForInteraction()
    {
        if (Input.GetMouseButtonDown(0) && _currentInteractive != null)
        {
            if (_currentInteractive.type == Interactive.InteractiveType.PICKABLE)
                PickCurrentInteractive();
            else if (_requirementsInInventory)
                InteractWithCurrentInteractive();
        }
    }

    private void PickCurrentInteractive()
    {
        _currentInteractive.gameObject.SetActive(false);
        AddToInventory(_currentInteractive);
    }

    private void InteractWithCurrentInteractive()
    {
        for (int i = 0; i < _currentInteractive.requirements.Length; ++i)
        {
            Interactive currentRequirement = _currentInteractive.requirements[i];
            currentRequirement.gameObject.SetActive(true);
            currentRequirement.Interact();
            RemoveFromInventory(currentRequirement);
        }

        _currentInteractive.Interact();

        ClearCurrentInteractive();
    }

    private void AddToInventory(Interactive item)
    {
        _inventory.Add(item);
        canvasManager.SetInventoryIcon(_inventory.Count - 1, item.icon);
    }

    private void RemoveFromInventory(Interactive item)
    {
        _inventory.Remove(item);

        canvasManager.ClearInventoryIcons();

        for (int i = 0; i < _inventory.Count; ++i)
            canvasManager.SetInventoryIcon(i, _inventory[i].icon);
    }

    private bool IsInInventory(Interactive item)
    {
        return _inventory.Contains(item);
    }

}
