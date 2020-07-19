using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField] private Animator menuAnim;
    [SerializeField] private Animator gameUIAnim;
    public void GameOver() {
        menuAnim.SetTrigger("Gameover");
        gameUIAnim.SetTrigger("Gameover");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
