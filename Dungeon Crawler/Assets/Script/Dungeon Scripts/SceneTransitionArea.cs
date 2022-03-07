using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionArea : MonoBehaviour
{
    bool _isPlayerWithinZone = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = true;
        Debug.Log("Opened Door!");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = false;
        Debug.Log("Closeed Door!");
    }

    void Update()
    {
        if (_isPlayerWithinZone)
        {
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene("Dungeon");
            }
        }
    }
}
