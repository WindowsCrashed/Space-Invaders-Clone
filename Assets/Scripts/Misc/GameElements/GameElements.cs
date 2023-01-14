using UnityEngine;

public class GameElements : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemies;

    public GameObject Player => player;
    public GameObject Enemies => enemies;
}
