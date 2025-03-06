using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumibles : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;

            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            Destroy(gameObject, 0.5f);

            PlayerPrefs.SetInt("Consumibles", PlayerPrefs.GetInt("Consumibles") + 1);
            PlayerPrefs.Save();
            Debug.Log("Consumibles_OnTriggerEnter2D_Consumibles: " + PlayerPrefs.GetInt("Consumibles"));
        }
    }
}
