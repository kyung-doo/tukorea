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
    public GameObject touch4;

    [SerializeField]
    public GameObject mouse;
    [SerializeField]
    public GameObject mouseTouch;

    [SerializeField]
    public GameObject f6;
    [SerializeField]
    public GameObject f6Touch;

    [SerializeField]
    public GameObject handle;

    [SerializeField]
    public GameObject holder;

    [SerializeField]
    public GameObject driver;

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

    private Vector3 zoomPlayerPos2 = new Vector3(0.919327259f, 0.274860114f, 4.72083473f);
    private Vector3 zoomPlayerRo2 = new Vector3(0f, -36.75f, 0f);
    private Vector3 zoomCameraRo2 = new Vector3(23.85f, 0f, 0f);

    private Vector3 zoomPlayerPos3 = new Vector3(0.4764349f, -0.05728188f, 5.186139f);
    private Vector3 zoomPlayerRo3 = new Vector3(0f, -52.5f, 0f);
    private Vector3 zoomCameraRo3 = new Vector3(9.75f, 0f, 0f);

    private int isZoom = 0;
    private IEnumerator coGlowAni = null;


    public override void StartSection ( bool isFirst = false ) 
    {
        Debug.Log("startSection2");
        target.SetActive(true);
        
        touch1.SetActive(false);
        touch2.SetActive(false);
        touch3.SetActive(false);
        touch4.SetActive(false);
        screen1.SetActive(false);
        popup1.SetActive(false);
        mouse.SetActive(false);
        mouseTouch.SetActive(false);
        f6.SetActive(false);
        f6Touch.SetActive(false);
        handle.GetComponent<BoxCollider>().enabled = false;
        holder.GetComponent<BoxCollider>().enabled = false;
        driver.GetComponent<BoxCollider>().enabled = false;
        
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
        popup1.SetActive(false);
        coTimer = Start4();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start4() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[5], () => {
            mouse.SetActive(true);
            mouseTouch.SetActive(true);
            mouseTouch.GetComponent<Clickable>().onMouseClick += ClickMouse;
        });
    }

    private void ClickMouse ( GameObject target, Vector3 mousePos ) 
    {
        mouse.SetActive(false);
        mouseTouch.SetActive(false);
        mouseTouch.GetComponent<Clickable>().onMouseClick -= ClickMouse;
        coTimer = Start5();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start5() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[6], () => {
            f6.SetActive(true);
            f6Touch.SetActive(true);
            f6Touch.GetComponent<Clickable>().onMouseClick += ClickF6;
        });
    }

    private void ClickF6 ( GameObject target, Vector3 mousePos ) 
    {
        f6.SetActive(false);
        f6Touch.SetActive(false);
        f6Touch.GetComponent<Clickable>().onMouseClick -= ClickF6;
        coTimer = Start6();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start6() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[7], () => {
            coTimer = Start7();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start7() 
    {
        yield return new WaitForSeconds( 2f );
        isZoom = 1;
        player.GetComponent<Player>().isActive = false;
        player.transform.DOLocalMove(zoomPlayerPos2, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(zoomPlayerRo2, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(zoomCameraRo2, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            player.GetComponent<Player>().isActive = true;
            coTimer = Start8();
            StartCoroutine(coTimer);
        });
        Main.Instance.repositionBtn.SetActive(true);
    }

    private IEnumerator Start8() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[8], () => {
            animator.Play("handle_outline_on");
            handle.GetComponent<BoxCollider>().enabled = true;
            handle.GetComponent<Clickable>().onMouseClick += ClickHandle;
        });
    }

    private void ClickHandle ( GameObject target, Vector3 mousePos ) 
    {
        handle.GetComponent<BoxCollider>().enabled = false;
        handle.GetComponent<Clickable>().onMouseClick -= ClickHandle;
        animator.Play("handle_open");
        coTimer = Start9();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start9() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[9], () => {
            animator.Play("holder_outline_on");
            holder.GetComponent<BoxCollider>().enabled = true;
            holder.GetComponent<Clickable>().onMouseClick += ClickHolder;
        });
    }

    private void ClickHolder ( GameObject target, Vector3 mousePos ) 
    {
        holder.GetComponent<BoxCollider>().enabled = false;
        holder.GetComponent<Clickable>().onMouseClick -= ClickHolder;

        player.transform.DOLocalMove(zoomPlayerPos3, 1f).SetEase(Ease.OutCubic).SetDelay(1f);
        player.transform.DOLocalRotate(zoomPlayerRo3, 1f).SetEase(Ease.OutCubic).SetDelay(1f);
        camera.transform
        .DOLocalRotate(zoomCameraRo3, 1f)
        .SetEase(Ease.OutCubic)
        .SetDelay(1f)
        .OnStart(() => {
            isZoom = 2;
            player.GetComponent<Player>().isActive = false;
            Main.Instance.repositionBtn.SetActive(false);
        })
        .OnComplete(() => {
            player.GetComponent<Player>().isActive = true;
            Main.Instance.repositionBtn.SetActive(true);
        });

        animator.Play("holder_move");
        coTimer = Start10();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start10() 
    {
        yield return new WaitForSeconds( 3f );

        player.GetComponent<Player>().isActive = false;
        Main.Instance.repositionBtn.SetActive(false);
        player.transform.DOLocalMove(zoomPlayerPos2, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(zoomPlayerRo2, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(zoomCameraRo2, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            isZoom = 1;
            player.GetComponent<Player>().isActive = true;
            Main.Instance.repositionBtn.SetActive(true);
        });

        Main.Instance.PlayAudio(audioClips[10], () => {
            animator.Play("HexagonDriver_outline_on");
            driver.GetComponent<BoxCollider>().enabled = true;
            driver.GetComponent<Clickable>().onMouseClick += ClickDriver;
        });
    }

    private void ClickDriver ( GameObject target, Vector3 mousePos ) 
    {
        driver.GetComponent<BoxCollider>().enabled = false;
        driver.GetComponent<Clickable>().onMouseClick -= ClickDriver;

        player.transform.DOLocalMove(zoomPlayerPos3, 1f).SetEase(Ease.OutCubic).SetDelay(0.5f);
        player.transform.DOLocalRotate(zoomPlayerRo3, 1f).SetEase(Ease.OutCubic).SetDelay(0.5f);
        camera.transform
        .DOLocalRotate(zoomCameraRo3, 1f)
        .SetEase(Ease.OutCubic)
        .SetDelay(0.5f)
        .OnStart(() => {
            isZoom = 2;
            player.GetComponent<Player>().isActive = false;
            Main.Instance.repositionBtn.SetActive(false);
        });

        animator.Play("HexagonDriver_move");
        coTimer = Start11();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start11() 
    {
        yield return new WaitForSeconds( 5f );
        
        player.transform.DOLocalMove(zoomPlayerPos2, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(zoomPlayerRo2, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(zoomCameraRo2, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            isZoom = 1;
            player.GetComponent<Player>().isActive = true;
            Main.Instance.repositionBtn.SetActive(true);
        });

        Main.Instance.PlayAudio(audioClips[11], () => {
            coTimer = Start12();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start12() 
    {
        yield return new WaitForSeconds( 1f );

        Main.Instance.PlayAudio(audioClips[12], () => {
            animator.Play("handle_outline_on2");
            handle.GetComponent<BoxCollider>().enabled = true;
            handle.GetComponent<Clickable>().onMouseClick += ClickHandle2;
           
        });
    }

    private void ClickHandle2 ( GameObject target, Vector3 mousePos ) 
    {
        handle.GetComponent<BoxCollider>().enabled = false;
        handle.GetComponent<Clickable>().onMouseClick -= ClickHandle2;
        animator.Play("handle_move2");
        coTimer = Start13();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start13()
    {
        yield return new WaitForSeconds( 3f );
        screen1.SetActive(false);
        player.GetComponent<Player>().isActive = false;
        Main.Instance.repositionBtn.SetActive(false);
        player.transform.DOLocalMove(zoomPlayerPos1, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(zoomPlayerRo1, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(zoomCameraRo1, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            player.GetComponent<Player>().isActive = true;
            Main.Instance.repositionBtn.SetActive(true);
            coTimer = Start14();
            StartCoroutine(coTimer);
        });
        isZoom = 0;
    }

    private IEnumerator Start14() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[13], () => {
            Main.Instance.PlayAudio(audioClips[14], () => {
            
                touch1.SetActive(true);
                coGlowAni = GlowAni(touch1);
                StartCoroutine(coGlowAni);
                touch1.GetComponent<Clickable>().onMouseClick += ClickTouch1_2;
            });
        });
    }

    private void ClickTouch1_2 ( GameObject target, Vector3 mousePos ) 
    {
        touch1.SetActive(false);
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1_2;
        StopCoroutine(coGlowAni);
        screen1.SetActive(true);
        coTimer = Start15();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start15() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[15], () => {
            touch2.SetActive(true);
            coGlowAni = GlowAni(touch2);
            StartCoroutine(coGlowAni);
            touch2.GetComponent<Clickable>().onMouseClick += ClickTouch2_2;
        });
    }

    private void ClickTouch2_2 ( GameObject target, Vector3 mousePos ) 
    {
        touch2.SetActive(false);
        touch2.GetComponent<Clickable>().onMouseClick -= ClickTouch2_2;
        StopCoroutine(coGlowAni);
        popup1.SetActive(true);
        coTimer = Start16();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start16() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[16], () => {
            touch3.SetActive(true);
            coGlowAni = GlowAni(touch3);
            StartCoroutine(coGlowAni);
            touch3.GetComponent<Clickable>().onMouseClick += ClickTouch3_2;
        });
    }

    private void ClickTouch3_2 ( GameObject target, Vector3 mousePos ) 
    {
        touch3.SetActive(false);
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3_2;
        StopCoroutine(coGlowAni);
        popup1.SetActive(false);
        coTimer = Start17();
        StartCoroutine(coTimer);
    }


    private IEnumerator Start17() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[17], () => {
            mouse.SetActive(true);
            mouseTouch.SetActive(true);
            mouseTouch.GetComponent<Clickable>().onMouseClick += ClickMouse2;
        });
    }

    private void ClickMouse2 ( GameObject target, Vector3 mousePos ) 
    {
        mouse.SetActive(false);
        mouseTouch.SetActive(false);
        mouseTouch.GetComponent<Clickable>().onMouseClick -= ClickMouse2;
        coTimer = Start18();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start18() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[18], () => {
            f6.SetActive(true);
            f6Touch.SetActive(true);
            f6Touch.GetComponent<Clickable>().onMouseClick += ClickF62;
        });
    }

    private void ClickF62 ( GameObject target, Vector3 mousePos ) 
    {
        f6.SetActive(false);
        f6Touch.SetActive(false);
        f6Touch.GetComponent<Clickable>().onMouseClick -= ClickF62;
        coTimer = Start19();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start19() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[19], () => {
            coTimer = Start20();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start20() 
    {
        yield return new WaitForSeconds( 2f );
        isZoom = 1;
        player.GetComponent<Player>().isActive = false;
        player.transform.DOLocalMove(zoomPlayerPos2, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(zoomPlayerRo2, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(zoomCameraRo2, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            player.GetComponent<Player>().isActive = true;
            coTimer = Start21();
            StartCoroutine(coTimer);
        });
        Main.Instance.repositionBtn.SetActive(true);
    }

    private IEnumerator Start21() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[20], () => {
            animator.Play("handle_outline_on3");
            handle.GetComponent<BoxCollider>().enabled = true;
            handle.GetComponent<Clickable>().onMouseClick += ClickHandle3;
        });
    }

    private void ClickHandle3 ( GameObject target, Vector3 mousePos ) 
    {
        handle.GetComponent<BoxCollider>().enabled = false;
        handle.GetComponent<Clickable>().onMouseClick -= ClickHandle3;
        animator.Play("handle_open2");
        coTimer = Start22();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start22() 
    {
        yield return new WaitForSeconds( 3f );
        Main.Instance.PlayAudio(audioClips[21], () => {
            animator.Play("HexagonDriver_outline_on2");
            driver.GetComponent<BoxCollider>().enabled = true;
            driver.GetComponent<Clickable>().onMouseClick += ClickDriver2;
        });
    }

    private void ClickDriver2 ( GameObject target, Vector3 mousePos ) 
    {
        player.transform.DOLocalMove(zoomPlayerPos3, 1f).SetEase(Ease.OutCubic).SetDelay(1f);
        player.transform.DOLocalRotate(zoomPlayerRo3, 1f).SetEase(Ease.OutCubic).SetDelay(1f);
        camera.transform
        .DOLocalRotate(zoomCameraRo3, 1f)
        .SetEase(Ease.OutCubic)
        .SetDelay(1f)
        .OnStart(() => {
            isZoom = 2;
            player.GetComponent<Player>().isActive = false;
            Main.Instance.repositionBtn.SetActive(false);
        });
        
        driver.GetComponent<BoxCollider>().enabled = false;
        driver.GetComponent<Clickable>().onMouseClick -= ClickDriver2;
        animator.Play("HexagonDriver_move2");
        coTimer = Start23();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start23() 
    {
        yield return new WaitForSeconds( 4f );
        
        player.transform.DOLocalMove(zoomPlayerPos2, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(zoomPlayerRo2, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(zoomCameraRo2, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            isZoom = 1;
            player.GetComponent<Player>().isActive = true;
            Main.Instance.repositionBtn.SetActive(true);
        });

        yield return new WaitForSeconds( 3f );
        Main.Instance.PlayAudio(audioClips[22], () => {
            coTimer = Start24();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start24() 
    {
        yield return new WaitForSeconds( 1f );
        Main.Instance.PlayAudio(audioClips[23], () => {
            animator.Play("handle_outline_on4");
            handle.GetComponent<BoxCollider>().enabled = true;
            handle.GetComponent<Clickable>().onMouseClick += ClickHandle4;
           
        });
    }

    private void ClickHandle4 ( GameObject target, Vector3 mousePos ) 
    {
        handle.GetComponent<BoxCollider>().enabled = false;
        handle.GetComponent<Clickable>().onMouseClick -= ClickHandle4;
        animator.Play("handle_close");
        coTimer = Start25();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start25()
    {
        yield return new WaitForSeconds( 3f );
        screen1.SetActive(false);
        player.GetComponent<Player>().isActive = false;
        Main.Instance.repositionBtn.SetActive(false);
        player.transform.DOLocalMove(zoomPlayerPos1, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(zoomPlayerRo1, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(zoomCameraRo1, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            player.GetComponent<Player>().isActive = true;
            Main.Instance.repositionBtn.SetActive(true);
            coTimer = Start26();
            StartCoroutine(coTimer);
        });
        isZoom = 0;
    }

    private IEnumerator Start26() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[24], () => {
             touch1.SetActive(true);
            coGlowAni = GlowAni(touch1);
            StartCoroutine(coGlowAni);
            touch1.GetComponent<Clickable>().onMouseClick += ClickTouch1_3;
        });
    }

    private void ClickTouch1_3 ( GameObject target, Vector3 mousePos ) 
    {
        touch1.SetActive(false);
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1_3;
        StopCoroutine(coGlowAni);
        screen1.SetActive(true);
        coTimer = Start27();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start27() 
    {
        yield return new WaitForSeconds( 2f );
        Main.Instance.PlayAudio(audioClips[25], () => {
            touch4.SetActive(true);
            coGlowAni = GlowAni(touch4);
            StartCoroutine(coGlowAni);
            touch4.GetComponent<Clickable>().onMouseClick += ClickTouch4;
        });
    }


    private void ClickTouch4 ( GameObject target, Vector3 mousePos ) 
    {
        touch4.SetActive(false);
        touch4.GetComponent<Clickable>().onMouseClick -= ClickTouch4;
        StopCoroutine(coGlowAni);
        Main.Instance.PlayAudio(audioClips[26], () => {
            coTimer = Ended();
            StartCoroutine(coTimer);
        });
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
        if(isZoom == 0) 
        {
            player.transform.DOLocalMove(zoomPlayerPos1, 3f).SetEase(Ease.OutCubic);
            player.transform.DOLocalRotate(zoomPlayerRo1, 3f).SetEase(Ease.OutCubic);
            camera.transform.DOLocalRotate(zoomCameraRo1, 3f).SetEase(Ease.OutCubic);
        } 
        else if(isZoom == 1)
        {
            player.transform.DOLocalMove(zoomPlayerPos2, 3f).SetEase(Ease.OutCubic);
            player.transform.DOLocalRotate(zoomPlayerRo2, 3f).SetEase(Ease.OutCubic);
            camera.transform.DOLocalRotate(zoomCameraRo2, 3f).SetEase(Ease.OutCubic);
        } else {
            player.transform.DOLocalMove(zoomPlayerPos3, 3f).SetEase(Ease.OutCubic);
            player.transform.DOLocalRotate(zoomPlayerRo3, 3f).SetEase(Ease.OutCubic);
            camera.transform.DOLocalRotate(zoomCameraRo3, 3f).SetEase(Ease.OutCubic);
        }
    }

    public override void ResetSection () 
    {
        Main.Instance.StopAudio();
        animator.Rebind();
        animator.Update(0f);
        target.SetActive(false);
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1;
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1_2;
        touch1.GetComponent<Clickable>().onMouseClick -= ClickTouch1_3;
        touch2.GetComponent<Clickable>().onMouseClick -= ClickTouch2;
        touch2.GetComponent<Clickable>().onMouseClick -= ClickTouch2_2;
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3;
        touch3.GetComponent<Clickable>().onMouseClick -= ClickTouch3_2;
        touch4.GetComponent<Clickable>().onMouseClick -= ClickTouch4;
        mouseTouch.GetComponent<Clickable>().onMouseClick -= ClickMouse;
        f6Touch.GetComponent<Clickable>().onMouseClick -= ClickF6;
        handle.GetComponent<Clickable>().onMouseClick -= ClickHandle;
        handle.GetComponent<Clickable>().onMouseClick -= ClickHandle2;
        handle.GetComponent<Clickable>().onMouseClick -= ClickHandle3;
        handle.GetComponent<Clickable>().onMouseClick -= ClickHandle4;
        holder.GetComponent<Clickable>().onMouseClick -= ClickHolder;
        driver.GetComponent<Clickable>().onMouseClick -= ClickDriver;
        driver.GetComponent<Clickable>().onMouseClick -= ClickDriver2;
        
        if(coTimer != null)     StopCoroutine(coTimer);
        if(coGlowAni != null)   StopCoroutine(coGlowAni);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}
