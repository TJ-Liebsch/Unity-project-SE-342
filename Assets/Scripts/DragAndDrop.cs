using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler
{
    //DampingSpeed conntrols how fast the object can move (It allows the object to drag behind the mouse)
    [SerializeField]
    private float dampingSpeed = 0.05f;

    //This is based off the object that holds the C# file
    private RectTransform draggingObjectRectTransform;
    private Vector3 velocity = Vector3.zero;
    
    private void Awake()
    {
        //changes the type of transform into RectTransform
        //allows the draggingObject to store the transform of the object that holds the C# file
        draggingObjectRectTransform = transform as RectTransform; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        //If the mouse clicks the object then move it
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObjectRectTransform, eventData.position, eventData.pressEventCamera, out var globalMousePosition))
        {
            draggingObjectRectTransform.position = Vector3.SmoothDamp(draggingObjectRectTransform.position, globalMousePosition, ref velocity, dampingSpeed);
        }
    }

}
