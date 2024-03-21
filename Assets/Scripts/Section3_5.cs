using System.Collections;
using UnityEngine;
using DG.Tweening;
using EPOOutline;

public class Section3_5 : SectionBase
{

    [SerializeField]
    public AudioClip[] audioClips;

    [SerializeField]
    public TabMenu tabMenu;


    [SerializeField]
    public GameObject touch1;
    [SerializeField]
    public GameObject touch2;
    [SerializeField]
    public GameObject touch3;
    [SerializeField]
    public GameObject touch4;
    [SerializeField]
    public GameObject touch5;
    [SerializeField]
    public GameObject touch6;
    [SerializeField]
    public GameObject touch7;
    [SerializeField]
    public GameObject touch8;
    [SerializeField]
    public GameObject touch9;


    
    [SerializeField]
    public GameObject screen1;
    [SerializeField]
    public GameObject screen2;
    [SerializeField]
    public GameObject screen3;
    [SerializeField]
    public GameObject screen4;
    [SerializeField]
    public GameObject screen5;
    [SerializeField]
    public GameObject screen6;
    [SerializeField]
    public GameObject screen7;
    [SerializeField]
    public GameObject screen8;
    [SerializeField]
    public GameObject screen9;
    [SerializeField]
    public GameObject screen10;

    [SerializeField]
    public GameObject toggle;

    [SerializeField]
    public GameObject text1;
    [SerializeField]
    public GameObject text2;
    [SerializeField]
    public GameObject text3;


    private IEnumerator coTimer = null;

    private Vector3 zoomPlayerPos = new Vector3(-2.024493f, 0.2285329f, 4.831224f);
    private Vector3 zoomPlayerRo = new Vector3(0f, -89.8f, 0f);
    private Vector3 zoomCameraRo = new Vector3(0.35f, 0f, 0f);

    private bool isZoom = false;



    public override void StartSection ( bool isFirst = false ) 
    {
        screen1.SetActive(true);
        screen2.SetActive(true);
        screen3.SetActive(false);
        screen4.SetActive(true);
        screen5.SetActive(true);
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
        screen6.SetActive(true);
        coTimer = Start2();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start2() 
    {
        yield return new WaitForSeconds( 2f );
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
        toggle.SetActive(true);
        coTimer = Start3();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[2], () => {
            screen7.SetActive(true);
            touch3.SetActive(true);
            touch3.GetComponent<Animator>().Play("touch");
            coTimer = Start4();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start4() 
    {
        yield return new WaitForSeconds( 3f );
        touch3.SetActive(false);
        Main.Instance.PlayAudio(audioClips[3], () => {
            touch4.SetActive(true);
            touch4.GetComponent<Animator>().Play("touch");
            touch4.GetComponent<Clickable>().onMouseClick += ClickTouch4;
        });
    }

    private void ClickTouch4 ( GameObject target, Vector3 mousePos ) 
    {
        touch4.SetActive(false);
        touch4.GetComponent<Clickable>().onMouseClick -= ClickTouch4;
        touch4.GetComponent<Animator>().Rebind();
        
        coTimer = Start5();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start5() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[4], () => {
            touch5.SetActive(true);
            touch5.GetComponent<Animator>().Play("touch");
            touch5.GetComponent<Clickable>().onMouseClick += ClickTouch5;
        });
    }

    private void ClickTouch5 ( GameObject target, Vector3 mousePos ) 
    {
        touch5.SetActive(false);
        touch5.GetComponent<Clickable>().onMouseClick -= ClickTouch5;
        touch5.GetComponent<Animator>().Rebind();
        screen8.SetActive(true);
        
        coTimer = Start6();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start6() 
    {
        yield return new WaitForSeconds( 1f );
        touch6.SetActive(true);
        touch6.GetComponent<Animator>().Play("touch");
        touch6.GetComponent<Clickable>().onMouseClick += ClickTouch6;
    }

    private void ClickTouch6 ( GameObject target, Vector3 mousePos ) 
    {
        touch6.SetActive(false);
        touch6.GetComponent<Clickable>().onMouseClick -= ClickTouch6;
        touch6.GetComponent<Animator>().Rebind();
        screen8.SetActive(false);
        
        coTimer = Start7();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start7() 
    {
        yield return new WaitForSeconds( 1f );
        touch7.SetActive(true);
        touch7.GetComponent<Animator>().Play("touch");
        touch7.GetComponent<Clickable>().onMouseClick += ClickTouch7;
    }

    private void ClickTouch7 ( GameObject target, Vector3 mousePos ) 
    {
        touch7.SetActive(false);
        touch7.GetComponent<Clickable>().onMouseClick -= ClickTouch7;
        touch7.GetComponent<Animator>().Rebind();
        coTimer = Start8();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start8() 
    {
        yield return new WaitForSeconds( 1f );
        isZoom = true;
        player.GetComponent<Player>().isActive = false;
        Main.Instance.repositionBtn.SetActive(false);
        player.transform.DOLocalMove(zoomPlayerPos, 1f).SetEase(Ease.OutCubic).SetDelay(1f);
        player.transform.DOLocalRotate(zoomPlayerRo, 1f).SetEase(Ease.OutCubic).SetDelay(1f);
        camera.transform
        .DOLocalRotate(zoomCameraRo, 1f)
        .SetEase(Ease.OutCubic)
        .SetDelay(1f)
        .OnComplete(() => {
            tabMenu.CloseMenu();
            screen9.SetActive(true);
            screen9.GetComponent<Animator>().Play("picture1");
            screen9.GetComponent<Animator>().speed = 0;
            text1.SetActive(true);
            Main.Instance.PlayAudio(audioClips[5], () => {
                touch8.SetActive(true);
                touch8.GetComponent<Animator>().Play("touch");
                touch8.GetComponent<Clickable>().onMouseClick += ClickTouch8;
            });
        });
    }

    private void ClickTouch8 ( GameObject target, Vector3 mousePos ) 
    {
        touch8.SetActive(false);
        touch8.GetComponent<Clickable>().onMouseClick -= ClickTouch8;
        touch8.GetComponent<Animator>().Rebind();
        text1.SetActive(false);
        screen10.SetActive(true);
        screen10.GetComponent<Animator>().Play("jump");
        screen10.GetComponent<Animator>().speed = 0;
        screen9.GetComponent<Animator>().speed = 1;
        coTimer = Start9();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start9() 
    {
        yield return new WaitForSeconds( 1f );
        text2.SetActive(true);
        Main.Instance.PlayAudio(audioClips[6], () => {
            touch9.SetActive(true);
            touch9.GetComponent<Animator>().Play("touch");
            coTimer = Start10();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start10() 
    {
        yield return new WaitForSeconds( 3f );
        text2.SetActive(false);
        touch9.SetActive(false);
        touch9.GetComponent<Animator>().Rebind();
        text3.SetActive(true);
        Main.Instance.PlayAudio(audioClips[7], () => {
            
        });
    }

    

    


    private IEnumerator Ended() 
    {
        yield return new WaitForSeconds( 4.0f );
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

        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        touch1.SetActive(false);
        touch2.GetComponent<Clickable>().onMouseClick -= ClickTouch2;
        touch2.SetActive(false);
        touch3.SetActive(false);
        touch4.GetComponent<Clickable>().onMouseClick -= ClickTouch4;
        touch4.SetActive(false);
        touch5.GetComponent<Clickable>().onMouseClick -= ClickTouch5;
        touch5.SetActive(false);
        touch6.GetComponent<Clickable>().onMouseClick -= ClickTouch6;
        touch6.SetActive(false);
        touch7.GetComponent<Clickable>().onMouseClick -= ClickTouch7;
        touch7.SetActive(false);
        touch8.GetComponent<Clickable>().onMouseClick -= ClickTouch8;
        touch8.SetActive(false);
        touch9.SetActive(false);
        
        
        
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(false);
        screen5.SetActive(false);
        screen6.SetActive(false);
        screen7.SetActive(false);
        screen8.SetActive(false);
        screen9.SetActive(false);
        screen9.GetComponent<Animator>().Rebind();
        screen9.GetComponent<Animator>().speed = 1;
        screen10.GetComponent<Animator>().Rebind();
        screen10.GetComponent<Animator>().speed = 1;
        

        toggle.SetActive(false);

        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}
