using UnityEngine;

public class ShowControls : MonoBehaviour
{
    [Header("Images")]
    [SerializeField] private GameObject upButton;
    [SerializeField] private GameObject downButton;
    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    
    [Header("Sprites")]
    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite downSprite;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite upSpriteHold;
    [SerializeField] private Sprite downSpriteHold;
    [SerializeField] private Sprite leftSpriteHold;
    [SerializeField] private Sprite rightSpriteHold;

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
            upButton.GetComponent<SpriteRenderer>().sprite = upSpriteHold;
        else
            upButton.GetComponent<SpriteRenderer>().sprite = upSprite;

        if(Input.GetKey(KeyCode.S))
            downButton.GetComponent<SpriteRenderer>().sprite = downSpriteHold;
        else
            downButton.GetComponent<SpriteRenderer>().sprite = downSprite;

        if(Input.GetKey(KeyCode.A))
            leftButton.GetComponent<SpriteRenderer>().sprite = leftSpriteHold;
        else
            leftButton.GetComponent<SpriteRenderer>().sprite = leftSprite;

        if(Input.GetKey(KeyCode.D))
            rightButton.GetComponent<SpriteRenderer>().sprite = rightSpriteHold;
        else
            rightButton.GetComponent<SpriteRenderer>().sprite = rightSprite;        
    }
}
