using UnityEngine;

namespace Characters
{

    public class PlayerCharacter : Character
    {
        //[SerializeField] private HealthbarControl healthBar;
        //private float healthInPercentage = 100;

        private void Awake()
        {
            //healthBar = GameObject.Find("Healthbar").GetComponent<HealthbarControl>();
            //figure = FindObjectOfType<Figure>();
            setDefaultCharacterProperties();
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
            HandleAttack();

            //healthInPercentage -= 0.1f;
            //updateHealthBar(healthBar, healthInPercentage);
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }


        //private void updateHealthBar(HealthbarControl hbCtl, float healthInPercentage)
        //{
        //    hbCtl.setHealth(healthInPercentage);
        //}



        private void HandleMovement()
        {
            Vector3 movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f).normalized;

            TryToMove(movementDirection * Time.deltaTime * movementScaler);
        }


        private void HandleAttack()
        {
            if (Input.GetKey("space"))
            {
                properties.isAttacking = true;
            }
            else
            {
                properties.isAttacking = false;
            }
        }
    }

}
