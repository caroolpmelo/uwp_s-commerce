﻿namespace PrismSample.Services
{
    public class CounterService : ICounterService
    {
        private int counter = 0;

        public int GetCount()
        {
            return counter;
        }

        public int IncrementCount(int val)
        {
            counter += val;
            return counter;
        }
    }
}
