using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public GUISkin finalLayout;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "GoodEnding" || scene.name == "BadEnding"){
            if(Input.GetKey(KeyCode.Space)){
                GameManager.RestartGame();
            }
        }
    }

    void OnGUI(){
        GUI.skin = finalLayout;
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "GoodEnding"){
            GUI.Label(new Rect(Screen.width / 2 - 310 - 12, Screen.height / 2 - 450, 2000, 1000), "Voce ganhou!");
        }
        else if(scene.name == "BadEnding"){
            GUI.Label(new Rect(Screen.width / 2 - 310 - 12, Screen.height / 2 - 450, 2000, 1000), "Voce perdeu!");
        }
        if(scene.name == "GoodEnding" || scene.name == "BadEnding"){
            GUI.Label(new Rect(Screen.width / 2 - 330 - 12, Screen.height / 2 - 300, 2000, 1000), "Final Score: " + GameManager.score);
            GUI.Label(new Rect(Screen.width / 2 - 400 - 12, Screen.height / 2 + 200, 2000, 1000), "Pressione Space");
            GUI.Label(new Rect(Screen.width / 2 - 330 - 12, Screen.height / 2 + 270, 2000, 1000), "para reiniciar");
        }
    }
}
