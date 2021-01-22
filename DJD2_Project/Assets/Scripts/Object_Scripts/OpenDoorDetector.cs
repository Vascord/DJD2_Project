using UnityEngine;

public class OpenDoorDetector : MonoBehaviour
{
    [SerializeField] private GameObject player = default;
    [SerializeField] private Animator[] doors = default;

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if(player.transform.CompareTag("Player")) {
            foreach(Animator door in doors)
            {
                door.SetTrigger("Activate");
            }
            Destroy(gameObject);
        }
    }
}
