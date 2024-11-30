using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of enemy prefabs
    public Transform spawnPoint; // The position where the enemy will appear

    // Start is called before the first frame update
    void Start()
    {
        // Randomly spawn an enemy at the start

        SpawnRandomEnemy();
    }

    // Function to spawn a random enemy
    void SpawnRandomEnemy()
    {
        // Select a random index from the array
        int randomIndex = Random.Range(0, enemyPrefabs.Length);

        // Instantiate the selected enemy at the spawn point
        GameObject spawnedEnemy = Instantiate(enemyPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);

        // Play the enemy's animation (this assumes the Animator component is set up on the prefab)
        Animator animator = spawnedEnemy.GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, -1, 0);
        }
    }
}
