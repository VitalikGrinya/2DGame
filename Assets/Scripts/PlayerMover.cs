using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private const string Speed = "Speed";

    private Animator _animator;
    private Vector2 _moveInput;
    private Rigidbody2D _rigidbody;
    private bool _isFaceRight = true;
    private bool _isGround = true;
    

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Reflect();
        AnimatePlayer();
        Run();
        Jump();
    }

    private void Run()
    {
        _moveInput.x = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(_moveInput.x * _speed, _rigidbody.velocity.y);
    }

    private void AnimatePlayer()
    {
        _animator.SetFloat(Speed, Mathf.Abs(_moveInput.x));
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround == true)
            _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, _jumpPower));
    }

    private void Reflect()
    {
        if (_moveInput.x > 0 && _isFaceRight == false || _moveInput.x < 0 && _isFaceRight == true)
        {
            Vector2 transformScale = transform.localScale;
            transformScale.x *= -1;
            transform.localScale = transformScale;

            _isFaceRight = !_isFaceRight;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
            _isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
            _isGround = false;
    }
}
