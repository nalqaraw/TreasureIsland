using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
 
    /**  Public Declarations   **/
    /**  Enemy Characteristics Declarations**/
    public Transform myTransform; //Enemy Transform
    public Animator enemyAnimator; //enemy animator
    public int enemyHealth; //enemy health
    public int damage = 1;


    /**  Enemy Movement Declarations   **/
    float moveSpeed = 0.5f;
    float rotationSpeed = 3f;
    float stop = 0;

    /**  Enemy Attack Declarations   **/
    float range = 30f; //range to attack pirate
    public float enemyCooldown = 1;

    /**  Combat Declaration  **/
    //Combat Animator Declarations
    public int isRunHash;//run
    public int isAttackHash;//punch
    //Combat Boolean Declarations
    public bool run = false;
    public bool attack = false;

    //pirate transform
    public Transform Pirate;


    //setting the time shield powerup remains active
    public float protectTime = 10f; 

    
    /**  Private Declarations **/
    private bool playerInRange = false;
    private bool canAttack = true;

     /**  End of Declarations  **/

    void Awake()
    {

        Pirate = GameObject.FindWithTag("Pirate").transform;//target player1
        myTransform = transform; //cache transform data for easy access
    }

    void Start()
    {
        //initializing the enemy health to 10
        enemyHealth = 10;

    }

    public void EnemyAttack()
    {
        bool isAttack = enemyAnimator.GetBool("isAttack");
        
        //if enemy is in attack mode
        if(isAttack)
        {
            enemyAnimator.SetBool(isAttackHash, true);
            attack = true;
        }
        if(!isAttack)
        {
            enemyAnimator.SetBool(isAttackHash, false);
            attack = false;
        }
    }

    public void EnemyRun()
    {
        bool isRun = enemyAnimator.GetBool("isRun");
        
        //if enemy is in attack mode
        if(isRun)
        {
            enemyAnimator.SetBool(isRunHash, true);
            run = true;
        }
        if(!isRun)
        {
            enemyAnimator.SetBool(isRunHash, false);
            run = false;
        }
    }


    void Update()
    {
        /**  Enemy Looking For and Moving Towards Pirate  **/
        //distance b/w Pirate and Enemy
        float distance = Vector3.Distance(myTransform.position, Pirate.position);

        //if distance is less than the allowed attackable range
        if(distance<=range)
        {
            //Look: keep searching for the Pirate
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(Pirate.position-myTransform.position), rotationSpeed*Time.deltaTime);

            //Move: if the distance is greater than the stop distance then keep moving
            if(distance>stop)
            {
                myTransform.position+= myTransform.forward * moveSpeed * Time.deltaTime;
                EnemyRun();
            }
        }

    /**  Check for Shield PowerUp Protection **/
    // if(GameObject.Find("Pirate").GetComponent<PlayerController>().protect == true){
    //     StartCoroutine(MyCoroutine());
    // }

        //else, if pirate is in the allowed attackable range & enemy can attack
        else if (playerInRange && canAttack)
        {
            //check if  pirate is protected by shield powerup
            // if(GameObject.Find("Pirate").GetComponent<PlayerController>().protect == false){
                EnemyAttack();
                GameObject.Find("Pirate").GetComponent<PlayerController>().health -= damage;
                StartCoroutine(AttackCooldown());
                if(GameObject.Find("Pirate").GetComponent<PlayerController>().health == 0)
                {
                 Invoke("Restart", 2); //restart the scene when the Pirate's health is zero
                }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
         if(coll.gameObject.CompareTag("Pirate"))
          {
             playerInRange = true;
         
            if(GameObject.Find("Pirate").GetComponent<PlayerController>().fight == true)
            {
            if(enemyHealth > 0)
            {
                enemyHealth -= damage;
                
            }
            if(enemyHealth <= 0)
            {
                Destroy(gameObject); 
                GameObject.Find("Pirate").GetComponent<PlayerController>().keyprogress += 1 ;
            }
            }
          }

        
        if(coll.gameObject.CompareTag("Sword") && (GameObject.Find("Pirate").GetComponent<PlayerController>().swing == true))
            {
            if(enemyHealth > 0)
            {
                enemyHealth -= damage;
            }
            if(enemyHealth <= 0)
            {
                Destroy(gameObject);
                GameObject.Find("Pirate").GetComponent<PlayerController>().keyprogress += 1 ;
            }
            }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.CompareTag("Pirate"))
        {
            playerInRange = false;
        }
    }

    IEnumerator AttackCooldown()
     {
        canAttack = false;
        yield return new WaitForSeconds(enemyCooldown);
        canAttack = true;
     }

    /** Shield Powerup CoRoutine**/
    // IEnumerator MyCoroutine()
    // {
    //     // GameObject.Find("Pirate").GetComponent<PlayerController>().protect = true; 
    //     // yield return new WaitForSeconds(10f); //wait 10 seconds
    //     // GameObject.Find("Pirate").GetComponent<PlayerController>().protect = false;
    // }
   

    public void Restart()
    {
        SceneManager.LoadScene("GameMode");
    }

}
