using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class foodStealing : MonoBehaviour
{
    [SerializeField] GameObject[] foodObjects;
    [SerializeField] InputAction stealFood;

    public float stealingDistance = 1.0f;

    private void OnValidate()
    {
        if (stealFood == null)
        {
            stealFood = new InputAction(type: InputActionType.Button);
            stealFood.AddCompositeBinding("2DVector").With("steal food", "<Keyboard>/space");
        }
    }
    void OnEnable()
    {
        stealFood.Enable();
    }

    void OnDisable()
    {
        stealFood.Disable();
    }

    private bool checkForWin()
    {
        int counter = 0;
        foreach (GameObject food in foodObjects)
        {
            if (!food.activeSelf)
            {
                counter++;
            }
        }
        return counter == 2;
    }
    void Update()
    {
        foreach (GameObject food in foodObjects)
        {
            if (Vector3.Distance(this.transform.position, food.transform.position) < stealingDistance)
            {
                if (stealFood.WasPressedThisFrame() && food)
                {
                    food.SetActive(false);
                }
            }
        }
        if (checkForWin())
        {
            SceneManager.LoadScene("Won-scene");
        }
    }
}
