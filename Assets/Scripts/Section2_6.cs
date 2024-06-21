using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Networking;

public class Section2_6 : SectionBase
{

    [SerializeField]
    public AudioClip[] audioClips;

    [SerializeField]
    public GameObject target;

    [SerializeField]
    public GameObject outTarget;

    [SerializeField]
    public GameObject handle;

    [SerializeField]
    public GameObject bulk;

    [SerializeField]
    public GameObject startBtn;

    [SerializeField]
    public Animator animator;

    [SerializeField]
    public AudioClip beefAudio;


    private IEnumerator coTimer = null;

    private Vector3 zoomPlayerPos1 = new Vector3(5.4573431f, 0.525396705f, 4.79495382f);
    private Vector3 zoomPlayerRo1 = new Vector3(0f, 359.55f, 0f);
    private Vector3 zoomCameraRo1 = new Vector3(33.00123f, 0f, 0f);

    private Vector3 zoomPlayerPos2 = new Vector3(5.45339298f, -0.000547677279f, 4.96265745f);
    private Vector3 zoomPlayerRo2 = new Vector3(0f, -0.6f, 0f);
    private Vector3 zoomCameraRo2 = new Vector3(6.752f, 0f, 0f);

    private bool isZoom = false;


    public override void StartSection ( bool isFirst = false ) 
    {
        Debug.Log("startSection2");
        target.SetActive(true);
        outTarget.SetActive(false);
        handle.GetComponent<BoxCollider>().enabled = false;
        bulk.GetComponent<BoxCollider>().enabled = false;
        startBtn.GetComponent<BoxCollider>().enabled = false;
        
        coTimer = Start1();
        StartCoroutine(coTimer);
        base.StartSection(isFirst);
        isZoom = false;
        if(Main.Instance.initIndex == 5 && Main.Instance.loginData.data.a6 == "0")
        {
            StartCoroutine(base.SaveContent("a6", "1", () => Main.Instance.loginData.data.a6 = "1"));
        }
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
                animator.Play("handle_outline_on");
                handle.GetComponent<BoxCollider>().enabled = true;
                handle.GetComponent<Clickable>().onMouseClick += ClickHandle;
            });
        });
        player.GetComponent<Player>().isActive = true;
    }

    private void ClickHandle ( GameObject target, Vector3 mousePos ) 
    {
        handle.GetComponent<BoxCollider>().enabled = false;
        handle.GetComponent<Clickable>().onMouseClick -= ClickHandle;
        animator.Play("handle_open");
        coTimer = Start2();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start2() 
    {
        yield return new WaitForSeconds( 3f );
        Main.Instance.PlayAudio(audioClips[2], () => {
            animator.Play("bulk_outline_on");
            bulk.GetComponent<BoxCollider>().enabled = true;
            bulk.GetComponent<Clickable>().onMouseClick += ClickBulk;
        });
    }

    private void ClickBulk ( GameObject target, Vector3 mousePos ) 
    {
        bulk.GetComponent<BoxCollider>().enabled = false;
        bulk.GetComponent<Clickable>().onMouseClick -= ClickBulk;
        animator.Play("bulk_move");
        coTimer = Start3();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds( 4f );
        Main.Instance.PlayAudio(audioClips[3], () => {
            Main.Instance.PlayAudio(audioClips[4], () => {
                isZoom = true;
                player.GetComponent<Player>().isActive = false;
                player.transform.DOLocalMove(zoomPlayerPos2, 1f).SetEase(Ease.OutCubic);
                player.transform.DOLocalRotate(zoomPlayerRo2, 1f).SetEase(Ease.OutCubic);
                camera.transform
                .DOLocalRotate(zoomCameraRo2, 1f)
                .SetEase(Ease.OutCubic)
                .OnComplete(() => {
                    player.GetComponent<Player>().isActive = true;
                    coTimer = Start4();
                    StartCoroutine(coTimer);
                });
                Main.Instance.repositionBtn.SetActive(true);
            });
        });
    }

    private IEnumerator Start4() 
    {
        yield return new WaitForSeconds( 1f );
        animator.Play("button_outline_on");
        startBtn.GetComponent<BoxCollider>().enabled = true;
        startBtn.GetComponent<Clickable>().onMouseClick += ClickStartBtn;
    }
    
    private void ClickStartBtn ( GameObject target, Vector3 mousePos ) 
    {
        startBtn.GetComponent<BoxCollider>().enabled = false;
        startBtn.GetComponent<Clickable>().onMouseClick -= ClickStartBtn;
        animator.Play("button_click");
        coTimer = Start5();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start5() 
    {
        yield return new WaitForSeconds( 5f );
        Main.Instance.PlayAudio(audioClips[5], () => {
            player.GetComponent<Player>().isActive = false;
            Main.Instance.repositionBtn.SetActive(false);
            player.transform.DOLocalMove(zoomPlayerPos1, 1f).SetEase(Ease.OutCubic);
            player.transform.DOLocalRotate(zoomPlayerRo1, 1f).SetEase(Ease.OutCubic);
            camera.transform
            .DOLocalRotate(zoomCameraRo1, 1f)
            .SetEase(Ease.OutCubic)
            .OnComplete(() => {
                Main.Instance.PlayAudio(beefAudio);
                player.GetComponent<Player>().isActive = true;
                Main.Instance.repositionBtn.SetActive(true);
                animator.Play("handle_outline_on2");
                handle.GetComponent<BoxCollider>().enabled = true;
                handle.GetComponent<Clickable>().onMouseClick += ClickHandle2;
            });
            isZoom = false;
        });
    }

    private void ClickHandle2 ( GameObject target, Vector3 mousePos ) 
    {
        handle.GetComponent<BoxCollider>().enabled = false;
        handle.GetComponent<Clickable>().onMouseClick -= ClickHandle2;
        animator.Play("handle_open2");
        coTimer = Start6();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start6() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[6], () => {
            animator.Play("bulk_outline_on2");
            bulk.GetComponent<BoxCollider>().enabled = true;
            bulk.GetComponent<Clickable>().onMouseClick += ClickBulk2;
        });
    }

    private void ClickBulk2 ( GameObject target, Vector3 mousePos ) 
    {
        bulk.GetComponent<BoxCollider>().enabled = false;
        bulk.GetComponent<Clickable>().onMouseClick -= ClickBulk;
        animator.Play("bulk_move2");
        coTimer = Start7();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start7() 
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
        if(!isZoom) 
        {
            player.transform.DOLocalMove(zoomPlayerPos1, 3f).SetEase(Ease.OutCubic);
            player.transform.DOLocalRotate(zoomPlayerRo1, 3f).SetEase(Ease.OutCubic);
            camera.transform.DOLocalRotate(zoomCameraRo1, 3f).SetEase(Ease.OutCubic);
        } 
        else 
        {
            player.transform.DOLocalMove(zoomPlayerPos2, 3f).SetEase(Ease.OutCubic);
            player.transform.DOLocalRotate(zoomPlayerRo2, 3f).SetEase(Ease.OutCubic);
            camera.transform.DOLocalRotate(zoomCameraRo2, 3f).SetEase(Ease.OutCubic);
        }
    }

    public override void ResetSection () 
    {
        Main.Instance.StopAudio();
        animator.Rebind();
        target.SetActive(false);
        outTarget.SetActive(true);
        handle.GetComponent<Clickable>().onMouseClick -= ClickHandle;
        handle.GetComponent<Clickable>().onMouseClick -= ClickHandle2;
        bulk.GetComponent<Clickable>().onMouseClick -= ClickBulk;
        bulk.GetComponent<Clickable>().onMouseClick -= ClickBulk2;
        startBtn.GetComponent<Clickable>().onMouseClick -= ClickStartBtn;
        
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        if(Main.Instance.initIndex == 5 && Main.Instance.loginData.data.a6 == "1")
        {
            Main.Instance.initIndex = 6;
            StartCoroutine(base.SaveContent("a6", "2", () => Main.Instance.loginData.data.a6 = "2"));
        }
        base.EndSection();
    }

}
