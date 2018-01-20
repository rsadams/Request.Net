using System;

namespace Request.Net
{
    public enum State 
    {
        Created,
        Accepted,
        Cancelled
    }

    public enum EscrowState 
    {
        Created,
        Refunded,
        Released
    }

    public delegate void TransactionHash(string transactionHash);
    public delegate void TransactionResponse(string any);
    public delegate void TransactionConfirmation(int confirmationNumber, object receipt);
    public delegate void TransactionError(string error);

    public delegate void GetRequest();
    public delegate void IPFSAddFile();
    public delegate void ErrorData(); 
}