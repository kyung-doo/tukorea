using System.Collections;
using UnityEngine;
using DG.Tweening;
using EPOOutline;

public class Section3_2 : SectionBase
{

    [SerializeField]
    public AudioClip[] audioClips;

    // [SerializeField]
    // public Animator animator;

    [SerializeField]
    public GameObject touch1;

    [SerializeField]
    public GameObject touch2;

    [SerializeField]
    public GameObject touch3;

    [SerializeField]
    public GameObject touch4;


    [SerializeField]
    public GameObject screen2;

    [SerializeField]
    public GameObject screen3;
    [SerializeField]
    public GameObject screen4;


    private Vector3 zoomPlayerPos = new Vector3(-2.06505466f, 0.2282888f, 4.67137241f);
    private Vector3 zoomPlayerRo = new Vector3(0f, -89.8f, 0f);
    private Vector3 zoomCameraRo = new Vector3(0.35f, 0f, 0f);


    private IEnumerator coTimer = null;
    
    private bool isZoom = false;
    private IEnumerator coGlowAni = null;


    public override void StartSection ( bool isFirst = false ) 
    {
        Debug.Log("startSection2");
        touch1.SetActive(false);
        touch2.SetActive(false);
        touch3.SetActive(false);
        touch4.SetActive(false);
        coTimer = Start1();
        StartCoroutine(coTimer);
        
        base.StartSection(isFirst);
    }

    private IEnumerator Start1() 
    {
        yield return new WaitForSeconds( 3.5f );
        Main.Instance.PlayAudio(audioClips[0], () => {
            touch1.SetActive(true);
            touch1.GetComponent<Animator>().Play("touch");
            touch1.GetComponent<Clickable>().onMouseClick += ClickTouch1;
        });
        player.GetComponent<Player>().isActive = true;
    }

    private void ClickTouch1 ( GameObject target, Vector3 mousePos ) 
    {
        touch1.SetActive(false);
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        touch1.GetComponent<Animator>().Rebind();
        screen2.SetActive(true);
        coTimer = Start2();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start2() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[1], () => {
            touch2.SetActive(true);
            touch2.GetComponent<Animator>().Play("touch");
            touch2.GetComponent<Clickable>().onMouseClick += ClickTouch2;
        });
    }

    private void ClickTouch2 ( GameObject target, Vector3 mousePos ) 
    {
        touch2.SetActive(false);
        touch2.GetComponent<Clickable>().onMouseClick -= ClickTouch2;
        touch2.GetComponent<Animator>().Rebind();
        coTimer = Start3();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[2], () => {
            screen3.SetActive(true);
            touch3.SetActive(true);
            touch3.GetComponent<Animator>().Play("touch");
            touch3.GetComponent<Clickable>().onMouseClick += ClickTouch3;
        });
    }

    private void ClickTouch3 ( GameObject target, Vector3 mousePos ) 
    {
        touch3.SetActive(false);
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3;
        touch3.GetComponent<Animator>().Rebind();
        screen4.SetActive(true);
        coTimer = Start4();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start4() 
    {
        yield return new WaitForSeconds( 1f );
        touch4.SetActive(true);
        touch4.GetComponent<Animator>().Play("touch");
        touch4.GetComponent<Clickable>().onMouseClick += ClickTouch4;
    }

    private void ClickTouch4 ( GameObject target, Vector3 mousePos ) 
    {
        touch4.SetActive(false);
        touch4.GetComponent<Clickable>().onMouseClick -= ClickTouch4;
        touch4.GetComponent<Animator>().Rebind();
        screen3.SetActive(false);
        screen4.SetActive(false);
        // coTimer = Start4();
        // StartCoroutine(coTimer);
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
        // animator.Rebind();
        // animator.Update(0f);
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        touch2.GetComponent<Clickable>().onMouseClick -= ClickTouch2;
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3;
        touch4.GetComponent<Clickable>().onMouseClick -= ClickTouch4;
        screen2.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(false);
        
       
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}
