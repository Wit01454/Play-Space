using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed = 5f; // ��������㹡������͹���
    public float jumpForce = 10f; // �ç���ⴴ
    public float gravity = 20f; // �ç�����ǧ
    public float turnSpeed = 360;

    public float rotationspeed = 0.5f;

    private Vector3 moveDirection = Vector3.zero; // ����͹�����᡹ x,y,z �ͧ�š (global axis)
    private Rigidbody rigidbody; // �Ǻ����������͹���ͧ����Ф�

    float horizontalMovement;
    float verticalMovement;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true; // ��ͤ�����ع�ͧ rigidbody
    }

    void Update()
    {
        Look();
        jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Look()
    {
        if (moveDirection != Vector3.zero)
        {
            var relative = (transform.position + moveDirection) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
        
    }

    private void jump()
    {
        if (Input.GetButtonDown("Jump"))
        { // ��Ǩ�ͺ��Ҽ����蹡��������ⴴ�������
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // ��˹��ç���ⴴ
        }

        moveDirection.y -= gravity * Time.deltaTime; // �����ç�����ǧ��鵡���ŧ
    }

    private void Move()
    {
        // ����͹�����᡹ x,y,z �ͧ�š (global axis)
        horizontalMovement = Input.GetAxis("Horizontal"); // ����͹������-���
        verticalMovement = Input.GetAxis("Vertical"); // ����͹�����-ŧ
        
        moveDirection = new Vector3(horizontalMovement, 0f, verticalMovement); // ��˹�����͹�����᡹ x,z

        rigidbody.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime); // ����͹������Ф�
    }
}
