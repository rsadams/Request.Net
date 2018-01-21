using System;
using System.Collections.Generic;

namespace Request.Net
{
    public class Abi
    {
        public bool Constant { get; set; }
        public List<Input> Inputs { get; set; }
        public string Name { get; set; }
        public List<Output> Outputs { get; set; }
        public bool Payable { get; set; }
        public string StateMutability { get; set; }
        public string Type { get; set; }
        public bool? Anonymous { get; set; }
    }

    public class Input
    {     
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Output
    {
        public string Name { get; set; }
        public string Type { get; set; } 
    }

    public class Compiler
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }

    public class Private
    {
        public string Address { get; set; }
        public int BlockNumber { get; set; }
    }

    public class Rinkeby
    {
        public string Address { get; set; }
        public int BlockNumber { get; set; }
    }

    public class Networks
    {
        public Private @Private { get; set; }
        public Rinkeby Rinkeby { get; set; }
    }

    public class Artifact
    {
        public string ContractName { get; set; }
        public List<Abi> Abi { get; set; }
        public string ByteCode { get; set; }
        public Compiler Compiler { get; set; }
        public Networks Networks { get; set; }
    }
}
