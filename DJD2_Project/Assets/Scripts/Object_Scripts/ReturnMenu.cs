using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Cursor.lockState = CursorLockMode.None;
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene(0);
    }
}
