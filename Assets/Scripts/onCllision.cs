using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onCllision : MonoBehaviour
{
    [SerializeField] string loseGameTriggerTag;
    [SerializeField] string furniture;
    InputMover mover;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.activeSelf && other.tag == loseGameTriggerTag)
        {

            SceneManager.LoadScene("level-1");
        }
    }



}
