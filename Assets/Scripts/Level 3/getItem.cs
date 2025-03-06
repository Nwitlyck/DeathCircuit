using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getItem : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;

            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            player.GetComponent<gemsCount>().SetGemCount(player.GetComponent<gemsCount>().GetGemCount() + 1);
            StartCoroutine("Wait");

            PlayerPrefs.SetInt("Consumibles", PlayerPrefs.GetInt("Consumibles") + 1);
            PlayerPrefs.Save();
            Debug.Log("Consumibles_OnTriggerEnter2D_Consumibles: " + PlayerPrefs.GetInt("Consumibles"));
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
