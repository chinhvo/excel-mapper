﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExcelMapper.Mappings;
using Xunit;

namespace ExcelMapper.Tests
{
    public class EnumerablePropertyMappingTests
    {
        [Theory]
        [InlineData(EmptyValueStrategy.SetToDefaultValue)]
        [InlineData(EmptyValueStrategy.ThrowIfPrimitive)]
        public void Ctor_MemberInfo_EmptyValueStategy(EmptyValueStrategy emptyValueStrategy)
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, emptyValueStrategy);
            Assert.Same(propertyInfo, mapping.Member);

            Assert.NotNull(mapping.ElementMapping);
        }

        [Theory]
        [InlineData(EmptyValueStrategy.SetToDefaultValue + 1)]
        [InlineData(EmptyValueStrategy.ThrowIfPrimitive - 1)]
        public void Ctor_InvalidEmptyValueStrategy_ThrowsArgumentException(EmptyValueStrategy emptyValueStrategy)
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            Assert.Throws<ArgumentException>("emptyValueStrategy", () => new SubPropertyMapping(propertyInfo, emptyValueStrategy));
        }

        [Fact]
        public void WithElementMapping_ValidMapping_Success()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var elementMapping = new SinglePropertyMapping<string>(propertyInfo, EmptyValueStrategy.SetToDefaultValue);

            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive);
            Assert.Same(mapping, mapping.WithElementMapping(e =>
            {
                Assert.Same(e, mapping.ElementMapping);
                return elementMapping;
            }));
            Assert.Same(elementMapping, mapping.ElementMapping);
        }

        [Fact]
        public void WithElementMapping_NullMapping_ThrowsArgumentNullException()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive);

            Assert.Throws<ArgumentNullException>("elementMapping", () => mapping.WithElementMapping(null));
        }

        [Fact]
        public void WithElementMapping_MappingReturnsNull_ThrowsArgumentNullException()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive);

            Assert.Throws<ArgumentNullException>("elementMapping", () => mapping.WithElementMapping(e => null));
        }

        [Fact]
        public void WithColumnName_SplitValidColumnName_Success()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive);
            Assert.Same(mapping, mapping.WithColumnName("ColumnName"));

            SplitPropertyMapper mapper = Assert.IsType<SplitPropertyMapper>(mapping.Mapper);
            ColumnPropertyMapper innerMapper = Assert.IsType<ColumnPropertyMapper>(mapper.Mapper);
            Assert.Equal("ColumnName", innerMapper.ColumnName);
        }

        [Fact]
        public void WithColumnName_MultiValidColumnName_Success()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive).WithColumnNames("ColumnName");
            Assert.Same(mapping, mapping.WithColumnName("ColumnName"));

            SplitPropertyMapper mapper = Assert.IsType<SplitPropertyMapper>(mapping.Mapper);
            ColumnPropertyMapper innerMapper = Assert.IsType<ColumnPropertyMapper>(mapper.Mapper);
            Assert.Equal("ColumnName", innerMapper.ColumnName);
        }

        [Fact]
        public void WithColumnName_NullColumnName_ThrowsArgumentNullException()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive);

            Assert.Throws<ArgumentNullException>("columnName", () => mapping.WithColumnName(null));
        }

        [Fact]
        public void WithColumnName_EmptyColumnName_ThrowsArgumentException()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive);

            Assert.Throws<ArgumentException>("columnName", () => mapping.WithColumnName(string.Empty));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void WithIndex_SplitColumnIndex_Success(int columnIndex)
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive);
            Assert.Same(mapping, mapping.WithIndex(columnIndex));

            SplitPropertyMapper mapper = Assert.IsType<SplitPropertyMapper>(mapping.Mapper);
            IndexPropertyMapper innerMapper = Assert.IsType<IndexPropertyMapper>(mapper.Mapper);
            Assert.Equal(columnIndex, innerMapper.ColumnIndex);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void WithIndex_MultiColumnIndex_Success(int columnIndex)
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive).WithColumnNames("ColumnName");
            Assert.Same(mapping, mapping.WithIndex(columnIndex));

            SplitPropertyMapper mapper = Assert.IsType<SplitPropertyMapper>(mapping.Mapper);
            IndexPropertyMapper innerMapper = Assert.IsType<IndexPropertyMapper>(mapper.Mapper);
            Assert.Equal(columnIndex, innerMapper.ColumnIndex);
        }

        [Fact]
        public void WithIndex_NegativeColumnIndex_ThrowsArgumentOutOfRangeException()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive);

            Assert.Throws<ArgumentOutOfRangeException>("columnIndex", () => mapping.WithIndex(-1));
        }

        public static IEnumerable<object[]> Separators_TestData()
        {
            yield return new object[] { new char[] { ',' } };
            yield return new object[] { new char[] { ';', '-' } };
            yield return new object[] { new List<char> { ';', '-' } };
        }

        [Theory]
        [MemberData(nameof(Separators_TestData))]
        public void WithSeparators_ParamsString_Success(IEnumerable<char> separators)
        {
            char[] separatorsArray = separators.ToArray();

            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive);
            Assert.Same(mapping, mapping.WithSeparators(separatorsArray));

            SplitPropertyMapper mapper = Assert.IsType<SplitPropertyMapper>(mapping.Mapper);
            Assert.Same(separatorsArray, mapper.Separators);
        }

        [Theory]
        [MemberData(nameof(Separators_TestData))]
        public void WithSeparators_IEnumerableString_Success(IEnumerable<char> separators)
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive);
            Assert.Same(mapping, mapping.WithSeparators(separators));

            SplitPropertyMapper mapper = Assert.IsType<SplitPropertyMapper>(mapping.Mapper);
            Assert.Equal(separators, mapper.Separators);
        }

        [Fact]
        public void WithSeparators_NullSeparators_ThrowsArgumentNullException()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive);

            Assert.Throws<ArgumentNullException>("value", () => mapping.WithSeparators(null));
            Assert.Throws<ArgumentNullException>("value", () => mapping.WithSeparators((IEnumerable<char>)null));
        }

        [Fact]
        public void WithSeparators_EmptySeparators_ThrowsArgumentException()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive);

            Assert.Throws<ArgumentException>("value", () => mapping.WithSeparators(new char[0]));
            Assert.Throws<ArgumentException>("value", () => mapping.WithSeparators(new List<char>()));
        }

        [Fact]
        public void WithSeperators_MultiMap_ThrowsExcelMappingException()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive).WithColumnNames("ColumnNames");

            Assert.Throws<ExcelMappingException>(() => mapping.WithSeparators(new char[0]));
            Assert.Throws<ExcelMappingException>(() => mapping.WithSeparators(new List<char>()));
        }

        [Fact]
        public void WithColumnNames_ParamsString_Success()
        {
            var columnNames = new string[] { "ColumnName1", "ColumnName2", };
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive).WithColumnNames("ColumnNames");
            Assert.Same(mapping, mapping.WithColumnNames(columnNames));

            ColumnsNamesPropertyMapper mapper = Assert.IsType<ColumnsNamesPropertyMapper>(mapping.Mapper);
            Assert.Same(columnNames, mapper.ColumnNames);
        }

        [Fact]
        public void WithColumnNames_IEnumerableString_Success()
        {
            var columnNames = new List<string> { "ColumnName1", "ColumnName2", };
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive).WithColumnNames("ColumnNames");
            Assert.Same(mapping, mapping.WithColumnNames(columnNames));

            ColumnsNamesPropertyMapper mapper = Assert.IsType<ColumnsNamesPropertyMapper>(mapping.Mapper);
            Assert.Equal(columnNames, mapper.ColumnNames);
        }

        [Fact]
        public void WithColumnNames_NullColumnNames_ThrowsArgumentNullException()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive).WithColumnNames("ColumnNames");

            Assert.Throws<ArgumentNullException>("columnNames", () => mapping.WithColumnNames(null));
            Assert.Throws<ArgumentNullException>("columnNames", () => mapping.WithColumnNames((IEnumerable<string>)null));
        }

        [Fact]
        public void WithColumnNames_EmptyColumnNames_ThrowsArgumentException()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive).WithColumnNames("ColumnNames");

            Assert.Throws<ArgumentException>("columnNames", () => mapping.WithColumnNames(new string[0]));
            Assert.Throws<ArgumentException>("columnNames", () => mapping.WithColumnNames(new List<string>()));
        }

        [Fact]
        public void WithColumnNames_NullValueInColumnNames_ThrowsArgumentException()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive).WithColumnNames("ColumnNames");

            Assert.Throws<ArgumentException>("columnNames", () => mapping.WithColumnNames(new string[] { null }));
            Assert.Throws<ArgumentException>("columnNames", () => mapping.WithColumnNames(new List<string> { null }));
        }

        [Fact]
        public void WithIndices_ParamsInt_Success()
        {
            var columnIndices = new int[] { 0, 1 };
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive).WithColumnNames("ColumnNames");
            Assert.Same(mapping, mapping.WithIndices(columnIndices));

            ColumnIndicesPropertyMapper mapper = Assert.IsType<ColumnIndicesPropertyMapper>(mapping.Mapper);
            Assert.Same(columnIndices, mapper.ColumnIndices);
        }

        [Fact]
        public void WithIndices_IEnumerableInt_Success()
        {
            var columnIndices = new List<int> { 0, 1 };
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive).WithColumnNames("ColumnNames");
            Assert.Same(mapping, mapping.WithIndices(columnIndices));

            ColumnIndicesPropertyMapper mapper = Assert.IsType<ColumnIndicesPropertyMapper>(mapping.Mapper);
            Assert.Equal(columnIndices, mapper.ColumnIndices);
        }

        [Fact]
        public void WithIndices_NullColumnIndices_ThrowsArgumentNullException()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive).WithColumnNames("ColumnNames");

            Assert.Throws<ArgumentNullException>("columnIndices", () => mapping.WithIndices(null));
            Assert.Throws<ArgumentNullException>("columnIndices", () => mapping.WithIndices((IEnumerable<int>)null));
        }

        [Fact]
        public void WithIndices_EmptyColumnIndices_ThrowsArgumentException()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive).WithColumnNames("ColumnNames");

            Assert.Throws<ArgumentException>("columnIndices", () => mapping.WithIndices(new int[0]));
            Assert.Throws<ArgumentException>("columnIndices", () => mapping.WithIndices(new List<int>()));
        }

        [Fact]
        public void WithIndices_NegativeValueInColumnIndices_ThrowsArgumentOutOfRangeException()
        {
            MemberInfo propertyInfo = typeof(TestClass).GetProperty(nameof(TestClass.Value));
            var mapping = new SubPropertyMapping(propertyInfo, EmptyValueStrategy.ThrowIfPrimitive).WithColumnNames("ColumnNames");

            Assert.Throws<ArgumentOutOfRangeException>("columnIndices", () => mapping.WithIndices(new int[] { -1 }));
            Assert.Throws<ArgumentOutOfRangeException>("columnIndices", () => mapping.WithIndices(new List<int> { -1 }));
        }

        private class SubPropertyMapping : EnumerablePropertyMapping<string>
        {
            public SubPropertyMapping(MemberInfo member, EmptyValueStrategy emptyValueStrategy) : base(member, emptyValueStrategy)
            {
            }

            public override object CreateFromElements(IEnumerable<string> elements)
            {
                throw new NotImplementedException();
            }
        }

        private class TestClass
        {
            public string[] Value { get; set; }
        }
    }
}