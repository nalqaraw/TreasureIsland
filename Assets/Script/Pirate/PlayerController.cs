using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    /**  Public Declarations**/
    /**  Pirate Characteristics Declarations**/
    public Animator animator;
    public float speed = 10f;
    public int damage = 3;

    /**  Health Declarations**/
    public float health;

    /**   Key Declarations  **/
    //Public Key GOs Pickups
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    //public variable for keeping track key progress
    public int keyprogress;
    //public variable GO for displaying the hint to find the key
    public GameObject KeyHint;
    //public variable GO for containing the hint text to find the key
    // public GameObject keyText;

    public GameObject treasure;

    /**  Pickups Declarations **/
    // public GameObject Shield; //protective shield pickup

    /**  Combat Declaration  **/
    //Combat Animator Declarations
    public int isSwingingHash; //swing sword
    public int isFightingHash;//punch
    //Combat Boolean Declarations
    public bool fight = false;
    public bool swing = false;
    public bool jump = false;

    // public bool protect = false; //for shield pickup

    /**  Public UI GameObject Declarations **/
    public GameObject menu;

    /**  Private Declarations **/
    //Private Key Boolean Declarations
    private bool hasKey1 = false;
    private bool hasKey2 = false;
    private bool hasKey3 = false;

    /**  End of Declarations  **/

    public void MenuFunction()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Menu is open");
    }


    IEnumerator Wait()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(10);
        KeyHint.SetActive(false);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void Start()
    {   
        /**  Initializing Variables **/
        /**  Health **/
        health = 100;
        /** Keys **/
        keyprogress = 0;

        MenuFunction();

        //Animator for combat animation
        animator = GetComponent<Animator>();
        // isSwingingHash = Animator.StringToHash("isSwinging");
        // isFightingHash = Animator.StringToHash("isFighting");
        // isJumpingHash = Animator.StringToHash("is");
    }
    
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject==key1)
        {
            Debug.Log("Key1 collected");
            hasKey1 = true;
            keyprogress+=1;
            Destroy(key1);
        }
        else if(coll.gameObject==key2)
        {
            Debug.Log("Key2 collected");
            hasKey2 = true;
            keyprogress+=1;
            Destroy(key2);
        }
        else if(coll.gameObject==key3)
        {
            Debug.Log("Key3 collected");
            hasKey3 = true;
            keyprogress+=1;
            Destroy(key3);
            KeyHint.SetActive(true);
            StartCoroutine (Wait());
            Debug.Log("hint deactivated");
        }
    }
//         if(coll.gameObject.CompareTag("shield"))
//         {
//             protect = true;
//             Destroy(coll.gameObject);
//         }
// }
    public void OpenChest()
    {
        if(hasKey1 && (keyprogress == 1))
        {
            Debug.Log("only Key 1 collected");
        }
        else if(hasKey2 && (keyprogress == 2))
        {
            Debug.Log("only 2 Keys collected");
            // hasKey2 = false;
        }
        else if(hasKey3 && (keyprogress == 3))
        {
            Debug.Log("3 Keys collected");
            Destroy(treasure);
            // hasKey3 =  false;
        }
        }

        
        public void Update()
        {
            /** Walking Forward **/
            bool isWalking = animator.GetBool("isWalking");
            bool forwardPressed = Input.GetKey(KeyCode.UpArrow);

            /** Walking Backward **/
            bool isBackward = animator.GetBool("isBackward");
            bool backwardPressed = Input.GetKey(KeyCode.DownArrow);

            /** Running **/
            bool isRunning = animator.GetBool("isRunning");
            bool runningPressed = Input.GetKey(KeyCode.X);

            /** Jumping **/
            bool isJumping = animator.GetBool("isJumping");
            bool jumpingPressed = Input.GetKey(KeyCode.Space);

            bool isFighting = animator.GetBool("isFighting");
            bool fightingPressed = Input.GetKey(KeyCode.Q); //press Q to punch

            bool isSwinging = animator.GetBool("isSwinging");
            bool swingingPressed = Input.GetKey(KeyCode.S); // press S to swing with the sword


        // healthBar.SetHealth(currentHealth); 

        bool chestOpen = Input.GetKey(KeyCode.O); //press letter "O" to open treasure chest

        // Debug.Log(animator.GetBool("isWalking"));
        
        transform.position += transform.forward * speed * Time.deltaTime;
 
        // if (isPause)
        // {
        //      Debug.Log("Escape key was pressed"); 
        // }
        //  if(Input.GetKeyDown(KeyCode.Escape))
        // {
        //     Debug.Log("Escape key was pressed");
        // }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            transform.Rotate(0.0f, -20.0f, 0.0f);
        }

      
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            transform.Rotate(0.0f, 20.0f, 0.0f);
        }
        
        //if player pressed forward key (or up arrow)
        if(forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }
        if(!forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }

        //if player pressed backward key (or down arrow)
        if(backwardPressed)
        {
            animator.SetBool("isBackward", true);
        }
        if(!backwardPressed)
        {
            animator.SetBool("isBackward", false);
        }

        //if player pressed the x key 
        if(runningPressed)
        {
            animator.SetBool("isRunning", true);
        }
        if(!runningPressed)
        {
            animator.SetBool("isRunning", false);
        }

        if(jumpingPressed)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        //if player pressed Q key 
        if(fightingPressed)
        {
            animator.SetBool("isFighting", true);
            fight = true;
        }
        if(!fightingPressed)
        {
            animator.SetBool("isFighting", false);
            fight = false;
        }

        //if player pressed S key 
        if(swingingPressed)
        {
            animator.SetBool("isSwinging", true);
            swing = true;
        }
        if(!swingingPressed)
        {
            animator.SetBool("isSwinging", false);
            swing = false;
        }

        if(chestOpen)
        {
            OpenChest();
        }
    }
    
}

