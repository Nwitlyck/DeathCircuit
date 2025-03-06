using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Text text;
    public GameObject player;
    public GameObject canvas;
    public GameObject items;
    public List<GameObject> objectsIfItNeeds;
    public string actionName;
    bool inside;

    private BoxCollider2D boxCollider;
    private bool finishedQuest = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            inside = true;
            canvas.transform.GetChild(6).gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inside = false;
            canvas.transform.GetChild(6).gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if(inside == true)
        {
            if (Input.GetKey("space"))
            {
                switch (actionName)
                {
                    case "monsterInteract":
                        monsterInteract();
                        break;
                    case "oldmanInteract":
                        oldmanInteract();
                        break;
                    case "ladyInteract":
                        ladyInteract();
                        break;
                    case "mrInteract":
                        mrInteract();
                        break;
                    case "guyInteract":
                        guyInteract();
                        break;
                    case "bearInteract":
                        bearInteract();
                        break;
                    case "tumbInteract":
                        tumbInteract();
                        break;
                    case "chestInteract":
                        chestInteract();
                        break;
                    case "bushInteract":
                        bushInteract();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    IEnumerator DialogSequence(string dialogText, float waitTime)
    {
        text.text = dialogText;
        canvas.transform.GetChild(7).gameObject.SetActive(true);

        yield return new WaitForSeconds(waitTime);

        canvas.transform.GetChild(7).gameObject.SetActive(false);
    }

    public void monsterInteract()
    {
        float waitTime = 5f;
        string dialogText;

        canvas.transform.GetChild(6).gameObject.SetActive(false);
        if (canvas.transform.GetChild(1).gameObject.activeSelf)
        {

            dialogText = "¡Fuego! ¡No, no! ¡Sácame de aquí! ¡Huiré antes de que me quemen!";
            StartCoroutine(DialogSequence(dialogText, waitTime));


            canvas.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.GetComponent<Animator>().SetBool("run", true);
            objectsIfItNeeds[0].GetComponent<Interact>().SetFinishedQuest(true);
            StartCoroutine("Wait");


        }
        else
        {
            dialogText = "¡No me voy a mover de aquí! ¡Este es mi territorio!";
            StartCoroutine(DialogSequence(dialogText, waitTime));
        }
    }

    public void oldmanInteract()
    {
        float waitTime = 5f;
        string dialogText;

        canvas.transform.GetChild(6).gameObject.SetActive(false);
        if (!finishedQuest)
        {
            dialogText = "¡Por favor, necesito tu ayuda! ¡Hay un monstruo aterrador que me está atormentando! (Una antorcha quizas pueda ayudar)";
            StartCoroutine(DialogSequence(dialogText, waitTime));
        }
        else
        {
            dialogText = "¡Lo lograste! ¡El monstruo se ha ido! Aquí tienes esta gema como muestra de mi agradecimiento.";
            StartCoroutine(DialogSequence(dialogText, waitTime));

            items.transform.GetChild(4).gameObject.SetActive(true);
            boxCollider = gameObject.GetComponent<BoxCollider2D>();
            boxCollider.enabled = !enabled;
        }

    }

    public void ladyInteract()
    {
        float waitTime = 5f;
        string dialogText;

        canvas.transform.GetChild(6).gameObject.SetActive(false);
        if (objectsIfItNeeds[0].activeInHierarchy)
        {
            dialogText = "¿Sabes? He visto algo muy extraño detrás de esos barriles. Deberías echar un vistazo.";
            StartCoroutine(DialogSequence(dialogText, waitTime));
        }
        else
        {
            dialogText = "¡Lo encontraste! ¡Increíble! Ahora sigue el mapa, te guiará hacia algo importante.";
            StartCoroutine(DialogSequence(dialogText, waitTime));
        }
    }

    public void mrInteract()
    {
        float waitTime = 5f;
        string dialogText;

        canvas.transform.GetChild(6).gameObject.SetActive(false);
        if (!finishedQuest)
        {
            dialogText = "Tengo un presentimiento... Algo está oculto aquí. Creo que tiene que ver con esos espacios en el piso y los jarrones.";
            StartCoroutine(DialogSequence(dialogText, waitTime));
        }
        else
        {
            dialogText = "¡Excelente trabajo! Sabía que había algo oculto ahí. ¡Felicidades por resolver el puzzle!";
            StartCoroutine(DialogSequence(dialogText, waitTime));
        }
    }

    public void guyInteract()
    {
        float waitTime = 5f;
        string dialogText;

        canvas.transform.GetChild(6).gameObject.SetActive(false);
        if (!finishedQuest)
        {
            dialogText = "Oye, he visto una tumba bastante extraña por ahí. Deberías investigar.";
            StartCoroutine(DialogSequence(dialogText, waitTime));
        }
        else
        {
            dialogText = "¡No puedo creerlo! ¡Encontraste una gema dentro de la tumba! ¡Eso es increíble!";
            StartCoroutine(DialogSequence(dialogText, waitTime));
        }
    }

    public void bearInteract()
    {
        canvas.transform.GetChild(6).gameObject.SetActive(false);
        if (!finishedQuest)
        {
            if (canvas.transform.GetChild(3).gameObject.activeInHierarchy)
            {

                items.transform.GetChild(13).gameObject.SetActive(true);
                canvas.transform.GetChild(3).gameObject.SetActive(false);
                finishedQuest = true;
            }
            else
            {

            }
        }
        else
        {
            
        }
        
    }

    public void tumbInteract()
    {
        canvas.transform.GetChild(6).gameObject.SetActive(false);
        if (canvas.transform.GetChild(2).gameObject.activeInHierarchy)
        {
            items.transform.GetChild(5).gameObject.SetActive(true);
            canvas.transform.GetChild(2).gameObject.SetActive(false);
            objectsIfItNeeds[0].GetComponent<Interact>().SetFinishedQuest(true);
            Destroy(gameObject, 0.5f);
        }
        else
        {

        }
    }

    public void chestInteract()
    {
        canvas.transform.GetChild(6).gameObject.SetActive(false);
        if (canvas.transform.GetChild(5).gameObject.activeInHierarchy)
        {
            items.transform.GetChild(3).gameObject.SetActive(true);
            objectsIfItNeeds[0].SetActive(true);
            canvas.transform.GetChild(5).gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
        else
        {

        }
    }

    public void bushInteract()
    {
        canvas.transform.GetChild(6).gameObject.SetActive(false);
        if (canvas.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            items.transform.GetChild(2).gameObject.SetActive(true);
            canvas.transform.GetChild(0).gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
        else
        {

        }
    }

    public bool GetFinishedQuest()
    {
        return finishedQuest;
    }

    public void SetFinishedQuest(bool finishedQuest)
    {
        this.finishedQuest = finishedQuest;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        items.transform.GetChild(7).gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
