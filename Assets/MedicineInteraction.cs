using UnityEngine;
using TMPro;

public class MedicineInteraction : MonoBehaviour
{
    [Header("Medicine Data")]
    public string medicineName;
    public string medicineUsage;
    public bool isCorrectMedicine;

    [Header("Hover UI")]
    public GameObject hoverUI;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI usageText;

    [Header("Audio")]
    public AudioSource grabSound;

    private bool isGrabbed = false;

    public void OnHoverEnter()
    {
        if (isGrabbed) return;

        if (hoverUI != null)
            hoverUI.SetActive(true);

        if (nameText != null)
            nameText.text = medicineName;

        if (usageText != null)
            usageText.text = medicineUsage;
    }

    public void OnHoverExit()
    {
        if (hoverUI != null)
            hoverUI.SetActive(false);
    }

    public void OnGrab()
    {
        isGrabbed = true;

        if (hoverUI != null)
            hoverUI.SetActive(false);

        if (grabSound != null)
            grabSound.Play();
    }

    public void OnRelease()
    {
        isGrabbed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Patient"))
        {
            if (hoverUI != null)
                hoverUI.SetActive(false);

            if (GameManager.Instance != null)
                GameManager.Instance.FinishTreatment(isCorrectMedicine);
        }
    }
}