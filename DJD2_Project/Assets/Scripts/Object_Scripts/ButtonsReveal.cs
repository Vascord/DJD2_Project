using UnityEngine;

/// <summary>
/// Class that shows the final puzzle if the conditions are met.
/// </summary>
public class ButtonsReveal : MonoBehaviour
{
    [SerializeField] private GameObject[] Keystones = default;
    private Animator animator;
    private int i;
    private int a;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Private method called 50 times per second.
    /// </summary>
    private void FixedUpdate()
    {
        /* Sees if each keystone has been placed and triggers the animation
        if they are all placed. */
        a = 0;
        for (i = 0; i < 3; i++)
        {
            if (!Keystones[i].GetComponent<BoxCollider>().enabled)
            {
                a++;
            }
        }
        if(a == 3)
            animator.SetTrigger("Interact");
    }
}