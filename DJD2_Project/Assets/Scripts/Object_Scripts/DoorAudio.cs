using UnityEngine;

public class DoorAudio : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource _audioSource;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            _audioSource.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
