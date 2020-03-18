﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LiveSplit.CatchTheRun
{
    internal static class Util
    {
        internal const int SPLIT_NAME_INDEX = 0;
        internal const int SPLIT_TIME_INDEX = 1;
        internal const int THRESHOLD_INDEX = 2;

        internal const string CREDENTIALS_ELEMENT_NAME = "Credentials";
        internal const string CLIENT_ID_ELEMENT_NAME = "ClientID";
        internal const string CLIENT_KEY_ELEMENT_NAME = "ClientKey";
        internal const string THRESHOLD_ELEMENT_NAME = "Threshold";

        internal static Dictionary<string, string> ConvertDataRowsToDictionary(DataGridViewRowCollection rows)
        {
            var result = new Dictionary<string, string>();

            foreach (DataGridViewRow row in rows)
            {
                var splitName = row.Cells[SPLIT_NAME_INDEX].Value as string;
                var thresholdValue = row.Cells[THRESHOLD_INDEX].Value as string;

                if (thresholdValue == null)
                    thresholdValue = "";

                result.Add(splitName, thresholdValue);
            }

            return result;
        }

        internal static bool IsThresholdInputValid(string input)
        {
            if (input[0] == '+' || input[0] == '-')
                return Double.TryParse(input.Substring(1), out double _);
            else
                return false;
        }
    }
}
