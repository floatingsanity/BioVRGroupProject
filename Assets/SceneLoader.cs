
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMRI()
    {
        SceneManager.LoadScene("MRI_Room");
    }

    public void LoadXRay()
    {
        SceneManager.LoadScene("XRay_Room");
    }

    public void FinishMRIAndReturn()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.SetMRICompleted();

        SceneManager.LoadScene("MainRoom");
    }

    public void FinishXRayAndReturn()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.SetXRayCompleted();

        SceneManager.LoadScene("MainRoom");
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("MainRoom");
    }
}
