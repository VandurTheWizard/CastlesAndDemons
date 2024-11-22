using TMPro;
using UnityEngine;

public class InfoText : MonoBehaviour
{
    [SerializeField] private GameObject levelText;
    [SerializeField] private GameObject damageText;

    public void LevelUp(){
        Instantiate(levelText, transform);
    }

    public void Damage(float damage){
        GameObject damageTextInstance = Instantiate(damageText, transform);
        damageTextInstance.GetComponent<TextMeshProUGUI>().text = "-" + damage + " HP";
    }
}
