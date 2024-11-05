using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats stats;
    public PlayerController controller;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        stats = GetComponent<PlayerStats>();
        controller = GetComponent<PlayerController>();
    }
}
