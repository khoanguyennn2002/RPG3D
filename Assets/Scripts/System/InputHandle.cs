using UnityEngine;
using UnityEngine.Events;

public class InputHandle : MonoBehaviour
{
    public Vector3 MoveInput;
    public bool isShiftPressed;
    public bool isWalk;
    public bool isJumpPressed;
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        MoveInput = new Vector3(horizontal, 0 , vertical);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isShiftPressed = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isShiftPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isWalk = !isWalk;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumpPressed = false;
        }
    }
}
