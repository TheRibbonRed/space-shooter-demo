using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private List<PlayerBullet> _playerBullets;
    [SerializeField] private float _fireCooldownSeconds = 0.2f;
    [SerializeField] private UnityEvent _bulletFireEvent;
    private bool _justFired;

    // Update is called once per frame
    private void Update()
    {
        if (Time.timeScale == 0f || !Input.GetButtonDown("Fire1") || _justFired) return;
        FireBullet();
    }

    public void FireBullet()
    {
        foreach (var bullet in _playerBullets) 
            if (!bullet.gameObject.activeSelf)
            {
                //fires bullet and starts method that counts down _countGone or check transform position min max
                Debug.Log("Bullet fired");
                bullet.gameObject.SetActive(true);
                bullet.FireBullet(this.transform);
                _bulletFireEvent?.Invoke();
                /*_justFired = true;
                StartCoroutine(FireRate());*/
                return;
            }
    }

    private IEnumerator FireRate()
    {
        yield return new WaitForSeconds(_fireCooldownSeconds);
        _justFired = false;
        StopCoroutine(FireRate());
    }
}
