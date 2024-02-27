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


    void Awake()
    {
        player = GameObject.Find("Player");
        camera = GameObject.Find("Camera");
    }

    public virtual void StartSection ( bool isFirst = false ) 
    {
        if(isFirst) 
        {
            player.transform.DOLocalMove(startPlayerPos, 3f).SetEase(Ease.InOutCubic);
            player.transform.DOLocalRotate(startPlayerRo, 3f).SetEase(Ease.InOutCubic);
            camera.transform.DOLocalRotate(startCameraRo, 3f).SetEase(Ease.InOutCubic);
        }
        else 
        {
            player.transform.DOLocalMove(startPlayerPos, 3f).SetEase(Ease.OutCubic);
            player.transform.DOLocalRotate(startPlayerRo, 3f).SetEase(Ease.OutCubic);
            camera.transform.DOLocalRotate(startCameraRo, 3f).SetEase(Ease.OutCubic);
        }
        
    }

    public abstract void ResetSection();


    public virtual void EndSection () 
    {
        this.onSectionEnd();
    }
}
