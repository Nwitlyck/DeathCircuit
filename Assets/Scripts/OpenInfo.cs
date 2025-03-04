using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenInfo : MonoBehaviour
{
    public Text text;
    public string levelName;
    public string levelText;
    private bool inDoor = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.text = "**HalfFredo** " +
                "\nCuenta la historia de Alfredo, un slime curioso, que es atacado y dividido" +
                " en dos por una fuerza misteriosa. Para recuperar su mitad perdida, Alfredo, ahora HalfFredo, se embarca en una aventura " +
                "a través de mundos mágicos. Enfrenta retos y rompecabezas, descubre objetos para restaurar sus poderes y desentraña un " +
                "misterio mayor tras el ataque.La historia trata sobre redención, " +
                "autodescubrimiento y valentía, mostrando que la perseverancia y el coraje pueden superar cualquier obstáculo. " + levelText;
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
