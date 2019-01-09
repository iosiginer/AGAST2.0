using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AGAST2.GameUI.DAL
{

    public class QueryManager
    {
        private static QueryManager instance = null;
        private string queryDirectory;
        private string factDirectory;
        private Dictionary<int, string> phraseToQuery;
        private Dictionary<int, string> falseAnswersToQuery;
        private Dictionary<int, string> factToQuery;

        private QueryManager()
        {
            phraseToQuery = new Dictionary<int, string>();
            falseAnswersToQuery = new Dictionary<int, string>();
            factToQuery = new Dictionary<int, string>();
            //queryDirectory = System.Configuration.ConfigurationManager.AppSettings["QuestionQueries"];
            //factDirectory = System.Configuration.ConfigurationManager.AppSettings["FactQueries"];
            queryDirectory = "C:\\QueryResources\\QuestionQueries";
            factDirectory = "C:\\QueryResources\\FactQueries";
            InitializeQueriesFromDirectory(queryDirectory);
            InitializeQueriesFromDirectory(factDirectory);
        }

        public static QueryManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QueryManager();
                }
                return instance;
            }
        }

        private void InitializeQueriesFromDirectory(string directory)
        {
            int queryId;
            string queryString = String.Empty;
            foreach (string file in Directory.EnumerateFiles(directory, "*.sql"))
            {
                string[] fileLines = File.ReadAllLines(file);
                if (fileLines[0].StartsWith("#") && fileLines[0].EndsWith("false"))
                {
                    Int32.TryParse(Regex.Match(fileLines[0], @"\d+").Value, out queryId);
                    queryString = TrimFileToQuery(fileLines);
                    falseAnswersToQuery.Add(queryId, queryString);

                }
                else if (fileLines[0].StartsWith("#") && !fileLines[0].EndsWith("fact"))
                {
                    Int32.TryParse(Regex.Match(fileLines[0], @"\d+").Value, out queryId);
                    queryString = TrimFileToQuery(fileLines);
                    Console.WriteLine(queryId);
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
                    queryString += "\n";
                }
            }
            return queryString;
        }

        public string GetQuestionQuery(int phrase)
        {
            return this.phraseToQuery[phrase];
        }

        public string GetFalseQuestionQuery(int phrase)
        {
            return this.falseAnswersToQuery[phrase];
        }

        public string GetFactQuery(int fact)
        {
            return this.factToQuery[fact];
        }
    }
}
