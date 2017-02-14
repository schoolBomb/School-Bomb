using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    public Vector3 startPosition;
    private Vector3 screenPoint;
    public bool move;

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;//마우스로 drag할 item 인식한다
        startPosition = transform.position;//처음 위치를 저장한다
        move = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        screenPoint = Input.mousePosition;
        screenPoint.z = 1f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

    }

    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (move)//아직 item이 슬롯에 들어가지 않았으면, 원래 자리로 돌아간다
        {
            transform.position = startPosition;
        }
    }

}
