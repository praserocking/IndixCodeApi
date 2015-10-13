using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using IndixCodeSearch.Api;

namespace IndixCodeSearch.ApiDefinitions
{
    public class DataProcessor : IDataProcessor
    {
        private static readonly IDataReader _dataReader = new DataReader();
        private static readonly string[] _ignoreFunctions={"if", "while", "do", "for", "switch"} ;
        private static readonly Dictionary<string, string> _fileToContentMap = _dataReader.ReadAllSourceFiles();
        private static readonly string isolateFnNamesRegex = @"((?<=[\s:~])(\w+)\s*\(([\w\s,<>\[\].=&':/*]*?)\)\s*(const)?\s*(?={))";
        
        private List<string> FunctionNames(string content)
        {
            List<string> functionNames = new List<string>();
            
            MatchCollection matches = Regex.Matches(content, isolateFnNamesRegex);
            foreach (Match match in matches)
            {
                var functionName = match.Groups[2].Value;
                if(!_ignoreFunctions.Contains(functionName))
                    functionNames.Add(functionName);    
            }

            return functionNames;
        }

        private List<string> ParamsLists(string content)
        {
            List<string> paramsList = new List<string>();

            MatchCollection matches = Regex.Matches(content, isolateFnNamesRegex);
            foreach (Match match in matches)
            {
                var paramName = match.Groups[3].Value;
                var functionName = match.Groups[2].Value;
                if (!_ignoreFunctions.Contains(functionName))
                    paramsList.Add(paramName);
            }

            return paramsList;
        } 

        public Dictionary<string, HashSet<string>> ReturnFunctionsNamesMappedToOccurences()
        {

            Dictionary<string,HashSet<string>> fnNameToOccurence = new Dictionary<string, HashSet<string>>();

            foreach (var keyValue in _fileToContentMap)
            {
                List<string> functions = FunctionNames(keyValue.Value);
                foreach (var fnName in functions)
                {
                    if(fnNameToOccurence.ContainsKey(fnName))
                        fnNameToOccurence[fnName].Add(keyValue.Key);
                    else
                    {
                        HashSet<string> hs = new HashSet<string>();
                        hs.Add(keyValue.Key);
                        fnNameToOccurence.Add(fnName,hs);
                    }
                }
            }
            return fnNameToOccurence;
        }

        public Dictionary<string, HashSet<String>> ReturnParamListMappedToOccurence()
        {
            Dictionary<string,HashSet<string>> paramListToOccurence = new Dictionary<string, HashSet<string>>();

            foreach (var keyValue in _fileToContentMap)
            {
                List<string> paramsList = ParamsLists(keyValue.Value);
                foreach (var param in paramsList)
                {
                    if (paramListToOccurence.ContainsKey(param))
                        paramListToOccurence[param].Add(keyValue.Key);
                    else
                    {
                        HashSet<string> hs = new HashSet<string>();
                        hs.Add(keyValue.Key);
                        paramListToOccurence.Add(param, hs);
                    }
                }
            }
            return paramListToOccurence;
        }
    }
}