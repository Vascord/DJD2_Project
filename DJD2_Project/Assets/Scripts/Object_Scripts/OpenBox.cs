using UnityEngine;

public class OpenBox : MonoBehaviour
{
    [SerializeField] GameObject[] paternCubes;
    [SerializeField] GameObject[] cubes;
    private int e;
    private int i;

    // Update is called once per frame
    void FixedUpdate()
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
