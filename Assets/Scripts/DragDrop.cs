using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{

    [SerializeField]
    private Canvas canvas;

    //variable to snap back the 
    private Vector3 startingPosition;

    //this int value will be determine outside of the script, and will be passed to the node class so that it knows which tower to place
    public int towerArrayPosition;

    void Start()
    {
        startingPosition = this.transform.position;
    }

    

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        Vector2 position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out position);

        transform.position = canvas.transform.TransformPoint(position);
    }

    public void BeginDraggingMethod()
    {

        NodeScript.draggingTower = true;
        NodeScript.towerOrder = towerArrayPosition;
        
    }

    public void EndDragMethod()
    {
        NodeScript.draggingTower = false;
        this.transform.position = startingPosition;
    }
    
    
}
