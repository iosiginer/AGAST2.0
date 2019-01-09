
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
        private Dictionary<int, string> QuestionsBank;

        public Factory()
        {
            randy = new Random();
            prevRand = -1;
            dataBase = DataRetriever.Instance;
            qManager = QueryManager.Instance;
            QuestionsBank = dataBase.GetQuestionDictionary();
        }

        
        // TODO finish this...
        // just need to access the jarray correctly to properly build the question
        public Question GetQuestion()
        {
            List<string> falseAnswers = new List<string>();
            int rand = randy.Next(1,QuestionsBank.Count);
            while (!QuestionsBank.ContainsKey(rand) && rand!=prevRand)
            {
                rand = randy.Next(1, QuestionsBank.Keys.Max());
            }
            string phrase = QuestionsBank[rand];
            JArray jerry1 = new JArray();
            JArray jerry2 = new JArray();
            //jerry1 = dataBase.GetDataFromDB(qManager.GetQuestionQuery(rand));
            //if (HasPlaceholder(phrase))
            //{
            //   phrase = String.Format(phrase, jerry1[0]);
            //}
            //string correctAnswer = String.Empty;
            //jerry2 = dataBase.GetDataFromDB(qManager.GetFalseQuestionQuery(rand));
            //foreach (string option in jerry2)
            //{
            //    falseAnswers.Add(option);
            //}
            //return new Question(phrase, falseAnswers, correctAnswer , "yepppppp");
            return new Question("this is the phrase", new List<string>(), "correct answer", "subject");
        }

        public Fact GetFact()
        {
            //TODO implement. 
            return new Fact();
        }

        public bool HasPlaceholder(string s)
        {
            return Regex.IsMatch(s, "{\\d+}");
        }

    }
}
