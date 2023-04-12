using RehabAid.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RehabAid.Data
{
   partial class SpecialistReview
    {

        [NotMapped]
        public SentimentType Sentiment
        {
            get => (SentimentType)SentimentId;
            set => SentimentId = (int)value;
        }

        [NotMapped]
        public TimeOfSessionEnum TimeOfSession
        {
            get => (TimeOfSessionEnum)TimeOfSessionId;
            set => TimeOfSessionId = (int)value;
        }
    }
}
