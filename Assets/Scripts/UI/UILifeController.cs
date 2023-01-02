using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UILifeController : MonoBehaviour
{
    [SerializeField] GameObject lifeIconsContainer;
    [SerializeField] GameManager gameManager;

    void Awake()
    {
        GameManager.TakeLifeEvent.AddListener(TakeLife);    
    }

    void TakeLife()
    {
        if (gameManager.PlayerLives > 1)
        {
            lifeIconsContainer.transform.GetChild(gameManager.PlayerLives - 2)
                .gameObject.SetActive(false);
        }
    }
}
