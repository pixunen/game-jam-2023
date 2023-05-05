using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    // Example word list, replace with your own list or API
    private static List<string> wordList = new List<string>
    {
        "BIRD", "OCEAN", "RIVER", "FOREST", "FLOWER", "BUTTERFLY", "EAGLE",
        "PANDA", "KOALA", "JAGUAR", "LEOPARD", "GORILLA", "ORANGUTAN", "CHIMPANZEE",
        "DOLPHIN", "WHALE", "PLATYPUS", "GIRAFFE", "KANGAROO", "RHINOCEROS",
        "ANTELOPE", "BUFFALO", "PELICAN", "PENGUIN", "SALMON", "TURTLE",
        "COUGAR", "MEERKAT", "LION", "TIGER", "ZEBRA", "HIPPOPOTAMUS",
        "OCTOPUS", "CORAL", "SEAHORSE", "STARFISH", "SQUID", "JELLYFISH",
        "ALBATROSS", "WALRUS", "ARCTIC", "DESERT", "SAVANNA", "MOUNTAIN",
        "TUNDRA", "WETLAND", "ECOSYSTEM", "RAINFOREST", "PRAIRIE", "HABITAT",
        "LANGUAGE", "CULTURE", "BARRIER", "TRANSLATE", "INTERPRET", "GESTURE",
        "SLANG", "IDIOM", "PHRASE", "SPEECH", "ACCENT", "DIALECT", "CONTEXT",
        "AMBIGUITY", "MEANING", "SYNTAX", "SEMANTIC", "PRONUNCIATION", "CONVERSATION",
        "DIALOGUE", "MISUNDERSTAND", "EXPRESSION", "LINGUIST", "BILINGUAL",
        "MULTILINGUAL", "TRANSLATOR", "POLYGLOT", "SUBTITLE", "DUBBING",
        "VOICEOVER", "LOCALIZE", "ADAPTATION", "JARGON", "COGNATE",
        "FALSE_FRIEND", "ETYMOLOGY", "MORPHOLOGY", "GRAMMAR", "VOCABULARY",
        "METAPHOR", "SIMILE", "PROVERB", "ANALOGY", "SYNONYM", "ANTONYM",
        "HOMONYM", "PUN", "IRONY", "SARCASM", "RHETORIC", "EUPHEMISM"
    };


    public static string GenerateWord()
    {
        int index = Random.Range(0, wordList.Count);
        ShuffleSprites();
        return wordList[index];
    }

    private static void ShuffleSprites()
    {
        for (int i = wordList.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            string temp = wordList[i];
            wordList[i] = wordList[randomIndex];
            wordList[randomIndex] = temp;
        }
    }
}
