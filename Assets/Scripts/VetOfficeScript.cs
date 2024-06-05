using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VetOfficeScript : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public TMP_Text text;

    public Dictionary<string, string> symptoms = new Dictionary<string, string>(){
        {"Select a Symptom", ""},
        {"Fever", "When a horse has a higher than normal body temperature, it is often a sign of infection or inflammation.Possible reasons for a horse to catch a fever include: Gastrointestinal(digestive system) infections, Lamintis(hoof) injury, sepsis(rapid heart rate/ breathing)(Can cause death), West Nile Virus, wound infections, dental problems, organ issue, tick - borne diseases, heat stress."},
        {"Lameness", "Hoof issues, Poor Shoeing, infections, joint issues, trauma, neurological issues, poor conformation: Structural abnormalities or imbalances in a horse's body can lead to lameness over time.Overexertion: Excessive exercise or work without proper conditioning can cause lameness.Infections: Bacterial or viral infections affecting the joints or soft tissues can lead to lameness."},
        {"Abscess", "Foreign objects: Entry of foreign objects such as thorns, rocks, or debris into the hoof can cause a puncture wound, leading to an abscess.Infection: Bacterial infection of the hoof, often through a break in the hoof wall or sole, can lead to the formation of an abscess.Poor hoof care: Neglecting proper hoof care, such as infrequent trimming or shoeing, can result in uneven weight distribution and pressure points, increasing the likelihood of abscess formation.Trauma: Traumatic injuries to the hoof, such as bruising or excessive concussion, can predispose the area to infection and abscess formation.Complications from laminitis: In severe cases of laminitis, the disruption of blood flow to the hoof can lead to tissue damage and abscess formation.Inflammatory conditions: Conditions such as white line disease, where bacteria invade the inner layers of the hoof wall, can lead to abscess formation.Systemic illness: Underlying systemic illnesses or conditions that compromise the immune system can increase the susceptibility to hoof infections and abscesses.Poor environmental conditions: Prolonged exposure to wet or unsanitary conditions can soften the hoof and make it more susceptible to infection.Poor circulation: Conditions that affect circulation to the extremities, such as circulatory disorders or vascular diseases, can predispose the horse to abscess formation.Pre-existing hoof conditions: Certain hoof conditions, such as seedy toe or cracks, can create entry points for bacteria, increasing the risk of abscess formation."},
        {"Colic", "Colic in horses is intense stomach pain that can have various causes, from gas to twisted intestines, and it requires prompt veterinary care to prevent serious complications or even death."},
        {"Dehydration", "Dehydration in horses happens when they don't drink enough water or lose too much fluid, making them feel tired and causing dryness in their mouth and nose, which can be harmful if not treated promptly."},
        {"Dull eyes", "\"Dull eyes\" in horses mean their eyes don't look bright or alert, usually signaling they might be feeling unwell or tired, and it's essential to figure out why and help them feel better. You can help a horse with dull eyes by giving them water, good food, and a cozy place to rest, and by calling the vet if they don't seem better soon."},
        {"Weight Loss", "Weight loss in horses can occur due to various reasons such as poor nutrition, dental problems, parasites, illness, or stress. It's essential to assess their diet, dental health, and overall well-being, and consult with a vet to determine the underlying cause and develop a suitable treatment plan to help them regain weight and health."},
        {"Coughing", "Coughing in horses is like when people cough – it's a reflex to clear their airways. It can happen because of respiratory infections, allergies, or even dusty environments. Making sure they have clean air to breathe and checking with a vet if they keep coughing is important to keep them healthy."},
        {"Nasal Discharge", "asal discharge in horses is when fluid comes out of their nose, which can happen due to various reasons like respiratory infections, allergies, or irritants. It's important to monitor the discharge's color and consistency and consult with a vet if it's persistent, foul-smelling, or accompanied by other symptoms like coughing or fever."},
        {"Neurological", "Neurological issues in horses affect how they move or behave and can be caused by infections, injuries, or diseases. It's important to get a vet involved to figure out what's going on and how to help the horse feel better."},
    };

    public Sprite horseSprite;
    public Sprite feverSprite;
    public Sprite lamenessSprite;
    public Sprite abscessSprite;
    public Sprite colicSprite;
    public Sprite dehydrationSprite;
    public Sprite dulleyesSprite;
    public Sprite weightlossSprite;
    public Sprite coughingSprite;
    public Sprite nasaldischargeSprite;
    public Sprite neurologicalSprite;


    public Image image;


    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }


    // Start is called before the first frame update
    void Start()
    {
        dropdown.ClearOptions();
        //var a = new List<string>(symptoms.Keys);
        dropdown.AddOptions(new List<string>(symptoms.Keys));
        OnChangeDropdownOption();


        //foreach (string key in symptoms.Keys)
        //{
        //    //TMP_Dropdown.OptionData
        //    //dropdown.AddOptions(List<string>(symptoms.Keys));
        //}


    }



    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnChangeDropdownOption()
    {
        List<string> symptomsList = new List<string>(symptoms.Keys);
        string currentSymptom = symptomsList[dropdown.value];

        if (currentSymptom == "Select a Symptom") { image.sprite = horseSprite; }
        if (currentSymptom == "Fever") { image.sprite = feverSprite; }
        if (currentSymptom == "Lameness") { image.sprite = lamenessSprite; }
        if (currentSymptom == "Abscess") { image.sprite = abscessSprite; }
        if (currentSymptom == "Colic") { image.sprite = colicSprite; }
        if (currentSymptom == "Dehydration") { image.sprite = dehydrationSprite; }
        if (currentSymptom == "Dull eyes") { image.sprite = dulleyesSprite; }
        if (currentSymptom == "Weight Loss") { image.sprite = weightlossSprite; }
        if (currentSymptom == "Coughing") { image.sprite = coughingSprite; }
        if (currentSymptom == "Nasal Discharge") { image.sprite = nasaldischargeSprite; }
        if (currentSymptom == "Neurological") { image.sprite = neurologicalSprite; }

        print(currentSymptom);

        text.text = symptoms[currentSymptom];
    }
}
