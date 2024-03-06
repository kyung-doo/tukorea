using UnityEngine;
using DG.Tweening;

public abstract class SectionBase : MonoBehaviour
{
    [SerializeField]
    protected Vector3 startPlayerPos;

    [SerializeField]
    protected Vector3 startPlayerRo;

    [SerializeField]
    protected Vector3 startCameraRo;

    
    protected GameObject player;

    protected GameObject camera;


    public delegate void OnSectionEnd();

    public event OnSectionEnd onSectionEnd;

    public delegate void OnSectionStart();

    public event OnSectionEnd onSectionStart;


    void Awake()
    {
        player = GameObject.Find("Player");
        camera = GameObject.Find("Camera");
    }

    public virtual void StartSection ( bool isFirst = false ) 
    {
        Ease ease = Ease.OutCubic;
        if(isFirst) 
        {
            ease = Ease.InOutCubic;
        }
        player.transform.DOLocalMove(startPlayerPos, 3f).SetEase(ease);
        player.transform.DOLocalRotate(startPlayerRo, 3f).SetEase(ease);
        camera.transform.DOLocalRotate(startCameraRo, 3f)
        .SetEase(ease)
        .OnComplete(() => {
            if(onSectionStart != null) onSectionStart();
        });
        
    }

    public virtual void RepositionSection ()
    {
        player.transform.DOLocalMove(startPlayerPos, 3f).SetEase(Ease.OutCubic);
        player.transform.DOLocalRotate(startPlayerRo, 3f).SetEase(Ease.OutCubic);
        camera.transform.DOLocalRotate(startCameraRo, 3f).SetEase(Ease.OutCubic);
    }

    public abstract void ResetSection();


    public virtual void EndSection () 
    {
        if(onSectionEnd != null) onSectionEnd();
    }
}
