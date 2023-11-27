using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    //This allows us to use the gameObjects of all the wrong questions
    //public GameObject[] wrongAnswers;

    //This allows us to use the correct answers game object
    [SerializeField]
    public GameObject[] checkmark;
    
    public GameObject nextLevel;
    public GameObject text;

    private int j = 0;



    //private RectTransform originalPos;

    void Start()
    {
        //makes the checkmark invisible
        nextLevel.gameObject.GetComponent<Image>().enabled = false;
        text.gameObject.GetComponent<Text>().enabled = false;

        //originalPos = playerPos;
    }

    void LateUpdate()
    {
        j = 0;
        if (nextLevel.gameObject.GetComponent<Image>().enabled == false)
        {

            for (int i = 0; i < checkmark.Length; i++)
            {
                if (checkmark[i].gameObject.GetComponent<Image>().enabled == true)
                {
                    j++;
                }
                else
                {
                    j = 0;
                }

                Debug.Log("i = " + i + " and length of checkmark = " + checkmark.Length + " and j = " + j);

            }

            if (j == checkmark.Length)
            {
                nextLevel.gameObject.GetComponent<Image>().enabled = true;
                text.gameObject.GetComponent<Text>().enabled = true;
            }
        }
    }
}
