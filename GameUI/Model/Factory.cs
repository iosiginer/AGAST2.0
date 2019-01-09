
using AGAST2.Infrastructure.LevelTypes;
using AGAST2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using AGAST2.GameUI.DAL;

namespace AGAST2.GameUI.Model
{
    public class Factory
    {
        IDataRetriever dataBase;
        QueryManager qManager;
        private Dictionary<int, string> QuestionsBank;

        public Factory()
        {
            dataBase = DataRetriever.Instance;
            qManager = QueryManager.Instance;
            this.QuestionsBank = dataBase.GetQuestionDictionary();
        }

        public Question GetQuestion()
        {
            
            return new Question();
        }

        public Fact GetFact()
        {
            //TODO implement. 
            return new Fact();
        }

       

    }
}
