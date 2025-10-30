using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Labb3_NET22.DataModels;   

public class Quiz
{
    private IEnumerable<Question> _questions;
    private string _title = string.Empty;
    public IEnumerable<Question> Questions => _questions;
    public string Title => _title;

    public Quiz()
    {
        _questions = new List<Question>();
        var list = (List<Question>)_questions;

        list.Add(new Question("1. In 1768, Captain James Cook set out to explore which ocean?",new string[]
        { "1: Pacific Ocean", "2: Atlantic Ocean","3: Indian Ocean","4: Arctic Ocean"},0));

        list.Add(new Question("2.What is actually electricity?", new string[]
        {"1: A flow of water","2: A flow of air","3: A flow of electrons","4: A flow of atoms" }, 2));

        list.Add(new Question("3. Which of the following is not an international organisation?", new string[]
            {"1: FIFA", "2: NATO","3: ASEAN","4: FBI" },2));

    }
    public void SetTitle(string title)
    {
        _title = title;
    }

    public Question GetRandomQuestion()
    {
        throw new NotImplementedException("A random Question needs to be returned here!");
    }

    public void AddQuestion(string statement, int correctAnswer, params string[] answers)
    {
        var question = new Question(statement, answers, correctAnswer);
        List<Question> list = (List<Question>) _questions;
        list.Add(question);
    }

    public void RemoveQuestion(int index)
    {
        throw new NotImplementedException("Question at requested index need to be removed here!");
    }
}