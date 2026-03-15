using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    GameObject enemies; 
    public static int score = 0;
    PlayerControls playerControls;
    public GUISkin layout;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       enemies = GameObject.FindGameObjectWithTag("Enemis");
       playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene("Game");
        score = 0;
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
        GUI.Label(new Rect(Screen.width / 2 - 250 - 12, 20, 2000, 1000), "Score: " + score);
        GUI.Label(new Rect(Screen.width / 2 + 50 - 12, 20, 2000, 1000), "Lives: " + playerControls.lives);
    }

}
