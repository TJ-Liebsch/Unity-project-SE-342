using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Questions : MonoBehaviour, IDropHandler
{
    //This allows us to use the gameObjects of all the wrong questions
    //public GameObject[] wrongAnswers;

    //This allows us to use the correct answers game object
    public GameObject correct;
    public GameObject checkmark;
    public GameObject wrong;
    public GameObject disappearingText;

    //private RectTransform originalPos;

    void Start()
    {
        //makes the checkmark invisible
        checkmark.gameObject.GetComponent<Image>().enabled = false;
        wrong.gameObject.GetComponent<Image>().enabled = false;
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
                checkmark.gameObject.GetComponent<Image>().enabled = true;
                wrong.gameObject.GetComponent<Image>().enabled = false;
                disappearingText.gameObject.GetComponent<Text>().enabled = false;

                Debug.Log("You selected the correct answer. You got it right!");
                //makes checkmark visible once they answer correctly
            }
            else
            {
                checkmark.gameObject.GetComponent<Image>().enabled = false;
                wrong.gameObject.GetComponent<Image>().enabled = true;
                disappearingText.gameObject.GetComponent<Text>().enabled = false;

                //Debug.Log("The original position of the player is " + originalPos);
                //playerPos.anchoredPosition = originalPos;

                Debug.Log("You selected the wrong answer. Try again.");
            }

        }
        //throw new System.NotImplementedException();
    }

}
