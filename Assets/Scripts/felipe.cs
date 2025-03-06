using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class felipe : MonoBehaviour
{
    public GameObject canvas;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvas.transform.GetChild(7).gameObject.SetActive(false);
        }
    }
}
