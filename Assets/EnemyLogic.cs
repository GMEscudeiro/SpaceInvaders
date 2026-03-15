using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EnemyLogic : MonoBehaviour
{

    public GameObject enemyRow;
    public int numberOfRows = 8;
    private List<GameObject> rows = new List<GameObject>();

    private float timer = 0.0f;
    public float waitTime = 1.0f;

    public GameObject mothership;
    private float motherShipTimer = 0.0f;
    public float motherShipTime = 30.0f;

    public GameObject bullet;
    private int numberOfEnemies = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        createEnemies();
    }

    void createEnemies(){
        float initialPos = -3.0f;

        for(int i=0; i < numberOfRows; i++){
            rows.Add(Instantiate(enemyRow, new Vector3(initialPos, -0.5f, 0), Quaternion.identity));
            initialPos += 0.8f;
            numberOfEnemies += enemyRow.transform.childCount;
        }
    }

    void EnemyKilled(){
        numberOfEnemies--;
    }

    GameObject getFirstInRow(GameObject row){
        Transform first = row.transform.GetChild(0);
        foreach (Transform child in row.transform){
            if(child.position.y < first.position.y){
                first = child;
            }
        }
        return first.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime){
            int row = Random.Range(0, 7);
            GameObject enemy = getFirstInRow(rows[row]);
            if(enemy){
                Shoot(enemy);
            }
            timer = 0.0f;
        }

        motherShipTimer += Time.deltaTime;
        if(motherShipTimer >= motherShipTime){
            float chance = Random.Range(0.0f,1.0f);
            if(chance >= 0.5f){
                Instantiate(mothership, new Vector3(-4.0f, 3.0f, 0), Quaternion.identity);
            }
            motherShipTimer = 0.0f; 
        }

        if(numberOfEnemies <= 0){
           SceneManager.LoadScene("GoodEnding");
        }
        Debug.Log(numberOfEnemies);
    }

    void Shoot(GameObject enemy){
        var pos = enemy.transform.position;
        GameObject bulletInstance = Instantiate(bullet, new Vector3(pos.x, pos.y - 0.5f, 0), Quaternion.identity);
        var bulletRb2d = bulletInstance.GetComponent<Rigidbody2D>();
        var vel = bulletRb2d.linearVelocity;
        vel.y = -3.0f;
        bulletRb2d.linearVelocity = vel;
    }


}

