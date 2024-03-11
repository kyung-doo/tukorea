using System.Collections;
using UnityEngine;
using DG.Tweening;
using EPOOutline;

public class Section2_7 : SectionBase
{

    [SerializeField]
    public AudioClip[] audioClips;

    [SerializeField]
    public GameObject target;


    [SerializeField]
    public GameObject touch1;

    [SerializeField]
    public GameObject touch2;

    [SerializeField]
    public GameObject touch3;

    [SerializeField]
    public GameObject mouse;

    [SerializeField]
    public GameObject screen1;

    [SerializeField]
    public GameObject popup1;




    [SerializeField]
    public Animator animator;


    private IEnumerator coTimer = null;

    private Vector3 zoomPlayerPos1 = new Vector3(-0.4847202f, 0.05884716f, 5.134882f);
    private Vector3 zoomPlayerRo1 = new Vector3(0f, 12.60008f, 0f);
    private Vector3 zoomCameraRo1 = new Vector3(1.050421f, 0f, 0f);


    // private Vector3 zoomPlayerPos2 = new Vector3(5.45339298f, -0.000547677279f, 4.96265745f);
    // private Vector3 zoomPlayerRo2 = new Vector3(0f, -0.6f, 0f);
    // private Vector3 zoomCameraRo2 = new Vector3(6.752f, 0f, 0f);

    // private bool isZoom = false;
    private IEnumerator coGlowAni = null;


    public override void StartSection ( bool isFirst = false ) 
    {
        Debug.Log("startSection2");
        target.SetActive(true);
        
        touch1.SetActive(false);
        touch2.SetActive(false);
        touch3.SetActive(false);
        mouse.SetActive(false);
        screen1.SetActive(false);
        popup1.SetActive(false);

        
        coTimer = Start1();
        StartCoroutine(coTimer);
        base.StartSection(isFirst);
        // isZoom = false;
    }
    
    private IEnumerator Start1() 
    {
        yield return new WaitForSeconds( 2.5f );

        player.transform.DOLocalMove(zoomPlayerPos1, 1.5f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(zoomPlayerRo1, 1.5f).SetEase(Ease.OutCubic);
        camera.transform.DOLocalRotate(zoomCameraRo1, 1.5f).SetEase(Ease.OutCubic);

        yield return new WaitForSeconds( 1.5f );
        
        Main.Instance.PlayAudio(audioClips[0], () => {
            Main.Instance.PlayAudio(audioClips[1], () => {
                Main.Instance.PlayAudio(audioClips[2], () => {
                    touch1.SetActive(true);
                    coGlowAni = GlowAni(touch1);
                    StartCoroutine(coGlowAni);
                    touch1.GetComponent<Clickable>().onMouseClick += ClickTouch1;
                });
            });
        });
        player.GetComponent<Player>().isActive = true;
    }

    private void ClickTouch1 ( GameObject target, Vector3 mousePos ) 
    {
        touch1.SetActive(false);
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        StopCoroutine(coGlowAni);
        screen1.SetActive(true);
        coTimer = Start2();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start2() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[3], () => {
            touch2.SetActive(true);
            coGlowAni = GlowAni(touch2);
            StartCoroutine(coGlowAni);
            touch2.GetComponent<Clickable>().onMouseClick += ClickTouch2;
        });
    }

    private void ClickTouch2 ( GameObject target, Vector3 mousePos ) 
    {
        touch2.SetActive(false);
        touch2.GetComponent<Clickable>().onMouseClick -= ClickTouch2;
        StopCoroutine(coGlowAni);
        popup1.SetActive(true);
        coTimer = Start3();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[4], () => {
            touch3.SetActive(true);
            coGlowAni = GlowAni(touch3);
            StartCoroutine(coGlowAni);
            touch3.GetComponent<Clickable>().onMouseClick += ClickTouch3;
        });
    }

    private void ClickTouch3 ( GameObject target, Vector3 mousePos ) 
    {
        touch3.SetActive(false);
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3;
        StopCoroutine(coGlowAni);
        // coTimer = Start3();
        // StartCoroutine(coTimer);
    }


    private IEnumerator GlowAni( GameObject target ) 
    {
        int num = 0;
        while (true)
        {
            if(num >= 100) num = 0;
            if(num >= 0 && num < 50) 
            {
                target.GetComponent<Outlinable>().enabled = true;
            }
            else if(num >= 50 && num < 100) 
            {
                target.GetComponent<Outlinable>().enabled = false;
            }
            num+=2;
            yield return new WaitForFixedUpdate();
        }
    }


    private IEnumerator Ended() 
    {
        yield return new WaitForSeconds( 3.0f );
        player.GetComponent<Player>().isActive = false;
        Main.Instance.repositionBtn.SetActive(false);
        player.transform.DOLocalMove(startPlayerPos, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(startPlayerRo, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(startCameraRo, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            this.EndSection();
        });
    }

    

    public override void RepositionSection ()
    {
        // if(!isZoom) 
        // {
            player.transform.DOLocalMove(zoomPlayerPos1, 3f).SetEase(Ease.OutCubic);
            player.transform.DOLocalRotate(zoomPlayerRo1, 3f).SetEase(Ease.OutCubic);
            camera.transform.DOLocalRotate(zoomCameraRo1, 3f).SetEase(Ease.OutCubic);
        // } 
        // else 
        // {
            // player.transform.DOLocalMove(zoomPlayerPos2, 3f).SetEase(Ease.OutCubic);
            // player.transform.DOLocalRotate(zoomPlayerRo2, 3f).SetEase(Ease.OutCubic);
            // camera.transform.DOLocalRotate(zoomCameraRo2, 3f).SetEase(Ease.OutCubic);
        // }
    }

    public override void ResetSection () 
    {
        Main.Instance.StopAudio();
        animator.Rebind();
        animator.Update(0f);
        target.SetActive(false);
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        touch2.GetComponent<Clickable>().onMouseClick -= ClickTouch2;
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3;
        
        
        if(coTimer != null)     StopCoroutine(coTimer);
        if(coGlowAni != null)   StopCoroutine(coGlowAni);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}
