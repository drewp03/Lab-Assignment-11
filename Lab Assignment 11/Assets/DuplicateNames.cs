using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DuplicateNames : MonoBehaviour
{
    private static string[] firstNames = new string[]
    {
        "Carol", "Adam", "Maria", "John", "Leila", "Chris", "Nina", "David",
        "Sophie", "Liam", "Emma", "Noah", "Olivia", "Ava", "Mason",
        "Lucas", "Ethan", "Mia", "Isabella", "James", "Logan", "Amelia",
        "Elijah", "Harper", "Benjamin"
    };

    void Start()
    {
        //builds the array of names with repetition
        string[] nameArray = new string[15];
        for (int i = 0; i < nameArray.Length; i++)
        {
            int randomIndex = Random.Range(0, firstNames.Length);
            nameArray[i] = firstNames[randomIndex];
        }

        //logs the full array
        Debug.Log($"Created the name array: {string.Join(", ", nameArray)}");

        //using hashsets, find out if there are any duplicate names
        HashSet<string> seen = new HashSet<string>();
        HashSet<string> duplicates = new HashSet<string>();

        foreach (string name in nameArray)
        {
            if (!seen.Add(name))
            {
                duplicates.Add(name);
            }
        }

        //report all of the duplicate names
        if (duplicates.Count > 0)
        {
            Debug.Log($"The array has duplicate names: {string.Join(", ", duplicates)}");
        }
        else
        {
            Debug.Log("The array has no duplicate names.");
        }
    }
}