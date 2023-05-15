using System.Collections;
using UnityEngine;

public class MonkeyClick : ClickTrigger
{
    [SerializeField] private string[] _clickSounds;

    [Header("Instances")]
    [SerializeField] private Sprite _idleSprite;
    [SerializeField] private Sprite _clickSprite;

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        gameManager.SendParticlesWave();
        gameManager.ShakeCamera();
        audioManager.Play(_clickSounds[Random.Range(0, _clickSounds.Length)]);
        StopAllCoroutines();
        StartCoroutine(ClickRoutine());
    }

    IEnumerator ClickRoutine()
    {
        rend.sprite = _clickSprite;
        yield return new WaitForSeconds(.2f);
        rend.sprite = _idleSprite;
    }
}
