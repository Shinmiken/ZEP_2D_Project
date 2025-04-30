using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
     private Rigidbody2D _rigidbody;
     private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private Vector2 moveVec;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        //// ���� �ش�
        //_rigidbody.AddForce(Vec);

        ////�ӵ��� �����Ѵ�.
        //_rigidbody.velocity = Vector3;

        ////��ġ �̵�
        //_rigidbody.MovePosition(_rigidbody.position + Vec);

    }

    // Update is called once per frame
    void Update()
    {
        moveVec.x = Input.GetAxisRaw("Horizontal");
        moveVec.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 myMove = moveVec.normalized * playerSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + myMove);
    }

    private void LateUpdate()
    {
        _animator.SetFloat("isRun", moveVec.magnitude);
        if (moveVec.x != 0)
        {
            _spriteRenderer.flipX = moveVec.x < 0;
        }
    }
}
