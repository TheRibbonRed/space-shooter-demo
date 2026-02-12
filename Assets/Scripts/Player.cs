using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public float PlayerHealth = 100f, PlayerAmmo = 100f, PlayerMoveSpeed = 3f;
    [SerializeField] private AudioSource _damageSfx;
    public UnityEvent<float> SetSpeed, SetInitialAmmo, SetInitialHealth;
    public UnityEvent GameOverEvent;

    private void Awake()
    {
        SetSpeed?.Invoke(PlayerMoveSpeed);
        SetInitialAmmo?.Invoke(PlayerAmmo);
        SetInitialHealth?.Invoke(PlayerHealth);
    }

    public void AdjustHealth(float adjust)
    {
        _damageSfx.Play();
        PlayerHealth -= adjust;
        if (PlayerHealth <= 0)
        {
            PlayerHealth = 0;
            GameOverEvent?.Invoke();
        }
    }

    public void AdjustAmmo(float adjust)
    {
        PlayerAmmo = adjust;
    }

}
