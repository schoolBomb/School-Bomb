using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineButton : MonoBehaviour
{
    public Item data;

    Combinationblock slot1;
    Combinationblock slot2;
    Combinationblock slot3;

    Item item1;
    Item item2;
    Item item3;

    GameObject[] bombs;

    // Use this for initialization
    void Start()
    {
        slot1 = GameObject.Find("combine_box_1").GetComponent<Combinationblock>();
        slot2 = GameObject.Find("combine_box_2").GetComponent<Combinationblock>();
        slot3 = GameObject.Find("combine_box_3").GetComponent<Combinationblock>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()//조합 버튼을 눌렀을때 실행
    {
        //Debug.Log("조합버튼 누름");
        ItemManager manager = GameObject.Find("Item Manager").GetComponent<ItemManager>();
        /*
        if (slot1.hasItem)
        {
            item1 = slot1.item.GetComponent<ItemBasic>().data;
            slot1.item.SetActive(false);
            item1.location = (int)ItemPosition.alreadyUsed;
            Debug.Log(item1.name + " " + item1.location);
        }
        if (slot2.hasItem)
        {
            item2 = slot2.item.GetComponent<ItemBasic>().data;
            slot2.item.SetActive(false);
            item2.location = (int)ItemPosition.alreadyUsed;
            Debug.Log(item2.name + " " + item2.location);
        }
        if (slot3.hasItem)
        {
            item3 = slot3.item.GetComponent<ItemBasic>().data;
            slot3.item.SetActive(false);
            item3.location = (int)ItemPosition.alreadyUsed;
            Debug.Log(item3.name + " " + item3.location);
        }
        */
        if (slot1.hasItem && slot2.hasItem)//3 슬롯에 모두 아이템이 있으면
        {
            item1 = slot1.item.GetComponent<ItemBasic>().data;
            item2 = slot2.item.GetComponent<ItemBasic>().data;
            //item3 = slot3.item.GetComponent<ItemBasic>().data;
            
            item1.location = (int)ItemPosition.alreadyUsed;
            item2.location = (int)ItemPosition.alreadyUsed;
            //item3.location = (int)ItemPosition.alreadyUsed;

            //slot1.item.SetActive(false);
            //slot2.item.SetActive(false);
            //slot3.item.SetActive(false);
            bombs = GameObject.FindGameObjectsWithTag("Bomb");
            if (item1.bomb.Equals("수소폭탄") && item2.bomb.Equals("수소폭탄") && item3.bomb.Equals("수소폭탄"))
            {

            }
           else if (item1.bomb.Equals(item2.bomb))
            {
                slot1.item.SetActive(false);
                slot2.item.SetActive(false);
                Debug.Log("다이너마이트");
                for(int i = 0; i < bombs.Length; i++)
                {
                    if (bombs[i].name.Equals("dynamite"))
                    {
                        bombs[i].GetComponent<SpriteRenderer>().enabled = true;
                        //bombs[i].SetActive(true);
                    }
                }
  
            }
            else if (item1.bomb.Equals("소이폭탄") && item2.bomb.Equals("소이폭탄") && item3.bomb.Equals("소이폭탄"))
            {

            }
            else if (item1.bomb.Equals("액체폭탄") && item2.bomb.Equals("액체폭탄") && item3.bomb.Equals("액체폭탄"))
            {

            }
            else if (item1.bomb.Equals("EMP폭탄") && item2.bomb.Equals("EMP폭탄") && item3.bomb.Equals("EMP폭탄"))
            {

            }
            else if (item1.bomb.Equals("3F 폭탄") && item2.bomb.Equals("3F 폭탄") && item3.bomb.Equals("3F 폭탄"))
            {

            }
            else if (item1.bomb.Equals("고양이폭탄") && item2.bomb.Equals("고양이폭탄") && item3.bomb.Equals("고양이폭탄"))
            {

            }
            else if (item1.bomb.Equals("데자와폭탄") && item2.bomb.Equals("데자와폭탄") && item3.bomb.Equals("데자와폭탄"))
            {

            }
            else if (item1.bomb.Equals("수소화리튬") && item2.bomb.Equals("수소화리튬") && item3.bomb.Equals("수소화리튬"))
            {

            }
            else if (item1.bomb.Equals("가스폭탄") && item2.bomb.Equals("가스폭탄") && item3.bomb.Equals("가스폭탄"))
            {

            }

        }


    }
}
