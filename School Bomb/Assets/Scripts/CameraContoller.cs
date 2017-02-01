using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    float xMin = -18f;//배경이 보이는 x 최소값
    float xMax = 18f;//배경이 보이는 x 최대값
    bool check = true;
    Vector3 pos;

    // Update is called once per frame
    void LateUpdate()
    {
        
        CheckPosition();//player의 시야 적절한지 확인하는 메소드 호출
        if (check==true)//player의 시야에 배경이 안 나오는지 확인하는 변수 check가 true면
        {
            transform.position = pos;//camera의 위치 변경
        }
    }

    void CheckPosition()//player의 시야에 배경만 나오는지 확인하는 메소드
    {
        pos= new Vector3(player.position.x + offset.x, player.position.y + offset.y, -10);//현재 player의 위치확인
        if (pos.x > xMin && pos.x < xMax)//적절한 범위내에 camera가 존재하면
        {
            check = true;
        }
        else
        {
            check = false;
        }
            
    }
}
