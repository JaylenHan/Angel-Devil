using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

     private float minY = -7;

    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    void Jump() {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        float randomJumpForce = Random.Range(4f, 8f);
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;
        jumpVelocity.x = Random.Range(-2f, 2f);
        rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse); //코인이 랜덤으로 점프해서 떨어짐. 게임의 재미 및 변수 늘림
    }

    // Update is called once per frame
    void Update()
    {
         if (transform.position.y < minY) {
            Destroy(gameObject);
        }
    }
}
