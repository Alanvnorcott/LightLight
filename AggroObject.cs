using UnityEngine;

public class PassiveNpc : Fighter
{
    public int transformThreshold = 5; // Set the amount of hitpoints to trigger transformation
    public GameObject enemyPrefab; // Assign the Enemy prefab in the Inspector
    public string aggroMessage;
    public Color aggroMessageColor;

    public bool aggroOnObjectDestroyed = false; // Toggle for optional aggro on object destruction
    public GameObject objectToDestroyForAggro; // Assign the GameObject to destroy for aggro

    protected override void Death()
    {
        if (hitpoint <= 0)
        {
            // Check if the remaining hitpoints are below the transformation threshold
            if (hitpoint == 0)
            {
                GameManager.instance.ShowText(aggroMessage, 25, aggroMessageColor, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, 0.9f);

                if (aggroOnObjectDestroyed && objectToDestroyForAggro == null)
                {
                    // Destroy the specified game object for aggro
                    TransformIntoEnemy();
                }

                TransformIntoEnemy();
            }
            else
            {
                // Handle regular death logic
                base.Death();
            }
        }
    }

    private void TransformIntoEnemy()
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

