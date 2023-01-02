using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float destroyDelay;

    SpriteController spriteController;

    void Awake()
    {
        spriteController = GetComponent<SpriteController>();
    }

    IEnumerator ExplosionCoroutine(string sprite)
    {
        if (spriteController != null) spriteController.SetSprite(sprite);
        yield return new WaitForSecondsRealtime(destroyDelay);
        Destroy(gameObject);
    }

    public void Explode(string sprite = "Death")
    {
        if (spriteController != null) spriteController.SetSprite(sprite);
        Destroy(gameObject, destroyDelay);
    }

    public void ExplodeAsync(string sprite = "Death")
    {
        StartCoroutine(ExplosionCoroutine(sprite));
    }
}
