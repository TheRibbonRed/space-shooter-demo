using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    private bool _isMoving;
    private float _moveSpeed;

    public void SetSpeed(float speed)
    {
        _moveSpeed = speed;
    }
    
    private void Update()
    {
        SetMove();
    }
    
    private void FixedUpdate()
    {
        if (!_isMoving) return;
        Moving();
    }

    private void SetMove()
    {
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) _isMoving = true;
    }

    private void Moving()
    {
        if (!_isMoving) return;
        //Debug.Log("Input Received");
        float frontback = Input.GetAxis("Vertical") * _moveSpeed * Time.fixedDeltaTime;
        float leftright = Input.GetAxis("Horizontal") * _moveSpeed * Time.fixedDeltaTime;
        _playerObject.transform.Translate(leftright, 0f, frontback);
        _playerObject.transform.position = 
            new Vector3 (Mathf.Clamp(_playerObject.transform.position.x, -2.5f, 2.5f), 0f,
            Mathf.Clamp(_playerObject.transform.position.z, 0.5f, 8f));

    }
}
