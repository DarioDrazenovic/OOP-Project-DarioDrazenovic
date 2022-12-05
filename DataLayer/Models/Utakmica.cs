using DataLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Models
{
   public class Utakmica
    {
        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("fifa_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long FifaId { get; set; }

        [JsonProperty("attendance")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Attendance { get; set; }

        [JsonProperty("officials")]
        public List<string> Officials { get; set; }

        [JsonProperty("stage_name")]
        public string StageName { get; set; }

        [JsonProperty("home_team_country")]
        public string HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public string AwayTeamCountry { get; set; }

        [JsonProperty("datetime")]
        public string Datetime { get; set; }

        [JsonProperty("winner")]
        public string Winner { get; set; }

        [JsonProperty("winner_code")]
        public string WinnerCode { get; set; }

        [JsonProperty("home_team")]
        public Country HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public Country AwayTeam { get; set; }

        [JsonProperty("home_team_events")]
        public List<TimEvent> HomeTeamEvents { get; set; }

        [JsonProperty("away_team_events")]
        public List<TimEvent> AwayTeamEvents { get; set; }

        [JsonProperty("home_team_statistics")]
        public StatistikaTima HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public StatistikaTima AwayTeamStatistics { get; set; }

        [JsonProperty("last_event_update_at")]
        public DateTime? LastEventUpdateAt { get; set; }

        [JsonProperty("last_score_update_at")]
        public DateTime? LastScoreUpdateAt { get; set; }

        public string Format() => $"{Location}  {Attendance}  {HomeTeamCountry}  {AwayTeamCountry}";

        
        
    }
}

