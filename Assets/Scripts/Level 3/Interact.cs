using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
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

    public void monsterInteract()
    {
        canvas.transform.GetChild(6).gameObject.SetActive(false);
        if (canvas.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            canvas.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.GetComponent<Animator>().SetBool("run", true);
            objectsIfItNeeds[0].GetComponent<Interact>().SetFinishedQuest(true);
            StartCoroutine("Wait");
        }
        else
        {

        }
    }

    public void oldmanInteract()
    {
        canvas.transform.GetChild(6).gameObject.SetActive(false);
        if (!finishedQuest)
        {
            
        }
        else
        {
            items.transform.GetChild(4).gameObject.SetActive(true);
            boxCollider = gameObject.GetComponent<BoxCollider2D>();
            boxCollider.enabled = !enabled;
        }

    }

    public void ladyInteract()
    {
        canvas.transform.GetChild(6).gameObject.SetActive(false);
        if (objectsIfItNeeds[0].activeInHierarchy)
        {

        }
        else
        {

        }
    }

    public void mrInteract()
    {
        canvas.transform.GetChild(6).gameObject.SetActive(false);
        if (!finishedQuest)
        {

        }
        else
        {

        }
    }

    public void guyInteract()
    {
        canvas.transform.GetChild(6).gameObject.SetActive(false);
        if (!finishedQuest)
        {
            
        }
        else
        {
            
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
