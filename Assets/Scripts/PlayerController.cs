using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speedRotation;
    
    [SerializeField] private Transform camera;

    [SerializeField] private Transform feetPos;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float radius;
    [HideInInspector] public Vector3 startPos;
    [HideInInspector] public static PlayerController instance;

    private Animator anim;

    private void Start()
    {
        Application.targetFrameRate = 120;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        startPos = transform.position;
        instance = this;

    }


    private void FixedUpdate()
    {
        Vector3 velocity;
        
        if (!DialogController.instance.isStartDialog)
        {
            
            if (Input.GetKey(KeyCode.LeftControl))
            {
                velocity = transform.forward * Input.GetAxisRaw("Vertical") * speed * 1.75f + transform.right * Input.GetAxisRaw("Horizontal") * speed + new Vector3(0, rb.velocity.y, 0);
            }
            else
            {
                velocity = transform.forward * Input.GetAxisRaw("Vertical") * speed + transform.right * Input.GetAxisRaw("Horizontal") * speed + new Vector3(0, rb.velocity.y, 0);
            }


            rb.velocity = velocity;
            float mouseX = Input.GetAxis("Mouse X");
            if (velocity.x != 0 || velocity.z != 0)
            {
                anim.SetBool("isWalk", true);
                if (Cursor.lockState == CursorLockMode.Locked)
                    transform.Rotate(0, mouseX * 2 * speedRotation, 0);

            }
            else
            {
                anim.SetBool("isWalk", false);
                if (Cursor.lockState == CursorLockMode.Locked)
                    camera.transform.Rotate(0, mouseX * speedRotation, 0);

            }
        }
        else
        {
            anim.SetBool("isWalk", false);
        }
        

    }

    private void Update()
    {
        if (!DialogController.instance.isStartDialog)
        {
            
            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Calculatore.instance.panel.SetBool("isOpen", false);
            }
        }
    }

    void Jump()
    {
        bool onGround = Physics.OverlapSphere(feetPos.position, radius, whatIsGround).Length > 0;
        if (onGround)
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }
}
