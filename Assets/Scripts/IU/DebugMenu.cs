using UnityEngine;
using TMPro;

public class DebugMenu : MonoBehaviour
{
    [SerializeField] private GameInfo gameInfo;

    private TextMeshProUGUI nameUser;
    private TextMeshProUGUI life;
    private TextMeshProUGUI points;

    private bool infiniteLife = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Obtén los hijos por nombre
        nameUser = transform.Find("NameUser").GetComponent<TextMeshProUGUI>();
        life = transform.Find("Life").GetComponent<TextMeshProUGUI>();
        points = transform.Find("Points").GetComponent<TextMeshProUGUI>();

        nameUser.text = "Name User: " + gameInfo.GetNameUser();
    }

    // Update is called once per frame
    void Update()
    {
        if(infiniteLife)
            gameInfo.SetLives(999);

        life.text = "Life: " + gameInfo.GetLives().ToString();
        points.text = "Points: " + gameInfo.GetPoints().ToString();
    }

    public void ChangeInfiniteLife()
    {
        infiniteLife = !infiniteLife;
    }
}
