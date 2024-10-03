using System;
using System.Collections.Generic;

public class QuizService
{
    private List<Question> _questions;
    private Dictionary<int, int> _userAnswers; // To store the user's answers
    private int _score = 0;

    public QuizService()
    {
        _questions = LoadQuestions();
        _userAnswers = new Dictionary<int, int>(); // Initialize the dictionary
        ShuffleQuestions();
    }

    // Load sample questions
    private List<Question> LoadQuestions()
    {
        return new List<Question>
        {
            new Question
            {
                Text = "What is the capital of France?",
                Options = new List<string> { "Berlin", "Madrid", "Paris", "Bergen" },
                CorrectAnswerIndex = 2 // Correct answer is "Paris"
            },
            new Question
            {
                Text = "Which planet is known as the Red Planet?",
                Options = new List<string> { "Earth", "Mars", "Jupiter", "Saturn" },
                CorrectAnswerIndex = 1 // Correct answer is "Mars"
            },
            new Question
            {
                Text = "What is the largest ocean on Earth?",
                Options = new List<string> { "Indian Ocean", "Pacific Ocean", "Atlantic Ocean", "Arctic Ocean" },
                CorrectAnswerIndex = 1 // Correct answer is "Pacific Ocean"
            },
            new Question
            {
              Text = "What year did World War II end?",
              Options = new List<string> {"1945", "1918", "1939", "1963"},
              CorrectAnswerIndex = 0 // Correct answer is "1945"
            }
        };
    }

    // Shuffle questions randomly
    private void ShuffleQuestions()
    {
        Random rand = new Random();
        for (int i = _questions.Count - 1; i > 0; i--)
        {
            int j = rand.Next(0, i + 1); // Use i + 1 to get a proper range
            var temp = _questions[i];
            _questions[i] = _questions[j];
            _questions[j] = temp;
        }
    }

    // Retrieve the list of questions
    public List<Question> GetQuestions() => _questions;

    // Method to submit the answer and update the score
    public void SubmitAnswer(int questionIndex, int answerIndex)
    {
        // Store the user's answer for reference
        _userAnswers[questionIndex] = answerIndex;

        // Check if the answer is correct and update the score
        if (_questions[questionIndex].CorrectAnswerIndex == answerIndex)
        {
            _score++;
        }
    }

    // Method to get the final score
    public int GetScore() => _score;
}
