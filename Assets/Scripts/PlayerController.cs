using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow) == true)    
        //{
        //    playerRigidbody.AddForce(0f, 0f, speed);
        //}
        //if (Input.GetKey(KeyCode.DownArrow) == true)
        //{
        //    playerRigidbody.AddForce(0f, 0f, -speed);
        //}
        //if (Input.GetKey(KeyCode.RightArrow) == true)
        //{
        //    playerRigidbody.AddForce(speed, 0f, 0f);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow) == true)
        //{
        //    playerRigidbody.AddForce(-speed, 0f, 0f);
        //}
        if(Input.GetMouseButton(0))
        {
            Vector3 screePos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screePos.z);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.y = 1.0f;
            transform.position = Vector3.MoveTowards(transform.position, worldPos, speed * Time.deltaTime);
        }

        float xInput = Input.GetAxis("Horizontal");     //수평축의 입력값을 감지
        float zInput = Input.GetAxis("Vertical");       //수직축의 입력값을 값지

        float xSpeed = xInput * speed ;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);      //새로운 속도 생성
        playerRigidbody.velocity = newVelocity;                     //Rigidbody에 새로운 속도 할당
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
