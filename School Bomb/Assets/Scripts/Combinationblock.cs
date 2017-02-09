using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Combinationblock : MonoBehaviour//, IDropHandler
{
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)//칸에 item이 있다면 (child이 있다면)
            {
               // Debug.Log("이미 item 존재함");
                return transform.GetChild(0).gameObject;//칸에 존재하는 item return
            }
            else
            {
               // Debug.Log("item 없음");
                return null;//칸에 item이 없다면 null return
            }

        }
    }
    /*
    public void OnDrop(PointerEventData eventData)
    {
        if (!item)//칸에 물건이 없다면
        {
            Debug.Log("Catch");
            DragHandler.itemBeingDragged.transform.SetParent(transform);//칸이 물건을 잡는다

        }
        else//칸에 아이템이 있으면, 아이템 swap하기
        {
            Transform aux = DragHandler.itemBeingDragged.transform.parent;
            DragHandler.itemBeingDragged.transform.SetParent(transform);
            item.transform.SetParent(aux);
        }
    }
    */
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("enter " + other.gameObject.name);
        if (other.gameObject.tag=="item")
        {
            if (!item)//칸에 물건이 없다면
            {
                Debug.Log("Catch "+other.gameObject.name);
                DragHandler.itemBeingDragged.transform.SetParent(transform);//칸이 물건을 잡는다

            }
            else//칸에 아이템이 있으면, 아이템 swap하기
            {
                Transform aux = DragHandler.itemBeingDragged.transform.parent;
                DragHandler.itemBeingDragged.transform.SetParent(transform);
                item.transform.SetParent(aux);
            }
        }
    }
}
