using System;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Health")]    
    [SerializeField] private int maxHealth = 9;
    [SerializeField] private int healthIncreasePerLevel = 1;
    private int health;
    [Header("Experience")]   
    [SerializeField] private float expRequired = 10;
    [SerializeField] private float expIncreasePerLevel = 1.5f;
    [SerializeField] private float exp;
    [Header("Money")]   
    [SerializeField] private float money;
    [SerializeField] private TextMeshProUGUI textMoney;
    [Header("Shot")]
    [SerializeField] private float bulletDamage = 1f;
    [SerializeField] private float shotCooldown = 2f;
    [Header("UI")]
    [SerializeField] private GameObject deadScreen;
    [SerializeField] private GameObject lifeBar;
    private int level = 1;

    void Awake()
    {
        health = maxHealth;
        lifeBar.GetComponent<BarFunction>().UpdateBar(health, maxHealth);
        textMoney.text = money.ToString();
    }

    public void LevelUp()
    {
        // Vida 
        maxHealth += healthIncreasePerLevel;
        Heal(5);
        lifeBar.GetComponent<BarFunction>().UpdateBar(health, maxHealth);
        //Experiencia
        level ++;
        expRequired *= expIncreasePerLevel;
        transform.GetChild(3).GetComponent<InfoText>().LevelUp();
        // Cooldown
        if((shotCooldown - 0.1f) > 0.5f)
        {
            shotCooldown -= 0.1f;
            gameObject.GetComponent<ShotGun>().SetShotCooldown(shotCooldown);
        }
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

    public float ShotCooldown
    {
        get { return shotCooldown; }
    }

    
}
