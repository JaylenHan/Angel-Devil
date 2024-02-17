using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10; //스피드
    public float damage = 1f; //공격, 데미지

    // Start is called before the first frame update
    void Start()
    {
       Destroy(gameObject, 1f); //1초 뒤에 총알을 없앰, 계속 위로 올라가서 오브젝트가 계속 생성되지 않게
            
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
