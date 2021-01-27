using UnityEngine;

/// <summary>
/// Class which opens a door in a certain condition.
/// </summary>
public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject[] paternCubes = default;
    [SerializeField] private GameObject[] cubes = default;
    private int e;
    private int i;

    /// <summary>
    /// Private method called 50 times per second.
    /// </summary>
    private void FixedUpdate()
    {
        /* Activates an animation if all the materials matched between the
        different objects. */
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
