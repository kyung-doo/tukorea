using System.Collections;
using UnityEngine;
using DG.Tweening;
using EPOOutline;

public class Section3_6 : SectionBase
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
    public GameObject touch1;
    [SerializeField]
    public GameObject touch2;
    [SerializeField]
    public GameObject touch3;
    


    
    [SerializeField]
    public GameObject screen1;
    [SerializeField]
    public GameObject screen2;
    [SerializeField]
    public GameObject screen3;
    [SerializeField]
    public GameObject screen4;

    [SerializeField]
    public GameObject loadBtnOver;
    [SerializeField]
    public GameObject visionBtnOver;
    [SerializeField]
    public GameObject drillStartOver;
    


    private IEnumerator coTimer = null;

    private Vector3 zoomPlayerPos = new Vector3(-2.12830806f, 0.243510276f, 2.82439518f);
    private Vector3 zoomPlayerRo = new Vector3(0f, -89.7f, 0f);
    private Vector3 zoomCameraRo = new Vector3(24.45f, 0f, 0f);

    private bool isZoom = false;



    public override void StartSection ( bool isFirst = false ) 
    {
        screen1.SetActive(true);
        screen2.SetActive(true);
        screen3.SetActive(true);
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
        screen4.SetActive(true);
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
        loadBtnOver.SetActive(true);
        visionBtnOver.SetActive(false);
        coTimer = Start3();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds( 2f );
        isZoom = true;
        player.GetComponent<Player>().isActive = false;
        player.transform.DOLocalMove(zoomPlayerPos, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(zoomPlayerRo, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(zoomCameraRo, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            player.GetComponent<Player>().isActive = true;
            Main.Instance.PlayAudio(audioClips[2], () => {
                animator.Play("handle_outline_on3");
                door.GetComponent<BoxCollider>().enabled = true;
                door.GetComponent<Clickable>().onMouseClick += ClickDoor1;
            });
        });
    }

    private void ClickDoor1 ( GameObject target, Vector3 mousePos ) 
    {
        door.GetComponent<BoxCollider>().enabled = false;
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor1;
        animator.Play("handle_open2");
        coTimer = Start4();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start4() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[3], () => {
            animator.Play("handle_outline_on2");
            door.GetComponent<BoxCollider>().enabled = true;
            door.GetComponent<Clickable>().onMouseClick += ClickDoor2;
        });
    }

    private void ClickDoor2 ( GameObject target, Vector3 mousePos ) 
    {
        door.GetComponent<BoxCollider>().enabled = false;
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor2;
        animator.Play("handle_close2");
        coTimer = Start5();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start5() 
    {
        yield return new WaitForSeconds( 2f );
        player.GetComponent<Player>().isActive = false;
        Main.Instance.repositionBtn.SetActive(false);
        player.transform.DOLocalMove(startPlayerPos, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(startPlayerRo, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(startCameraRo, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            player.GetComponent<Player>().isActive = true;
            Main.Instance.repositionBtn.SetActive(true);
            isZoom = false;
            Main.Instance.PlayAudio(audioClips[4], () => {
                touch3.SetActive(true);
                touch3.GetComponent<Animator>().Play("touch");
                touch3.GetComponent<Clickable>().onMouseClick += ClickTouch3;
            });
        });
    }

    private void ClickTouch3 ( GameObject target, Vector3 mousePos ) 
    {
        touch3.SetActive(false);
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3;
        touch3.GetComponent<Animator>().Rebind();
        coTimer = Start6();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start6() 
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
            Main.Instance.PlayAudio(audioClips[5], () => {
                animator.Play("handle_outline_on3");
                door.GetComponent<BoxCollider>().enabled = true;
                door.GetComponent<Clickable>().onMouseClick += ClickDoor3;
            });
        });
    }

    private void ClickDoor3 ( GameObject target, Vector3 mousePos ) 
    {
        door.GetComponent<BoxCollider>().enabled = false;
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor3;
        animator.Play("handle_open2");
        coTimer = Start7();
        StartCoroutine(coTimer);
    }
    
    private IEnumerator Start7() 
    {
        yield return new WaitForSeconds( 3f );
        Main.Instance.PlayAudio(audioClips[6], () => {
            animator.Play("pannel_outline_on2");
            panel.GetComponent<BoxCollider>().enabled = true;
            panel.GetComponent<Clickable>().onMouseClick += ClickPanel;
        });
    }

    private void ClickPanel ( GameObject target, Vector3 mousePos ) 
    {
        panel.GetComponent<BoxCollider>().enabled = false;
        panel.GetComponent<Clickable>().onMouseClick -= ClickPanel;
        animator.Play("pannel_move2");
        coTimer = Start8();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start8() 
    {
        yield return new WaitForSeconds( 3f );
        Main.Instance.PlayAudio(audioClips[7], () => {
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

        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        touch1.SetActive(false);
        touch2.GetComponent<Clickable>().onMouseClick -= ClickTouch2;
        touch2.SetActive(false);
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch2;
        touch3.SetActive(false);

        door.GetComponent<Clickable>().onMouseClick -= ClickDoor1;
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor2;
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor3;
        panel.GetComponent<Clickable>().onMouseClick -= ClickPanel;
        
        
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(false);

        loadBtnOver.SetActive(false);
        visionBtnOver.SetActive(true);
        drillStartOver.SetActive(false);
        
        
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}
