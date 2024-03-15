using System.Collections;
using UnityEngine;
using DG.Tweening;
using EPOOutline;

public class Section3_1 : SectionBase
{

    [SerializeField]
    public AudioClip[] audioClips;

    [SerializeField]
    public Animator animator;

    [SerializeField]
    public GameObject door;

    [SerializeField]
    public GameObject panel;

    [SerializeField]
    public GameObject screen;

    [SerializeField]
    public GameObject touch1;


    private Vector3 zoomPlayerPos = new Vector3(-2.06505466f, 0.2282888f, 4.67137241f);
    private Vector3 zoomPlayerRo = new Vector3(0f, -89.8f, 0f);
    private Vector3 zoomCameraRo = new Vector3(0.35f, 0f, 0f);


    private IEnumerator coTimer = null;
    
    private bool isZoom = false;
    


    public override void StartSection ( bool isFirst = false ) 
    {
        Debug.Log("startSection2");
        door.GetComponent<BoxCollider>().enabled = false;
        panel.GetComponent<BoxCollider>().enabled = false;
        touch1.SetActive(false);
        coTimer = Start1();
        StartCoroutine(coTimer);
        
        base.StartSection(isFirst);
    }

    private IEnumerator Start1() 
    {
        yield return new WaitForSeconds( 3.5f );
        Main.Instance.PlayAudio(audioClips[0], () => {
            Main.Instance.PlayAudio(audioClips[1], () => {
                animator.Play("handle_outline_on");
                door.GetComponent<BoxCollider>().enabled = true;
                door.GetComponent<Clickable>().onMouseClick += ClickDoor;
            });
        });
        player.GetComponent<Player>().isActive = true;
    }

    private void ClickDoor ( GameObject target, Vector3 mousePos ) 
    {
        door.GetComponent<BoxCollider>().enabled = false;
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor;
        animator.Play("handle_open");
        coTimer = Start2();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start2() 
    {
        yield return new WaitForSeconds(2f );
        Main.Instance.PlayAudio(audioClips[2], () => {
            animator.Play("pannel_appear");
            coTimer = Start3();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds(2f );
        Main.Instance.PlayAudio(audioClips[3], () => {
            animator.Play("pannel_outline_on");
            panel.GetComponent<BoxCollider>().enabled = true;
            panel.GetComponent<Clickable>().onMouseClick += ClickPanel;
        });
    }

    private void ClickPanel ( GameObject target, Vector3 mousePos ) 
    {
        panel.GetComponent<BoxCollider>().enabled = false;
        panel.GetComponent<Clickable>().onMouseClick -= ClickPanel;
        animator.Play("pannel_move");
        coTimer = Start4();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start4() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[4], () => {
            animator.Play("handle_outline_on2");
            door.GetComponent<BoxCollider>().enabled = true;
            door.GetComponent<Clickable>().onMouseClick += ClickDoor2;
        });
    }

    private void ClickDoor2 ( GameObject target, Vector3 mousePos ) 
    {
        door.GetComponent<BoxCollider>().enabled = false;
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor2;
        animator.Play("handle_close");
        coTimer = Start5();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start5() 
    {
        yield return new WaitForSeconds( 3f );
        isZoom = true;
        player.GetComponent<Player>().isActive = false;
        player.transform.DOLocalMove(zoomPlayerPos, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(zoomPlayerRo, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(zoomCameraRo, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            player.GetComponent<Player>().isActive = true;
            Main.Instance.repositionBtn.SetActive(true);
            Main.Instance.PlayAudio(audioClips[5], () => {
                touch1.SetActive(true);
                touch1.GetComponent<Animator>().Play("touch");
                touch1.GetComponent<Clickable>().onMouseClick += ClickTouch1;
            });
        });
    }

    private void ClickTouch1 ( GameObject target, Vector3 mousePos ) 
    {
        touch1.SetActive(false);
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        touch1.GetComponent<Animator>().Rebind();
        coTimer = Start6();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start6() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[6], () => {
            coTimer = Ended();
            StartCoroutine(coTimer);
        });
    }
    

    private IEnumerator Ended() 
    {
        yield return new WaitForSeconds( 3.0f );
        this.EndSection();
    }

    public override void RepositionSection ()
    {
        if(!isZoom) 
        {
            base.RepositionSection();
        } 
        else 
        {
            player.transform.DOLocalMove(zoomPlayerPos, 3f).SetEase(Ease.OutCubic);
            player.transform.DOLocalRotate(zoomPlayerRo, 3f).SetEase(Ease.OutCubic);
            camera.transform.DOLocalRotate(zoomCameraRo, 3f).SetEase(Ease.OutCubic);
        }
    }

    public override void ResetSection () 
    {
        Main.Instance.StopAudio();
        animator.Rebind();
        animator.Update(0f);
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor;
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor2;
        panel.GetComponent<Clickable>().onMouseClick -= ClickPanel;
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        
       
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}
