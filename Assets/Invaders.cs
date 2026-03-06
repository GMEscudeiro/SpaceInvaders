using UnityEngine;

public class Invaders : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 3.0f;
    private float speed = 0.1f;
    private int step = 0;
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
        timer += Time.deltaTime;
        if (timer >= waitTime){
            ChangeState();
            timer = 0.0f;
        }
    }

    void ChangeState(){
        step++;
        var vel = rb2d.linearVelocity;
        var pos = transform.position;
        vel.x *= -1;
        rb2d.linearVelocity = vel;
        if(step == 2){
            pos.y -= 0.1f;
            transform.position = pos;
            step = 0;
        }
    }
}
