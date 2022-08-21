using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 jumpForce;
    public Vector2 jumpForceUp;
    public float minForceX;
    public float maxForceX;
    public float minForceY;
    public float maxForceY;

    [HideInInspector]
    public int lastPlatformId;
    bool m_Jumped;
    bool m_powerSetted;

    Rigidbody2D m_rb;
    Animator m_anim;

    float m_curPowerBarVal = 0;

    public bool Jumped { get => m_Jumped; set => m_Jumped = value; }
    public float CurPowerBarVal { get => m_curPowerBarVal; set => m_curPowerBarVal = value; }
    public Animator Anim { get => m_anim; set => m_anim = value; }
    public Rigidbody2D Rb { get => m_rb; set => m_rb = value; }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }
    private void Start()
    {
 
    }
    private void Update()
    {
        if (GameManager.Ins.IsGameStarted)
        {
            SetPower();
            if (Input.GetMouseButtonDown(0))
            {
                SetPower(true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                SetPower(false);

            }
        }

    }
    void SetPower()
    {
        if (m_powerSetted && !Jumped)
        {
            jumpForce.x += jumpForceUp.x * Time.deltaTime;
            jumpForce.y += jumpForceUp.y * Time.deltaTime;

            jumpForce.x = Mathf.Clamp(jumpForce.x, minForceX, maxForceX);
            jumpForce.y = Mathf.Clamp(jumpForce.y, minForceY, maxForceY);

            CurPowerBarVal += GameManager.Ins.powerBarUp *Time.deltaTime;

            GameGUIManager.Ins.UpdatePowerBar(CurPowerBarVal, 1);
        }
    }

    public void SetPower(bool isHoldingMouse)
    {
        m_powerSetted = isHoldingMouse;

        if (!m_powerSetted && !Jumped)
        {
            Jump();
        }
    }

    void Jump()
    {
        AudioController.Ins.PlaySound(AudioController.Ins.jump);
        if (!Rb || jumpForce.x <= 0 || jumpForce.y <= 0)
        {
            return;
        }
        Rb.velocity = jumpForce;
        Jumped = true;

        if (Anim)
        {
            Anim.SetBool("Jumped", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(TagsConsts.DEAD_ZONE))
        {
            GameGUIManager.Ins.ShowGameOverDialog();
            AudioController.Ins.PlaySound(AudioController.Ins.gameover);
            Destroy(gameObject);
        }
    }
}
