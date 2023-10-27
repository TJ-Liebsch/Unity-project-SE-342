using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //DampingSpeed conntrols how fast the object can move (It allows the object to drag behind the mouse)
    //[SerializeField]
    //private float dampingSpeed = 0.05f;

    [SerializeField]
    private Canvas canvas;

    private CanvasGroup canvasGroup;

    //This is based off the object that holds the C# file
    private RectTransform draggingObjectRectTransform;
    private Vector3 velocity = Vector3.zero;
    
    private void Awake()
    {
        //changes the type of transform into RectTransform
        //allows the draggingObject to store the transform of the object that holds the C# file
        draggingObjectRectTransform = transform as RectTransform;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //making it transparent when dragging
        canvasGroup.alpha = .6f;

        //allows it to snap to the questions
        canvasGroup.blocksRaycasts = false;
    }

    //To Drag an object while it is on top of another object you need to consider how the objects are layered
    public void OnDrag(PointerEventData eventData)
    {
        //If the mouse clicks the object then move it
        //if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObjectRectTransform, eventData.position, eventData.pressEventCamera, out var globalMousePosition))
        //{
        //    draggingObjectRectTransform.position = Vector3.SmoothDamp(draggingObjectRectTransform.position, globalMousePosition, ref velocity, dampingSpeed);
        //}

        //delta is the amount that the mouse moved since the previous frame
        draggingObjectRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }
}
