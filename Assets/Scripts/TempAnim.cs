using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class TempAnim : MonoBehaviour
{
    [SerializeField] List<GameObject> objs;

    AnimationManager animationManager;

    private void Awake()
    {
        animationManager = GetComponent<AnimationManager>();

        for (int i = 0; i < objs.Count; i++)
        {
            animationManager.SetAnimatorController(objs[i].GetComponentInChildren<Animator>());        
        }
    }
}
