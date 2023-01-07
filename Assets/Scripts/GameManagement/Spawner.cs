using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameElements gameElements;
    [SerializeField] GameObject currentGameElementsInstance;
    [SerializeField] GameObject currentPlayerInstance;

    public void SpawnPlayer()
    {
        currentPlayerInstance = Instantiate(gameElements.Player, currentGameElementsInstance.transform);
    }

    public void SpawnGameElements()
    {
        currentGameElementsInstance = Instantiate(gameElements.gameObject);
    }

    public void DespawnPlayer()
    {
        if (currentPlayerInstance != null)
        {
            Destroy(currentPlayerInstance);
            currentPlayerInstance = null;
        }      
    }

    public void DespawnGameElements()
    {
        if (currentGameElementsInstance != null)
        {
            Destroy(currentGameElementsInstance);
            currentGameElementsInstance = null;
        }    
    }
}
