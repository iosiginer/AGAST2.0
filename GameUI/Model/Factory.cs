
using AGAST2.Infrastructure.LevelTypes;
using AGAST2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using AGAST2.GameUI.DAL;
using Newtonsoft.Json.Linq;

namespace AGAST2.GameUI.Model
{
    public class Factory
    {
        private IDataRetriever dataBase;
        private QueryManager qManager;
        private Random randy;
        private Dictionary<int, string> QuestionsBank;

        public Factory()
        {
            randy = new Random();
            dataBase = DataRetriever.Instance;
            qManager = QueryManager.Instance;
            QuestionsBank = dataBase.GetQuestionDictionary();
        }

        // THIS IS FOR TESTING!!!!
        // NOT FINISHED!
        public Question GetQuestion()
        {
            int rand = randy.Next(QuestionsBank.Count);
            JArray jerry1 = new JArray();
            JArray jerry2 = new JArray();
            jerry1 = dataBase.GetDataFromDB(qManager.GetQuestionQuery(rand));
            jerry2 = dataBase.GetDataFromDB(qManager.GetFalseQuestionQuery(rand));

            //return new Question(QuestionsBank[rand], );
            return new Question("omg", new List<string>(), "im da subject", "yeppp");
        }

        public Fact GetFact()
        {
            //TODO implement. 
            return new Fact();
        }

       

    }
}
