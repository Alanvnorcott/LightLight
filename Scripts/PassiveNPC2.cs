using UnityEngine;

public class PassiveNPC2 : Fighter
{
    public int transformThreshold = 5; // Set the amount of hitpoints to trigger transformation
    public GameObject enemyPrefab; // Assign the Enemy prefab in the Inspector

    protected override void Death()
    {
        if (hitpoint <= 0)
        {
            // Check if the remaining hitpoints are below the transformation threshold
            if (hitpoint == 0)
            {
                // Perform transformation logic
                TransformIntoEnemy();
            }
            else
            {
                // Handle regular death logic
                base.Death();
            }
        }
    }

    public void TransformIntoEnemy()
    {
        // Instantiate an Enemy GameObject or activate an existing one at the same position
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // You might want to transfer some properties or state from the NPC to the new enemy
        Enemy enemyComponent = enemy.GetComponent<Enemy>();
        if (enemyComponent != null)
        {
            // Transfer properties here if needed
        }

        // Destroy the NPC
        Destroy(gameObject);
    }
}


