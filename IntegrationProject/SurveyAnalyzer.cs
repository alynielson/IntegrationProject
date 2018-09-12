using IntegrationProject.Data;
using IntegrationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject
{
    public static class SurveyAnalyzer
    {
        public static void GetSurveyResultsBar(ApplicationDbContext context, Bar bar)
        {
            int barAnswers = GetBarAnswersId(bar);
            Answer answer = GetAnswersFromDb(context, barAnswers);

        }

        public static void GetSurveyResultsMember(ApplicationDbContext context, Member member)
        {
            int memberAnswers = GetMemberAnswersId(member);
            Answer answer = GetAnswersFromDb(context, memberAnswers);
            int heaviestWeightQuestion = GetHeaviestWeightedQuestion(answer);
            AssignQuestionWeights(heaviestWeightQuestion);
        }
        private static int GetBarAnswersId(Bar bar)
        {
            int barAnswers = bar.AnswerId;
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

        private static void AssignQuestionWeights(int heaviestWeightQuestion)
        {

        }

       
    }
}
