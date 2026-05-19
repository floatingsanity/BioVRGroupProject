using UnityEngine;

public class PatientData : MonoBehaviour
{
    public GameObject laptopUI;
    public AudioSource laptopSound;

    private bool isOpen = false;

    public void ToggleLaptop()
    {
        isOpen = !isOpen;

        laptopUI.SetActive(isOpen);

        if (laptopSound != null)
        {
            laptopSound.Play();
        }
    }

    public void CloseLaptop()
    {
        isOpen = false;
        laptopUI.SetActive(false);
    }
}