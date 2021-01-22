using UnityEngine;

public class ButtonsReveal : MonoBehaviour
{
    [SerializeField] private readonly GameObject[] Keystones = default;


    private Animator animator;

    private int i;
    private int a;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        a = 0;
        for (i = 0; i < 3; i++)
        {
            if (!Keystones[i].GetComponent<BoxCollider>().enabled)
            {
                a += 1;
            }
        }
        if(a == 3)
            animator.SetTrigger("Interact");
    }
}