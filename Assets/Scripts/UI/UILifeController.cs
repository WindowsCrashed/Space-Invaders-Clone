using UnityEngine;
using TMPro;

public class UILifeController : MonoBehaviour
{
    [SerializeField] TMP_Text lifeText; 
    [SerializeField] GameObject lifeIconsContainer;
    [SerializeField] GameManager gameManager;

    void Start()
    {
        GameManager.OnTakeLife.AddListener(TakeLife);    
    }

    void TakeLife()
    {
        lifeText.text = gameManager.PlayerLives.ToString();

        if (gameManager.PlayerLives > 0)
        {
            lifeIconsContainer.transform.GetChild(gameManager.PlayerLives - 1)
                .gameObject.SetActive(false);
        }
    }
}
