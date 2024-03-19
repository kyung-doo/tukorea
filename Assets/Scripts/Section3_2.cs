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
    public GameObject touch5;

    [SerializeField]
    public GameObject toolTouch1;

    [SerializeField]
    public GameObject toolTouch2;

    [SerializeField]
    public GameObject toolTouch3;

    [SerializeField]
    public GameObject toolLine1;

    [SerializeField]
    public GameObject toolLine2;

    [SerializeField]
    public GameObject toolLine3;

    [SerializeField]
    public GameObject toolBtnOver1;

    [SerializeField]
    public GameObject toolBtnOver2;

    [SerializeField]
    public GameObject toolBtnOver3;

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


    private Vector3 zoomPlayerPos = new Vector3(-2.064669f, 0.2282887f, 4.781382f);
    private Vector3 zoomPlayerRo = new Vector3(0f, -89.8f, 0f);
    private Vector3 zoomCameraRo = new Vector3(0.35f, 0f, 0f);


    private IEnumerator coTimer = null;
    
    private bool isZoom = false;
    

    private int toolClickCount = 0;


    public override void StartSection ( bool isFirst = false ) 
    {
        Debug.Log("startSection2");
        touch1.SetActive(false);
        touch2.SetActive(false);
        touch3.SetActive(false);
        touch4.SetActive(false);
        touch5.SetActive(false);
        toolTouch1.SetActive(false);
        toolTouch2.SetActive(false);
        toolTouch2.SetActive(false);
        
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
        screen3.SetActive(true);
        Main.Instance.PlayAudio(audioClips[2], () => {
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
        coTimer = Start5();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start5() 
    {
        yield return new WaitForSeconds( 1f );
        screen5.SetActive(true);
        Main.Instance.PlayAudio(audioClips[3], () => {
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
        screen5.SetActive(false);
        coTimer = Start6();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start6() 
    {
        yield return new WaitForSeconds( 2f );
        screen6.SetActive(true);
        toolLine1.SetActive(true);
        toolLine2.SetActive(true);
        toolLine3.SetActive(true);
        toolBtnOver1.SetActive(true);
        toolBtnOver2.SetActive(true);
        toolBtnOver3.SetActive(true);
        Main.Instance.PlayAudio(audioClips[4], () => {
            Main.Instance.PlayAudio(audioClips[5], () => {
                toolTouch1.SetActive(true);
                toolTouch1.GetComponent<Animator>().Play("touch");
                toolTouch1.GetComponent<Clickable>().onMouseClick += ClickTool;

                toolTouch2.SetActive(true);
                toolTouch2.GetComponent<Animator>().Play("touch");
                toolTouch2.GetComponent<Clickable>().onMouseClick += ClickTool;

                toolTouch3.SetActive(true);
                toolTouch3.GetComponent<Animator>().Play("touch");
                toolTouch3.GetComponent<Clickable>().onMouseClick += ClickTool;
            });
        });
    }

    private void ClickTool ( GameObject target, Vector3 mousePos ) 
    {
        target.SetActive(false);
        target.GetComponent<Clickable>().onMouseClick -= ClickTool;
        target.GetComponent<Animator>().Rebind();
        if(target.name == "touch01") 
        {
            toolLine1.SetActive(false);
            toolBtnOver1.SetActive(false);
        } 
        else if(target.name == "touch02") 
        {
            toolLine2.SetActive(false);
            toolBtnOver2.SetActive(false);
        } 
        else 
        {
            toolLine3.SetActive(false);
            toolBtnOver3.SetActive(false);
        }

        toolClickCount++;

        if(toolClickCount == 3) {
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
                player.GetComponent<Player>().isActive = true;
                Main.Instance.repositionBtn.SetActive(true);
                screen7.SetActive(true);
                Main.Instance.PlayAudio(audioClips[6], () => {
                    toolTouch1.SetActive(true);
                    toolTouch1.GetComponent<Animator>().Play("touch");
                    toolTouch1.GetComponent<Clickable>().onMouseClick += ClickTool1;
                });
            });
        }
        
    }

    private void ClickTool1 ( GameObject target, Vector3 mousePos ) 
    {
        toolTouch1.SetActive(false);
        toolTouch1.GetComponent<Clickable>().onMouseClick -= ClickTool1;
        toolTouch1.GetComponent<Animator>().Rebind();
        toolLine1.SetActive(true);
        toolBtnOver1.SetActive(true);
        coTimer = Start7();
        StartCoroutine(coTimer);
    }


    private IEnumerator Start7() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[7], () => {
            // screen5.SetActive(true);
            // touch5.SetActive(true);
            // touch5.GetComponent<Animator>().Play("touch");
            // touch5.GetComponent<Clickable>().onMouseClick += ClickTouch5;
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
        // animator.Rebind();
        // animator.Update(0f);
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        touch2.GetComponent<Clickable>().onMouseClick -= ClickTouch2;
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3;
        touch4.GetComponent<Clickable>().onMouseClick -= ClickTouch4;
        touch5.GetComponent<Clickable>().onMouseClick -= ClickTouch5;
        toolTouch1.GetComponent<Clickable>().onMouseClick -= ClickTool;
        toolTouch2.GetComponent<Clickable>().onMouseClick -= ClickTool;
        toolTouch3.GetComponent<Clickable>().onMouseClick -= ClickTool;
        toolTouch1.GetComponent<Clickable>().onMouseClick -= ClickTool1;
        
        screen2.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(false);
        screen5.SetActive(false);
        screen6.SetActive(false);
        screen7.SetActive(false);

        toolLine1.SetActive(false);
        toolLine2.SetActive(false);
        toolLine3.SetActive(false);
        toolBtnOver1.SetActive(false);
        toolBtnOver2.SetActive(false);
        toolBtnOver3.SetActive(false);
        
       
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}
