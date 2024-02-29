using System.Collections;
using UnityEngine;
using DG.Tweening;


public class Section3 : SectionBase
{

    [SerializeField]
    public AudioClip[] audioClips;


    [SerializeField]
    public Animator animator;

    [SerializeField]
    public GameObject door;

    [SerializeField]
    public GameObject prop;

    [SerializeField]
    public GameObject propBtn;

    [SerializeField]
    public GameObject tongs;


    private Vector3 zoomPlayerPos = new Vector3(3.372322f, 0.6167073f, 4.592638f);
    private Vector3 zoomPlayerRo = new Vector3(0f, -0.001f, 0f);
    private Vector3 zoomCameraRo = new Vector3(43.658f, 0f, 0f);

    private IEnumerator coTimer = null;


    public override void StartSection ( bool isFirst = false ) {
        Debug.Log("startSection3");
        coTimer = Start1();
        StartCoroutine(coTimer);
        base.StartSection(isFirst);
    }

    private IEnumerator Start1() {
        yield return new WaitForSeconds( 3.5f );
        Main.Instance.PlayAudio(audioClips[0], () => {
            animator.Play("Xray_outline_on");
            door.GetComponent<Clickable>().onMouseClick += ClickDoor;
        });
        player.GetComponent<Player>().isActive = true;
    }


    private void ClickDoor ( GameObject target, Vector3 mousePos ) 
    {
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor;
        animator.Play("Xray_door_open");
        coTimer = Start2();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start2() {
        yield return new WaitForSeconds(1f);
        player.GetComponent<Player>().isActive = false;
        player.transform.DOLocalMove(zoomPlayerPos, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(zoomPlayerRo, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(zoomCameraRo, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            player.GetComponent<Player>().isActive = true;
            Main.Instance.PlayAudio(audioClips[1], () => {
                animator.Play("Pan01_outline_on");
                prop.GetComponent<Clickable>().onMouseClick += Clickprop1;
            });
        });
    }

    private void Clickprop1 ( GameObject target, Vector3 mousePos ) 
    {
        prop.GetComponent<Clickable>().onMouseClick -= Clickprop1;
        animator.Play("Pan01_disappear");
        coTimer = Start3();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start3() {
        yield return new WaitForSeconds(2f);
        prop.GetComponent<Clickable>().onMouseClick += Clickprop2;
    }

    private void Clickprop2 ( GameObject target, Vector3 mousePos ) 
    {
        prop.GetComponent<Clickable>().onMouseClick -= Clickprop2;
        animator.Play("60_disappear");
        coTimer = Start4();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start4() {
        yield return new WaitForSeconds(4f);
        Main.Instance.PlayAudio(audioClips[2], () => {
            animator.Play("03_outline_on");
            propBtn.GetComponent<Clickable>().onMouseClick += ClickpropBtn;
        });
    }

    private void ClickpropBtn ( GameObject target, Vector3 mousePos ) 
    {
        propBtn.GetComponent<Clickable>().onMouseClick -= ClickpropBtn;
        animator.Play("03_move");    
        coTimer = Start5();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start5() {
        yield return new WaitForSeconds(2f);
        Main.Instance.PlayAudio(audioClips[3], () => {
            animator.Play("Pan01_appear");
            prop.GetComponent<Clickable>().onMouseClick += Clickprop3;
        });
    }

    private void Clickprop3 ( GameObject target, Vector3 mousePos ) 
    {
        prop.GetComponent<Clickable>().onMouseClick -= Clickprop3;
        animator.Play("Pan01_move");
        coTimer = Start6();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start6() {
        yield return new WaitForSeconds(3f);
        Main.Instance.PlayAudio(audioClips[4], () => {
            animator.Play("Tongs_outline_on");
            tongs.GetComponent<Clickable>().onMouseClick += ClickTongs;
        });
    }

    private void ClickTongs ( GameObject target, Vector3 mousePos ) 
    {
        tongs.GetComponent<Clickable>().onMouseClick -= ClickTongs;
        animator.Play("Tongs_move");
        coTimer = Start7();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start7() {
        yield return new WaitForSeconds(8f);
        player.GetComponent<Player>().isActive = false;
        player.transform.DOLocalMove(startPlayerPos, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(startPlayerRo, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(startCameraRo, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            player.GetComponent<Player>().isActive = true;
            coTimer = Start8();
            StartCoroutine(coTimer);
        });
    }

    private IEnumerator Start8() {
        yield return new WaitForSeconds(0.5f);
        Main.Instance.PlayAudio(audioClips[5], () => {
            animator.Play("Xray_door_close_outline_on");
            door.GetComponent<Clickable>().onMouseClick += ClickDoor2;
        });
    }

    private void ClickDoor2 ( GameObject target, Vector3 mousePos ) 
    {
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor2;
        animator.Play("Xray_door_close");
        coTimer = Start9();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start9() {
        yield return new WaitForSeconds(2f);
        Main.Instance.PlayAudio(audioClips[6], () => {
            coTimer = Ended();
            StartCoroutine(coTimer);
        });
    }
    

    private IEnumerator Ended() {
        yield return new WaitForSeconds( 1.0f );
        this.EndSection();
    }

    public override void ResetSection () {
        Main.Instance.StopAudio();
        animator.Rebind();
        animator.Update(0f);
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor;
        prop.GetComponent<Clickable>().onMouseClick -= Clickprop1;
        prop.GetComponent<Clickable>().onMouseClick -= Clickprop2;
        propBtn.GetComponent<Clickable>().onMouseClick -= ClickpropBtn;
        prop.GetComponent<Clickable>().onMouseClick -= Clickprop3;
        tongs.GetComponent<Clickable>().onMouseClick -= ClickTongs;
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () {
        base.EndSection();
    }

}
