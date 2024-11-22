using System;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [Header("General Info")]
    [SerializeField] private String nameUser;
    [SerializeField] private int points;
    [SerializeField] private int lives;
    [SerializeField] private float extraRangeTower;

    void Awake()
    {
        if(nameUser == "")
            nameUser = "Player";
        else
            Debug.Log("Welcome " + nameUser);

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        

        if(points == 0)
            points = 0;
        if(lives == 0)
            lives = 3;
    }

    public void AddPoints(int points)
    {
        this.points += points;
    }

    public void RemovePoints(int points)
    {
        this.points -= points;
    }

    public void AddLives(int lives)
    {
        this.lives += lives;
    }

    public void RemoveLives(int lives)
    {
        this.lives -= lives;
        if(this.lives <= 0)
            GameOver();
    }

    public void GameOver(){
        Debug.Log("Game Over");
    }

    // Getter and Setter
    public String GetNameUser()
    {
        return nameUser;
    }

    public void SetNameUser(String nameUser)
    {
        this.nameUser = nameUser;
    }

    public int GetLives()
    {
        return lives;
    }

    public void SetLives(int lives)
    {
        this.lives = lives;
    }

    public int GetPoints()
    {
        return points;
    }

    public void SetPoints(int points)
    {
        this.points = points;
    }

    public float GetExtraRangeTower()
    {
        return extraRangeTower;
    }

    public void SetExtraRangeTower(float extraRangeTower)
    {
        this.extraRangeTower = extraRangeTower;
    }

}
