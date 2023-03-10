using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public int isWalkingHash;
    public int isBackwardHash;
    public int isRunningHash;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;


    public GameObject menu;
    public GameObject treasure;

    public GameObject KeyHint;

    public float speed = 10f;

    private bool hasKey1 = false;
    private bool hasKey2 = false;
    private bool hasKey3 = false;

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

        MenuFunction();
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isBackwardHash = Animator.StringToHash("isBackward");
        isRunningHash = Animator.StringToHash("isRunning");

    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject==key1)
        {
            Debug.Log("Key1 collected");
            hasKey1 = true;
            Destroy(key1);
        }
        else if(coll.gameObject==key2)
        {
            Debug.Log("Key2 collected");
            hasKey2 = true;
            Destroy(key2);
        }
        else if(coll.gameObject==key3)
        {
            Debug.Log("Key3 collected");
            hasKey3 = true;
            Destroy(key3);
            KeyHint.SetActive(true);
            StartCoroutine (Wait());
            Debug.Log("hint deactivated");
        }
}
    public void OpenChest()
    {
        if(hasKey1)
        {
            Debug.Log("only Key 1 collected");
            // hasKey1 = false;
        }
        else if(hasKey2)
        {
            Debug.Log("only 2 Keys collected");
            // hasKey2 = false;
        }
        else if(hasKey3)
        {
            Debug.Log("3 Keys collected");
            Destroy(treasure);
            // hasKey3 =  false;
        }
        }

        
        public void Update()
        {
            bool isWalking = animator.GetBool("isWalking");
            bool forwardPressed = Input.GetKey(KeyCode.UpArrow);
            bool isBackward = animator.GetBool("isBackward");
            bool backwardPressed = Input.GetKey(KeyCode.DownArrow);
            bool isRunning = animator.GetBool("isRunning");
            bool runningPressed = Input.GetKey(KeyCode.X);
        //  bool isPause = Input.GetKeyDown(KeyCode.Escape);

        bool chestOpen = Input.GetKey(KeyCode.O); //press letter "O" to open treasure chest
        
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
            transform.Rotate(0.0f, -45.0f, 0.0f);
        }

      
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            transform.Rotate(0.0f, 45.0f, 0.0f);
        }
        
        //if player pressed forward key (or up arrow)
        if(forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if(!forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        //if player pressed backward key (or down arrow)
        if(backwardPressed)
        {
            animator.SetBool(isBackwardHash, true);
        }
        if(!backwardPressed)
        {
            animator.SetBool(isBackwardHash, false);
        }

        //if player pressed the x key 
        if(runningPressed)
        {
            animator.SetBool(isRunningHash, true);
        }
        if(!runningPressed)
        {
            animator.SetBool(isRunningHash, false);
        }

        if(chestOpen)
        {
            OpenChest();
        }
    }
}

