using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSInput : MonoBehaviour
{
    // Public fields
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public Joystick joystick;

    // Private fields
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!ShowHideMenu.gameIsPaused)
        {
            GetMobileInput();
            //GetDesktopInput();
        }
    }

    // For mobile inputs
    private void GetMobileInput()
    {
        float deltaX = joystick.Horizontal * speed;
        float deltaZ = joystick.Vertical * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }

    // For testion on desktop
    private void GetDesktopInput()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
