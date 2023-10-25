using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Questions : MonoBehaviour
{
    //This allows us to use the gameObjects of all the wrong questions
    public GameObject[] wrongAnswers;

    //This allows us to use the correct answers game object
    public GameObject correct;

    //This allows us to use the draggingObjects transform.position numbers
    public RectTransform draggingObjectRectTransform;

    private void Awake()
    {
        //changes the type of transform into RectTransform
        //allows the draggingObject to store the transform of the object that holds the C# file
        draggingObjectRectTransform = transform as RectTransform;
    }

    void Update()
    {
        if(((correct.transform.position.x + 50) <= draggingObjectRectTransform.position.x) && ((correct.transform.position.x - 50) >= draggingObjectRectTransform.position.x))
        {
            Debug.Log("You chose the correct answer!");
        }    
    }
}
