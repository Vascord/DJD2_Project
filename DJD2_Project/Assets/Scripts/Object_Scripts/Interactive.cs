using UnityEngine;

public class Interactive : MonoBehaviour
{
    public enum InteractiveType { PICKABLE, INTERACT_ONCE, INTERACT_MULTI, INDIRECT };

    public InteractiveType  type;
    public bool             isActive;
    public bool             deactivationLeader = false;
    public string[]         interactionTexts;
    public string           requirementText;
    public Texture          icon;
    public Interactive[]    requirements;
    public Interactive[]    activationChain;
    public Interactive[]    deActivationChain;
    public Interactive[]    interactionChain;
    private Animator _animator;
    private int      _curInteractionTextId;
    private AudioSource sound;

    void Start()
    {
        _animator               = GetComponent<Animator>();
        _curInteractionTextId   = 0;
        sound                   = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (deactivationLeader == true)
            CheckForDeactivationCicle();
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
        if(!isActive)
        {
            ProcessDeactivationChain();
        }
        if (isActive)
        {
            ProcessDeactivationChain();
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
            {
                activationChain[i].Activate();
            }
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
    private void DeActivate()
    {
        isActive = false;
    }
    private void ProcessDeactivationChain()
    {
        if (deActivationChain != null)
        {
            for (int i = 0; i < deActivationChain.Length; ++i)
            {
                deActivationChain[i].DeActivate();
            }
        }
        if(sound != null)
        {
            sound.Play();
        }
    }
    private void CheckForDeactivationCicle()
    {
        if (deActivationChain != null)
        {
            for (int i = 0; i < deActivationChain.Length; ++i)
            {
                if (!deActivationChain[i].isActive)
                    continue;
                else
                    return;
            }
            Activate();
        }
    }
}
