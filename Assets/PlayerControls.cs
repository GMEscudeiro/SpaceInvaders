using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode shoot = KeyCode.Space;
    public float speed = 3.0f;
    public float boundX = 3.0f;
    private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.linearVelocity;                // Acessa a velocidade da raquete
        if (Input.GetKey(moveRight)) {             // Velocidade da Raquete para ir para cima
            vel.x = speed;
        }
        else if (Input.GetKey(moveLeft)) {      // Velocidade da Raquete para ir para cima
            vel.x = -speed;                    
        }
        else {
            vel.x = 0;                          // Velociade para manter a raquete parada
        }
        rb2d.linearVelocity = vel;                    // Atualizada a velocidade da raquete

        var pos = transform.position;           // Acessa a Posição da raquete
        if (pos.x > boundX) {                  
            pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        else if (pos.x < -boundX) {
            pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite inferior
        }
        transform.position = pos;  
    }

    void Shoot(){
        
    }
}
