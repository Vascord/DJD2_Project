using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject child;
    
    public CharacterController controller;

    private Animator floaty;

    public float speed = 12f;
    
    void Start()
    {
        floaty = child.GetComponent<Animator>();
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
            floaty.enabled = false;
        }
        else
        {
            floaty.enabled = true;
        }
    }
}
