using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CanvasScript : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] TMP_Text bulletText;
    [SerializeField] TMP_Text pointsText;
    [SerializeField] TMP_Text reloadingText;

    [Header("Panel")]
    [SerializeField] GameObject gameOverPanel;

    ShootBullet playerBullet;

    void Start()
    {
        playerBullet = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootBullet>();
    }

    void Update()
    {
        //checar pontos e numero de balas do jogador
        CanvasTexts();
        //mostrar o texto de reloading
        ShowReloadText();
        //quando o jogador morre, mostra o panel de gameover
        ShowGameOverPanel();
    }


    void ShowReloadText()
    {
        if (playerBullet.IsReloading)
            reloadingText.gameObject.SetActive(true);
        else
            reloadingText.gameObject.SetActive(false);
    }

    void CanvasTexts()
    {
        bulletText.text = playerBullet.CurrentBullet.ToString() + " / " + playerBullet.MaxBullet.ToString();
        pointsText.text = GameController.instance.Points.ToString();
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(GameController.instance.GameOver);
    }
}
