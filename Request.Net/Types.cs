using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;

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

    [FunctionOutput]
    public class Request
    {
        [Parameter("address", "creator", 1)]
        public string Creator { get; set; }

        [Parameter("address", "payee", 2)]
        public string Payee { get; set; }

        [Parameter("address", "payer", 3)]
        public string Payer { get; set; }

        [Parameter("int256", "expectedAmount", 4)]
        public BigInteger ExpectedAmount { get; set; }

        [Parameter("address", "currencyContract", 5)]
        public string CurrencyContract { get; set; }

        [Parameter("int256", "balance", 6)]
        public BigInteger Balance { get; set; }

        [Parameter("uint8", "state", 7)]
        public uint State { get; set; }

        [Parameter("address", "extension", 8)]
        public string Extension { get; set; }

        [Parameter("string", "data", 9)]
        public string Data { get; set; }
    }

    public delegate void TransactionHash(string transactionHash);
    public delegate void TransactionResponse(string any);
    public delegate void TransactionConfirmation(int confirmationNumber, object receipt);
    public delegate void TransactionError(string error);

    public delegate void GetRequest();
    public delegate void IPFSAddFile();
    public delegate void ErrorData();
}



