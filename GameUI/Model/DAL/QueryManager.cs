using System;
using System.Collections.Generic;

namespace AGAST2.GameUI.DAL
{
    class QueryManager
    {

        private Dictionary<int, string> phraseToQuery;
        private Dictionary<int, string> phraseToFalseQuery;
        private Dictionary<int, string> factToQuery;

        public QueryManager()
        {
            InitializeMap();
        }

        private void InitializeMap()
        {
            throw new NotImplementedException();
        }

        private string GetQuestionQuery(int phrase)
        {
            return this.phraseToQuery[phrase];
        }

        private string GetQuestionFalseAnswers(int phrase)
        {
            return this.phraseToFalseQuery[phrase];
        }
    }
}
