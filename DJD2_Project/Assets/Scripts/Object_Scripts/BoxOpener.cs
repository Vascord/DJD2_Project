using UnityEngine;

public class BoxOpener : MonoBehaviour
{
    [SerializeField] private GameObject[] lights = default;

    private Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(lights[0].GetComponent<Light>().enabled &&
            lights[1].GetComponent<Light>().enabled &&
            lights[2].GetComponent<Light>().enabled)
        {
            gameObject.SetActive(false);
        }
    }
}
