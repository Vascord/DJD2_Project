using UnityEngine;

/// <summary>
/// Class which triggers a sound if the player enters in contact with the
/// object associated to.
/// </summary>
public class DoorAudio : MonoBehaviour
{
    private AudioSource _audioSource;

    /// <summary>
    /// Private method called when another object enter in collition 
    /// with this object.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            _audioSource.Play();
    }

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}