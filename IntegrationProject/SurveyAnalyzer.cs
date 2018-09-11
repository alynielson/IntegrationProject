using IntegrationProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject
{
    public static class SurveyAnalyzer
    {
        public static void GetSurveyResults()
        {
            //ApplicationDbContext db = new ApplicationDbContext();
            int heaviestWeightQuestion = GetHeaviestWeightedQuestion();
            AssignQuestionWeights(heaviestWeightQuestion);
        }

        private static int GetHeaviestWeightedQuestion()
        {
            return 3;
        }

        private static void AssignQuestionWeights(int heaviestWeightQuestion)
        {

        }

       
    }
}
