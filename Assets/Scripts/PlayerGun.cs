using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask enemyLayer;
    public float maxRayDistance = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Left Mouse Button or Controller Trigger
        {
            Debug.Log("Fire button pressed!");
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Raycast Fired");

        // Convert the mouse position to world coordinates
        Vector2 rayOrigin = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // Create a ray direction from the player to the mouse cursor
        Vector2 rayDirection = (rayOrigin - (Vector2)transform.position).normalized;

        // Fire the 2D raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, maxRayDistance, enemyLayer);

        if (hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.name);

            // Try to get the Enemy script from the hit object
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(); // Call the TakeDamage method on the enemy
            }
        }
        else
        {
            Debug.Log("Missed!");
        }
    }
}
