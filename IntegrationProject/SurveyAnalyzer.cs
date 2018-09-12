using IntegrationProject.Data;
using IntegrationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject
{
    public static class SurveyAnalyzer
    {   //need to seed database with bar answers
        public static void GetMatchResults(Bar bar, Member member, ApplicationDbContext context)
        {
            int memberAnswersId = GetMemberAnswersId(member);
            Answer memberAnswers = GetAnswersFromDb(context, memberAnswersId);
            int barAnswersId = GetBarAnswersId(bar);
            Answer barAnswers = GetAnswersFromDb(context, barAnswersId);
            double pointsPerQuestion = GetPointsPerQuestion();

        }

       private static double GetPointsPerQuestion()
        {
            int numberOfQuestions = 10;
            int totalPoints = 100;
            return totalPoints / numberOfQuestions;
        }

        
        
        private static int GetBarAnswersId(Bar bar)
        {
            int barAnswers = 0;
            if (bar.AnswerId != null)
            {
                return (int)bar.AnswerId;
            }
            return barAnswers;
        }

        private static int GetMemberAnswersId(Member member)
        {
            int memberAnswers = member.AnswerId;
            return memberAnswers;
        }
        private static Answer GetAnswersFromDb(ApplicationDbContext context, int AnswersId)
        {
            Answer answers = context.Answers.Find(AnswersId);
            return answers;
        }

        private static int GetHeaviestWeightedQuestion(Answer answers)
        {
            int heaviestWeightQuestion = answers.Master;
            return heaviestWeightQuestion;
        }

       

       
    }
}
