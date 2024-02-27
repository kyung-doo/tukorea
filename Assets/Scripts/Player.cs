using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    public float movementSpeed = 10f;

    [SerializeField]
    public float freeLookSensitivity = 3f;

    [SerializeField]
    public float pannigSpeed = 150f;

    [SerializeField]
    public Vector3 minPosition = new Vector3(-10f, 0f, -10f);

    [SerializeField]
    public Vector3 maxPosition = new Vector3(10f, 5f, 10f);

    [SerializeField]
    public Transform cam;

    [SerializeField]
    public bool isActive = false;

    private bool looking = false;

    private bool pannig = false;
    
    private bool zooming = false;

    private Vector3 prevPos;
    
    
    

    private void Update()
    {
        if(!isActive) return;
        
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

        if(Input.GetAxis("Mouse ScrollWheel") > 0f) 
        {
            zooming = true;
            this.transform.position = this.transform.position + (cam.transform.forward * movementSpeed * 5f * Time.deltaTime);
        } 

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            zooming = true;
            this.transform.position = this.transform.position - (cam.transform.forward * movementSpeed * 5f * Time.deltaTime);
        }

        if (looking)
        {
            float newRotationX = this.transform.localEulerAngles.y - Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = cam.transform.localEulerAngles.x + Input.GetAxis("Mouse Y") * freeLookSensitivity;
            this.transform.localEulerAngles = new Vector3(0f, newRotationX, 0f);
            cam.transform.localEulerAngles = new Vector3(newRotationY, 0f, 0f);
        }

        if(pannig) {
            this.transform.position = this.transform.position + (-this.transform.right * Input.GetAxis("Mouse X") * pannigSpeed * Time.deltaTime);
            this.transform.position = this.transform.position + (-this.transform.up * Input.GetAxis("Mouse Y") * pannigSpeed * Time.deltaTime);
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

    private void LateUpdate() 
    {    
        Vector3 targetPos = this.transform.position;
        if(zooming) targetPos = prevPos;
        if(this.transform.position.x > maxPosition.x)
        {
            this.transform.position = new Vector3(maxPosition.x, targetPos.y, targetPos.z);
        }
        if(this.transform.position.x < minPosition.x)
        {
            this.transform.position = new Vector3(minPosition.x, targetPos.y, targetPos.z);
        }

        if(this.transform.position.y > maxPosition.y)
        {
            this.transform.position = new Vector3(targetPos.x, maxPosition.y, targetPos.z);
        }
        if(this.transform.position.y < minPosition.y)
        {
            this.transform.position = new Vector3(targetPos.x, minPosition.y, targetPos.z);
        }

        if(this.transform.position.z > maxPosition.z)
        {
            this.transform.position = new Vector3(targetPos.x, targetPos.y, maxPosition.z);
        }
        if(this.transform.position.z < minPosition.z)
        {
            this.transform.position = new Vector3(targetPos.x, targetPos.y, minPosition.z);
        }
        zooming = false;
        prevPos = this.transform.position;
    }
}
