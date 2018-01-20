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

    // Appears to provide a wrapper for de-serialising the artifact JSON?
    public class Abi
    {
        string Name { get; set; }
    }

    // Appears to provide a wrapper for de-serialising the artifact JSON?
    public class Network
    {
        public string Address { get; set; }
        public string BlockNumber { get; set; }
    }

    // Appears to provide a wrapper for de-serialising the artifact JSON?
    public class InterfaceArtifact
    {
        public Abi Abi { get; set; }
        public Network[] Networks { get; set; }
    }
}