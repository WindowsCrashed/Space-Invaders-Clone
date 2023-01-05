using UnityEngine;
using TMPro;

public class UILifeController : MonoBehaviour
{
    [SerializeField] TMP_Text lifeText; 
    [SerializeField] GameObject lifeIconsContainer;
    [SerializeField] HealthManager healthManager;

    void Start()
    {
        GameManager.OnPlayerDestroyed.AddListener(TakeLife);    
    }

    void TakeLife()
    {
        lifeText.text = healthManager.PlayerLives.ToString();

        if (healthManager.PlayerLives > 0)
        {
            lifeIconsContainer.transform.GetChild(healthManager.PlayerLives - 1)
                .gameObject.SetActive(false);
        }
    }
}
