﻿using System;
using DBVC;
using NLog;
using RankingandCompletion.CompletionLogic;
using RankingandCompletion.RankingLogic;
using Result = LarrysList.Result;

namespace RankingandCompletion
{
    class CollectorQueue
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public CollectorQueue()
        {
            log.Info("CollectorQueue instantiated");

        }

        public void process()
        {
            try
            {
                     log.Info("debugging in here");

            var collectors = new CollectorRun().collectors;
            foreach (var c in collectors)
            {
                log.Info("processing " + c.firstName + " " + c.lastName);
                new AssignRanking(c).assign();
                new AssignCompletion(c).assign();
                log.Info("finsihed calculation for " + c.firstName + " " + c.lastName);

            }

            var orm = new Orm();
            log.Info("trying to save ranking and completion for all");
            var result = orm.execObject<Result>(collectors, "job.collector_ranking_completion_set");
            log.Info("sucessfuly saved ranking and completion for all");
        }
            catch(Exception exp)
            {
                log.Error(exp);
            }
        }

    }
    }

