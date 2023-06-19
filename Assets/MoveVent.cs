using UnityEngine;

public class MoveVent : MonoBehaviour
{
    public float rotationSpeed = 100f; // Adjust the rotation speed as desired
    public float movementSpeed = 5f; // Adjust the movement speed as desired

    void Update()
    {
        // Rotation
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * movementSpeed * Time.deltaTime;
        movement = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * movement;
        transform.position += movement;
    }
}