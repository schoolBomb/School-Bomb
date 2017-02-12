using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraContoller : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    float xMin = -23.5f;//배경이 보이는 x 최소값
    float xMax = 23.5f;//배경이 보이는 x 최대값
    bool check = true;
    Vector3 pos;
    /*
    public float screenWidth = 1850;

    private Camera camera;

    private float size;
    private float ratio;
    private float screenHeight;
    */
    void Awake()
    {
        /*
        camera = GetComponent<Camera>();
        ratio = (float)Screen.height / (float)Screen.width;
        screenHeight = screenWidth * ratio;
        size = screenHeight / 200;
        camera.orthographicSize = size;
        */
    }

    void Start()
    {
        /*
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        float cameraHeight = 10 / aspectRatio;
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = cameraHeight / 2f;
        */
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        /*
        camera = GetComponent<Camera>();
        ratio = (float)Screen.height / (float)Screen.width;
        screenHeight = screenWidth * ratio;
        size = screenHeight / 200;
        camera.orthographicSize = size;
        */

        CheckPosition();//player의 시야 적절한지 확인하는 메소드 호출
        if (check==true)//player의 시야에 배경이 안 나오는지 확인하는 변수 check가 true면
        {
            transform.position = pos;//camera의 위치 변경
        }
    }

    void CheckPosition()//player의 시야에 배경만 나오는지 확인하는 메소드
    {
        pos= new Vector3(player.position.x + offset.x,offset.y, -10);//현재 player의 위치확인
        if (pos.x > xMin && pos.x < xMax)//적절한 범위내에 camera가 존재하면
        {
            check = true;
        }
        else
        {
            check = false;
        }
            
    }

	public void rangeChange(float min, float max){
		xMin = min;
		xMax = max;
	}

    
}
