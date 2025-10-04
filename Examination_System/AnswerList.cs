﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class AnswerList : List<Answer>
    {
        public IEnumerable<Answer> GetCorrectAnswers()
        {
            return this.Where(a => a.IsCorrect);
        }
    }
}
