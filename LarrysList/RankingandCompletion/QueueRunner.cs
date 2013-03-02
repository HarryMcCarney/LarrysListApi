using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Timers;
using NLog;

namespace RankingandCompletion
{
    public class QueueRunner
    {

        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        private readonly Timer _timer;

        public QueueRunner()
        {
            _timer = new Timer(5000) {AutoReset = true};
            _timer.Elapsed += (sender, eventArgs) => process();
        }

        public void start()
        {
            _timer.Start();
        }

        public void stop()
        {
            _timer.Stop();
        }

        public void process()
        {
            log.Info("starting job");
            new CollectorQueue().process();
            log.Info("finsihed job");
        }
    }
}