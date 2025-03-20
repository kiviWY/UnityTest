using System.Collections;
using System.Collections.Generic;
using ProtoBuf;
using UnityEngine;

namespace Example_05
{

    [ProtoContract]
    public class Person
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }
        
        [ProtoMember(3)]
        public Address Address { get; set; }


        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Address: {2}", Id, Name, Address);
        }
    }

    [ProtoContract]
    public class Address
    {
        [ProtoMember(1)]
        public string Province { get; set; }
        [ProtoMember(2)]
        public string City { get; set; }
        
        public override string ToString(){ return string.Format("Province: {0}, City: {1}", Province, City); }
    }
}
