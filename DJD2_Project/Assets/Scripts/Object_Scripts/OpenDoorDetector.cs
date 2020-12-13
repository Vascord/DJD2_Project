using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorDetector : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Animator[] doors;

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if(player.transform.CompareTag("Player")==true) {
            foreach(Animator door in doors)
            {
                door.SetTrigger("Interact");
            }
            Destroy(gameObject);
        }
    }
}
