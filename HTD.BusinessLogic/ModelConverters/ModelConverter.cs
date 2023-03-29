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

        protected (DateTime res, bool success) GetTimeFromString(string value)
        {
            DateTime res = new DateTime(1980, 1, 1, 1, 1, 1);
            bool success = true;
            try
            {
                var hours = int.Parse(value.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                var minutes = int.Parse(value.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                res = new DateTime(1980, 1, 1, hours, minutes, 0);
            }
            catch
            {
                success = false;
            }

            return (res, success);
        }
    }
}
