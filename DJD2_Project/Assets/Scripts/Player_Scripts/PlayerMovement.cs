using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject child;

    [SerializeField] private ParticleSystem particleRight;
    [SerializeField] private ParticleSystem particleLeft;
    [SerializeField] private ParticleSystem particleTrail;

    public CharacterController controller;

    private Animator floaty;

    public float speed = 12f; 

    private float bubbleTime = 10.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input for th movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Up/Down");
        

        // Update player position with the movement input
        Vector3 move = transform.right * x + transform.forward * z + transform.up * y;
        
        controller.Move(move * speed * Time.deltaTime);

        if (x != 0 || z != 0 || y != 0)
        {
            //When player is moving
            bubbleTime = 0.0f;
            if (particleLeft.isPlaying)
            {
                particleLeft.Stop();
            }
            if (particleRight.isPlaying)
            {
                particleRight.Stop();
            }
            if (!particleTrail.isPlaying)
            {
                particleTrail.Play();
            }
        }
        else
        {
            //When player is stoped
            particleTrail.Stop();
            if (bubbleTime < 0.5f)
            {
                if (!particleLeft.isPlaying)
                {
                    particleLeft.Play();
                }
                if (!particleRight.isPlaying)
                {
                    particleRight.Play();
                }
                bubbleTime = particleLeft.time;
            }

            else
            {
                particleLeft.Stop();
                particleRight.Stop();
            }
        }
    }
}
