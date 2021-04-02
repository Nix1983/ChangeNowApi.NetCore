using ChangeNowApi_V2.Enums;

namespace ChangeNowApi_V2.Helper
{
    public static class ChangeNowConverter
    {
        public static TransactionStatus StringToTransactionStatus(object value)
        {
            if (value == null) return TransactionStatus.UnKnown;

            if(value is string valueString) value = valueString.ToUpper();

            if (value.Equals(TransactionStatus.New))
            {
                return TransactionStatus.New;
            }
            else if (value.Equals(TransactionStatus.Waiting))
            {
                return TransactionStatus.Waiting;
            }
            else if (value.Equals(TransactionStatus.Confirming))
            {
                return TransactionStatus.Confirming;
            }
            else if (value.Equals(TransactionStatus.Exchanging))
            {
                return TransactionStatus.Exchanging;
            }
            else if (value.Equals(TransactionStatus.Sending))
            {
                return TransactionStatus.Sending;
            }
            else if (value.Equals(TransactionStatus.Finished))
            {
                return TransactionStatus.Finished;
            }
            else if (value.Equals(TransactionStatus.Failed))
            {
                return TransactionStatus.Failed;
            }
            else if (value.Equals(TransactionStatus.Refunded))
            {
                return TransactionStatus.Refunded;
            }
            else if (value.Equals(TransactionStatus.Veriying))
            {
                return TransactionStatus.Veriying;
            }
            else
            {
                return TransactionStatus.UnKnown;
            }
        }

        public static string TransactionStatusToString(TransactionStatus status)
        {
            return status.ToString().ToUpper();
        }
    }
}
