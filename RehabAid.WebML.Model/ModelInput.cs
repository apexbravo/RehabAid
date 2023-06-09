// This file was auto-generated by ML.NET Model Builder. 

using Microsoft.ML.Data;

namespace RehabAid_WebML.Model
{
    public class ModelInput
    {
        [ColumnName("expert_review"), LoadColumn(0)]
        public string Expert_review { get; set; }


        [ColumnName("selected_text"), LoadColumn(1)]
        public string Selected_text { get; set; }


        [ColumnName("sentiment"), LoadColumn(2)]
        public string Sentiment { get; set; }


        [ColumnName("Time_of_session"), LoadColumn(3)]
        public string Time_of_session { get; set; }


        [ColumnName("Age_of_Patient"), LoadColumn(4)]
        public string Age_of_Patient { get; set; }


        [ColumnName("sentiment_scores"), LoadColumn(5)]
        public string Sentiment_scores { get; set; }


    }
}
