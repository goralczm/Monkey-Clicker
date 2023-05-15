using System.Collections;
using UnityEngine;

public class ClickTrigger : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _clickReward;

    public GameManager gameManager { get; private set; }
    public AudioManager audioManager { get; private set; }
    public SpriteRenderer rend { get; private set; }

    private void Start()
    {
        gameManager = GameManager.Instance;
        audioManager = AudioManager.Instance;
        rend = GetComponent<SpriteRenderer>();
    }

    public virtual void OnMouseDown()
    {
        gameManager.AddCurrency(_clickReward);
    }
}
