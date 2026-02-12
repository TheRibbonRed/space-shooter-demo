using System;
using UnityEngine;
using Random = System.Random;

public class EnemyMovement : MonoBehaviour
{
    public float SineCenterX;
    [SerializeField] private float _enemySpeed = 5f;
    [SerializeField] private bool _randomizeMove = true;
    [SerializeField] private MovementType _moveType;
    [SerializeField] private Rigidbody _rigidbody;

    private void Start()
    {
        if (_randomizeMove) _moveType = RandomType(); 
    }

    private void FixedUpdate()
    {
        EnemyMove(_moveType);    
    }

    private void EnemyMove(MovementType type)
    {
        if (transform.position.z < -12 || transform.position.x > 5 || transform.position.x < -5 || transform.position.z > 20)
        {
            if (this.gameObject.activeSelf)
            {
                _rigidbody.linearVelocity = Vector3.zero;
                gameObject.SetActive(false);
            }
            return;
        }
        switch (type)
        {
            case MovementType.Straight:
                transform.Translate(0f, 0f, (_enemySpeed * Time.fixedDeltaTime * -1));
                break;
            case MovementType.SineWave:
                float sin = Mathf.Sin(transform.position.z);
                transform.Translate(0f, SineCenterX + sin, (_enemySpeed * Time.fixedDeltaTime * -1));
                break;
        }
    }

    private MovementType RandomType()
    {
        Array values = Enum.GetValues(typeof(MovementType));
        Random random = new Random();
        return (MovementType)values.GetValue(random.Next(values.Length));
    }
}

public enum MovementType
{
    Straight,
    SineWave
}
