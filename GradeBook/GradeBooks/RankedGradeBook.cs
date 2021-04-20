using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            var grade = 'A';
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("At least 5 students are required for RankedGradeBook");
            }
            var studentsCountPerGrade = Math.Round((decimal) Students.Count / 5);
            var sortedAverage = Students.Select(s => s.AverageGrade).OrderByDescending(x => x).ToList();
            for(var i = 0 ; i < sortedAverage.Count ; i++)
            {
                switch (i)
                {
                    case var d when d < studentsCountPerGrade:
                        grade = 'A';
                        break;
                    case var d when d < studentsCountPerGrade * 2:
                        grade = 'B';
                        break;
                    case var d when d < studentsCountPerGrade * 3:
                        grade = 'C';
                        break;
                    case var d when d < studentsCountPerGrade * 4:
                        grade = 'D';
                        break;
                    default:
                        grade = 'F';
                        break;
                }
                if (sortedAverage[i] <= averageGrade)
                {
                    break;
                }
            }

            return grade;
        }
    }
}
