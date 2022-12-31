using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [Header("Enemy Projectile")]
    [SerializeField] List<RuntimeAnimatorController> animControllers;

    int currentIndex = 0;

    void IncrementIndex()
    {
        currentIndex = currentIndex < animControllers.Count ? currentIndex + 1 : 0;
    }

    public void SetAnimatorController(Animator anim)
    {
        anim.runtimeAnimatorController = animControllers[currentIndex];
        IncrementIndex();
    }
}
