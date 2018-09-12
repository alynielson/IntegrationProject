﻿using IntegrationProject.Data;
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
            int pointsPerQuestion = 10;

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

       

       
    }
}