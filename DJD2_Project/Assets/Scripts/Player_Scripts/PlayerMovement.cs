using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleRight = default;
    [SerializeField] private ParticleSystem particleLeft = default;
    [SerializeField] private ParticleSystem particleTrail = default;
    [SerializeField] public CharacterController controller;
    [SerializeField] public float speed = 12f;
    [SerializeField] private GameObject moveSound;
    private float bubbleTime = 10.0f;
    private float movementFlow = 0.3f;
    private bool velocity = true;
    private float x;
    private float z;
    private float y;

    // Update is called once per frame
    private void Update()
    {
        // Get the input for th movement
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        y = Input.GetAxis("Up/Down");

        // Update player position with the movement input
        Vector3 move = (transform.right * x) + (transform.forward * z) + 
            (transform.up * y);
        controller.Move(move * speed * Time.deltaTime * movementFlow);

        if (x != 0 || z != 0 || y != 0)
        {
            //When player is moving
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
            //When player is stopped
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

    void FixedUpdate()
    {
        if(x == 0 && y == 0 && z == 0)
        {
            movementFlow = 0.4f;
            velocity = true;
        }
        else
        {
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
