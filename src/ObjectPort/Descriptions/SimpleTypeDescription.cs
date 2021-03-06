﻿#region License
//Copyright(c) 2016 Dmytro Mukalov

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
#endregion

namespace ObjectPort.Descriptions
{
    using Builders;
    using System;
    using System.Linq.Expressions;

    internal class SimpleTypeDescription<T> : SpecializedTypeDescription<T>
    {
        private MemberSerializerBuilder _builder;

        public SimpleTypeDescription(ushort typeId, Type type, SerializerState state) : base(typeId, type, state)
        {
            _builder = BuilderFactory.GetBuilder(type, null, state);
        }

        internal override MemberDescription[] GetDescriptions(SerializerState state)
        {
            return new MemberDescription[] { };
        }

        internal override Expression GetDeserializerExpression(ParameterExpression readerExp)
        {
            return _builder.GetDeserializerExpression(Type, readerExp);
        }

        internal override Expression GetSerializerExpression(ParameterExpression instanceExp, ParameterExpression writerExp)
        {
            return _builder.GetSerializerExpression(Type, instanceExp, writerExp);
        }
    }
}
