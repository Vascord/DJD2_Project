using UnityEngine;

public class BoxOpener : MonoBehaviour
{
    [SerializeField] GameObject Light_1;
    [SerializeField] GameObject Light_2;
    [SerializeField] GameObject Light_3;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Light_1.GetComponent<Light>().enabled == true &&
            Light_2.GetComponent<Light>().enabled == true &&
            Light_3.GetComponent<Light>().enabled == true)
        {
            gameObject.SetActive(false);
        }
    }
}
