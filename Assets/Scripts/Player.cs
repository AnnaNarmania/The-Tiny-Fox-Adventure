using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private float runSpeed = 40f;
    [SerializeField] private Animator animator;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulltSpeed = 20f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float nextFire = 0f;
    [SerializeField] private int maxAmmo = 20;
    [SerializeField] private int currentAmmo = 5;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private PauseScreen pauseScreen;
  

    private float horizontalInput;


    bool jump = false;
   

    void Start()
    {
    }

    void Update()
    {
       
        horizontalInput = Input.GetAxisRaw("Horizontal")* runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            SoundManager.Instance.PlayJumpSound();
        }

        if (!pauseScreen.IsPaused 
          && Input.GetButtonDown("Fire1") 
          && Time.time > nextFire 
          && !EventSystem.current.IsPointerOverGameObject())
          {
            nextFire = Time.time + fireRate;
            Shoot();
            }


        
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }


    void FixedUpdate()
    {
        
        controller.Move(horizontalInput*Time.fixedDeltaTime, false, jump);
        jump = false;

    }



    void LateUpdate()
    {
        if (horizontalInput == 1)
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        else if (horizontalInput == -1)
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);

    
    }

    private void Shoot()
{
    if (currentAmmo <= 0)
    {
        Debug.Log("Out of ammo!");
        return;
    }

    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

    
    Vector2 direction;
    if (transform.localScale.x > 0)
    {
        direction = Vector2.right;
    }
    else
    {
        direction = Vector2.left;
    }

    rb.linearVelocity = direction * bulltSpeed;
    currentAmmo--;
    ammoText.text = currentAmmo + "x";
    SoundManager.Instance.PlayShootSound();
    Debug.Log("Ammo left: " + currentAmmo);
}

   private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Ammo"))
    {
        AddAmmo(1);
        Destroy(collision.gameObject);
        SoundManager.Instance.PlayCollectSound();
    }
    else if (collision.CompareTag("FinishHouse"))
    {
        SoundManager.Instance.PlayWinSound();
        SceneManager.LoadScene(2);
    }
    else if (collision.CompareTag("FinishHouseTwo"))
    {
           SoundManager.Instance.PlayWinSound();
          SceneManager.LoadScene(3);

    }
    else if (collision.CompareTag("FinalHouse"))
    {
        SoundManager.Instance.PlayWinSound();
        SceneManager.LoadScene(4);
    }
}

    private void AddAmmo(int ammo)
    {
        currentAmmo += ammo;
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        ammoText.text = currentAmmo + "x";
        Debug.Log("Ammo added. Current ammo: " + currentAmmo);
    }

    
    
}
