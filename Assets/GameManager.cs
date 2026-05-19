using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Progress")]
    public bool openedLaptop;
    public bool openedBook;
    public bool mriCompleted;
    public bool xrayCompleted;
    public bool bloodTestViewed;
    public bool correctMedicineGiven;

    [Header("Required Tests For This Patient")]
    public bool mriRequired = true;
    public bool xrayRequired = true;
    public bool bloodRequired = true;

    [Header("UI")]
    public GameObject bloodTestUI;
    public GameObject evaluationUI;

    [Header("Evaluation Texts")]
    public TextMeshProUGUI diagnosisResult;
    public TextMeshProUGUI medicineResult;
    public TextMeshProUGUI treatmentResult;
    public TextMeshProUGUI finalScore;

    [Header("Audio")]
    public AudioSource successSound;
    public AudioSource failSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MarkLaptopOpened()
    {
        openedLaptop = true;
    }

    public void MarkBookOpened()
    {
        openedBook = true;
    }

    public void OpenBloodTest()
    {
        if (bloodTestUI != null)
            bloodTestUI.SetActive(true);

        bloodTestViewed = true;
    }

    public void CloseBloodTest()
    {
        if (bloodTestUI != null)
            bloodTestUI.SetActive(false);
    }

    public void SetMRICompleted()
    {
        mriCompleted = true;
    }

    public void SetXRayCompleted()
    {
        xrayCompleted = true;
    }

    public void FinishTreatment(bool medicineIsCorrect)
    {
        correctMedicineGiven = medicineIsCorrect;
        ShowEvaluation();
    }

    public void ShowEvaluation()
    {
        if (evaluationUI != null)
            evaluationUI.SetActive(true);

        int score = 0;
        int total = 0;

        total++;
        if (openedLaptop) score++;

        total++;
        if (openedBook) score++;

        if (mriRequired)
        {
            total++;
            if (mriCompleted) score++;
        }

        if (xrayRequired)
        {
            total++;
            if (xrayCompleted) score++;
        }

        if (bloodRequired)
        {
            total++;
            if (bloodTestViewed) score++;
        }

        total++;
        if (correctMedicineGiven) score++;

        if (diagnosisResult != null)
        {
            diagnosisResult.text =
                "Diagnosis steps:\n" +
                "- Laptop opened: " + YesNo(openedLaptop) + "\n" +
                "- Medical book checked: " + YesNo(openedBook) + "\n" +
                "- MRI completed: " + YesNo(mriCompleted) + "\n" +
                "- X-Ray completed: " + YesNo(xrayCompleted) + "\n" +
                "- Blood test viewed: " + YesNo(bloodTestViewed);
        }

        if (medicineResult != null)
        {
            medicineResult.text = correctMedicineGiven
                ? "Medicine: Correct medicine was given."
                : "Medicine: Wrong medicine was given.";
        }

        if (treatmentResult != null)
        {
            treatmentResult.text = score == total
                ? "Treatment completed successfully."
                : "Treatment is incomplete. Some required steps were missed.";
        }

        if (finalScore != null)
        {
            finalScore.text = "Final Score: " + score + " / " + total;
        }

        if (correctMedicineGiven && score == total)
        {
            if (successSound != null) successSound.Play();
        }
        else
        {
            if (failSound != null) failSound.Play();
        }
    }

    private string YesNo(bool value)
    {
        return value ? "Done" : "Missing";
    }
}