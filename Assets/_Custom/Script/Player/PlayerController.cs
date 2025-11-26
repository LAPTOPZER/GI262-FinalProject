using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    //Move
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastMoveDir = Vector2.down;
    private Animator animator;
    private SpriteRenderer sr;

    //Stat
    public int hp = 100;
    public int maxHp = 100;
    private bool isDied = false;

    //UI
    [SerializeField]private TMP_Text hpText;
    [SerializeField] private GameObject loseUI;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        SetHp(hp);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = moveInput.normalized;

        bool isMoving = moveInput.sqrMagnitude > 0.01f;

        if (isMoving)
        {
            lastMoveDir = moveInput;
        }

        animator.SetBool("isMoving", isMoving);
        if (isMoving)
        {
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);
        }
        else
        {
            animator.SetFloat("MoveX", lastMoveDir.x);
            animator.SetFloat("MoveY", lastMoveDir.y);
        }

        if (lastMoveDir.x > 0.01f) sr.flipX = false;
        if (lastMoveDir.x < -0.01f) sr.flipX = true;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 0) hp = 0;

        SetHp(hp);

        if (hp <= 0)
        {
            isDied = true;
            loseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void SetHp(int value)
    {
        hp = value;

        if (hpText != null)
            hpText.text = $": {hp}";
    }
    public void Heal(int amount)
    {
        if (hp <= 0) return;

        hp += amount;
        if (hp > maxHp) hp = maxHp;

        SetHp(hp);
    }

}
