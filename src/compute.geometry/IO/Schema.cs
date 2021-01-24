﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Resthopper.IO
{
    public class Schema
    {
        public Schema() {}

        [JsonProperty(PropertyName = "algo")]
        public string Algo { get; set; }

        [JsonProperty(PropertyName = "pointer")]
        public string Pointer { get; set; }

        [JsonProperty(PropertyName = "values")]
        public List<DataTree<ResthopperObject>> Values { get; set; } = new List<DataTree<ResthopperObject>>();
    }

    public class IoQuerySchema
    {
        [JsonProperty(PropertyName = "requestedFile")]
        public string RequestedFile { get; set; }

    }

    public class IoParamSchema
    {
        public string Name { get; set; }
        public string ParamType { get; set; }
        
        public IoParamSchemaRange Range { get; set; }
        public IoParamSchemaValue<bool> Boolean { get; set; }
        public IoParamSchemaValue<int> Integer { get; set; }
        public IoParamSchemaValue<double> Number { get; set; }
    }

    public class IoParamSchemaRange
    {
        public double Max { get; set; }
        public double Min { get; set; }
        public double Value { get; set; }
    }

    public class IoParamSchemaValue<T>
    {
        public IoParamSchemaValue(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }


    public class IoResponseSchema
    {
        public List<string> InputNames { get; set; }
        public List<string> OutputNames { get; set; }

        public List<IoParamSchema> Inputs { get; set; }
        public List<IoParamSchema> Outputs { get; set; }
    }

    public class ResthopperObject : IEquatable<ResthopperObject>
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }

        [JsonConstructor]
        public ResthopperObject()
        {
        }

        public ResthopperObject(object obj)
        {
            Data = JsonConvert.SerializeObject(obj, compute.geometry.GeometryResolver.Settings);
            Type = obj.GetType().FullName;
        }

        public bool Equals(ResthopperObject other)
        {
            return string.Equals(Type, other.Type) && string.Equals(Data, other.Data);
        }
    }
}
