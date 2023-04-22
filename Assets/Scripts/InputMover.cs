using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputMover : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] InputAction moveHorizontal;
    [SerializeField] InputAction moveVertical;

    private bool isBlocked = false;

    public void setIsBlocked(bool value)
    {
        this.isBlocked = value;
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

    private void Update()
    {
       
        if (!isBlocked)
        {
            float horizontal = moveHorizontal.ReadValue<float>();
            float vertical = moveVertical.ReadValue<float>();
            Vector3 movementVector = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
            transform.position += movementVector;
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {

    //     if (other.gameObject.tag == "Furniture")
    //     {

    //         this.isBlocked = true;
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Furniture")
    //     {
    //         this.isBlocked = false;

    //     }
    // }

}

