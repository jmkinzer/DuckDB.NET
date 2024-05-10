﻿using System;
using System.Numerics;
using DuckDB.NET.Native;

namespace DuckDB.NET.Data.Internal.Writer;

internal sealed unsafe class NumericVectorDataWriter(IntPtr vector, void* vectorData, DuckDBType columnType) : VectorDataWriterBase(vector, vectorData, columnType)
{
    internal override bool AppendNumeric<T>(T value, int rowIndex) => AppendValueInternal(value, rowIndex);

    internal override bool AppendBigInteger(BigInteger value, int rowIndex) => AppendValueInternal<DuckDBHugeInt>(new DuckDBHugeInt(value), rowIndex);
}
