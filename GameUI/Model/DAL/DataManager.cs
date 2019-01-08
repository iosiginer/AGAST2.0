using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;

namespace AGAST2.GameUI.Model.DAL
{
    class DataManager
    {

        private Dictionary<int, string> PhraseToQuery;
        private Dictionary<int, string> PhraseToFalseQuery;

        public DataManager()
        {
            InitializeMap();
        }

        private void InitializeMap()
        {
            throw new NotImplementedException();
        }

        private string GetQuestionQuery(int phrase)
        {
            return this.PhraseToQuery[phrase];
        }

        private string GetQuestionFalseAnswers(int phrase)
        {
            return this.PhraseToFalseQuery[phrase];
        }
    }
}
