using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Networking;


public class Section1_3 : SectionBase
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

    private Vector3 zoomPlayerPos = new Vector3(3.34241962f, 0.696435094f, 4.6283226f);
    private Vector3 zoomPlayerRo = new Vector3(0f, -0.001f, 0f);
    private Vector3 zoomCameraRo = new Vector3(43.658f, 0f, 0f);

    private IEnumerator coTimer = null;

    private bool isZoom = false;


    public override void StartSection ( bool isFirst = false ) 
    {
        Debug.Log("startSection3");
        door.GetComponent<BoxCollider>().enabled = false;
        prop.GetComponent<BoxCollider>().enabled = false;
        propBtn.GetComponent<BoxCollider>().enabled = false;
        tongs.GetComponent<BoxCollider>().enabled = false;
        coTimer = Start1();
        StartCoroutine(coTimer);
        base.StartSection(isFirst);
        isZoom = false;
        Debug.Log("initIndex : " + Main.Instance.initIndex + ", ??????????????"+Main.Instance.loginData.data.b3);
        if(Main.Instance.initIndex == 2 && Main.Instance.loginData.data.b3 == "0")
        {
            StartCoroutine(SaveContent("1"));
        }
    }

    private IEnumerator Start1() 
    {
        yield return new WaitForSeconds( 3.5f );
        Main.Instance.PlayAudio(audioClips[0], () => {
            animator.Play("Xray_outline_on");
            door.GetComponent<BoxCollider>().enabled = true;
            door.GetComponent<Clickable>().onMouseClick += ClickDoor;
        });
        player.GetComponent<Player>().isActive = true;
    }


    private void ClickDoor ( GameObject target, Vector3 mousePos ) 
    {
        door.GetComponent<BoxCollider>().enabled = false;
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor;
        animator.Play("Xray_door_open");
        coTimer = Start2();
        StartCoroutine(coTimer);
        Main.Instance.repositionBtn.SetActive(false);
    }

    private IEnumerator Start2() 
    {
        yield return new WaitForSeconds(1f);
        isZoom = true;
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
                prop.GetComponent<BoxCollider>().enabled = true;
                prop.GetComponent<Clickable>().onMouseClick += Clickprop1;
            });
            Main.Instance.repositionBtn.SetActive(true);
        });
    }

    private void Clickprop1 ( GameObject target, Vector3 mousePos ) 
    {
        prop.GetComponent<BoxCollider>().enabled = false;
        prop.GetComponent<Clickable>().onMouseClick -= Clickprop1;
        animator.Play("Pan01_disappear");
        coTimer = Start3();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start3() 
    {
        yield return new WaitForSeconds(2f);
        prop.GetComponent<BoxCollider>().enabled = true;
        prop.GetComponent<Clickable>().onMouseClick += Clickprop2;
    }

    private void Clickprop2 ( GameObject target, Vector3 mousePos ) 
    {
        prop.GetComponent<BoxCollider>().enabled = false;
        prop.GetComponent<Clickable>().onMouseClick -= Clickprop2;
        animator.Play("60_disappear");
        coTimer = Start4();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start4() 
    {
        yield return new WaitForSeconds(4f);
        Main.Instance.PlayAudio(audioClips[2], () => {
            animator.Play("03_outline_on");
            propBtn.GetComponent<BoxCollider>().enabled = true;
            propBtn.GetComponent<Clickable>().onMouseClick += ClickpropBtn;
        });
    }

    private void ClickpropBtn ( GameObject target, Vector3 mousePos ) 
    {
        propBtn.GetComponent<BoxCollider>().enabled = false;
        propBtn.GetComponent<Clickable>().onMouseClick -= ClickpropBtn;
        animator.Play("03_move");    
        coTimer = Start5();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start5() 
    {
        yield return new WaitForSeconds(2f);
        Main.Instance.PlayAudio(audioClips[3], () => {
            animator.Play("Pan01_appear");
            prop.GetComponent<BoxCollider>().enabled = true;
            prop.GetComponent<Clickable>().onMouseClick += Clickprop3;
        });
    }

    private void Clickprop3 ( GameObject target, Vector3 mousePos ) 
    {
        prop.GetComponent<BoxCollider>().enabled = false;
        prop.GetComponent<Clickable>().onMouseClick -= Clickprop3;
        animator.Play("Pan01_move");
        coTimer = Start6();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start6() 
    {
        yield return new WaitForSeconds(3f);
        Main.Instance.PlayAudio(audioClips[4], () => {
            animator.Play("Tongs_outline_on");
            tongs.GetComponent<BoxCollider>().enabled = true;
            tongs.GetComponent<Clickable>().onMouseClick += ClickTongs;
        });
    }

    private void ClickTongs ( GameObject target, Vector3 mousePos ) 
    {
        tongs.GetComponent<BoxCollider>().enabled = false;
        tongs.GetComponent<Clickable>().onMouseClick -= ClickTongs;
        animator.Play("Tongs_move");
        coTimer = Start7();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start7() 
    {
        yield return new WaitForSeconds(8f);
        player.GetComponent<Player>().isActive = false;
        player.transform.DOLocalMove(startPlayerPos, 1f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(startPlayerRo, 1f).SetEase(Ease.OutCubic);
        camera.transform
        .DOLocalRotate(startCameraRo, 1f)
        .SetEase(Ease.OutCubic)
        .OnComplete(() => {
            player.GetComponent<Player>().isActive = true;
            Main.Instance.repositionBtn.SetActive(true);
            coTimer = Start8();
            StartCoroutine(coTimer);
        });
        Main.Instance.repositionBtn.SetActive(false);
        isZoom = false;
    }

    private IEnumerator Start8() 
    {
        yield return new WaitForSeconds(0.5f);
        Main.Instance.PlayAudio(audioClips[5], () => {
            animator.Play("Xray_door_close_outline_on");
            door.GetComponent<BoxCollider>().enabled = true;
            door.GetComponent<Clickable>().onMouseClick += ClickDoor2;
        });
    }

    private void ClickDoor2 ( GameObject target, Vector3 mousePos ) 
    {
        door.GetComponent<BoxCollider>().enabled = false;
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor2;
        animator.Play("Xray_door_close");
        coTimer = Start9();
        StartCoroutine(coTimer);
    }

    private IEnumerator Start9() 
    {
        yield return new WaitForSeconds(2f);
        Main.Instance.PlayAudio(audioClips[6], () => {
            coTimer = Ended();
            StartCoroutine(coTimer);
        });
        
    }
    

    private IEnumerator Ended() 
    {
        yield return new WaitForSeconds( 1.0f );
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
        door.GetComponent<Clickable>().onMouseClick -= ClickDoor;
        prop.GetComponent<Clickable>().onMouseClick -= Clickprop1;
        prop.GetComponent<Clickable>().onMouseClick -= Clickprop2;
        propBtn.GetComponent<Clickable>().onMouseClick -= ClickpropBtn;
        prop.GetComponent<Clickable>().onMouseClick -= Clickprop3;
        tongs.GetComponent<Clickable>().onMouseClick -= ClickTongs;
        if(coTimer != null) StopCoroutine(coTimer);
    }

    public override void EndSection () {
        if(Main.Instance.initIndex == 2 && Main.Instance.loginData.data.b3 == "1")
        {
            StartCoroutine(SaveContent("2"));
        }
        base.EndSection();
    }

    private IEnumerator SaveContent( string status ) {
        UnityWebRequest request;
        Debug.Log("http://117.52.84.30/api/learnUpdate?memberSeq="+Main.Instance.loginData.data.memberSeq+"&b3=" + status);
        using (request = UnityWebRequest.Get("http://117.52.84.30/api/learnUpdate?memberSeq="+Main.Instance.loginData.data.memberSeq+"&b3=" + status))
        {
            yield return request.SendWebRequest();
            Main.Instance.loginData.data.b3 = status;
        }
    }

}