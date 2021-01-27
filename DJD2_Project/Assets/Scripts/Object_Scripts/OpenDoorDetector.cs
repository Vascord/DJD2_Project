using UnityEngine;

/// <summary>
/// Class that opens doors if the player enter in collition with the object.
/// </summary>
public class OpenDoorDetector : MonoBehaviour
{
    [SerializeField] private Animator[] doors = default;

    /// <summary>
    /// Private method called when another object enter in collition with
    /// this object.
    /// </summary>
    private void OnTriggerEnter(Collider player)
    {
        /* If the tag of the colliding object is Player, then it activates their
        animation and it destroys itself. */
        if(player.transform.CompareTag("Player")) {
            foreach(Animator door in doors)
            {
                door.SetTrigger("Activate");
            }
            Destroy(gameObject);
        }
    }
}
