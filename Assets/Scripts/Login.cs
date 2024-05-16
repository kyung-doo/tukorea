
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{

    [SerializeField]
    private InputField idInput;

    [SerializeField]
    private InputField passInput;

    [SerializeField]
    private Button enterBtn;

    [SerializeField]
    private MessageDialog alert;

    [SerializeField]
    private string loadScene;
    



    private void Awake()
    {
        
        enterBtn.onClick.AddListener(OnClickEnter);
    }

    private void OnClickEnter () 
    {
        if(idInput.text == "") {
            alert.ShowMessage("아이디를 입력해 주세요.", () => {
                idInput.Select();
            });
            return;
        } 

        if(passInput.text == "") {
            alert.ShowMessage("패스워드를 입력해 주세요.");
            passInput.Select();
            return;
        } 

        StartCoroutine(StartLogin());

        // SceneManager.LoadScene(loadScene, LoadSceneMode.Single);
    }

    private IEnumerator StartLogin()
    {
        UnityWebRequest request;
        using (request = UnityWebRequest.Get("http://117.52.84.30/api/login?memberId="+idInput.text+"&memberPw="+passInput.text))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                LoginData loginData = JsonUtility.FromJson<LoginData>(request.downloadHandler.text);
                PlayerPrefs.SetString("loginData", request.downloadHandler.text);
                PlayerPrefs.SetString("LabName", loadScene);
                Debug.Log(JsonUtility.ToJson(loginData));
                

                if(loginData.result == "1") 
                {
                    bool isStudy = true;

                    if(loadScene == "Lab2" && loginData.data.aday == "2") 
                    {
                        isStudy = false;
                    }
                    if(loadScene == "Lab" && loginData.data.bday == "2") 
                    {
                        isStudy = false;
                    }
                    if(loadScene == "Lab3" && loginData.data.cday == "2") 
                    {
                        isStudy = false;
                    }

                    if(isStudy)
                    {
                        SceneManager.LoadScene(loadScene, LoadSceneMode.Single);
                    }
                    else
                    {
                        alert.ShowMessage("교육기간이 만료되었습니다.");
                    }
                } 
                else 
                {
                    alert.ShowMessage("아이디 또는 패스워드를 확인해 주세요.");
                }
            }
        }
    }

    

}
