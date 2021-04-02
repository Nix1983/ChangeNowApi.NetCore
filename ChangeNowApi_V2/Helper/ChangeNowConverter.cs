using ChangeNowApi_V2.Enums;

namespace ChangeNowApi_V2.Helper
{
    public static class ChangeNowConverter
    {
        public static TransactionStatus StringToTransactionStatus(object value)
        {
            if (value == null) return TransactionStatus.UnKnown;

            if(value is string valueString) value = valueString.ToLower();

            if (value.Equals(TransactionStatus.New.ToString().ToLower()))
            {
                return TransactionStatus.New;
            }
            else if (value.Equals(TransactionStatus.Waiting.ToString().ToLower()))
            {
                return TransactionStatus.Waiting;
            }
            else if (value.Equals(TransactionStatus.Confirming.ToString().ToLower()))
            {
                return TransactionStatus.Confirming;
            }
            else if (value.Equals(TransactionStatus.Exchanging.ToString().ToLower()))
            {
                return TransactionStatus.Exchanging;
            }
            else if (value.Equals(TransactionStatus.Sending.ToString().ToLower()))
            {
                return TransactionStatus.Sending;
            }
            else if (value.Equals(TransactionStatus.Finished.ToString().ToLower()))
            {
                return TransactionStatus.Finished;
            }
            else if (value.Equals(TransactionStatus.Failed.ToString().ToLower()))
            {
                return TransactionStatus.Failed;
            }
            else if (value.Equals(TransactionStatus.Refunded.ToString().ToLower()))
            {
                return TransactionStatus.Refunded;
            }
            else if (value.Equals(TransactionStatus.Verifying.ToString().ToLower()))
            {
                return TransactionStatus.Verifying;
            }
            else
            {
                return TransactionStatus.UnKnown;
            }
        }

        public static string TransactionStatusToString(TransactionStatus status)
        {
            return status.ToString().ToLower();
        }
    }
}
