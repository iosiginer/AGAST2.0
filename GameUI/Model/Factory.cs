
using AGAST2.Infrastructure.LevelTypes;
using AGAST2.Infrastructure;
using System;
using System.Collections.Generic;
using AGAST2.GameUI.DAL;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

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
        private int _placeHolderCounter;

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
            List<string> options = new List<string>();
            int randomInt = randy.Next(1,QuestionsBank.Count);
            // Getting a random question making sure it exists and that its not the previous question
            while (!QuestionsBank.ContainsKey(randomInt) && randomInt != prevRand)
            {
                randomInt = randy.Next(1, QuestionsBank.Keys.Max());
            }
            prevRand = randomInt;
            string phrase = QuestionsBank[randomInt];
            // Getting the query for the question and proccessing the data
            JArray jerry1 = dataBase.GetDataFromDB(qManager.GetQuestionQuery(randomInt));
            // Getting the question subject if it has one and trimming it
            if (HasPlaceholder(phrase))
            {
                foreach (JToken entry in jerry1)
                {
                    subject = entry["template"].ToString().TrimEnd('\r','\n');
                }
            }
            // Getting the correct answer
            string correctAnswer = String.Empty;
            foreach (JToken entry in jerry1)
            {
                correctAnswer = entry["answer"].ToString().Trim();
            }
            options.Add(correctAnswer);
            // Getting the false answers for the question
            JArray jerry2 = dataBase.GetDataFromDB(qManager.GetFalseQuestionQuery(randomInt));
            foreach (JToken entry in jerry2)
            {
                options.Add(entry["false_answer"].ToString().Trim());
            }
            return new Question(phrase, options, correctAnswer, subject);
        }

        public Fact GetFact()
        {
            bool isCorrectFact = true;
            int queryTemplateNumber = randy.Next(1, factBankSize);
            queryTemplateNumber = 1;
            string fact, entryOne, entryTwo, link_phrase;
            entryOne = entryTwo = link_phrase = String.Empty;
            List<string> factInformation = new List<string>();

            JArray jerry = dataBase.GetDataFromDB(qManager.GetFactQuery(queryTemplateNumber));
            var a = jerry[0];
            foreach (JToken entry in jerry)
            {
                entryOne = entry["template_1"].ToString().TrimEnd() + " ";
                entryTwo = " " + entry["template_2"].ToString().TrimEnd();
                link_phrase = entry["link_phrase"].ToString().Trim();
            }

            bool falsifyFact = randy.Next(100) <= 50 ? true : false;
            if (falsifyFact)
            {
                entryTwo = " " + dataBase.GetRandomArtist();
                isCorrectFact = false;
            }
            // If theres a placeholder we'll replace it and remove any others
            fact = BuildFactPhrase(entryOne, entryTwo, link_phrase);

            
            
            return new Fact(fact, isCorrectFact);
        }

        private string BuildFactPhrase(string entryOne, string entryTwo, string link_phrase)
        {
            _placeHolderCounter = 0;
            string fact = String.Empty;
            if (HasPlaceholder(link_phrase))
            {
                MatchEvaluator evaluator = new MatchEvaluator(PlaceHolderCounter);
                link_phrase = Regex.Replace(link_phrase, TriviaConstants.PlaceHolder, evaluator);
                link_phrase = Regex.Replace(link_phrase, "{[0-9]*}", string.Empty);

                if (link_phrase.Contains("member of"))
                    link_phrase = "is a " + link_phrase;
                if (link_phrase.Contains("children"))
                    link_phrase = "is a child of";

            }
            fact = entryOne + link_phrase + entryTwo;

            return RemoveExcessiveWhitespace(fact);
        }

        public bool HasPlaceholder(string s)
        {
            return Regex.IsMatch(s, TriviaConstants.PlaceHolder);
        }

        private string PlaceHolderCounter(Match match)
        {
            return "{" + _placeHolderCounter++ + "}"; ;
        }

        private string RemoveExcessiveWhitespace(string value)
        {
            if (value == null) { return null; }

            var builder = new StringBuilder();
            var ignoreWhitespace = false;
            foreach (var c in value)
            {
                if (!ignoreWhitespace || c != ' ')
                {
                    builder.Append(c);
                }
                ignoreWhitespace = c == ' ';
            }
            return builder.ToString();
        }

    }
}
