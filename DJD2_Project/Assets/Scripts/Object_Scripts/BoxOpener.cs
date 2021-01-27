using UnityEngine;

/// <summary>
/// Class that removes the field around a box if a certain condition is met.
/// </summary>
public class BoxOpener : MonoBehaviour
{
    [SerializeField] private GameObject[] lights = default;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // Desactivate the field if all lights are on.
        if(lights[0].GetComponent<Light>().enabled &&
            lights[1].GetComponent<Light>().enabled &&
            lights[2].GetComponent<Light>().enabled)
        {
            gameObject.SetActive(false);
        }
    }
}
