using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Section2_4 : SectionBase
{

    [SerializeField]
    public AudioClip[] audioClips;

    [SerializeField]
    public GameObject target;

    [SerializeField]
    public GameObject holder;

    [SerializeField]
    public GameObject nickelCarbonTape;

    [SerializeField]
    public GameObject bulk;

    [SerializeField]
    public GameObject pincette;

    [SerializeField]
    public GameObject carbonTape;

    [SerializeField]
    public GameObject bulkUi;


    [SerializeField]
    public Animator animator;


    private IEnumerator coTimer = null;

    private Vector3 zoomPlayerPos = new Vector3(0.959688187f, -0.197897345f, 3.02322054f);
    private Vector3 zoomPlayerRo = new Vector3(0f, 180.450241f, 0f);
    private Vector3 zoomCameraRo = new Vector3(27.1530857f, 0f, 0f);

    private bool isZoom = false;



    public override void StartSection ( bool isFirst = false ) 
    {
        Debug.Log("startSection2");
        target.SetActive(true);
        holder.GetComponent<BoxCollider>().enabled = false;
        nickelCarbonTape.GetComponent<BoxCollider>().enabled = false;
        bulk.GetComponent<BoxCollider>().enabled = false;
        pincette.GetComponent<BoxCollider>().enabled = false;
        carbonTape.GetComponent<BoxCollider>().enabled = false;
        coTimer = Start1();
        StartCoroutine(coTimer);
        base.StartSection(isFirst);
    }

    private IEnumerator Start1() 
    {
        yield return new WaitForSeconds( 3.5f );
        Main.Instance.PlayAudio(audioClips[0], () => {
            animator.Play("Holder03_outline_on");
            holder.GetComponent<BoxCollider>().enabled = true;
            holder.GetComponent<Clickable>().onMouseClick += ClickHolder;
        });
        player.GetComponent<Player>().isActive = true;
    }

    private void ClickHolder ( GameObject target, Vector3 mousePos ) 
    {
        holder.GetComponent<BoxCollider>().enabled = false;
        holder.GetComponent<Clickable>().onMouseClick -= ClickHolder;
        animator.Play("Holder03_move");
        coTimer = Start2();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start2() 
    {
        yield return new WaitForSeconds( 3f );
        Main.Instance.PlayAudio(audioClips[1], () => {
            animator.Play("NickelCarbonTape_outline_on");
            nickelCarbonTape.GetComponent<BoxCollider>().enabled = true;
            nickelCarbonTape.GetComponent<Clickable>().onMouseClick += ClickNickelCarbonTape;
        });
    }

    private void ClickNickelCarbonTape ( GameObject target, Vector3 mousePos ) 
    {
        nickelCarbonTape.GetComponent<BoxCollider>().enabled = false;
        nickelCarbonTape.GetComponent<Clickable>().onMouseClick -= ClickNickelCarbonTape;
        animator.Play("NickelCarbonTape_move");

        player.transform.DOLocalMove(zoomPlayerPos, 1f).SetEase(Ease.OutCubic).SetDelay(7f);
        player.transform.DOLocalRotate(zoomPlayerRo, 1f).SetEase(Ease.OutCubic).SetDelay(7f);
        camera.transform
        .DOLocalRotate(zoomCameraRo, 1f)
        .SetEase(Ease.OutCubic)
        .SetDelay(7f)
        .OnStart(() => {
            isZoom = true;
            player.GetComponent<Player>().isActive = false;
            Main.Instance.repositionBtn.SetActive(false);
        })
        .OnComplete(() => {
            player.GetComponent<Player>().isActive = true;
            Main.Instance.repositionBtn.SetActive(true);
        });

        coTimer = Start3();
        StartCoroutine(coTimer);
    }


    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds( 10f );
        
        player.GetComponent<Player>().isActive = false;
        Main.Instance.repositionBtn.SetActive(false);
        player.transform.DOLocalMove(startPlayerPos, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(startPlayerRo, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(startCameraRo, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            isZoom = false;
            player.GetComponent<Player>().isActive = true;
            Main.Instance.repositionBtn.SetActive(true);
        });

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
        animator.Play("bulk_outline_move");
        coTimer = Start4();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start4() 
    {
        yield return new WaitForSeconds( 1.5f );
        animator.Play("Pincette_outline_on");
        pincette.GetComponent<BoxCollider>().enabled = true;
        pincette.GetComponent<Clickable>().onMouseClick += ClickPincette;
    }

    private void ClickPincette ( GameObject target, Vector3 mousePos ) 
    {
        pincette.GetComponent<BoxCollider>().enabled = false;
        pincette.GetComponent<Clickable>().onMouseClick -= ClickPincette;

        player.transform.DOLocalMove(zoomPlayerPos, 1f).SetEase(Ease.OutCubic).SetDelay(3f);
        player.transform.DOLocalRotate(zoomPlayerRo, 1f).SetEase(Ease.OutCubic).SetDelay(3f);
        camera.transform
        .DOLocalRotate(zoomCameraRo, 1f)
        .SetEase(Ease.OutCubic)
        .SetDelay(3f)
        .OnStart(() => {
            isZoom = true;
            player.GetComponent<Player>().isActive = false;
            Main.Instance.repositionBtn.SetActive(false);
        })
        .OnComplete(() => {
            player.GetComponent<Player>().isActive = true;
            Main.Instance.repositionBtn.SetActive(true);
        });

        animator.Play("Pincette_move");
        coTimer = Start5();
        StartCoroutine(coTimer);
    }


    private IEnumerator Start5() 
    {
        yield return new WaitForSeconds( 5f );
        Main.Instance.PlayAudio(audioClips[3]);
        yield return new WaitForSeconds( 8f );

        player.GetComponent<Player>().isActive = false;
        Main.Instance.repositionBtn.SetActive(false);
        player.transform.DOLocalMove(startPlayerPos, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(startPlayerRo, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(startCameraRo, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            isZoom = false;
            player.GetComponent<Player>().isActive = true;
            Main.Instance.repositionBtn.SetActive(true);
        });
        
        Main.Instance.PlayAudio(audioClips[4], () => {
            bulkUi.SetActive(true);
            coTimer = Start6();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start6() 
    {
        yield return new WaitForSeconds( 5f );
        bulkUi.SetActive(false);
        Main.Instance.PlayAudio(audioClips[5], () => {
            animator.Play("CarbonTape_outline_on");
            carbonTape.GetComponent<BoxCollider>().enabled = true;
            carbonTape.GetComponent<Clickable>().onMouseClick += ClickCarbonTape;
        });
    }

    private void ClickCarbonTape ( GameObject target, Vector3 mousePos ) 
    {
        carbonTape.GetComponent<BoxCollider>().enabled = false;
        carbonTape.GetComponent<Clickable>().onMouseClick -= ClickCarbonTape;
        player.transform.DOLocalMove(zoomPlayerPos, 1f).SetEase(Ease.OutCubic).SetDelay(5f);
        player.transform.DOLocalRotate(zoomPlayerRo, 1f).SetEase(Ease.OutCubic).SetDelay(5f);
        camera.transform
        .DOLocalRotate(zoomCameraRo, 1f)
        .SetEase(Ease.OutCubic)
        .SetDelay(5f)
        .OnStart(() => {
            isZoom = true;
            player.GetComponent<Player>().isActive = false;
            Main.Instance.repositionBtn.SetActive(false);
        })
        .OnComplete(() => {
            player.GetComponent<Player>().isActive = true;
        });

        animator.Play("CarbonTape_move");
        coTimer = Ended();
        StartCoroutine(coTimer);
    }


    private IEnumerator Ended() 
    {
        yield return new WaitForSeconds( 12.0f );
        this.EndSection();
    }

    public override void ResetSection () 
    {
        Main.Instance.StopAudio();
        animator.Rebind();
        target.SetActive(false);
        holder.GetComponent<Clickable>().onMouseClick -= ClickHolder;
        nickelCarbonTape.GetComponent<Clickable>().onMouseClick -= ClickNickelCarbonTape;
        bulk.GetComponent<Clickable>().onMouseClick -= ClickBulk;
        pincette.GetComponent<Clickable>().onMouseClick -= ClickPincette;
        carbonTape.GetComponent<Clickable>().onMouseClick -= ClickCarbonTape;
        bulkUi.SetActive(false);
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}
