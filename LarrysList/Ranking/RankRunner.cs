using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ranking
{
    public class RankRunner
    {
        readonly Timer _timer;
         public RankRunner()
        {
            _timer = new Timer(1000) { AutoReset = true };
             _timer.Elapsed += (sender, eventArgs) => elapsedEvent();
        }


        private void elapsedEvent()
        {
            _timer.Interval = 86400000;
            Ranks.getRanks();
            

        }

        public void start() { _timer.Start(); }
        public void stop() { _timer.Stop(); }
    }
}
