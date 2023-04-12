using System;

namespace HTD.BusinessLogic.ModelConverters
{
    internal abstract class ModelConverter
    {
        protected (int res, bool success) GetIntFromString(string value)
        {
            int res = 0;
            bool success = true;
            try
            {
                res = int.Parse(value);
            }
            catch
            {
                success = false;
            }

            return (res, success);
        }

        protected (DateTime res, bool success) GetDateFromString(string value)
        {
            DateTime res = new DateTime(1980, 1, 1, 1, 1, 1);
            bool success = true;
            try
            {
                res = DateTime.Parse(value);
            }
            catch
            {
                success = false;
            }

            return (res, success);
        }

        protected (TimeSpan res, bool success) GetTimeFromString(string value)
        {
            TimeSpan res = new TimeSpan(0, 0, 0);
            bool success = true;
            try
            {
                var hours = int.Parse(value
                    .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                var minutes = int.Parse(value
                    .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                if (hours < 0 || hours > 23)
                {
                    success = false;
                    return (res, success);
                }
                if (minutes < 0 || minutes > 59)
                {
                    success = false;
                    return (res, success);
                }

                res = new TimeSpan(hours, minutes, 0);
            }
            catch
            {
                success = false;
            }

            return (res, success);
        }
    }
}
