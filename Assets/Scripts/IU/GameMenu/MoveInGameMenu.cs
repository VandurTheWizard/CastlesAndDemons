using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveInGameMenu : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField] private Transform[] levelPositions; // Array de posiciones de las casillas del nivel
    [SerializeField] private float moveSpeed = 5.0f; // Velocidad de movimiento del personaje
    [SerializeField] private int[] moveSteps; // Array de pasos para moverse al siguiente o anterior objetivo
    [SerializeField] private int[] completedLevels; // Array de niveles completados
    [SerializeField] private string[] levelsName; // Array de niveles

    [Header("InfoText")]
    [SerializeField] private GameObject textPrefab; // Prefab del texto de información
    [SerializeField] private Transform textParent; // Padre del texto de información
    [SerializeField] private TextMeshProUGUI textLevelInfo; // Texto del nombre del nivel

    [Header("BlockButtons")]
    [SerializeField] private GameObject imageRBlock; // Botón de siguiente
    [SerializeField] private GameObject imageLBlock; // Botón de anterior
    [SerializeField] private GameObject playButton; // Botón de jugar

    private Animator animator;

    private int currentLevelIndex = 0; // Índice de la casilla actual
    private bool isMoving = false; // Indica si el personaje se está moviendo
    private int moveStepIndex = 0; // Índice actual en el array de pasos para moverse al siguiente objetivo

    void Update()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isRun", isMoving);

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoveToNext();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoveToPrevious();
        }

        UpdateBlockButtons();
    }

    public void MoveToNext()
    {
        if(completedLevels[moveStepIndex+1] > 0){
            if (moveStepIndex < moveSteps.Length && !isMoving){
                int steps = moveSteps[moveStepIndex];
                moveStepIndex++;
                MoveToTarget(currentLevelIndex + steps);
                PutTextLevelInfo();
            }
        }else{
            GameObject text = Instantiate(textPrefab, textParent);
        }
        
    }

    public void MoveToPrevious()
    {
        if (moveStepIndex > 0 && !isMoving){
            moveStepIndex--;
            int steps = moveSteps[moveStepIndex];
            MoveToTarget(currentLevelIndex - steps);
            PutTextLevelInfo();
        }
    }

    public void MoveToTarget(int targetIndex)
    {
        if (targetIndex >= 0 && targetIndex < levelPositions.Length)
        {
            StartCoroutine(MoveThroughPoints(currentLevelIndex, targetIndex));
        }
    }

    private System.Collections.IEnumerator MoveThroughPoints(int startIndex, int endIndex)
    {
        isMoving = true;
        int step = startIndex < endIndex ? 1 : -1;

        for (int i = startIndex; i != endIndex; i += step)
        {
            yield return StartCoroutine(MoveToPosition(levelPositions[i + step].position));
        }

        currentLevelIndex = endIndex;
        isMoving = false;
    }

    private System.Collections.IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            FlipSprite(targetPosition);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
    }

    private void FlipSprite(Vector3 targetPosition)
    {
        if(transform.position.x <= targetPosition.x){
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }else{
            gameObject.GetComponent<SpriteRenderer>().flipX = true;   
        }
    }

    private void UpdateBlockButtons(){
        if(completedLevels[moveStepIndex+1] <= 0 || moveStepIndex == moveSteps.Length){
            imageRBlock.SetActive(true);
        }else{
            imageRBlock.SetActive(false);
        }

        if(moveStepIndex == 0){
            imageLBlock.SetActive(true);
        }else{
            imageLBlock.SetActive(false);
        }

        if(levelsName[moveStepIndex].Equals("")){
            ChangePlayButton(false);
        }else{
            ChangePlayButton(true);
        }
    }

    private void ChangePlayButton(bool active){
        playButton.SetActive(active);
    }

    public void PlayLevel(){
        if(!levelsName[moveStepIndex].Equals("")){
            SceneManager.LoadScene(levelsName[moveStepIndex]);
        }
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void PutTextLevelInfo(){
        textLevelInfo.text = levelsName[moveStepIndex];
    }
}
