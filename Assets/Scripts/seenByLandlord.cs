using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class seenByLandlord : MonoBehaviour
{
    [SerializeField] public float seenDistance = 2.0f;
    [SerializeField] GameObject[] landlords;
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
