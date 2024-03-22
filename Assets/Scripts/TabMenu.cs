using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class TabMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject[] btns;

    [SerializeField]
    public Button openBtn;

    [SerializeField]
    public Sprite[] defaultSprites;

    [SerializeField]
    public Sprite[] activeSprites;

    private int _currentIndex = 0;

    public int currentIndex {
        get {
            return _currentIndex;
        }
        set {
            _currentIndex = value;
            setBtns();
            OpenMenu();
        }
    }

    public delegate void OnTabChange( int idx );

    public event OnTabChange onTabChange;

    private float openPosX;
    private float closePosX;

    private bool isOpen = true;


    private void Awake()
    {
        RectTransform rect = this.GetComponent<RectTransform>() as RectTransform;
        
        openPosX = rect.localPosition.x;
        closePosX = rect.localPosition.x - 26f;
        rect.localPosition = new Vector3(closePosX, rect.localPosition.y, 0);
        rect.DOLocalMoveX(openPosX, 0.6f).SetEase(Ease.OutCubic);

        int i = 0;
        foreach(GameObject btn in btns) 
        {
            int i2 = i;
            btn.GetComponent<Button>().onClick.AddListener(() => clickTab(i2));
            i++;
        }
        setBtns();

        openBtn.onClick.AddListener(() => {
            if(isOpen)  CloseMenu();
            else        OpenMenu();
        });
    }

    private void clickTab ( int idx ) 
    {
        if(currentIndex != idx)
        {
            currentIndex = idx;
            if(onTabChange != null) onTabChange(currentIndex);
        }
    }

    private void setBtns () 
    {
        int i = 0;
        foreach(GameObject btn in btns) 
        {
            if(currentIndex == i) {
                btn.GetComponent<Image>().sprite = activeSprites[i];
            } else {
                btn.GetComponent<Image>().sprite = defaultSprites[i];
            }
            i++;
        }
    }

    public void OpenMenu () 
    {
        RectTransform rect = this.GetComponent<RectTransform>() as RectTransform;
        rect.DOLocalMoveX(openPosX, 0.6f).SetEase(Ease.OutCubic);
        isOpen = true;
    }

    public void CloseMenu () 
    {
        RectTransform rect = this.GetComponent<RectTransform>() as RectTransform;
        rect.DOLocalMoveX(closePosX, 0.6f).SetEase(Ease.OutCubic);
        isOpen = false;
    }


}
