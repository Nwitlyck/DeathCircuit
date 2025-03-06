using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatuePuzzle : MonoBehaviour
{
    public GameObject gem;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject mr;
    private bool finished = false;

    private void FixedUpdate()
    {
        bool leftJarStatus = leftButton.GetComponent<validateButtonCollision>().GetJarCollision();
        bool rightJarStatus = rightButton.GetComponent<validateButtonCollision>().GetJarCollision();

        if (leftJarStatus && rightJarStatus && finished == false)
        {
            gem.SetActive(leftJarStatus && rightJarStatus);
            mr.GetComponent<Interact>().SetFinishedQuest(true);
            finished = true;
        }
    }

}
