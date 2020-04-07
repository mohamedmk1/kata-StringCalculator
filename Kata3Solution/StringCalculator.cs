using System;
using System.Collections.Generic;
using System.Text;

namespace Kata3Solution
{
    public class StringCalculator
    {
        public int AddNumber(string numbers, List<String> seperators)
        {   
            int sum = 0;
            if(numbers.Length == 1)
            {
                sum = Int32.Parse(numbers);
            }
            else if (numbers.Length > 1)
            {
                try
                {
                    sum = ParseString(numbers, sum, seperators);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return sum;
        }

        private static int ParseString(string numbers, int sum, List<String> seperators)
        {
            bool isPreviousSeperator = false;
            bool isNegative = false;
            bool isDemileter = false;
            string negativeNumbers = "";
            string value = "";
            string delimeters = "";
            int delimeterOccurence = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers.StartsWith("//") && i == 0)
                {
                    i = i + 1;
                    continue;
                }
                if (numbers[i].ToString() == "-")
                {
                    isNegative = true;
                    continue;
                }
                if (numbers[i].ToString() == "[")
                {
                    isDemileter = true;
                    continue;
                }
                if (numbers[i].ToString() == "]")
                {
                    isDemileter = false;
                }
                if (isDemileter)
                {
                    delimeters += numbers[i].ToString();
                    continue;
                }
                if (isPreviousSeperator && seperators.Contains(numbers[i].ToString()))
                {
                    throw new Exception("The following input is not ok");
                }
                if (!string.IsNullOrEmpty(delimeters) 
                    && delimeters.Contains(numbers[i]))
                {
                    delimeterOccurence++;
                    continue;
                }
                if((!string.IsNullOrEmpty(delimeters) && (int)char.GetNumericValue(numbers[i]) >= 0
                            && (int)char.GetNumericValue(numbers[i]) <= 9))
                {
                    if (delimeterOccurence == delimeters.Length || delimeterOccurence == 0)
                    {
                        sum = CalculateSum(sum, numbers[i].ToString());
                        delimeterOccurence = 0;
                        continue;
                    }
                    else
                    {
                        throw new Exception("The delimeters must be the same");
                    }
                }
                if ((seperators.Contains(numbers[i].ToString()) && !string.IsNullOrEmpty(value)))
                {
                    sum = CalculateSum(sum, value);
                    value = "";
                    isPreviousSeperator = true;
                }
                if (!seperators.Contains(numbers[i].ToString()) 
                    && numbers[i].ToString() != "\n" && numbers[i].ToString() != "-") 
                {
                    isPreviousSeperator = false;
                    if (isNegative)
                    {
                        negativeNumbers += $" -{(int)char.GetNumericValue(numbers[i])}";
                    }
                    else
                    {
                        if ((int)char.GetNumericValue(numbers[i]) >= 0 
                            && (int)char.GetNumericValue(numbers[i]) <= 9)
                        {
                            if(delimeters.Length > 0 && delimeterOccurence == delimeters.Length)
                            {
                                sum = CalculateSum(sum, value);
                                delimeterOccurence = 0;
                            }
                            else
                            {
                                value += numbers[i];
                            }
                        }
                    }
                }
                if(isNegative && i == numbers.Length - 1)
                {
                    throw new Exception($"negatives not allowed:{negativeNumbers}");
                }
                if (i == numbers.Length - 1 && !string.IsNullOrEmpty(value))
                {
                    sum = CalculateSum(sum, value);
                }
            }

            return sum;
        }

        private static int CalculateSum(int sum, string value)
        {
            if (Convert.ToInt32(value) < 1000)
            {
                sum += Convert.ToInt32(value);
            }

            return sum;
        }
    }
}
