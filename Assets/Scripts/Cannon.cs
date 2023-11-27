using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cannon : MonoBehaviour, IDropHandler
{
    //This allows us to use the gameObjects of all the wrong questions
    //public GameObject[] wrongAnswers;

    //This allows us to use the correct answers game object
    public GameObject correct;
    public GameObject checkmark;
    public GameObject wrong;
    public GameObject disappearingText;
    public RectTransform cannonball;
    private bool questionAnswered = false;

    //private RectTransform originalPos;

    void Start()
    {
        //makes the checkmark invisible
        checkmark.gameObject.GetComponent<Image>().enabled = false;
        wrong.gameObject.GetComponent<Image>().enabled = false;

        //originalPos = playerPos;
    }

    //This happens whenever you drop an object onto it
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("On Drop");

        //if there is an object on it, then snap that obect to the center
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            //if the name of the correct answer and pointerDrag equal then it is the correct answer
            if (eventData.pointerDrag.name == correct.name)
            {
                // This causes the promt to only happen once
                if (questionAnswered == false)
                {
                    // This causes the cannonball sprite to move
                    cannonball.anchoredPosition = new Vector2(cannonball.anchoredPosition.x + 435, cannonball.anchoredPosition.y + 158);
                }

                checkmark.gameObject.GetComponent<Image>().enabled = true;
                wrong.gameObject.GetComponent<Image>().enabled = false;
                disappearingText.gameObject.GetComponent<Text>().enabled = false;
                questionAnswered = true;

                Debug.Log("You selected the correct answer. You got it right!");
                //makes checkmark visible once they answer correctly
            }
            else
            {
                // This causes the promt to only happen once
                if (questionAnswered == true)
                {
                    // This causes the cannonball sprite to move iversersly to how they moved before
                    cannonball.anchoredPosition = new Vector2(cannonball.anchoredPosition.x - 435, cannonball.anchoredPosition.y - 158);
                }

                checkmark.gameObject.GetComponent<Image>().enabled = false;
                wrong.gameObject.GetComponent<Image>().enabled = true;
                disappearingText.gameObject.GetComponent<Text>().enabled = false;
                questionAnswered = false;

                //Debug.Log("The original position of the player is " + originalPos);
                //playerPos.anchoredPosition = originalPos;

                Debug.Log("You selected the wrong answer. Try again.");
            }

        }
        //throw new System.NotImplementedException();
    }

}

