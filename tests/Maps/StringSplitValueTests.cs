﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace ExcelMapper.Tests
{
    public class StringSplitValueTests
    {
        [Fact]
        public void ReadRow_SeparatorsArrayMap_ReturnsExpected()
        {
            using (var importer = Helpers.GetImporter("SplitWithCustomSeparators.xlsx"))
            {
                importer.Configuration.RegisterClassMap<SplitWithSeparatorsArrayMap>();

                ExcelSheet sheet = importer.ReadSheet();
                sheet.ReadHeading();

                AutoSplitWithSeparatorClass row1 = sheet.ReadRow<AutoSplitWithSeparatorClass>();
                Assert.Equal(new string[] { "1", "2", "3", "4", "5" }, row1.Value);

                AutoSplitWithSeparatorClass row2 = sheet.ReadRow<AutoSplitWithSeparatorClass>();
                Assert.Equal(new string[] { "1", "2", "3" }, row2.Value);
            }
        }

        [Fact]
        public void ReadRow_IEnumerableSeparatorsMap_ReturnsExpected()
        {
            using (var importer = Helpers.GetImporter("SplitWithCustomSeparators.xlsx"))
            {
                importer.Configuration.RegisterClassMap<SplitWithEnumerableSeparatorsMap>();

                ExcelSheet sheet = importer.ReadSheet();
                sheet.ReadHeading();

                AutoSplitWithSeparatorClass row1 = sheet.ReadRow<AutoSplitWithSeparatorClass>();
                Assert.Equal(new string[] { "1", "2", "3", "4", "5" }, row1.Value);

                AutoSplitWithSeparatorClass row2 = sheet.ReadRow<AutoSplitWithSeparatorClass>();
                Assert.Equal(new string[] { "1", "2", "3" }, row2.Value);
            }
        }

        private class AutoSplitWithSeparatorClass
        {
            public string[] Value { get; set; }
            public ObservableCollection<ObservableCollectionEnum> EnumValue { get; set; }
        }

        private class CustomSplitWithSeparatorClass
        {
            public string[] Value { get; set; }
            public string[] ValueWithColumnName { get; set; }
            public string[] ValueWithColumnIndex { get; set; }

            public string[] ValueWithColumnNameAcrossMultiColumnNames { get; set; }
            public string[] ValueWithColumnNameAcrossMultiColumnIndices { get; set; }

            public string[] ValueWithColumnIndexAcrossMultiColumnNames { get; set; }
            public string[] ValueWithColumnIndexAcrossMultiColumnIndices { get; set; }
        }

        private class SplitWithSeparatorsArrayMap : ExcelClassMap<AutoSplitWithSeparatorClass>
        {
            public SplitWithSeparatorsArrayMap()
            {
                Map(p => p.Value)
                    .WithSeparators(";", ",");
            }
        }

        private class SplitWithEnumerableSeparatorsMap : ExcelClassMap<AutoSplitWithSeparatorClass>
        {
            public SplitWithEnumerableSeparatorsMap()
            {
                Map(p => p.Value)
                    .WithSeparators(new List<string> { ";", "," });
            }
        }

        public enum ObservableCollectionEnum
        {
            Value1,
            Value2,
            Value3,
            Empty,
            Invalid
        }
    }
}
