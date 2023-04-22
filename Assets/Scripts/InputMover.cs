using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMover : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] InputAction moveHorizontal;
    [SerializeField] InputAction moveVertical;

    private GameObject[] furnitures;
    // private CharacterController controller;
    private bool isCollidingWithFurniture = false;

    private void Start()
    {
        furnitures = GameObject.FindGameObjectsWithTag("Furniture");
    }

    void OnEnable()
    {
        moveHorizontal.Enable();
        moveVertical.Enable();
    }

    void OnDisable()
    {
        moveHorizontal.Disable();
        moveVertical.Disable();
    }

    private void OnValidate()
    {

        if (moveHorizontal == null)
        {
            moveHorizontal = new InputAction(type: InputActionType.Button);
            moveHorizontal.AddCompositeBinding("1DAxis")
                .With("Positive", "<Keyboard>/D")
                .With("Negative", "<Keyboard>/A");
        }

        if (moveVertical == null)
        {
            moveVertical = new InputAction(type: InputActionType.Button);
            moveVertical.AddCompositeBinding("1DAxis")
                .With("Positive", "<Keyboard>/W")
                .With("Negative", "<Keyboard>/S");
        }

    }

    private void FixedUpdate()
    {
        float horizontal = moveHorizontal.ReadValue<float>();
        float vertical = moveVertical.ReadValue<float>();
        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        Vector3 movementVector = moveDirection * speed * Time.deltaTime;

        if (isCollidingWithFurniture)
        {
            foreach (GameObject furniture in furnitures)
            {
                Vector3 furniturePos = furniture.transform.position;
                Vector3 playerToFurniture = furniturePos - transform.position;
                Vector3 horizontalDir = Vector3.Project(playerToFurniture, transform.right).normalized;
                Vector3 verticalDir = Vector3.Project(playerToFurniture, transform.up).normalized;
                bool isHorizontalBlocked = Vector3.Dot(movementVector, horizontalDir) > 0;
                bool isVerticalBlocked = Vector3.Dot(movementVector, verticalDir) > 0;
                bool isFurnitureBlocking = playerToFurniture.sqrMagnitude < 3.5f && (isHorizontalBlocked || isVerticalBlocked);
                if (isFurnitureBlocking)
                {
                    // If colliding with furniture and moving towards it, stop movement
                    movementVector = Vector3.zero;
                    break;
                }
            }

        }
        transform.position += movementVector;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Furniture")
        {
            isCollidingWithFurniture = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Furniture")
        {
            isCollidingWithFurniture = false;
        }
    }
}
