using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerQueue: MonoBehaviour
{
    private static string[] firstNames = new string[]
    {
        "Carol", "Adam", "Maria", "John", "Leila", "Chris", "Nina", "David",
        "Sophie", "Liam", "Emma", "Noah", "Olivia", "Ava", "Mason",
        "Lucas", "Ethan", "Mia", "Isabella", "James", "Logan", "Amelia",
        "Elijah", "Harper", "Benjamin"
    };

    private static char[] lastInitials = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    //queue declaration
    private Queue<string> loginQueue = new Queue<string>();

    void Start()
    {
        //creates the initial queue based on requirements
        int initialCount = Random.Range(4, 7);

        for (int i = 0; i < initialCount; i++)
        {
            loginQueue.Enqueue(GetRandomPlayerName());
        }

        //logged the initial queue with LINQ .ToList
        List<string> players = loginQueue.ToList();
        Debug.Log($"Initial login queue created. There are {players.Count} players in the queue: {string.Join(", ", players)}");

        InvokeRepeating(nameof(AddPlayer), 4f, 3f);
        InvokeRepeating(nameof(LoginPlayer), 2f, 3f);
    }

    //method to generate random name
    string GetRandomPlayerName()
    {
        string first = firstNames[Random.Range(0, firstNames.Length)];
        char initial = lastInitials[Random.Range(0, lastInitials.Length)];
        return $"{first} {initial}.";
    }

    //method to add player to login queue
    void AddPlayer()
    {
        string newPlayer = GetRandomPlayerName();
        loginQueue.Enqueue(newPlayer);

        Debug.Log($"{newPlayer} is trying to login and added to the login queue.");
    }

    //method to dequeue player and log them in
    void LoginPlayer()
    {
        if (loginQueue.Count > 0)
        {
            string player = loginQueue.Dequeue();
            Debug.Log($"{player} is now inside the game.");
        }
        else
        {
            Debug.Log("Login server is idle. No players are waiting.");
        }
    }
}

