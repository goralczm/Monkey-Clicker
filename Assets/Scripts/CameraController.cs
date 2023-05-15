using UnityEngine;

public class CameraController : MonoBehaviour
{
    public new Camera camera;

    [SerializeField, Range(0f, 1f)] private float _startAmount = 0.7f;
    [SerializeField, Range(0f, 1f)] private float _startDuration = 0.5f;

    private Vector3 _startPos;
    private float _shakeAmount = 0;
    private float _shakeDuration = 0;
    private bool _canShake;

    private void Start()
    {
        _startPos = transform.position;
        _canShake = true;
    }
    void Update()
    {
        if (!_canShake)
        {
            _shakeDuration = 0;
            return;
        }

        if (_shakeDuration > 0)
        {
            transform.position = _startPos + Random.insideUnitSphere * _shakeAmount;
            _shakeDuration -= Time.deltaTime;
        }
        else
            transform.position = _startPos;
    }

    public void TriggerShake()
    {
        _shakeAmount = _startAmount;
        _shakeDuration = _startDuration;
    }
}
