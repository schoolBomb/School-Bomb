using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineButton : MonoBehaviour
{
	public Item data;

	Combinationblock slot1;
	Combinationblock slot2;
	Combinationblock slot3;

	Combinationblock slotBomb;//폭탄이 있는 칸
	Combinationblock slotItem1;//폭탄재료가 있어서 따로 구분을 둔 item있는 칸
	Combinationblock slotItem2;//폭탄재료가 있어서 따로 구분을 둔 item있는 칸

	Item item1;//재료들 객체
	Item item2;
	Item item3;

	GameObject[] bombs;//폭탄 객체 배열 생성
	GameObject bomb;//폭탄재료 object 저장한다
	public bool containBomb;

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
		ItemManager manager = GameObject.Find("Item Manager").GetComponent<ItemManager>();

		bombs = GameObject.FindGameObjectsWithTag("Bomb");//bomb에 대한 객체배열 생성

		CheckBomb(slot1, slot2, slot3);//재료중에 폭탄이 있는지 확인한다, 있으면 containBomb=true

		if (!containBomb)//재료중에 폭탄이 없다면 실행된다
		{
			if (slot1.hasItem && slot2.hasItem && slot3.hasItem)//3 슬롯에 모두 아이템이 있어야 조합기능이 실행된다!->emp4,다이너마이트0,액체3만들수있다
			{

				item1 = slot1.item.GetComponent<ItemBasic>().data;//각 슬롯에 있는 아이템을 가져온다
				item2 = slot2.item.GetComponent<ItemBasic>().data;
				item3 = slot3.item.GetComponent<ItemBasic>().data;

				item1.location = (int)ItemPosition.alreadyUsed;//아이템들은 사용된걸로 처리된다
				item2.location = (int)ItemPosition.alreadyUsed;
				item3.location = (int)ItemPosition.alreadyUsed;

				bombs = GameObject.FindGameObjectsWithTag("Bomb");//bomb에 대한 객체배열 생성

				if (item1.bomb.Equals(item2.bomb) && item2.bomb.Equals(item3.bomb))//칸에 있는 3아이템의 폭탄이름이 같으면 폭탄생성
				{

					afterBomb(slot1, slot2, slot3);//버튼 누른후, 슬롯 초기화작업

					if (item1.bomb.Equals("다이너마이트"))
					{
						appearBomb(bombs, 0);//다이너마이트 생성
					}
					else if (item1.bomb.Equals("액체폭탄"))
					{
						appearBomb(bombs, 3);//액체폭탄 생성
					}
					else if (item1.bomb.Equals("EMP폭탄"))
					{
						appearBomb(bombs, 4);//EMP폭탄 생성
					}

				}
				else//폭탄 재료가 서로 맞지 않을때(재료끼리만 있을때)
				{

					item1.location = (int)ItemPosition.toUser;//아이템들은 다시 유저껄로 처리된다
					item2.location = (int)ItemPosition.toUser;
					item3.location = (int)ItemPosition.toUser;

					//재료들은 다시 원래자리로 돌아간다
					againStart(slot1.item);
					againStart(slot2.item);
					againStart(slot3.item);

					//슬롯 초기화 작업
					slot1.hasItem = false;
					slot2.hasItem = false;
					slot3.hasItem = false;

					slot1.hasBomb = false;
					slot2.hasBomb = false;
					slot3.hasBomb = false;

					slot1.item = null;
					slot2.item = null;
					slot3.item = null;
				}

			}
		}//재료중에 폭탄이 없을때 실행된다, if(!containBomb)문

		else//재료중에 폭탄이 있을때 실행된다
		{
			if (slotItem1.hasItem && slotItem2.hasItem && slotBomb.hasBomb)
			{
				item1 = slotItem1.item.GetComponent<ItemBasic>().data;//각 슬롯에 있는 아이템을 가져온다
				item2 = slotItem2.item.GetComponent<ItemBasic>().data;
				bomb = slotBomb.item;

				item1.location = (int)ItemPosition.alreadyUsed;//아이템들은 사용된걸로 처리된다
				item2.location = (int)ItemPosition.alreadyUsed;

				bomb.GetComponent<Bomb>().isComplete = false;//그 폭탄은 미완성된걸로 처리한다
				bomb.GetComponent<SpriteRenderer>().enabled = false;//폭탄이 사라진다

				bombs = GameObject.FindGameObjectsWithTag("Bomb");//bomb에 대한 객체배열 생성

				if (item1.bomb.Equals(item2.bomb))//칸에 있는 2 아이템의 폭탄이름이 같으면 폭탄생성
				{

					afterBomb(slotItem1, slotItem2, slotBomb);//버튼 누른후, 슬롯 초기화작업

					if (item1.bomb.Equals("가스폭탄"))
					{
						appearBomb(bombs, 1);//가스폭탄 생성
					}
					else if (item1.bomb.Equals("소이폭탄"))
					{
						appearBomb(bombs, 2);//소이폭탄 생성
					}
					else if (item1.bomb.Equals("수소화리튬"))
					{
						appearBomb(bombs, 5);//수소화리튬 생성
					}
					else if (item1.bomb.Equals("수소폭탄"))
					{
						appearBomb(bombs, 6);//수소폭탄 생성
					}
					else if (item1.bomb.Equals("3F 폭탄"))
					{
						appearBomb(bombs, 7);//3F 폭탄 생성
					}
					else if (item1.bomb.Equals("고양이 폭탄"))
					{
						appearBomb(bombs, 8);//고양이 폭탄 생성
					}
					else if (item1.bomb.Equals("데자와 폭탄"))
					{
						appearBomb(bombs, 9);//데자와 폭탄 생성
					}

				}
				else//폭탄 재료가 서로 맞지 않을때(폭탄이 재료로 있는 상태에서)
				{
					item1.location = (int)ItemPosition.toUser;//아이템들은 다시 유저껄로 처리된다
					item2.location = (int)ItemPosition.toUser;

					bomb.GetComponent<Bomb>().isComplete = true;//그 폭탄은 다시 완성된걸로 처리한다
					bomb.GetComponent<SpriteRenderer>().enabled = true;//폭탄이 다시 나타난다

					//재료들은 다시 원래 자리로 돌아간다
					againStart(slotItem1.item);
					againStart(slotItem2.item);
					againStart(slotBomb.item);

					//슬롯 초기화 작업들
					slotItem1.hasItem = false;
					slotItem2.hasItem = false;
					slotBomb.hasItem = false;

					slotItem1.hasBomb = false;
					slotItem2.hasBomb = false;
					slotBomb.hasBomb = false;

					slotItem1.item = null;
					slotItem2.item = null;
					slotBomb.item = null;
				}
			}
		}//else문 끝(폭탄재료가 있을때)

	}//onMouseDown 끝


	void CheckBomb(Combinationblock slot1, Combinationblock slot2, Combinationblock slot3)
	{
		if (slot1.hasBomb || slot2.hasBomb || slot3.hasBomb)//슬롯들 중에 폭탄이 있다면
		{
			containBomb = true;
			if (slot1.hasBomb)//어떤 슬롯에 폭탄이 있는지 찾는다
			{
				slotBomb = slot1;
				slotItem1 = slot2;
				slotItem2 = slot3;
			}
			else if (slot2.hasBomb)
			{
				slotBomb = slot2;
				slotItem1 = slot1;
				slotItem2 = slot3;
			}
			else if (slot3.hasBomb)
			{
				slotBomb = slot3;
				slotItem1 = slot1;
				slotItem2 = slot2;
			}
		}
		else//슬롯들 중에 폭탄이 없다면
		{
			containBomb = false;
		}
	}

	void afterBomb(Combinationblock slot1, Combinationblock slot2, Combinationblock slot3)//조합한 후, 실행되는 행동 즉 슬롯 초기화
	{
		slot1.item.SetActive(false);
		slot2.item.SetActive(false);
		slot3.item.SetActive(false);

		slot1.hasItem = false;
		slot2.hasItem = false;
		slot3.hasItem = false;

		slot1.hasBomb = false;
		slot2.hasBomb = false;
		slot3.hasBomb = false;

		slot1.item = null;
		slot2.item = null;
		slot3.item = null;
	}

	void appearBomb(GameObject[] Bombs, int bombID)//다이너마이트0,액체3,emp4는 폭탄재료가 필요없다
	{
		for (int i = 0; i < bombs.Length; i++)//bombs배열에서 item과 폭탄이름이 같으면 폭탄이 나타난다
		{

			if (bombs[i].GetComponent<Bomb>().id == bombID)
			{
				bombs[i].GetComponent<SpriteRenderer>().enabled = true;//폭탄이 보여지고,
				bombs[i].GetComponent<Bomb>().isComplete = true;//폭탄이 완성됐다!!
				//bombs[i].SetActive(true);
			}
		}
	}

	void againStart(GameObject item)//실패해서 재료들이 원래 자리로 돌아간다
	{
		DragHandler dragHandler = item.GetComponent<DragHandler>();
		Vector3 startPos = dragHandler.startPosition;
		item.transform.position = startPos;
	}
}