using UnityEngine;
using UnityEngine.UI;

public class SimpleHUD : MonoBehaviour
{
    public Text healthText;
    public Text livesText;
    public Text scoreText;

    int health = 100;
    int lives = 3;
    int score = 0;

    void Update()
    {
        if (healthText) healthText.text = $"HP: {health}";
        if (livesText) livesText.text = $"Lives: {lives}";
        if (scoreText) scoreText.text = $"Score: {score}";
    }

    public void SetHealth(int h) { health = h; }
    public void SetLives(int l) { lives = l; }
    public void AddScore(int s) { score += s; }
}
