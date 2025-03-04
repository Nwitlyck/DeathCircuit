using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
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
           "\nEspada: Tendras que buscar en el lecho de muerte de un gran heroe" +
           "\nEscudo: Para la proteccion, busca la proteccion de la diosa y reza" +
           "\nMartillo: Revisa las bancas puede que encuentres lo que buscas" +
           "\nComida: Para comezar una aventura necesitaras comida, busca en las vasijas" +
           "\nMapa: Puedes buscar donde los aventureros buscan calor en las noches" + levelText;

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
