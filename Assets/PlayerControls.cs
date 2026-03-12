using UnityEngine;
using System.Collections.Generic;

public class PlayerControls : MonoBehaviour
{

    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode shoot = KeyCode.Space;
    public float speed = 3.0f;
    public float boundX = 3.0f;
    public int lives = 3;
    private Rigidbody2D rb2d;

    public GameObject bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.linearVelocity;
        if (Input.GetKey(moveRight)) {
            vel.x = speed;
        }
        else if (Input.GetKey(moveLeft)) {
            vel.x = -speed;                    
        }
        else {
            vel.x = 0;
        }
        rb2d.linearVelocity = vel;

        var pos = transform.position;
        if (pos.x > boundX) {                  
            pos.x = boundX;
        }
        else if (pos.x < -boundX) {
            pos.x = -boundX;
        }
        transform.position = pos;  

        if(Input.GetKeyDown(shoot)){
            Shoot();
        }
    }

    void OnCollisionEnter2D(Collision2D coll){
        if (coll.collider.CompareTag("EnemyBullet")){
            Destroy(coll.gameObject);
            lives--;
        }
        if(lives <= 0){
            Debug.Log("PERDEU");
        }
    }

    void Shoot(){
        var pos = transform.position;
        GameObject bulletInstance = Instantiate(bullet, new Vector3(pos.x, pos.y + 0.5f, 0), Quaternion.identity);
        var bulletRb2d = bulletInstance.GetComponent<Rigidbody2D>();
        var vel = bulletRb2d.linearVelocity;
        vel.y = 5.0f;
        bulletRb2d.linearVelocity = vel;
    }
}
