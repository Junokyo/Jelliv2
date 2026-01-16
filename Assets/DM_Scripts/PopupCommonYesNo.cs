using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PopupCommonYesNo : PopupCommon
{

    public Button retryButton;
    public string testUrl = "https://clients3.google.com/generate_204";


    public override void OnEventClose()
    {
        base.OnEventClose();

        Debug.Log("CLOSE PANEL");
    }
    public void CheckInternetNow(System.Action<bool> callback)
    {
       StartCoroutine(CheckConnection(callback));
    }

    public void CheckInternetNow()
    {
        StartCoroutine(CheckConnection());
    }

    private IEnumerator CheckConnection(System.Action<bool> callback)
    {
        using (var request = new UnityEngine.Networking.UnityWebRequest(testUrl))
        {
            request.timeout = 3;
            request.method = UnityEngine.Networking.UnityWebRequest.kHttpVerbHEAD;
            yield return request.SendWebRequest();

            bool hasInternet = !(request.result != UnityEngine.Networking.UnityWebRequest.Result.Success);

            callback?.Invoke(hasInternet);

            if (!hasInternet)
            {

                var popup = MonoSingleton<PopupManager>.Instance.Open(PopupType.PopupCommonYesNo);
                yield return new WaitUntil(() => popup != null);


                retryButton = popup.transform.Find("RetryButton")?.GetComponent<Button>();

                if (retryButton != null)
                {
                    retryButton.gameObject.SetActive(true);
                    retryButton.onClick.RemoveAllListeners();
                    retryButton.onClick.AddListener(() => StartCoroutine(OnRetry()));
                }
                else
                {
                    Debug.LogError("Not found RetryButton!");
                }
            }
            else
            {
                //MonoSingleton<PopupCommonYesNo>.Instance.OnEventClose();
                //OnEventClose();
            }
        }
    }

    private IEnumerator CheckConnection()
    {
        using (var request = new UnityEngine.Networking.UnityWebRequest(testUrl))
        {
            request.timeout = 3;
            request.method = UnityEngine.Networking.UnityWebRequest.kHttpVerbHEAD;
            yield return request.SendWebRequest();

            bool hasInternet = !(request.result != UnityEngine.Networking.UnityWebRequest.Result.Success);

            //callback?.Invoke(hasInternet);

            if (!hasInternet)
            {
                var popup = MonoSingleton<PopupManager>.Instance.Open(PopupType.PopupCommonYesNo);
                yield return new WaitUntil(() => popup != null);


                retryButton = popup.transform.Find("RetryButton")?.GetComponent<Button>();

                if (retryButton != null)
                {
                    retryButton.gameObject.SetActive(true);
                    retryButton.onClick.RemoveAllListeners();
                    retryButton.onClick.AddListener(() => StartCoroutine(OnRetry()));
                }
                else
                {
                    Debug.LogError("Not found RetryButton!");
                }
            }
            else
            {
                //base.OnEventClose();
            }
        }
    }

    public IEnumerator OnRetry()
    {
        Debug.Log("Chay vao nut OnRetry ");
        retryButton.interactable = false;
        yield return new WaitForSeconds(0.5f);
        using (var request = new UnityEngine.Networking.UnityWebRequest(testUrl))
        {
            request.timeout = 3;
            request.method = UnityEngine.Networking.UnityWebRequest.kHttpVerbHEAD;
            yield return request.SendWebRequest();

            bool hasInternet = !(request.result != UnityEngine.Networking.UnityWebRequest.Result.Success);

            if (hasInternet)
            {
                //Internet comeback
                Debug.Log("hasInternet :" + hasInternet);
                OnEventClose();
            }
            else
            {
                retryButton.interactable = true;
            }
        }
    }

}
