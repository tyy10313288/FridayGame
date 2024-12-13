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

    private bool isMoving = true;         // Controls if the object is moving   
    private Vector2 targetPosition;       // Position of the target area
     private bool hasPassedTarget = false;
    
    void Start()
    {
        // Initialize the target position as the center of the target area
        targetPosition = targetArea.transform.position;
    }

    void Update()
    {
        
        if (isMoving)
        {
            if (!hasPassedTarget)
            {
                MoveTowardTarget();
            }
            else
            {
                ContinueMoving();
            }
        }

        // Stop the object when in target area and left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            StopObject();
            CalculateMatchPercentage();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == targetArea)
        {
            CalculateMatchPercentage();
        }
    } 

    private void StopObject()
    {
        isMoving = false;
    }

    private void CalculateMatchPercentage()
    {
        // Get colliders of the moving object and the target area
        Collider2D movingObjectCollider = movingObject.GetComponent<Collider2D>();
        Collider2D targetAreaCollider = targetArea.GetComponent<Collider2D>();

        if (movingObjectCollider != null && targetAreaCollider != null)
        {
            // Calculate the overlap area
            Bounds movingBounds = movingObjectCollider.bounds;
            Bounds targetBounds = targetAreaCollider.bounds;

            Rect movingRect = new Rect(movingBounds.min.x, movingBounds.min.y, movingBounds.size.x, movingBounds.size.y);
            Rect targetRect = new Rect(targetBounds.min.x, targetBounds.min.y, targetBounds.size.x, targetBounds.size.y);

            Rect overlap = RectIntersection(movingRect, targetRect);

            if (overlap.width > 0 && overlap.height > 0)
            {
                // Calculate percentage overlap
                float overlapArea = overlap.width * overlap.height;
                float targetAreaSize = targetRect.width * targetRect.height;

                float matchPercentage = (overlapArea / targetAreaSize) * 100f;
                resultText.text = "Match Percentage: " + matchPercentage.ToString("F2") + "%";
            }
            else
            {
                resultText.text = "No overlap detected.";
            }
        }
    }

    private Rect RectIntersection(Rect a, Rect b)
    {
        float xMin = Mathf.Max(a.xMin, b.xMin);
        float xMax = Mathf.Min(a.xMax, b.xMax);
        float yMin = Mathf.Max(a.yMin, b.yMin);
        float yMax = Mathf.Min(a.yMax, b.yMax);

        if (xMax >= xMin && yMax >= yMin)
        {
            return new Rect(xMin, yMin, xMax - xMin, yMax - yMin);
        }
        else
        {
            return Rect.zero; // No intersection
        }
    }
    
    
}
