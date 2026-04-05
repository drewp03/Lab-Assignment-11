using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardGameSimulator : MonoBehaviour
{
    private string[] ranks = new string[] { "K", "Q", "J", "A" };
    private string[] suits = new string[] { "\u2660", "\u2663", "\u2665", "\u2666" };

    void Start()
    {
        //takes in K, then adds each suit to K, onto Q and so on and so forth
        List<string> deck = (from rank in ranks
                             from suit in suits
                             select $"{rank}{suit}").ToList();

        //LINQ command to shuffy deck
        deck = deck.OrderBy(x => Random.value).ToList();

        //draw your initial 4 cards
        List<string> hand = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            hand.Add(deck[0]);
            deck.RemoveAt(0);
        }

        Debug.Log($"I made the initial deck and draw. My hand is: {string.Join(", ", hand)}.");

        //while loop for the game
        while (true)
        {
            //counts number of suits in your hand
            var suitGroups = hand.GroupBy(card => card.Last()) //grouping using the last character, which is suit
                                 .Select(g => new { Suit = g.Key, Count = g.Count() });

            bool hasThreeSameSuit = suitGroups.Any(g => g.Count >= 3);

            if (hasThreeSameSuit)
            {
                Debug.Log($"The game is WON with hand: {string.Join(", ", hand)}.");
                break;
            }

            //checks if the deck is empty
            if (deck.Count == 0)
            {
                Debug.Log("The deck is empty. The game is LOST.");
                break;
            }

            //randomly discards a card from your hand
            int discardIndex = Random.Range(0, hand.Count);
            string discarded = hand[discardIndex];
            hand.RemoveAt(discardIndex);

            //draw a random card from the top of the deck and remove that card from the deck
            string drawn = deck[0];
            deck.RemoveAt(0);
            hand.Add(drawn);

            Debug.Log($"I discarded {discarded} and drew {drawn}. My hand is: {string.Join(", ", hand)}. This is not a winning hand. I will attempt to play another round.");
        }
    }
}