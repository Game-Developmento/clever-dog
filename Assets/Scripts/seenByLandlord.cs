using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class seenByLandlord : MonoBehaviour
{
    [SerializeField] public float seenDistance = 2.0f;
    [SerializeField] GameObject[] landlords;

    // InputMover mover;
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (gameObject.activeSelf && other.tag == loseGameTriggerTag)
    //     {

    //         SceneManager.LoadScene("level-1");
    //     }
    // }

    void Update()
    {
        foreach (GameObject landlord in landlords)
        {
            if (Vector3.Distance(this.transform.position, landlord.transform.position) < seenDistance)
            {
                SceneManager.LoadScene("level-1");
            }

        }
    }



}
