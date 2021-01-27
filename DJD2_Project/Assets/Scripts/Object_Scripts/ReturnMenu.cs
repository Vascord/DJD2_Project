using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that makes the player go to the menu if he collides with the object.
/// </summary>
public class ReturnMenu : MonoBehaviour
{
    /// <summary>
    /// Private method called when another object enter in collition 
    /// with this object.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // Removes the lock of the mouse and the player returns to the menu.
        Cursor.lockState = CursorLockMode.None;
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene(0);
    }
}
