
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
            int rand = randy.Next(1, factBankSize);
            string fact = String.Empty;
            string ent1 = String.Empty;
            string ent2 = String.Empty;
            string link_phrase = String.Empty;
            List<string> factInformation = new List<string>();
            JArray jerry = dataBase.GetDataFromDB(qManager.GetFactQuery(rand));
            var a = jerry[0];
            foreach (JToken entry in jerry)
            {
                ent1 = entry["template_1"].ToString().TrimEnd();
                ent2 = entry["template_2"].ToString().TrimEnd();
                link_phrase = entry["link_phrase"].ToString().Trim();
            }

            //************************************************************************
            // DEAR IOSI, I DID ALITTLE BIT OF CODE. DIDNT CHECK THINGS THROUGLY!!!!!!
            // ***********************************************************************
            // IF IT DOESNT ALWAYS WORK ITS BECAUSE - either the query returns a null.
            // or because the query doesnt return colums named "tempate_1" "tempalte_2" which i parse by later 
            // but returns "name" instead.....
            // these are both problems with the queries

            // Randomize if to falsify the fact or not
            rand = randy.Next(0, 1);
            if (rand == 0)
            {
                ent2 = dataBase.GetRandomArtist();
                isCorrectFact = false;
            }
            // If theres a placeholder we'll replace it and remove any others
            if (HasPlaceholder(link_phrase))
            {
                String.Format(link_phrase, ent1);
                // Doesnt really work becasue i dont know regular expressions ¯\_(ツ)_/¯
                Regex.Replace(link_phrase, "{*}", string.Empty);
            }
            // Otherwise just building the fact
            else
            {
                fact = ent1 + link_phrase + ent1;
            }
            
            
            return new Fact(fact, isCorrectFact);
        }

        public bool HasPlaceholder(string s)
        {
            return Regex.IsMatch(s, "{\\d+}");
        }

    }
}
