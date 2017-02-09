using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    private Vector3 screenPoint;
    Transform startParent;
//    GetComponent<CanvasGroup>().blockRaycasts=false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;//마우스로 drag할 item 인식한다
        startPosition = transform.position;//처음 위치를 저장한다
        startParent = transform.parent;//item parent는 itemManager이다

        itemBeingDragged.transform.SetParent(itemBeingDragged.transform.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        screenPoint = Input.mousePosition;
        screenPoint.z = 1f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

    }


    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;//drag하는 item null로 초기화
        
        if (transform.parent == startParent)
        {
            Debug.Log("drag end");
            transform.position = startPosition;
            //transform.position = transform.parent.position;
        }

    }

}
