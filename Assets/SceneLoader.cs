
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMRI()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadXRay()
    {
        SceneManager.LoadScene(2);
    }

    public void FinishMRIAndReturn()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.SetMRICompleted();

        SceneManager.LoadScene(0);
    }

    public void FinishXRayAndReturn()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.SetXRayCompleted();

        SceneManager.LoadScene(0);
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(0);
    }
}
