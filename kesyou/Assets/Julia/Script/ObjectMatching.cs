using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ObjectMatching : MonoBehaviour
{
    public GameObject movingObject;    // Reference to the moving object
    public GameObject targetArea;      // Reference to the target area
    public Text resultText;            // UI Text to display the match percentage    
    public Text showResult;
    public float moveSpeed = 2f;          // Speed of the moving object
    public float targetThreshold = 0.1f;
    public float postTargetSpeed = 2f;  
    public Vector2 postTargetDirection;
    public Transform[] spawnPoints;
    private Vector2 movementDirection;
    public Transform[] detectPoint;     

    public bool isMoving = true;         // Controls if the object is moving   
    private Vector2 targetPosition;       // Position of the target area
    private Vector2 originalDirection;
    private Camera mainCamera;

    public AudioClip failSE;
    public AudioClip successSE;
    public AudioClip BGM;
    public AudioSource audioSource;

    public GameObject panel;
    public Button startButton;
    public Text startText;
    public GameObject[] gameObjectsToActivate;
    private bool Started=false;

    public PauseMenu pauseMenu;    
    
    void Start()
    {
        SpawnAtRandomPoint();
        mainCamera = Camera.main;        
        targetPosition = targetArea.transform.position;
        movementDirection = (targetPosition - (Vector2)movingObject.transform.position).normalized;
        audioSource = GetComponent<AudioSource>();

        panel.SetActive(true);       
        startButton.onClick.AddListener(StartGame);
        startText.gameObject.SetActive(false);      
        foreach (var obj in gameObjectsToActivate)
        {
            obj.SetActive(false);
        }    

        
       
    }
    void StartGame()
    {
        panel.SetActive(false);
        showResult.gameObject.SetActive(false);
        StartCoroutine(StartCountdown());
    }
    IEnumerator StartCountdown()
    {
        startText.gameObject.SetActive(true);

        startText.text = "Ready";
        yield return new WaitForSeconds(1.5f);

        startText.text = "Start!";
        yield return new WaitForSeconds(1.0f);

        startText.gameObject.SetActive(false);

        
        foreach (var obj in gameObjectsToActivate)
        {
            obj.SetActive(true);
        }
        Started=true;        
       
    }

    void Update()
    {
        
        if (isMoving)
        {
          
            MoveObject();
            Respawn();
        }
        
        if (Input.GetMouseButtonDown(0) && 
        Started && 
        (pauseMenu == null || !pauseMenu.GameIsPaused) && 
        (EventSystem.current == null || !EventSystem.current.IsPointerOverGameObject()))
        {
            StopObject();
            DetectingPoint();
        }
    }
    private void MoveObject()
    {        
        movingObject.transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
    }
    private void Respawn()
    {
        Vector3 viewportPosition=mainCamera.WorldToViewportPoint(movingObject.transform.position);
        if(viewportPosition.x<-0.2f || viewportPosition.x>1.2f || viewportPosition.y<-0.2f || viewportPosition.y>1.2f)
        {
            SpawnAtRandomPoint();
            isMoving=true;
        }
    }
    private void SpawnAtRandomPoint()
    {
        // Ensure there are spawn points defined
        if (spawnPoints.Length > 0)
        {
            // Select a random spawn point
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndex];

            movingObject.transform.position = spawnPoint.position;
            movementDirection = (targetPosition - (Vector2)movingObject.transform.position).normalized;
        }
        
    }
    private void MoveTowardTarget()
    {
        // Get the current position of the moving object
        Vector2 currentPosition = movingObject.transform.position;

        // Calculate direction toward the target
        Vector2 direction = (targetPosition - currentPosition).normalized;

        // Move the object toward the target
        movingObject.transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Check if the object has passed through the target area

    }   
    private void ContinueMoving()
    {
        // Move the object in the post-target direction
        movingObject.transform.Translate(postTargetDirection * postTargetSpeed * Time.deltaTime);
    }   

    private void StopObject()
    {
        isMoving = false;
    }

    private void DetectingPoint()
{
    int totalPoint = detectPoint.Length;
    int touchingPoint = 0;    

    if (!isMoving)  // Only check when the object is stopped
    {
        // Get the moving object's collider
        Collider2D movingObjectCollider = movingObject.GetComponent<Collider2D>();
        if (movingObjectCollider == null) return; // Exit if no Collider2D is found

        // Sync physics (if needed) and get the bounds
        Physics2D.SyncTransforms();
        Bounds movingBounds = movingObjectCollider.bounds;        

        // Loop through each DetectPoint and check if it's inside the bounds
        foreach (Transform point in detectPoint)
{
    Vector3 pointPosition = point.position;

    float margin = 0.001f; // Small tolerance margin

    if (pointPosition.x > movingBounds.min.x - margin &&
        pointPosition.x < movingBounds.max.x + margin &&
        pointPosition.y > movingBounds.min.y - margin &&
        pointPosition.y < movingBounds.max.y + margin)
    {
        touchingPoint++;
        
    }
}
if(touchingPoint>6)
{
                showResult.gameObject.SetActive(true);
    showResult.text="Clear";
    audioSource.PlayOneShot(successSE);
                
                StartCoroutine(DelayLoadScene("bunki", 2));

            }
else
{
    audioSource.PlayOneShot(failSE);
                SceneManager.LoadScene("GameOver");
            }


        // Display the result
        resultText.text =touchingPoint.ToString();
    }
}
    IEnumerator DelayLoadScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}

        
        
        

    


    
    

