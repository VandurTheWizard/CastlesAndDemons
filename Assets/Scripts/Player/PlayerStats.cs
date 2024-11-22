using System;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Health")]    
    [SerializeField] private int maxHealth = 5;
    private int health;
    [Header("Experience")]   
    [SerializeField] private float expRequired = 10;
    [SerializeField] private float expIncreasePerLevel = 1.5f;
    [SerializeField] private float exp;
    [Header("Money")]   
    [SerializeField] private float money;
    [SerializeField] private TextMeshProUGUI textMoney;
    [Header("Shot")]
    [SerializeField] private float bulletDamage = 1;
    [SerializeField] private float shotCooldown = 1;
    [Header("UI")]
    [SerializeField] private GameObject deadScreen;
    [SerializeField] private GameObject lifeBar;
    private int level = 1;

    void Start()
    {
        health = maxHealth;
        lifeBar.GetComponent<BarFunction>().UpdateBar(health, maxHealth);
        textMoney.text = money.ToString();
    }

    public void LevelUp()
    {
        level ++;
        maxHealth += 1;
        health = maxHealth;
        lifeBar.GetComponent<BarFunction>().UpdateBar(health, maxHealth);
        expRequired *= expIncreasePerLevel;
        transform.GetChild(3).GetComponent<InfoText>().LevelUp();
    }

    public void Heal(int heal)
    {
        health += heal;
        if (health > maxHealth) 
        {
            health = maxHealth;
        }
        lifeBar.GetComponent<BarFunction>().UpdateBar(health, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        transform.GetChild(3).GetComponent<InfoText>().Damage(damage);
        lifeBar.GetComponent<BarFunction>().UpdateBar(health, maxHealth);
        if (health <= 0)
        {
            //Se termina el juego
            Instantiate(deadScreen, transform.position, Quaternion.identity);
        }
    }

    public void UpdateMoney(float money)
    {
        this.money += money;
        if(textMoney != null)
        {
            textMoney.text = this.money.ToString();
        }

    }

    public void Exp(float exp)
    {
        this.exp += exp;
        if (this.exp >= expRequired)
        {
            this.exp -= expRequired;
            LevelUp();
        }
    }

    public int GetLevel()
    {
        return level;
    }

    public float Money
    {
        get { return money; }
        set { money = value; }
    }

    
}
