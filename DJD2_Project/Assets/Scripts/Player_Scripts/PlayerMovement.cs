using UnityEngine;

/// <summary>
/// Class which manages the movement of the player and his effects.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleRight = default;
    [SerializeField] private ParticleSystem particleLeft = default;
    [SerializeField] private ParticleSystem particleTrail = default;
    [SerializeField] public CharacterController controller = default;
    [SerializeField] public float speed = 12f;
    [SerializeField] private GameObject moveSound = default;
    private float bubbleTime = 10.0f;
    private float movementFlow = 0.3f;
    private bool velocity = true;
    private float x;
    private float z;
    private float y;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // Get the input for th movement.
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        y = Input.GetAxis("Up/Down");

        // Update player position with the movement input.
        Vector3 move = (transform.right * x) + (transform.forward * z) + 
            (transform.up * y);
        controller.Move(move * speed * Time.deltaTime * movementFlow);

        // Conditions for the particles to work.
        if (x != 0 || z != 0 || y != 0)
        {
            // When player is moving.
            moveSound.GetComponent<AudioSource>().Play();
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
            // When player is stopped.
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

            // Stops the effects after 0.5 seconds.
            else
            {
                particleLeft.Stop();
                particleRight.Stop();
            }
        }
    }

    /// <summary>
    /// Private method called 50 times per second.
    /// </summary>
    private void FixedUpdate()
    {
        // Conditions for the aquatic movement.
        if(x == 0 && y == 0 && z == 0)
        {
            // Resets the movement flow and velocity when he stops.
            movementFlow = 0.4f;
            velocity = true;
        }
        else
        {
            /* If velocity is true, then the player will have a impulsion like
            movement until the movementFlow reaches 1.4, and this movement
            will degrades over time after that until it reaches 0.4. */
            if(velocity)
            {
                movementFlow += 0.05f;
            }
            else
            {
                movementFlow -= 0.01f;
            }

            if(movementFlow >= 1.4f)
            {
                velocity = false;
            }
            else if (movementFlow <= 0.4f)
            {
                velocity = true;
            }
        }
    }
}
