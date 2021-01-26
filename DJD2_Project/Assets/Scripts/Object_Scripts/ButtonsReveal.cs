using UnityEngine;

public class ButtonsReveal : MonoBehaviour
{
    [SerializeField] private GameObject[] Keystones = default;
    private Animator animator;
    private int i;
    private int a;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
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