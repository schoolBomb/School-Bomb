using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Combinationblock : MonoBehaviour//, IDropHandler
{

    public bool hasItem = false;//블록안에 아이템이 존재하는지 확인 여부
    //public Item data;
    public GameObject item;//칸에 들어온 아이템을 저장할 변수
    Vector3 swapPosition;
    public bool hasBomb;

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
        ItemManager manager = GameObject.Find("Item Manager").GetComponent<ItemManager>();
        if (other.gameObject.tag == "item")//재료가 슬롯에 들어온다면
        {

            if (!hasItem && !hasBomb)//칸에 물건이 없다면
            {
                item = other.gameObject;//칸에 들어온 아이템을 저장한다
                item.GetComponent<DragHandler>().move = false;//아이템은 움직일 수 없다
                hasItem = true;
                hasBomb = false;
            }
            
            else if(hasItem)//칸에 아이템이 있으면, 아이템 swap하기
            {
                swapPosition = item.transform.position;//예전 아이템의 위치 저장
                item.transform.position = item.GetComponent<DragHandler>().startPosition;//예전 아이템은 원래 위치로 돌아간다
                item = other.gameObject;//새로운 아이템 저장
                item.GetComponent<DragHandler>().move = false;//아이템은 움직일 수 없다
                item.transform.position = swapPosition;//바뀐위치로 새로운 아이템 이동

            }
            

        }
        else if (other.gameObject.tag == "Bomb")//폭탄이 슬롯에 들어온다면
        {
            if (!hasBomb && !hasItem)//칸에 폭탄이 없다면
            {
                item = other.gameObject;//칸에 들어온 아이템을 저장한다
                item.GetComponent<DragHandler>().move = false;//아이템은 움직일 수 없다
                hasBomb = true;
                hasItem = false;
            }
            else if (hasBomb)//칸에 아이템이 있으면, 아이템 swap하기
            {
                swapPosition = item.transform.position;//예전 아이템의 위치 저장
                item.transform.position = item.GetComponent<DragHandler>().startPosition;//예전 아이템은 원래 위치로 돌아간다
                item = other.gameObject;//새로운 아이템 저장
                item.GetComponent<DragHandler>().move = false;//아이템은 움직일 수 없다
                item.transform.position = swapPosition;//바뀐위치로 새로운 아이템 이동

            }
        }
        if (other.gameObject.tag != item.tag)//item있는 칸엥 Bomb이 들어올때 swap...
        {
            swapPosition = item.transform.position;//예전 아이템의 위치 저장
            item.transform.position = item.GetComponent<DragHandler>().startPosition;//예전 아이템은 원래 위치로 돌아간다
            item = other.gameObject;//새로운 아이템 저장
            item.GetComponent<DragHandler>().move = false;//아이템은 움직일 수 없다
            item.transform.position = swapPosition;//바뀐위치로 새로운 아이템 이동
            if (other.gameObject.tag == "item")
            {
                hasItem = true;
                hasBomb = false;
            }
            else if (other.gameObject.tag == "Bomb")
            {
                hasBomb = true;
                hasItem = false;
            }
        }
    }
}

