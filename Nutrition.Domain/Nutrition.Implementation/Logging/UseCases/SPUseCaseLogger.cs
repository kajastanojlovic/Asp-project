﻿using Newtonsoft.Json;
using Nutrition.Application;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Nutrition.Implementation.Logging.UseCases
{
    public class SPUseCaseLogger : IUseCaseLogger
    {
        private IDbConnection _connection;
        public SPUseCaseLogger(IDbConnection connection)
        {
            _connection = connection;
        }
        public void Log(UseCaseLog log)
        {
            _connection.Query("AddUseCaseLog",
                                new { log.UseCaseName, log.Username, Data = JsonConvert.SerializeObject(log.UseCaseData), ExecutedAt = DateTime.UtcNow });

        }
    }
}
