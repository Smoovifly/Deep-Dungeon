using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Door : MonoBehaviour
{
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
                _isPlayerWithinZone = true;
            Debug.Log("Closeed Door!");
        }

        IEnumerator watchForKeyPress()
        {
            while (_isPlayerWithinZone)
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    SceneManager.LoadScene("Dungeon");
                }
                yield return null;
            }
        }
    }


}
