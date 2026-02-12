using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBullet : MonoBehaviour
{
    public float FireVelocity = 2f, CountGone = 3f;
    public bool IsFired;
    public Transform MinLimit, MaxLimit;
    [SerializeField] private Rigidbody _bulletRb;
    [SerializeField] private UnityEvent _returnBulletEvent;
    [SerializeField] private AudioSource _fireSfx;
    private bool _isCounting;

    //check for collision with tag
    //execute method to destroy enemy when collided
    //add delay until despawn & reload to Player Ammo

    public void FireBullet(Transform fireorigin)
    {
        StopBulletMovement();
        transform.position = fireorigin.position;
        transform.rotation = fireorigin.rotation;
        _bulletRb.linearVelocity = new Vector3 (0, 0, FireVelocity);
        IsFired = true;
        _isCounting = true;
        FireSound();
        StartCoroutine(GoneCountDown());
    }

    private IEnumerator GoneCountDown()
    {
        yield return new WaitForSeconds(CountGone);
        ReturnBullet();
    }

    private void ReturnBullet()
    {
        StopBulletMovement();
        FireSound();
        _returnBulletEvent?.Invoke();
        this.gameObject.SetActive(false);
        StopAllCoroutines();
    }

    private void StopBulletMovement()
    {
        _bulletRb.linearVelocity = Vector3.zero;
        _bulletRb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!IsFired || !_isCounting) return;
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log($"Bullet hit {collision.gameObject.name}");
            ReturnBullet();
        }
    }

    private void FireSound()
    {
        if (IsFired)
            _fireSfx.Play();
        else
            _fireSfx.Stop();
    }
}
