using UnityEngine;

public class Interactive : MonoBehaviour
{
    public enum InteractiveType { PICKABLE, INTERACT_ONCE, INTERACT_MULTI, INDIRECT };

    public InteractiveType  type;
    public bool             isActive;
    public string[]         interactionTexts;
    public string           requirementText;
    public Texture          icon;
    public Interactive[]    requirements;
    public Interactive[]    activationChain;
    public Interactive[]    interactionChain;

    private Animator _animator;
    private int      _curInteractionTextId;

    void Start()
    {
        _animator               = GetComponent<Animator>();
        _curInteractionTextId   = 0;
    }

    public string GetInteractionText()
    {
        return interactionTexts[_curInteractionTextId];
    }

    public void Activate()
    {
        isActive = true;

        if (_animator != null)
            _animator.SetTrigger("Activate");
    }

    public void Interact()
    {
        if (_animator != null)
            _animator.SetTrigger("Interact");

        if (isActive)
        {
            ProcessActivationChain();
            ProcessInteractionChain();

            if (type == InteractiveType.INTERACT_ONCE || type == InteractiveType.PICKABLE)
                GetComponent<Collider>().enabled = false;
            else if (type == InteractiveType.INTERACT_MULTI)
                _curInteractionTextId = (_curInteractionTextId + 1) % interactionTexts.Length;
        }
    }

    private void ProcessActivationChain()
    {
        if (activationChain != null)
        {
            for (int i = 0; i < activationChain.Length; ++i)
                activationChain[i].Activate();
        }
    }
    private void ProcessInteractionChain()
    {
        if (interactionChain != null)
        {
            for (int i = 0; i < interactionChain.Length; ++i)
                interactionChain[i].Interact();
        }
    }
}
