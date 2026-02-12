using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public EnemyMovement MovementLogic;
    [SerializeField] private float _damagePlayerValue = 35f;
    [SerializeField] private UnityEvent<int> _enemyKillGainEvent;
    [SerializeField] private UnityEvent<float> _damagePlayerEvent;
    [SerializeField] private AudioSource _enemySfx;
    [SerializeField] private AudioClip[] _sfxClips;

    public void KillSelf()
    {
        if (!this.gameObject.activeSelf) return;
        gameObject.SetActive(false);
        _enemyKillGainEvent?.Invoke(1);
        Debug.Log($"Enemy Killed!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                _damagePlayerEvent?.Invoke(_damagePlayerValue);
                Debug.Log($"Damaged Player by {_damagePlayerValue}");
                KillSelf();
                break;
            case "Player Bullet":
                _enemySfx.clip = _sfxClips[0];
                _enemySfx.Play();
                KillSelf();
                break;

        }
    }
}
