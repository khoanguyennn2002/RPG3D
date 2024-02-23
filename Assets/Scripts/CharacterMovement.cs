using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float turnSmoothTime;
    [SerializeField] private float speed;
    private float gravityValue = -9.81f;
    float turnSmoothVelocity;
    [SerializeField] private Vector3 velocity;
    private Animator animator;
    private CharacterController characterController;

    private void Start()
    {
      // animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
       // ApplyGravity();
        Move(movementDirection);
    }
    private void Move(Vector3 movementDirection)
    {
        if (movementDirection.magnitude >= 0.1f)
        {
            float targetAngle= Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
    
           // animator.SetBool("isWalking", true);
        }
        else
        {
           // animator.SetBool("isWalking", false);
        }
    }
    //private void ApplyGravity()
    //{
    //    //if(characterController.isGrounded)
    //    //{
    //    //    velocity.y = 0;
    //    //}
    //    //else
    //    //{
    //    //    velocity.y += gravityValue * Time.deltaTime;
    //    //    characterController.Move(velocity * Time.deltaTime);
    //    //}
    //    velocity.y += gravityValue * Time.deltaTime;
    //    characterController.Move(velocity * Time.deltaTime);
    //}
}
