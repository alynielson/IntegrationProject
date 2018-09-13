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
            int numberOfQuestions = 10;
            int totalPoints = 100;
            double pointsPerQuestion = totalPoints / numberOfQuestions;
            int memberAnswersId = GetMemberAnswersId(member);
            Answer memberAnswers = GetAnswersFromDb(context, memberAnswersId);
            int barAnswersId = GetBarAnswersId(bar);
            Answer barAnswers = GetAnswersFromDb(context, barAnswersId);
            List<double> barDoubleAnswers = GetAnswersForDoubleQuestions(barAnswers);
            List<double> memberDoubleAnswers = GetAnswersForDoubleQuestions(memberAnswers);
            List<int> maxPerDoubleQuestion = GetNumberOfAnswersPerQuestion();
            List<double> pointsForDoubleQuestions = GetPointsForDoubleQuestions(pointsPerQuestion, barDoubleAnswers, memberDoubleAnswers, maxPerDoubleQuestion);
            List<List<string>> barListAnswers = GetAnswersForListQuestions(barAnswers, context);
            List<List<string>> memberListAnswers = GetAnswersForListQuestions(memberAnswers, context);
            List<double> pointsForListQuestions = GetPointsForListQuestions(pointsPerQuestion, barListAnswers, memberListAnswers);
            List<double> pointsForAllQuestions = PutListsTogether(pointsForDoubleQuestions, pointsForListQuestions);
            int heaviestWeightIndex = GetHeaviestWeightedIndex(memberAnswers);
            List<double> weightedPoints = AssignQuestionWeights(pointsForAllQuestions, heaviestWeightIndex, totalPoints, numberOfQuestions);
            double matchValue = GetSum(weightedPoints);
            SendMatchValueToDb(bar, member, context, matchValue);
        }

        public static void GetNewMemberMatchResults(Member member, ApplicationDbContext context)
        {
            List<Bar> bars = context.Bars.Select(b => b).Where(a => a.AnswerId != null).ToList();
            foreach (Bar bar in bars)
            {
                GetMatchResults(bar, member, context);
            }
        }

        public static void GetMatchResultsForNewBar(Bar bar, ApplicationDbContext context)
        {
            List<Member> members = context.Members.Select(m => m).ToList();
            foreach (Member member in members)
            {
                GetMatchResults(bar, member, context);
            }
        }

        private static void SendMatchValueToDb(Bar bar, Member member, ApplicationDbContext context, double matchValue)
        {
            Match newMatch = new Match();
            newMatch.Score = matchValue;
            newMatch.BarId = bar.Id;
            newMatch.MemberId = member.Id;
            context.Matches.Add(newMatch);
            context.SaveChanges();
        }
        private static double GetSum(List<double> weightedPoints)
        {
            return Math.Round(weightedPoints.Sum(p => p),2);
        }
        private static List<double> AssignQuestionWeights(List<double> pointsForAllQuestions, int heaviestWeightIndex, int totalPoints, int numberOfQuestions)
        {
            double currentWeightOfQuestions = numberOfQuestions / totalPoints;
            int weightOfHeaviestQuestion = 20;
            double amountToMultiplyHeaviest = weightOfHeaviestQuestion / currentWeightOfQuestions;
            double amountToMultiplyOthers = (totalPoints - (weightOfHeaviestQuestion * totalPoints / 100) / (numberOfQuestions - 1))/totalPoints;
            for (int i = 0; i < pointsForAllQuestions.Count; i++)
            {
                if (i == heaviestWeightIndex)
                {
                    pointsForAllQuestions[i] = pointsForAllQuestions[i] * amountToMultiplyHeaviest;
                }
                else
                {
                    pointsForAllQuestions[i] = pointsForAllQuestions[i] * amountToMultiplyOthers;
                }
            }
            return pointsForAllQuestions;

        }

        private static List<double> PutListsTogether(List<double> pointsForDoubleQuestions, List<double> pointsForListQuestions)
        {
            List<double> pointsForAllQuestions = new List<double>
            {
                pointsForDoubleQuestions[0],
                pointsForDoubleQuestions[1],
                pointsForListQuestions[0],
                pointsForListQuestions[1],
                pointsForListQuestions[2],
                pointsForDoubleQuestions[2],
                pointsForDoubleQuestions[3],
                pointsForListQuestions[3],
                pointsForDoubleQuestions[4],
                pointsForDoubleQuestions[5],
            };
            return pointsForAllQuestions;

        }

      

       private static List<int> GetNumberOfAnswersPerQuestion()
        {
            int peopleMax = Survey.PEOPLE.Count;
            int priceMax = Survey.PRICE.Count;
            int sitDownMax = Survey.SITDOWN.Count;
            int timeOfDayMax = Survey.TIMEOFDAY.Count;
            int dressCode = Survey.DRESSCODE.Count;
            int age = Survey.AGE.Count;
            List<int> maxPerQuestion = new List<int> { peopleMax, priceMax, sitDownMax, timeOfDayMax, dressCode, age};
            return maxPerQuestion;
            
        }

        private static List<double> GetAnswersForDoubleQuestions(Answer answers)
        {
            List<double> doubleAnswers = new List<double>
            {
                answers.People,
                answers.Price,
                answers.SitDown,
                answers.TimeOfDay,
                answers.DressCode,
                answers.Age
            };
            return doubleAnswers;

        }

        private static List<double> GetPointsForDoubleQuestions(double pointsPerQuestion, List<double> barAnswers, List<double> memberAnswers, List<int> maxValuesPerQuestion)
        {
            List<double> doubleMatches = new List<double> { };
            for (int i = 0; i < memberAnswers.Count; i++)
            {
                double pointsEarned = GetMatchValueForDoubleQuestion(pointsPerQuestion, barAnswers[i], memberAnswers[i], maxValuesPerQuestion[i]);
                doubleMatches.Add(pointsEarned);
            }
            return doubleMatches;
        }
        

        private static double GetMatchValueForDoubleQuestion(double pointsPerQuestion, double barAnswer, double memberAnswer, int max)
        {
            int maxDifference = max - 1;
            double percentMatch = (maxDifference - Math.Abs(barAnswer - memberAnswer)) / maxDifference;
            double points = pointsPerQuestion * percentMatch;
            return points;
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

        private static int GetHeaviestWeightedIndex(Answer answers)
        {
            int heaviestWeightQuestion = answers.Master;
            int heaviestWeightIndex = heaviestWeightQuestion - 1;
            return heaviestWeightIndex;
        }

       private static List<List<string>> GetAnswersForListQuestions(Answer answers, ApplicationDbContext context)
        {
            var activities = context.Activities.Where(a => a.AnswerId == answers.Id);
            var drinks = context.Drinks.Where(d => d.AnswerId == answers.Id);
            var foods = context.Foods.Where(f => f.AnswerId == answers.Id);
            var musics = context.Musics.Where(m => m.AnswerId == answers.Id);
            List<List<string>> stringAnswers = new List<List<string>>
            {
                activities.Select(a => a.Type).ToList(),
                drinks.Select(d => d.Type).ToList(),
                foods.Select(f => f.Type).ToList(),
                musics.Select(m => m.Type).ToList()
            };
            return stringAnswers;
        }

       private static List<double> GetPointsForListQuestions(double pointsPerQuestion, List<List<string>> barListAnswers, List<List<string>> memberListAnswers)
        {
            List<double> pointsForListQuestions = new List<double> { };
            for (int i = 0; i < memberListAnswers.Count; i++)
            {
                double pointsForOneQuestion = GetPointsForOneListQuestion(pointsPerQuestion, barListAnswers[i], memberListAnswers[i]);
                pointsForListQuestions.Add(pointsForOneQuestion);
            }
            return pointsForListQuestions;

        }

        private static double GetPointsForOneListQuestion(double pointsPerQuestion, List<string> barAnswer, List<string> memberAnswer)
        {
            int maxMatches = barAnswer.Count;
            int matches = 0;
            for (int i = 0; i < memberAnswer.Count; i++)
            {
                if (barAnswer.Contains(memberAnswer[i]))
                {
                    matches++;
                }
            }
            double matchPercent = matches / maxMatches;
            return matchPercent * pointsPerQuestion;
        }
    }
}
