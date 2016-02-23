namespace TheatreGuide
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Commands;
    using Interfaces;

    internal static class CommandExecuter
    {
        internal static string ExecuteAddTheatreCommand(IPerformanceDatabase db, AddThratreCommand command)
        {
            db.AddTheatre(command.TheatreName);
            return "Theatre added";
        }

        public static string ExecutePrintAllTheatresCommand(IPerformanceDatabase dataBase)
        {
            var theatresCount = dataBase.ListTheatres().Count();
            if (theatresCount > 0)
            {
                var resultTheatres = new LinkedList<string>();
                for (var i = 0; i < theatresCount; i++)
                {
                    dataBase.ListTheatres().Skip(i).ToList().ForEach(t => resultTheatres.AddLast(t));

                    foreach (var t in dataBase.ListTheatres().Skip(i + 1))
                    {
                        resultTheatres.Remove(t);
                    }
                }
                return string.Join(", ", resultTheatres);
            }
            return "No theatres";
        }

        public static string ExecutePrintAllPerformancesCommand(IPerformanceDatabase dataBase)
        {
            var performances = dataBase.ListAllPerformances().ToList();
            var result = string.Empty;
            if (performances.Any())
            {
                for (var i = 0; i < performances.Count; i++)
                {
                    var sb = new StringBuilder();
                    sb.Append(result);
                    if (i > 0)
                    {
                        sb.Append(", ");
                    }
                    var result1 = performances[i].Date.ToString("dd.MM.yyyy HH:mm");
                    sb.AppendFormat(
                        "({0}, {1}, {2})", performances
                            [i].PefrofmanceName, performances[i].Theatre, result1);
                    result = sb + "";
                }
                return result;
            }

            return "No performances";
        }

        public static string ExecuteAddPerformanceCommand(IPerformanceDatabase dataBase, AddPerformanceCommand command)
        {
            dataBase.AddPerformance(
                command.Theatre,
                command.Performance,
                command.Date,
                command.Duration,
                command.Price);

            return "Performance added";
        }

        public static string ExecutePrintPerformancesCommand(IPerformanceDatabase dataBase,
            PrintPerformancesCommand command)
        {
            string result = String.Empty;
            var performances = dataBase.ListPerformances(command.TheatreName)
                            .Select(p =>
                            {
                                var result1 = p.Date.ToString("dd.MM.yyyy HH:mm");
                                return string.Format("({0}, {1})", p.PefrofmanceName, result1);
                            })
                            .ToList();

            if (performances.Any())
            {
                result = string.Join(", ", performances);
            }
            else
            {
                result = "No performances";
            }
            return result;
        }
    }
}