using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openMap : MonoBehaviour
{
    public GameObject canvas;

    private void FixedUpdate()
    {
        if (canvas.transform.GetChild(4).gameObject.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("Space key was pressed.");
            }

            if (Input.GetKeyUp(KeyCode.M))
            {
                Debug.Log("Space key was released.");
            }
        }
    }
}
