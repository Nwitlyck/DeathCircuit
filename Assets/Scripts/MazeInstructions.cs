using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MazeInstructions : MonoBehaviour
{
    public Text text;
    public string levelName;
    public string levelText;
    private bool inDoor = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.text = "Notas de un viajero: " +
           "\n¡EL gran laberinto se presenta al frente tuyo!" +
           "\nTendras que recorrerlo si quieres continuar." +
           "\nNo te olvides de recoger las gemas para activar el portal." +
            levelText;

            text.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(false);
            inDoor = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (inDoor && Input.GetKey("x"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
