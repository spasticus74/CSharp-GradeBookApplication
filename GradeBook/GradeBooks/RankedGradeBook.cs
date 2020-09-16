using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool weighted) : base(name, weighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int x = (Students.Count / 5);

            List<double> studentScores = new List<double>();
            foreach(Student s in this.Students)
            {
                studentScores.Add(s.AverageGrade);
            }
            studentScores.Sort();
            studentScores.Reverse();

            for(int g = 0; g < studentScores.Count; ++g)
            {
                if(studentScores[g] <= averageGrade)
                {
                    if(g < x)
                    {
                        return 'A';
                    } else if (g < (2*x))
                    {
                        return 'B';
                    } else if (g < (3*x))
                    {
                        return 'C';
                    } else if (g < (4*x))
                    {
                        return 'D';
                    }
                }
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            } else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
