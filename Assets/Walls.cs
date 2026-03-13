using UnityEngine;

public class Walls : MonoBehaviour
{
    private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll){
        if (coll.collider.CompareTag("EnemyBullet") || coll.collider.CompareTag("Bullet")){
            Destroy(coll.gameObject);
        }
    }
}
