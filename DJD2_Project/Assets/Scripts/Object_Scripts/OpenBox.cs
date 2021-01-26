using UnityEngine;

public class OpenBox : MonoBehaviour
{
    [SerializeField] private GameObject[] paternCubes = default;
    [SerializeField] private GameObject[] cubes = default;
    private int e;
    private int i;

    // Update is called once per frame
    private void FixedUpdate()
    {
        e = 0;
        for(i = 0; i < 4; i++)
        {
            if(paternCubes[i].GetComponent<Renderer>().material.color ==
                cubes[i].GetComponent<Renderer>().material.color)
            {
                e++;
            }
        }

        if(e == 4)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Activate");
        }
    }
}
