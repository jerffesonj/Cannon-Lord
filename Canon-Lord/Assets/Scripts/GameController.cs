using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] bool gameOver;
    [SerializeField] float points;
    [SerializeField] float maxPoints;

    HpScript playerHp;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<HpScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsGameOver(bool value)
    {
        gameOver = value;
        print("gameob");
    }

    public void AddPoints(float value)
    {
        points += value;
        if (points >= maxPoints)
        {
            playerHp.AddHP(25);
            maxPoints+=maxPoints;
            if (playerHp.Hp >= 100)
            {
                playerHp.Hp = 100;
            }
        }
    }

    public void Restart()
    {
        gameOver = false;
        points = 0;
        SceneManager.LoadScene(0);
    }

    public bool GameOver { get { return gameOver; } }
    public float Points { get { return points; } }
}
