using UnityEngine;

public class Player : MonoBehaviour
{
    private const string Speed = "Speed";
    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private Coin _coin;
    private Animator _animator;
    private Vector2 _moveInput;
    private Rigidbody2D _rigidbody;
    private bool _isFaceRight = true;
    private bool _isGrounded;
    private int _coinCount = 0;

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

    private void OnEnable()
    {
        GroundChecker.IsGrounded += SetGround;
        Coin.TakeCoin += TakeCoin;
    }

    private void OnDisable()
    {
        GroundChecker.IsGrounded -= SetGround;
        Coin.TakeCoin -= TakeCoin;
    }

    private void SetGround(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, _jumpPower));
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

    private void TakeCoin()
    {
        _coinCount++;
        Debug.Log(_coinCount);
    }
}