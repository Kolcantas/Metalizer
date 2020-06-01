using Characters;
using UnityEngine;

public class PlayerCharacter : Character
{
    private float movementScaler = 5.0f;
    private Vector3 hitboxOffset = new Vector3(0, -0.3f, 0);

    //[SerializeField] private HealthbarControl healthBar;
    //private float healthInPercentage = 100;

    private void Awake()
    {
        //healthBar = GameObject.Find("Healthbar").GetComponent<HealthbarControl>();
        //figure = FindObjectOfType<Figure>();

        Debug.Log("PlayerCharacter Awake");
    }

    void Start()
    {
        //healthBar.setHealth(100);
        //healthBar.transform.localPosition = new Vector3(-0.5f, -1.5f, 0);
        //Debug.Log(healthBar.transform.localPosition);
    }


    void Update()
    {
        HandleMovement();
        HandleAttack();

        //healthInPercentage -= 0.1f;
        //updateHealthBar(healthBar, healthInPercentage);
    }


    //private void updateHealthBar(HealthbarControl hbCtl, float healthInPercentage)
    //{
    //    hbCtl.setHealth(healthInPercentage);
    //}



    private void HandleMovement()
    {
        Vector3 movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f).normalized;
        properties.moveDirection = movementDirection;

        if (movementDirection == new Vector3(0,0,0))
        {
            properties.isMoving = false;
        }
        else
        {
            Vector3 targetPosition = transform.position + movementDirection * Time.deltaTime * movementScaler;
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position + hitboxOffset, movementDirection, Time.deltaTime * movementScaler);
            if (raycastHit.collider == null)
            {
                transform.position = targetPosition;
                updateAnimationFacing(movementDirection);
                properties.isMoving = true;
            }
            else
            {
                Debug.Log(raycastHit.collider);
                properties.isMoving = false;
            }
        } 
    }


    private void HandleAttack()
    {
        if(Input.GetKey("space"))
        {
            properties.isAttacking = true;
        }
        else
        {
            properties.isAttacking = false;
        }
    }
}
