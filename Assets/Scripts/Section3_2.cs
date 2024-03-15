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
        // coTimer = Start2();
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
        
       
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () 
    {
        base.EndSection();
    }

}
