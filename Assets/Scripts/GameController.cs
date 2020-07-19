using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour {

    [SerializeField] private Animator menuAnim;
    [SerializeField] private Animator gameUIAnim;

    [SerializeField] private float energy;
    private TextMeshProUGUI energyText;
    private int score = 0;
    private TextMeshProUGUI scoreText;

    void Start() {
        energyText = GameObject.Find("EnergyText").GetComponent<TextMeshProUGUI>();
        energyText.text = $"Energy: {energy}";
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.text = $"Score: {score}";
    }

    public void UpdateEnergy(float points) {
        energy += points;
        energyText.text = $"Energy: {(int)energy}";
    }

    public void UpdateScore(int points) {
        score += points;
        scoreText.text = $"Score: {score}";
    }

    public void GameOver() {
        GameObject.Find("FinalScoreText").GetComponent<TextMeshProUGUI>().text = $"Final score: {score}";
        menuAnim.SetTrigger("Gameover");
        gameUIAnim.SetTrigger("Gameover");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
