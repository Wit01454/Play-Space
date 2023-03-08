using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed = 5f; // ความเร็วในการเคลื่อนที่
    public float jumpForce = 10f; // แรงกระโดด
    public float gravity = 20f; // แรงโน้มถ่วง
    public float turnSpeed = 360;

    public float rotationspeed = 0.5f;

    private Vector3 moveDirection = Vector3.zero; // เคลื่อนที่ตามแกน x,y,z ของโลก (global axis)
    private Rigidbody rigidbody; // ควบคุมการเคลื่อนที่ของตัวละคร

    float horizontalMovement;
    float verticalMovement;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true; // ล็อคการหมุนของ rigidbody
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
        { // ตรวจสอบว่าผู้เล่นกดปุ่มกระโดดหรือไม่
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // กำหนดแรงกระโดด
        }

        moveDirection.y -= gravity * Time.deltaTime; // เพิ่มแรงโน้มถ่วงให้ตกต่ำลง
    }

    private void Move()
    {
        // เคลื่อนที่ตามแกน x,y,z ของโลก (global axis)
        horizontalMovement = Input.GetAxis("Horizontal"); // เคลื่อนที่ซ้าย-ขวา
        verticalMovement = Input.GetAxis("Vertical"); // เคลื่อนที่ขึ้น-ลง
        
        moveDirection = new Vector3(horizontalMovement, 0f, verticalMovement); // กำหนดเคลื่อนที่ตามแกน x,z

        rigidbody.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime); // เคลื่อนที่ตัวละคร
    }
}
