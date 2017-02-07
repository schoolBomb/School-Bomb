using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float minClamp = -90f;
    float maxClamp = 90f;
    public float speed=3f;//회전속도
    private float rotationZ = 0f;//회전속도
    private float rotateZ = 1f;//1f일때 시계방향으로 회전, 회전방향

    private void FixedUpdate()
    {
        moveRotate();
        //StartCoroutine(delayTime());
        if (rotationZ >= 90f || rotationZ <= -90f)//일정 범위 넘어가면 회전방향 전환
        {
            //Invoke("delayTime", 0.5f);
            delayTime();
        }
        
    }
    /*
    IEnumerator delayTime()
    {
        //moveRotate();
        if (rotationZ >= 90f || rotationZ <= -90f)//일정 범위 넘어가면 회전방향 전환
        {
            //yield return new WaitForSeconds(0.3f);
            rotateZ *= -1f;
        }

        yield return new WaitForSeconds(2f);
        
 //       transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ);//회전!!
    }
    */
    void delayTime()
    {

            rotateZ *= -1f;
        
    }
    void moveRotate()
    {
        if (rotateZ == 1f)//시계방향 회전
        {
            rotationZ += speed;
        }
        else//반시계방향 회전
        {
            rotationZ -= speed;
        }
        rotationZ = Mathf.Clamp(rotationZ, minClamp, maxClamp);//빛의 회전범위 제한
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ);//회전!!
    }
}
