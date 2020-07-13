using System;

namespace HelloSockets
{
    public class OrderChecker
    {
        private readonly Random _random;
        private int _index;

        private readonly string[] _status = {"Processing", "Waiting for factory response", "In transit"};

        public OrderChecker(Random random)
        {
            this._random = random;
        }

        public CheckResult GetUpdate(Guid orderId)
        {
            if (_random.Next(1, 3) == 3)
            {
                if (_status.Length - 1 > _index)
                {
                    _index++;
                    var result = new CheckResult
                    {
                        New = true,
                        Update = _status[_index],
                        Finished = _status.Length - 1 == _index
                    };

                    if (result.Finished)
                    {
                        _index = 0;
                    }
                    return result;
                }
            }

            return new CheckResult { New = false };
        }
    }
}