using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
