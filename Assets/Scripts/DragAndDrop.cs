using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private RectTransform draggingObject;
    
    private void Awake()
    {
        //changes the type of transform into RectTransform
        draggingObject = transform as RectTransform; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle())
        {

        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Are you working?
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
