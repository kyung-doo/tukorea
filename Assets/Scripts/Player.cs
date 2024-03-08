using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField]
    public float movementSpeed = 10f;

    [SerializeField]
    public float freeLookSensitivity = 3f;

    [SerializeField]
    public float pannigSpeed = 150f;

    [SerializeField]
    public Transform cam;

    [SerializeField]
    public GameObject optionView;

    [SerializeField]
    public bool isActive = false;

    private bool looking = false;

    private bool pannig = false;
    
    private bool zooming = false;

    private Vector3 prevPos;

    private float mouseWheel = 0f;
    
    
    
    private void FixedUpdate()
    {
        if(!isActive) return;
        if(optionView.GetComponent<CanvasGroup>().interactable) return;
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position = this.transform.position + (-this.transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position = this.transform.position + (this.transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position = this.transform.position + (this.transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position = this.transform.position + (-this.transform.forward * movementSpeed * Time.deltaTime);
        }
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if(mouseWheel > 0f) 
        {
            zooming = true;
            Vector3 movePos = this.transform.position + (cam.transform.forward * movementSpeed * 2.5f * Time.deltaTime);
            if(!CheckHit(movePos)) this.transform.position = movePos;
        } 

        if(mouseWheel < 0f)
        {
            zooming = true;
            Vector3 movePos = this.transform.position - (cam.transform.forward * movementSpeed * 2.5f * Time.deltaTime);
            if(!CheckHit(movePos)) this.transform.position = movePos;
        }

        mouseWheel = 0f;

    }
    
    

    private void Update()
    {
        if(!isActive) return;
        if(optionView.GetComponent<CanvasGroup>().interactable) return;


        if (looking)
        {
            float newRotationX = this.transform.localEulerAngles.y - Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = cam.transform.localEulerAngles.x + Input.GetAxis("Mouse Y") * freeLookSensitivity;
            this.transform.localEulerAngles = new Vector3(0f, newRotationX, 0f);
            cam.transform.localEulerAngles = new Vector3(newRotationY, 0f, 0f);
        }

        if(pannig) 
        {
            float speed = pannigSpeed;
            if(PlayerPrefs.GetInt("quality") == 1) 
            {
                speed = pannigSpeed * 1.1f;
            } 
            else if(PlayerPrefs.GetInt("quality") == 0)
            {
                speed = pannigSpeed * 30;
            }
#if UNITY_EDITOR
            speed = pannigSpeed *5f;
#endif            
            if(Math.Abs(Input.GetAxis("Mouse X")) > Math.Abs(Input.GetAxis("Mouse Y"))) 
            {
                Vector3 moveX = this.transform.position + (-this.transform.right * Input.GetAxis("Mouse X") * speed * Time.deltaTime);
                if(!CheckHit(moveX)) this.transform.position = moveX;
            }
            if(Math.Abs(Input.GetAxis("Mouse Y")) > Math.Abs(Input.GetAxis("Mouse X"))) 
            {
                Vector3 moveY = this.transform.position + (-this.transform.up * Input.GetAxis("Mouse Y") * speed * Time.deltaTime);
                if(!CheckHit(moveY)) this.transform.position = moveY;
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0f) 
        {
            mouseWheel = 1f;
        } 

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            mouseWheel = -1f;
        }
        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            looking = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            looking = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            pannig = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            pannig = false;
        }
    }

    private bool CheckHit ( Vector3 targetPos )
    {
        // Debug.DrawRay(this.transform.position, (targetPos - this.transform.position) * 10f, Color.red);
        if (Physics.Raycast(this.transform.position, (targetPos - this.transform.position), out RaycastHit hit, 0.35f))
        {
            if (hit.collider)   
            {
                return true;
            }
        }
        return false;
    }

    private void LateUpdate() 
    {    
        Vector3 targetPos = this.transform.position;
        if(zooming) targetPos = prevPos;


        if(this.transform.position.y > 2f)
        {
            this.transform.position = new Vector3(targetPos.x, 2f, targetPos.z);
        }
        if(this.transform.position.y < 0f)
        {
            this.transform.position = new Vector3(targetPos.x, 0f, targetPos.z);
        }

        zooming = false;
        prevPos = this.transform.position;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
