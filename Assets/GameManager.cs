using UnityEngine;

public class GameManager : MonoBehaviour
{

    GameObject enemies; 
    public static int score = 0;
    public GUISkin layout;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       enemies = GameObject.FindGameObjectWithTag("Enemis");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RestartGame()
    {
        score = 0;
        enemies.SendMessage("createEnemies", null, SendMessageOptions.RequireReceiver);
    }

    public static void Score(string type){
        if(type == "common"){
            score = score + 10;
        }else{
            score = score + 50;
        }
    }

    void OnGUI(){
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 500, 500), "" + score);
    }

}
