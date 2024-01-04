using System;
using iQuest.VendingMachine.Business.Dependencies;

namespace iQuest.VendingMachine.Business.Payment
{
    public class CardPaymentValidator
    {
        public string Method { get; } = "card";
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public DateTime ExpirationDate { get; set; }

        public CardPaymentValidator(string CardNumber, string CVV, DateTime ExpirationDate)
        {
            this.CardNumber = CardNumber;
            this.CVV = CVV;
            this.ExpirationDate = ExpirationDate;
        }

        public static bool ValidCardNumber(string cardNumber)
        {
            int sum = 0;
            bool alternate = false;

            if (cardNumber.Length < 13 || cardNumber.Length > 19)
            {
                return false;
            }


            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int digit = cardNumber[i] - '0';

                if (alternate)
                {
                    digit *= 2;

                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
                alternate = !alternate;
            }
            return sum % 10 == 0;
        }

        public static bool ValidCVV(string CVV)
        {
            if (CVV.Length == 3 && int.TryParse(CVV, out _))
                return true;

            return false;
        }

        public static bool ValidExpirationDate(DateTime expirationDate)
        {
            return expirationDate.CompareTo(DateTime.Now) > 0;
        }

        public bool ValidCard()
        {
            return ValidCardNumber(CardNumber) && ValidCVV(CVV) && ValidExpirationDate(ExpirationDate);
        }

        public bool IsValidMethod()
        {
            return ValidCard();
        }
    }
}

