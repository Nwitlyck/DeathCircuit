using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{

    public GameObject canvas;
    public string item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (item)
            {
                case "axe":
                    canvas.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case "torch":
                    canvas.transform.GetChild(1).gameObject.SetActive(true);
                    break;
                case "hammer":
                    canvas.transform.GetChild(2).gameObject.SetActive(true);
                    break;
                case "beer":
                    canvas.transform.GetChild(3).gameObject.SetActive(true);
                    break;
                case "map":
                    canvas.transform.GetChild(4).gameObject.SetActive(true);
                    break;
                case "key":
                    canvas.transform.GetChild(5).gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}
