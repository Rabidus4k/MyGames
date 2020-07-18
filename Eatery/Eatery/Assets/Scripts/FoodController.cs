using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _slots;
    [SerializeField]
    private GameObject[] _prefs;
    private static int random;
    private static GameObject[] _created;
    public static FoodController inst;
    private void Start()
    {
        inst = this;
        _created = new GameObject[_slots.Length];
        StartCoroutine("WantEat");
        StartCoroutine("Eda");
    }

    public static void SpawnFood()
    {
        if (Slot.Count >= inst._slots.Length)
            return;

        random = Random.Range(0, inst._prefs.Length);
        _created[Slot.Count] = Instantiate(inst._prefs[random], inst._slots[Slot.Count].transform.position, Quaternion.identity);
        Slot.Count++;
    }

    public static GameObject TakeFood()
    {
        Destroy(_created[Slot.Count - 1]);
        _created[Slot.Count - 1] = null;
        Slot.Count--;
        return inst._prefs[random];
    }


    IEnumerator Eda()
    {
        yield return new WaitForSeconds(3f);

        if (Slot.Count < 4)
        {
            PovarMove.StartMove();
        }
        StartCoroutine("Eda");

    }
    IEnumerator WantEat()
    {
        yield return new WaitForSeconds(3f);


        if (City.EatingCount < 3)
        {
            int rand = Random.Range(0, 3);
            GameObject currentCity = GameObject.FindGameObjectWithTag("City" + rand.ToString());
            while (null != currentCity && currentCity.GetComponent<City>().isEating)
            {
                rand = Random.Range(0, 3);
                currentCity = GameObject.FindGameObjectWithTag("City" + rand.ToString());
            }

            if (null != currentCity)
                currentCity.GetComponent<City>().WantEat();
            
        }
       
        StartCoroutine("WantEat");


    }
}
