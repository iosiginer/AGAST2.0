
using AGAST2.Infrastructure.LevelTypes;
using AGAST2.Infrastructure;
using System;
using System.Collections.Generic;
using AGAST2.GameUI.DAL;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text.RegularExpressions;

namespace AGAST2.GameUI.Model
{
    public class Factory
    {
        private IDataRetriever dataBase;
        private QueryManager qManager;
        private Random randy;
        private int prevRand;
        private int factBankSize = 3;
        private Dictionary<int, string> QuestionsBank;

        public Factory()
        {
            randy = new Random();
            prevRand = -1;
            dataBase = DataRetriever.Instance;
            qManager = QueryManager.Instance;
            QuestionsBank = dataBase.GetQuestionDictionary();
        }

        
        public Question GetQuestion()
        {
            string subject = String.Empty;
            List<string> falseAnswers = new List<string>();
            int rand = randy.Next(1,QuestionsBank.Count);
            // Getting a random question making sure it exists and that its not the previous question
            while (!QuestionsBank.ContainsKey(rand) && rand!=prevRand)
            {
                rand = randy.Next(1, QuestionsBank.Keys.Max());
            }
            prevRand = rand;
            string phrase = QuestionsBank[rand];
            // Getting the query for the question and proccessing the data
            JArray jerry1 = dataBase.GetDataFromDB(qManager.GetQuestionQuery(rand));
            // Getting the question subject if it has one and trimming it
            if (HasPlaceholder(phrase))
            {
                foreach (JToken entry in jerry1)
                {
                    subject = entry["template"].ToString().TrimEnd('\r');
                }
            }
            // Getting the correct answer
            string correctAnswer = String.Empty;
            foreach (JToken entry in jerry1)
            {
                correctAnswer = entry["answer"].ToString().Trim();
            }
            // Getting the false answers for the question
            JArray jerry2 = dataBase.GetDataFromDB(qManager.GetFalseQuestionQuery(rand));
            foreach (JToken entry in jerry2)
            {
                falseAnswers.Add(entry["false_answer"].ToString());
            }
            return new Question(phrase, falseAnswers, correctAnswer, subject);
        }

        public Fact GetFact()
        {
            int rand = randy.Next(1, factBankSize);
            return new Fact();
        }

        public bool HasPlaceholder(string s)
        {
            return Regex.IsMatch(s, "{\\d+}");
        }

    }
}
