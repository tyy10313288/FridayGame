using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMatching : MonoBehaviour
{
    public GameObject movingObject;    // Reference to the moving object
    public GameObject targetArea;      // Reference to the target area
    public Text resultText;            // UI Text to display the match percentage    
     public float moveSpeed = 2f;          // Speed of the moving object
    public float targetThreshold = 0.1f;
    public float postTargetSpeed = 2f;  
    public Vector2 postTargetDirection;
    public Transform[] spawnPoints;
    private Vector2 movementDirection;
    public Transform[] detectPoint;     

    private bool isMoving = true;         // Controls if the object is moving   
    private Vector2 targetPosition;       // Position of the target area
     private bool hasPassedTarget = false;
     private Vector2 originalDirection;
     private Camera mainCamera;
    
    void Start()
    {
        SpawnAtRandomPoint();
        mainCamera = Camera.main;        
        targetPosition = targetArea.transform.position;
        movementDirection = (targetPosition - (Vector2)movingObject.transform.position).normalized;
        
        
       
    }

    void Update()
    {
        
        if (isMoving)
        {
          
            MoveObject();
            Respawn();
        }
        
        if (Input.GetMouseButtonDown(0))
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
            hasPassedTarget=false;
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
        if (Vector2.Distance(currentPosition, targetPosition) < 0.1f)
        {
            hasPassedTarget = true; // Mark the object as having passed the target
        }
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
        int totalPoint=detectPoint.Length;
        int touchingPoint=0;
        if(!isMoving)
        {
        
        foreach (Transform point in detectPoint)
        {
            Collider2D hitCollider = Physics2D.OverlapPoint(point.position);

            if (hitCollider != null && hitCollider.gameObject == movingObject)
            {
                touchingPoint++; // Increment count if the point is overlapping the moving object
            }
        }
        resultText.text=touchingPoint.ToString();
        }
        

    }

}
    
    

