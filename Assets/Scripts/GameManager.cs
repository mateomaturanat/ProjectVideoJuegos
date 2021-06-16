using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    int score;
    public static GameManager inst;

    [SerializeField] Text scoreText;

    [SerializeField] PlayerMovement playerMovement;
    //Aumento de puntaje del personaje
    public void IncrementScore ()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        // Aumento de velocidad por puntos
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    private void Awake ()
    {
        inst = this;
    }
}