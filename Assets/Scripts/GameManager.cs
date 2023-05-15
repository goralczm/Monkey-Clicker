using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Signleton

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Another instance of Game Manager found!");
            Destroy(Instance.gameObject);
        }

        Instance = this;
    }

    #endregion

    [Header("Gameplay")]
    public int currency;

    [Header("Instances")]
    [SerializeField] private TextMeshProUGUI _currencyText;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private GameObject _hitEffect;

    private void Start()
    {
        AddCurrency(0);
    }

    public void AddCurrency(int diff)
    {
        currency += diff;
        _currencyText.SetText(currency.ToString());
    }

    public void ShakeCamera()
    {
        _cameraController.TriggerShake();
    }

    public void SendParticlesWave()
    {
        Instantiate(_hitEffect, _cameraController.camera.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }
}
