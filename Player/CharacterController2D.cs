using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;
    [SerializeField] private float m_DubbleJumpForce = 400f;
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private bool m_AirControl = false;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck; 
    [SerializeField] private Transform m_CeilingCheck;
    [SerializeField] private Collider2D m_CrouchDisableCollider;               

    const float k_GroundedRadius = .2f; 
    private bool m_Grounded;            
    const float k_CeilingRadius = .2f; 
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  
    private Vector3 m_Velocity = Vector3.zero;


    public GameObject bulletRight, bulletLeft;
    public GameObject SuperBulletRight, SuperBulletLeft;
    // Vector2 bulletPos;
    public Transform shotPoint;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    private Mana mana;
    public bool canDuoubbleJump;

    public AudioClip MusicClip_laserShoot;
    public AudioSource MusicSource_laserShoot;

    public AudioClip MusicClip_superLaserShoot;
    public AudioSource MusicSource_superLaserShoot;





    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;


    void Start()
    {
        MusicSource_laserShoot.clip = MusicClip_laserShoot;
        MusicSource_superLaserShoot.clip = MusicClip_superLaserShoot;
    }

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }


    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;
        mana = GetComponent<Mana>();

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }


        if (Input.GetButtonDown("SpecialAttack1") && mana.updatedMana >= 25)
        {
            SuperAttack();
            mana.UseMana();
        }

        /*
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if (hitInfo.collider != null)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                isClimbing = true;
            }
        }
        if (isClimbing == true)
        {
            verticalMove = Input.GetAxisRaw("Vertical") * speedClimbing;
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.position.x, verticalMove);
            m_Rigidbody2D.gravityScale = 0;
        }
        */
    }


    public void Move(float move, bool crouch, bool jump)
    {
        // If crouching, check to see if the character can stand up
        if (!crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {

            // If crouching
            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                // Reduce the speed by the crouchSpeed multiplier
                move *= m_CrouchSpeed;

                // Disable one of the colliders when crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else
            {
                // Enable the collider when not crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }


            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }
        }
        if (jump)
        {

            if (m_Grounded)
            {
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                canDuoubbleJump = true;
            }
            else
            {
                if (canDuoubbleJump)
                {
                    canDuoubbleJump = false;
                    //m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0);
                    m_Rigidbody2D.AddForce(new Vector2(0f, m_DubbleJumpForce));
                }
            }

        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Fire()
    {
        //bulletPos = transform.position;
        MusicSource_laserShoot.Play();

        if (m_FacingRight)
        {
            //bulletPos += new Vector2(+1f, -0.43f);
            // Instantiate(bulletRight, bulletPos, Quaternion.identity);
            Instantiate(bulletRight, shotPoint.position, transform.rotation);
        }
        else
        {
            //bulletPos += new Vector2(-1f, -0.43f);
            //Instantiate(bulletLeft, bulletPos, Quaternion.identity);
            Instantiate(bulletLeft, shotPoint.position, transform.rotation);
        }

    }


    void SuperAttack()
    {
        MusicSource_superLaserShoot.Play();
        if (m_FacingRight)
        {
            Instantiate(SuperBulletRight, shotPoint.position, transform.rotation);
        }
        else
        {
            Instantiate(SuperBulletLeft, shotPoint.position, transform.rotation);
        }
    }

   
    /*
    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {

        float timer = 0;

        while (knockDur > timer)
        {

            timer += Time.deltaTime;

            m_Rigidbody2D.velocity = new Vector2(0, 0);
            m_Rigidbody2D.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));

        }

        yield return 0;

    }
    */
}
