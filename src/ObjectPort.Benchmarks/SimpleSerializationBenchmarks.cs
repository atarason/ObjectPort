﻿namespace ObjectPort.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Attributes.Exporters;
    using BenchmarkDotNet.Attributes.Jobs;
    using Serializers;
    using System;

    [ClrJob, CoreJob]
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    public class SimpleSerializationBenchmarks : SerializationBenchmarks
    {
#if !NETCORE
        [Serializable]
#endif
        public class TestClass
        {
            public string Field1 { get; set; }
            public int Field2 { get; set; }
            public int Prop1 { get; set; }
        }

        private TestClass _testObj;
        private Random _rnd;

        public SimpleSerializationBenchmarks()
        {
            _rnd = new Random();
            Inititalize(new[] { typeof(TestClass) });
        }

        [Setup]
        public void Setup()
        {
            _testObj = new TestClass
            {
                Field1 = new StringGenerator().Generate(20, 50),
                Field2 = _rnd.Next(0, int.MaxValue),
                Prop1 = _rnd.Next(0, int.MaxValue)
            };
            foreach (var serializer in _serializers)
                serializer.Value.InitializeIteration();
        }

        [Cleanup]
        public void Cleanup()
        {
            foreach (var serializer in _serializers)
                serializer.Value.CleanupIteration();
        }

#if !NETCORE
        [Benchmark]
        public void NetSerializerSerialize()
        {
            _serializers[typeof(NetSerializaerSerializer)].Serialize(_testObj);
        }

        [Benchmark]
        public void MessageSharkSerialize()
        {
            _serializers[typeof(MessageSharkSerializer)].Serialize(_testObj);
        }

        [Benchmark]
        public void SalarBoisSerialize()
        {
            _serializers[typeof(SalarBoisSerializer)].Serialize(_testObj);
        }

        public void AvroSerialize()
        {
        }
#endif

        [Benchmark]
        public void ProtobufSerialize()
        {
            _serializers[typeof(ProtobufSerializer)].Serialize(_testObj);
        }

        [Benchmark]
        public void WireSerialize()
        {
            _serializers[typeof(WireSerializer)].Serialize(_testObj);
        }


        [Benchmark]
        public void ObjectPortSerialize()
        {
            _serializers[typeof(ObjectPortSerializer)].Serialize(_testObj);
        }
    }
}
