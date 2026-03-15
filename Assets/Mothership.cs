using UnityEngine;

public class Mothership : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed = 0.5f;
    
    public GameObject bullet;
    private GameObject enemyLogic;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  
        var vel = rb2d.linearVelocity;
        vel.x = speed;
        rb2d.linearVelocity = vel;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll){
        if (coll.collider.CompareTag("Bullet")){
            Destroy(coll.gameObject);
            Destroy(gameObject);
            GameManager.Score("mothership");
        }
    }
}
