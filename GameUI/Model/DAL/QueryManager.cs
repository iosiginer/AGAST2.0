using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AGAST2.GameUI.DAL
{
    public class QueryManager
    {
        private string queryDirectory;
        private string factDirectory;
        private Dictionary<int, string> phraseToQuery;
        private Dictionary<int, string> falseAnswersToQuery;
        private Dictionary<int, string> factToQuery;

        public QueryManager()
        {
            //queryDirectory = System.Configuration.ConfigurationManager.AppSettings["queryResources"];
            queryDirectory = "..\\..\\QueryResources\\QuestionQueries";
            factDirectory = "..\\..\\QueryResources\\FactQueries";
            InitializeQueriesFromDirectory(queryDirectory);
            InitializeQueriesFromDirectory(factDirectory);
        }

        public void InitializeQueriesFromDirectory(string directory)
        {
            int queryId;
            string queryString = String.Empty;
            foreach (string file in Directory.EnumerateFiles(directory, "*.sql"))
            {
                string[] fileLines = File.ReadAllLines(file);
                if (fileLines[0].StartsWith("#") && fileLines[0].EndsWith("False"))
                {
                    Int32.TryParse(Regex.Match(fileLines[0], @"\d+").Value, out queryId);
                    queryString = TrimFileToQuery(fileLines);
                    falseAnswersToQuery.Add(queryId, queryString);

                }
                else if (fileLines[0].StartsWith("#"))
                {
                    Int32.TryParse(Regex.Match(fileLines[0], @"\d+").Value, out queryId);
                    queryString = TrimFileToQuery(fileLines);
                    phraseToQuery.Add(queryId, queryString);
                }
                else
                {
                    Int32.TryParse(Regex.Match(fileLines[0], @"\d+").Value, out queryId);
                    queryString = TrimFileToQuery(fileLines);
                    factToQuery.Add(queryId, queryString);
                }

            }
        }

        private string TrimFileToQuery(string[] fileLines)
        {
            string queryString = String.Empty;
            foreach (string line in fileLines)
            {
                if (!line.StartsWith("#"))
                {
                    queryString += line;
                }
            }
            return queryString;
        }

       
        private string GetQuestionQuery(int phrase)
        {
            return this.phraseToQuery[phrase];
        }

        private string GetFactQuery(int fact)
        {
            return this.factToQuery[fact];
        }
    }
}
