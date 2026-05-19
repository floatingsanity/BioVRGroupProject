using UnityEngine;
using TMPro;

public class BookController : MonoBehaviour
{
    public GameObject bookUI;
    public TextMeshProUGUI diseaseName;
    public TextMeshProUGUI diseaseDescription;
    public AudioSource pageSound;

    private int currentIndex = 0;

    private string[] diseases =
    {
        "Pneumonia",
        "Anemia",
        "Migraine"
    };

    private string[] descriptions =
    {
        "Symptoms: Cough, fever, chest pain, shortness of breath\nTests: X-Ray + Blood Test\nTreatment: Amoxicillin",
        "Symptoms: Fatigue, dizziness, pale skin, shortness of breath\nTests: Blood Test\nTreatment: Iron Supplements",
        "Symptoms: Severe headache, nausea, light sensitivity\nTests: MRI if severe or unusual\nTreatment: Sumatriptan"
    };

    public void OpenBook()
    {
        bookUI.SetActive(true);
        UpdateUI();
    }

    public void NextDisease()
    {
        currentIndex = (currentIndex + 1) % diseases.Length;
        UpdateUI();

        if (pageSound != null)
            pageSound.Play();
    }

    public void CloseBook()
    {
        bookUI.SetActive(false);
    }

    private void UpdateUI()
    {
        diseaseName.text = diseases[currentIndex];
        diseaseDescription.text = descriptions[currentIndex];
    }
}
