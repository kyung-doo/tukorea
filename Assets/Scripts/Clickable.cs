using UnityEngine;

public class Clickable : MonoBehaviour
{
    private GameObject camera;
    
    private Vector3 mousePos;
    private bool clicked;

    private bool hovered = false;


    public delegate void OnMouseOver( GameObject target, Vector3 mousePos );

    public event OnMouseOver onMouseOver;

    public delegate void OnMouseOut( GameObject target, Vector3 mousePos );

    public event OnMouseOut onMouseOut;

    public delegate void OnMouseClick( GameObject target, Vector3 mousePos );

    public event OnMouseClick onMouseClick;



    private void Awake() {
        camera = GameObject.Find("Camera");
    }

    private void Update()
    {
        clicked = Input.GetMouseButtonDown(0);
		mousePos = Input.mousePosition;
		Ray ray = camera.GetComponent<Camera>().ScreenPointToRay(mousePos);

        if(this.GetComponent<Collider>().bounds.IntersectRay(ray)) 
        {
            if(!hovered) 
            {
                if(onMouseClick == null) return;
                Main.Instance.SetCursor(true);
                if(onMouseOver != null)  onMouseOver(this.gameObject, mousePos);
                hovered = true;
            } 
        }
        else
        {
            if(hovered) 
            {
                Main.Instance.SetCursor(false);
                if(onMouseOut != null) onMouseOut(this.gameObject, mousePos);
                hovered = false;
            }
        }

        if (this.GetComponent<Collider>().bounds.IntersectRay(ray) && clicked)
		{
            if(hovered) 
            {
                Main.Instance.SetCursor(false);
                
                if(onMouseClick != null)
                {
                    Main.Instance.PlayClickAudio();
                    onMouseClick(this.gameObject, mousePos);
                }
                hovered = false;
            }
		}
    }
}
