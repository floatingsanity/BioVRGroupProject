using UnityEngine;

public class BloodTestButton : MonoBehaviour
{
    public GameObject bloodTestUI;
    public AudioSource buttonSound;
    public GameManager gameManager;

    public void OpenBloodTest()
    {
        bloodTestUI.SetActive(true);

        if (buttonSound != null)
            buttonSound.Play();

        if (gameManager != null)
            gameManager.bloodTestViewed = true;
    }
}