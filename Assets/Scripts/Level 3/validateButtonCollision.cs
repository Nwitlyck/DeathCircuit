using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class validateButtonCollision : MonoBehaviour
{
    private bool _jarCollision = false;

    public bool GetJarCollision()
    {
        return _jarCollision;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Jar"))
        {
            _jarCollision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Jar"))
        {
            _jarCollision = false;
        }
    }

}
