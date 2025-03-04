using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    public Text text;
    int Total;
    public Text levelCleared;

    void Start()
    {
        //CUENTA LAS FRUTAS EN PANTALLA
        Total = gameObject.transform.childCount;
        ObjectCount();
    }

    void Update()
    {
        ObjectCount();
    }

    void ObjectCount()
    {
        //CUENTA LAS FRUTAS EN PANTALLA
        int count = gameObject.transform.childCount;
        //ASIGNA EL VALOR EN EL TEXTO
        text.text = "Objetos recolectados: " + (Total - count) + " / " + Total;

        if (count == 0)
        {
            //MUESTRE EL TEXTO DE NIVEL SUPERADO
            //levelCleared.gameObject.SetActive(true);
            //CAMBIA DE NIVEL EN UN TIEMPO DE DOS SEGUNDOS
            //Invoke("ChangeScene", 2);

        }
    }

}
