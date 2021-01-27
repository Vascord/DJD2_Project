using UnityEngine;

/// <summary>
/// Class that removes an object if a certain condition is met.
/// </summary>
public class OpenField : MonoBehaviour
{
    [SerializeField] private GameObject[] coins = default;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // If all the objects are well rotated, then it desactives the field.
        if(coins[0].transform.localEulerAngles.z == 270 &&
            coins[1].transform.localEulerAngles.z == 0 &&
            coins[2].transform.localEulerAngles.z == 90 &&
            coins[3].transform.localEulerAngles.z == 270)
        {
            gameObject.SetActive(false);
        }
    }
}
