using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;

    [SerializeField]
    private GameObject[] weapons;

    private int weaponIndex = 0;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShotTime = 0f;
    float minX, maxX, minY, maxY;
    public Vector2 inputDirection;

    void Start()
    {
        minY = -2f;
        maxY = 5f;
        minX = -Camera.main.orthographicSize * Camera.main.aspect;
        maxX = Camera.main.orthographicSize * Camera.main.aspect;
    }


    // Update is called once per frame
    void Update()
    {
       Move(inputDirection);
       if (GameManager.instance.isGameOver == false) {
         Shoot();

       }
      
    }

    void Shoot() {
        if (Time.time - lastShotTime > shootInterval) {
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        } 
        //미사일이 갯수, 시간을 정하는 코드
        //10 - 0 > 0.05 일때, 새로운 미사일을 만듦
        //lastShotTime = 10;
        //10.001 - 10 > 0,05 ?
        //false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss") {
        GameManager.instance.SetGameOver(); //게임종료
        Destroy(gameObject);
        } else if (other.gameObject.tag == "Coin") {
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade() {
        weaponIndex += 1;
        if (weaponIndex >= weapons.Length) {
            weaponIndex = weapons.Length - 1;
        }
    }
     void LateUpdate()
    {
        // Step 3. 이동 제한
        LimitToMove();
    }

    public void Move(Vector2 inputDirection)
    {
        Vector3 _moveHoizontal = transform.up * inputDirection.y;
        Vector3 _moveVertial = -transform.right * -inputDirection.x;
        Vector3 move = (_moveVertial + _moveHoizontal).normalized * speed;
        transform.position += move * Time.deltaTime * speed;
        //Debug.Log(move);

    }

    void LimitToMove()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                         Mathf.Clamp(transform.position.y, minY, maxY));
    }
}

