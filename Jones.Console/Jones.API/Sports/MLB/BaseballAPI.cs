using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swiss;
using Swiss.Utilities.Web;
using Jones.Domain.External.Sports.MLB;
using Jones.Domain.External.Sports;
using Jones.Domain.Internal.API;

namespace Jones.API.Sports.MLB
{
    #region Classes

    public class BaseballResponse
    {
        public List<BaseballGame> Games = new List<BaseballGame>();
    }

    #endregion

    #region Shells

    internal class Away
    {
        public object tv { get; set; }
        public string radio { get; set; }
    }

    internal class Home
    {
        public string tv { get; set; }
        public string radio { get; set; }
    }

    internal class Broadcast
    {
        public Away away { get; set; }
        public Home home { get; set; }
    }

    internal class SavePitcher
    {
        public string id { get; set; }
        public string last { get; set; }
        public string saves { get; set; }
        public string losses { get; set; }
        public string era { get; set; }
        public string name_display_roster { get; set; }
        public string number { get; set; }
        public string svo { get; set; }
        public string first { get; set; }
        public string wins { get; set; }

        public Domain.External.Sports.MLB.Pitcher ConvertToRock()
        {
            return new Domain.External.Sports.MLB.Pitcher()
            {
                First = first,
                Last = last,
                ERA = era.ToDouble(),
                W = wins.ToInt(),
                L = losses.ToInt(),
                Status = PitcherStatus.Saver,
                IsHome = false
            };
        }
    }

    internal class Status
    {
        public string is_no_hitter { get; set; }
        public string top_inning { get; set; }
        public string s { get; set; }
        public string b { get; set; }
        public string reason { get; set; }
        public string ind { get; set; }
        public string status { get; set; }
        public string is_perfect_game { get; set; }
        public string o { get; set; }
        public string inning { get; set; }
        public string inning_state { get; set; }
        public string note { get; set; }
    }

    internal class WinningPitcher
    {
        public string id { get; set; }
        public string last { get; set; }
        public string losses { get; set; }
        public string era { get; set; }
        public string number { get; set; }
        public string name_display_roster { get; set; }
        public string first { get; set; }
        public string wins { get; set; }

        public Domain.External.Sports.MLB.Pitcher ConvertToRock()
        {
            return new Domain.External.Sports.MLB.Pitcher()
            {
                First = first,
                Last = last,
                ERA = era.ToDouble(),
                W = wins.ToInt(),
                L = losses.ToInt(),
                Status = PitcherStatus.Winner,
                IsHome = false
            };
        }
    }

    internal class GameMedia
    {
        public object media { get; set; }
    }

    internal class Hr
    {
        public string home { get; set; }
        public string away { get; set; }
    }

    internal class E
    {
        public string home { get; set; }
        public string away { get; set; }
    }

    internal class So
    {
        public string home { get; set; }
        public string away { get; set; }
    }

    internal class R
    {
        public string home { get; set; }
        public string away { get; set; }
        public string diff { get; set; }
    }

    internal class Sb
    {
        public string home { get; set; }
        public string away { get; set; }
    }

    internal class H
    {
        public string home { get; set; }
        public string away { get; set; }
    }

    internal class Linescore
    {
        public Hr hr { get; set; }
        public E e { get; set; }
        public So so { get; set; }
        public R r { get; set; }
        public Sb sb { get; set; }
        public object inning { get; set; }
        public H h { get; set; }
    }

    internal class HomeRuns
    {
        public object player { get; set; }
    }

    internal class Alerts
    {
        public string text { get; set; }
        public string brief_text { get; set; }
        public string type { get; set; }
    }

    internal class Links
    {
        public string away_audio { get; set; }
        public string wrapup { get; set; }
        public string preview { get; set; }
        public string home_preview { get; set; }
        public string away_preview { get; set; }
        public string tv_station { get; set; }
        public string home_audio { get; set; }
        public string mlbtv { get; set; }
    }

    internal class LosingPitcher
    {
        public string id { get; set; }
        public string last { get; set; }
        public string losses { get; set; }
        public string era { get; set; }
        public string number { get; set; }
        public string name_display_roster { get; set; }
        public string first { get; set; }
        public string wins { get; set; }

        public Domain.External.Sports.MLB.Pitcher ConvertToRock()
        {
            return new Domain.External.Sports.MLB.Pitcher()
            {
                First = first,
                Last = last,
                ERA = era.ToDouble(),
                W = wins.ToInt(),
                L = losses.ToInt(),
                Status = PitcherStatus.Loser,
                IsHome = false
            };
        }
    }

    internal class Thumbnail
    {
        public string content { get; set; }
        public string height { get; set; }
        public string scenario { get; set; }
        public string width { get; set; }
    }

    internal class VideoThumbnails
    {
        public List<Thumbnail> thumbnail { get; set; }
    }

    internal class Review
    {
        public string challenges_home_remaining { get; set; }
        public string challenges_home_used { get; set; }
        public string challenges_away_remaining { get; set; }
        public string challenges_away_used { get; set; }
    }

    internal class Pitcher
    {
        public string id { get; set; }
        public string last { get; set; }
        public string losses { get; set; }
        public string number { get; set; }
        public string name_display_roster { get; set; }
        public string era { get; set; }
        public string first { get; set; }
        public string er { get; set; }
        public string wins { get; set; }
        public string ip { get; set; }

        public Domain.External.Sports.MLB.Pitcher ConvertToRock()
        {
            return new Domain.External.Sports.MLB.Pitcher()
            {
                First = first,
                Last = last,
                ERA = era.ToDouble(),
                W = wins.ToInt(),
                L = losses.ToInt(),
                Status = PitcherStatus.Probable,
                IsHome = false
            };
        }
    }

    internal class RunnerOn2b
    {
        public string id { get; set; }
        public string last { get; set; }
        public string number { get; set; }
        public string name_display_roster { get; set; }
        public string first { get; set; }
    }

    internal class RunnerOn3b
    {
        public string id { get; set; }
        public string last { get; set; }
        public string number { get; set; }
        public string name_display_roster { get; set; }
        public string first { get; set; }
    }

    internal class RunnersOnBase
    {
        public RunnerOn2b runner_on_2b { get; set; }
        public string status { get; set; }
        public RunnerOn3b runner_on_3b { get; set; }
    }

    internal class DueUpBatter
    {
        public string hr { get; set; }
        public string last { get; set; }
        public string name_display_roster { get; set; }
        public string number { get; set; }
        public string h { get; set; }
        public string pos { get; set; }
        public string obp { get; set; }
        public string id { get; set; }
        public string rbi { get; set; }
        public string ab { get; set; }
        public string avg { get; set; }
        public string slg { get; set; }
        public string first { get; set; }
        public string ops { get; set; }

        public Domain.External.Sports.MLB.Batter ConvertToRock()
        {
            return new Domain.External.Sports.MLB.Batter()
            {
                First = first,
                Last = last,
                H = h.ToInt(),
                AB = ab.ToInt(),
                HR = hr.ToInt(),
                RBI = hr.ToInt(),
                SeasonAVG = avg.ToDouble(),
                SeasonSLG = slg.ToDouble()
            };
        }
    }

    internal class Inhole
    {
        public string hr { get; set; }
        public string last { get; set; }
        public string name_display_roster { get; set; }
        public string number { get; set; }
        public string h { get; set; }
        public string pos { get; set; }
        public string obp { get; set; }
        public string id { get; set; }
        public string rbi { get; set; }
        public string ab { get; set; }
        public string avg { get; set; }
        public string slg { get; set; }
        public string first { get; set; }
        public string ops { get; set; }

        public Domain.External.Sports.MLB.Batter ConvertToRock()
        {
            return new Domain.External.Sports.MLB.Batter()
            {
                First = first,
                Last = last,
                H = h.ToInt(),
                AB = ab.ToInt(),
                HR = hr.ToInt(),
                RBI = hr.ToInt(),
                SeasonAVG = avg.ToDouble(),
                SeasonSLG = slg.ToDouble()
            };
        }
    }

    internal class DueUpOndeck
    {
        public string hr { get; set; }
        public string last { get; set; }
        public string name_display_roster { get; set; }
        public string number { get; set; }
        public string h { get; set; }
        public string pos { get; set; }
        public string obp { get; set; }
        public string id { get; set; }
        public string rbi { get; set; }
        public string ab { get; set; }
        public string avg { get; set; }
        public string slg { get; set; }
        public string first { get; set; }
        public string ops { get; set; }

        public Domain.External.Sports.MLB.Batter ConvertToRock()
        {
            return new Domain.External.Sports.MLB.Batter()
            {
                First = first,
                Last = last,
                H = h.ToInt(),
                AB = ab.ToInt(),
                HR = hr.ToInt(),
                RBI = hr.ToInt(),
                SeasonAVG = avg.ToDouble(),
                SeasonSLG = slg.ToDouble()
            };
        }
    }

    internal class Batter
    {
        public string hr { get; set; }
        public string last { get; set; }
        public string name_display_roster { get; set; }
        public string number { get; set; }
        public string h { get; set; }
        public string pos { get; set; }
        public string obp { get; set; }
        public string id { get; set; }
        public string rbi { get; set; }
        public string ab { get; set; }
        public string avg { get; set; }
        public string slg { get; set; }
        public string first { get; set; }
        public string ops { get; set; }

        public Domain.External.Sports.MLB.Batter ConvertToRock()
        {
            return new Domain.External.Sports.MLB.Batter()
            {
                First = first,
                Last = last,
                H = h.ToInt(),
                AB = ab.ToInt(),
                HR = hr.ToInt(),
                RBI = hr.ToInt(),
                SeasonAVG = avg.ToDouble(),
                SeasonSLG = slg.ToDouble()
            };
        }
    }

    internal class OpposingPitcher
    {
        public string id { get; set; }
        public string last { get; set; }
        public string losses { get; set; }
        public string number { get; set; }
        public string name_display_roster { get; set; }
        public string era { get; set; }
        public string first { get; set; }
        public string wins { get; set; }
    }

    internal class Pbp
    {
        public string last { get; set; }
    }

    internal class DueUpInhole
    {
        public string hr { get; set; }
        public string last { get; set; }
        public string name_display_roster { get; set; }
        public string number { get; set; }
        public string h { get; set; }
        public string pos { get; set; }
        public string obp { get; set; }
        public string id { get; set; }
        public string rbi { get; set; }
        public string ab { get; set; }
        public string avg { get; set; }
        public string slg { get; set; }
        public string first { get; set; }
        public string ops { get; set; }

        public Domain.External.Sports.MLB.Batter ConvertToRock()
        {
            return new Domain.External.Sports.MLB.Batter()
            {
                First = first,
                Last = last,
                H = h.ToInt(),
                AB = ab.ToInt(),
                HR = hr.ToInt(),
                RBI = hr.ToInt(),
                SeasonAVG = avg.ToDouble(),
                SeasonSLG = slg.ToDouble()
            };
        }
    }

    internal class Ondeck
    {
        public string hr { get; set; }
        public string last { get; set; }
        public string name_display_roster { get; set; }
        public string number { get; set; }
        public string h { get; set; }
        public string pos { get; set; }
        public string obp { get; set; }
        public string id { get; set; }
        public string rbi { get; set; }
        public string ab { get; set; }
        public string avg { get; set; }
        public string slg { get; set; }
        public string first { get; set; }
        public string ops { get; set; }

        public Domain.External.Sports.MLB.Batter ConvertToRock()
        {
            return new Domain.External.Sports.MLB.Batter()
            {
                First = first,
                Last = last,
                H = h.ToInt(),
                AB = ab.ToInt(),
                HR = hr.ToInt(),
                RBI = hr.ToInt(),
                SeasonAVG = avg.ToDouble(),
                SeasonSLG = slg.ToDouble()
            };
        }
    }

    internal class AwayProbablePitcher
    {
        public string last { get; set; }
        public string stats_type { get; set; }
        public string name_display_roster { get; set; }
        public string number { get; set; }
        public string era { get; set; }
        public string id { get; set; }
        public string throwinghand { get; set; }
        public string s_losses { get; set; }
        public string first_name { get; set; }
        public string s_era { get; set; }
        public string stats_season { get; set; }
        public string last_name { get; set; }
        public string losses { get; set; }
        public string first { get; set; }
        public string s_wins { get; set; }
        public string wins { get; set; }

        public Domain.External.Sports.MLB.Pitcher ConvertToRock()
        {
            return new Domain.External.Sports.MLB.Pitcher()
            {
                First = first,
                Last = last,
                ERA = era.IsNumeric() ? era.ToDouble() : 0,
                W = wins.ToInt(),
                L = losses.ToInt(),
                Status = PitcherStatus.Probable,
                IsHome = false
            };
        }
    }

    internal class HomeProbablePitcher
    {
        public string last { get; set; }
        public string stats_type { get; set; }
        public string name_display_roster { get; set; }
        public string number { get; set; }
        public string era { get; set; }
        public string id { get; set; }
        public string throwinghand { get; set; }
        public string s_losses { get; set; }
        public string first_name { get; set; }
        public string s_era { get; set; }
        public string stats_season { get; set; }
        public string last_name { get; set; }
        public string losses { get; set; }
        public string first { get; set; }
        public string s_wins { get; set; }
        public string wins { get; set; }

        public Domain.External.Sports.MLB.Pitcher ConvertToRock()
        {
            return new Domain.External.Sports.MLB.Pitcher()
            {
                First = first,
                Last = last,
                ERA = era.IsNumeric() ? era.ToDouble() : 0,
                W = wins.ToInt(),
                L = losses.ToInt(),
                Status = PitcherStatus.Probable,
                IsHome = true
            };
        }
    }

    internal class Game
    {
        public string game_type { get; set; }
        public string double_header_sw { get; set; }
        public string location { get; set; }
        public string away_time { get; set; }
        public string time { get; set; }
        public string home_time { get; set; }
        public string home_team_name { get; set; }
        public string description { get; set; }
        public string original_date { get; set; }
        public string home_team_city { get; set; }
        public string venue_id { get; set; }
        public string gameday_sw { get; set; }
        public string away_win { get; set; }
        public string home_games_back_wildcard { get; set; }
        public SavePitcher save_pitcher { get; set; }
        public string away_team_id { get; set; }
        public string tz_hm_lg_gen { get; set; }
        public Status status { get; set; }
        public string home_loss { get; set; }
        public string home_games_back { get; set; }
        public string home_code { get; set; }
        public string away_sport_code { get; set; }
        public string home_win { get; set; }
        public string time_hm_lg { get; set; }
        public string away_name_abbrev { get; set; }
        public string league { get; set; }
        public string time_zone_aw_lg { get; set; }
        public string away_games_back { get; set; }
        public string home_file_code { get; set; }
        public string game_data_directory { get; set; }
        public string time_zone { get; set; }
        public string away_league_id { get; set; }
        public string home_team_id { get; set; }
        public string day { get; set; }
        public string time_aw_lg { get; set; }
        public string away_team_city { get; set; }
        public string tbd_flag { get; set; }
        public string tz_aw_lg_gen { get; set; }
        public string away_code { get; set; }
        public WinningPitcher winning_pitcher { get; set; }
        public string game_nbr { get; set; }
        public string time_date_aw_lg { get; set; }
        public string away_games_back_wildcard { get; set; }
        public string scheduled_innings { get; set; }
        public Linescore linescore { get; set; }
        public string venue_w_chan_loc { get; set; }
        public string first_pitch_et { get; set; }
        public string away_team_name { get; set; }
        public HomeRuns home_runs { get; set; }
        public string time_date_hm_lg { get; set; }
        public string id { get; set; }
        public string home_name_abbrev { get; set; }
        public string tiebreaker_sw { get; set; }
        public string ampm { get; set; }
        public string home_division { get; set; }
        public string home_time_zone { get; set; }
        public Alerts alerts { get; set; }
        public string away_time_zone { get; set; }
        public string hm_lg_ampm { get; set; }
        public string home_sport_code { get; set; }
        public string time_date { get; set; }
        public Links links { get; set; }
        public string home_ampm { get; set; }
        public string game_pk { get; set; }
        public string venue { get; set; }
        public string home_league_id { get; set; }
        public string video_thumbnail { get; set; }
        public string away_loss { get; set; }
        public string resume_date { get; set; }
        public string away_file_code { get; set; }
        public LosingPitcher losing_pitcher { get; set; }
        public string aw_lg_ampm { get; set; }
        public VideoThumbnails video_thumbnails { get; set; }
        public string time_zone_hm_lg { get; set; }
        public string away_ampm { get; set; }
        public string gameday { get; set; }
        public string away_division { get; set; }
        public Review review { get; set; }
        public Pitcher pitcher { get; set; }
        public RunnersOnBase runners_on_base { get; set; }
        public DueUpBatter due_up_batter { get; set; }
        public Inhole inhole { get; set; }
        public DueUpOndeck due_up_ondeck { get; set; }
        public Batter batter { get; set; }
        public OpposingPitcher opposing_pitcher { get; set; }
        public Pbp pbp { get; set; }
        public DueUpInhole due_up_inhole { get; set; }
        public Ondeck ondeck { get; set; }
        public AwayProbablePitcher away_probable_pitcher { get; set; }
        public HomeProbablePitcher home_probable_pitcher { get; set; }

        public BaseballGame ConvertToRock()
        {
            BaseballTeam home = new BaseballTeam()
            {
                Abbreviation = home_name_abbrev,
                City = home_team_city,
                Name = home_team_name,
                IsHome = true,
                Wins = home_win.ToInt(),
                Losses = home_loss.ToInt(),
            };

            if (linescore != null)
            {
                home.H = linescore.h.home.ToInt();
                home.HR = linescore.hr.home.ToInt();
                home.K = linescore.so.home.ToInt();
                home.SB = linescore.sb.home.ToInt();
                home.Score = linescore.r.home.ToInt();
            }

            BaseballTeam away = new BaseballTeam()
            {
                Abbreviation = away_name_abbrev,
                City = away_team_city,
                Name = away_team_name,
                IsHome = false,
                Wins = away_win.ToInt(),
                Losses = away_loss.ToInt(),
            };

            if (linescore != null)
            {
                away.H = linescore.h.away.ToInt();
                away.HR = linescore.hr.away.ToInt();
                away.K = linescore.so.away.ToInt();
                away.SB = linescore.sb.away.ToInt();
                away.Score = linescore.r.away.ToInt();
            }

            BaseballGame game = new BaseballGame()
            {
                HomeTeam = home,
                AwayTeam = away,
                Inning = status.inning,
                OnDeck = ondeck != null ? ondeck.ConvertToRock() : null,
                InHole = inhole != null ? inhole.ConvertToRock() : null,
                AtBat = batter != null ? batter.ConvertToRock() : null,
                Pitcher = pitcher != null ? pitcher.ConvertToRock() : null,
                ProbableAway = away_probable_pitcher != null ? away_probable_pitcher.ConvertToRock() : null,
                ProbableHome = home_probable_pitcher != null ? home_probable_pitcher.ConvertToRock() : null,
                IsPerfectGame = status.is_perfect_game != null ? !status.is_perfect_game.Equals("N") : false,
                IsNoHitter = status.is_no_hitter != null ? !status.is_no_hitter.Equals("N") : false,
                Venue = venue,
                StartTime = time.ToDate().AddHours(12),
                LastPlay = pbp != null ? pbp.last.ToString() : null
            };

            game.State = status.status.Equals("Final") ? GameState.Final
                       : status.status.Equals("In Progress") ? GameState.InProgress
                       : GameState.NotStarted;

            return game;
        }
    }

    internal class Games
    {
        public string next_day_date { get; set; }
        public string modified_date { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public List<Game> game { get; set; }
        public string day { get; set; }
    }

    internal class Data
    {
        public Games games { get; set; }
    }

    internal class ShellBaseballResponse
    {
        public string subject { get; set; }
        public string copyright { get; set; }
        public Data data { get; set; }

        public BaseballResponse ConvertToRock()
        {
            List<BaseballGame> games = data.games.game.Select(gm => gm.ConvertToRock()).ToList();

            BaseballResponse response = new BaseballResponse()
            {
                Games = games
            };

            return response;
        }
    }

    #endregion

    public class BaseballAPI : BaseAPI
    {
        private const string baseURL = "http://gd2.mlb.com/components/game/mlb/year_{0}/month_{1}/day_{2}/master_scoreboard.json";
        private string FullURL { get; set; }

        private List<BaseballGame> Games { get; set; }
        private List<BaseballPlayer> Players { get; set; }
        private List<BaseballTeam> Teams { get; set; }

        private List<BaseballPlayer> Targets { get; set; }

        public BaseballAPI() : base()
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month >= 10 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day >= 10 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString();

            FullURL = string.Format(baseURL, year, month, day);
        }

        public BaseballResponse GetGames()
        {
            try
            {
                ShellBaseballResponse response = InternetUtility.DeserializeResponse<ShellBaseballResponse>(FullURL);
                return response.ConvertToRock();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
