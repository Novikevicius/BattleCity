using System;

namespace BattleCity.Miscellaneous
{
    public class Timer
    {
        public  event EventHandler OnTimerEnded;

        public  bool  IsStarted { get; private set; }
        private float counter;

        public void Start(float seconds)
        {
            counter = seconds;
            IsStarted = true;
        }
        public void Update()
        {
            if (!IsEnded() && IsStarted)
            {
                counter -= UnityEngine.Time.deltaTime;
            }
        }
        public void AddSeconds(float seconds)
        {
            counter += seconds;
            if (!IsStarted)
                IsStarted = true;
        }
        public bool IsEnded()
        {
            bool ended = (counter <= 0);
            if (ended)
            {
                IsStarted = false;
                if (OnTimerEnded != null) OnTimerEnded(this, null);
            }
            return ended;
        }
    }
}
