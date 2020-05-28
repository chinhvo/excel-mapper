using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace ExcelMapper.Tests
{
    public class MapSplitEnumerableTests
    {
        [Fact]
        public void ReadRow_AutoMappedObjectArray_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            ObjectArrayClass row1 = sheet.ReadRow<ObjectArrayClass>();
            Assert.Equal(new string[] { "1", "2", "3" }, row1.Value);

            ObjectArrayClass row2 = sheet.ReadRow<ObjectArrayClass>();
            Assert.Equal(new string[] { "1", null, "2" }, row2.Value);

            ObjectArrayClass row3 = sheet.ReadRow<ObjectArrayClass>();
            Assert.Equal(new string[] { "1" }, row3.Value);

            ObjectArrayClass row4 = sheet.ReadRow<ObjectArrayClass>();
            Assert.Empty(row4.Value);

            ObjectArrayClass row5 = sheet.ReadRow<ObjectArrayClass>();
            Assert.Equal(new string[] { "Invalid" }, row5.Value);
        }

        [Fact]
        public void ReadRow_AutoMappedStringArray_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            StringArrayClass row1 = sheet.ReadRow<StringArrayClass>();
            Assert.Equal(new string[] { "1", "2", "3" }, row1.Value);

            StringArrayClass row2 = sheet.ReadRow<StringArrayClass>();
            Assert.Equal(new string[] { "1", null, "2" }, row2.Value);

            StringArrayClass row3 = sheet.ReadRow<StringArrayClass>();
            Assert.Equal(new string[] { "1" }, row3.Value);

            StringArrayClass row4 = sheet.ReadRow<StringArrayClass>();
            Assert.Empty(row4.Value);

            StringArrayClass row5 = sheet.ReadRow<StringArrayClass>();
            Assert.Equal(new string[] { "Invalid" }, row5.Value);
        }

        [Fact]
        public void ReadRow_AutoMappedIntArray_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            IntArrayClass row1 = sheet.ReadRow<IntArrayClass>();
            Assert.Equal(new int[] { 1, 2, 3 }, row1.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<IntArrayClass>());

            IntArrayClass row3 = sheet.ReadRow<IntArrayClass>();
            Assert.Equal(new int[] { 1 }, row3.Value);

            IntArrayClass row4 = sheet.ReadRow<IntArrayClass>();
            Assert.Empty(row4.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<IntArrayClass>());
        }

        [Fact]
        public void ReadRow_AutoMappedIEnumerableObject_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            IEnumerableObjectClass row1 = sheet.ReadRow<IEnumerableObjectClass>();
            Assert.Equal(new string[] { "1", "2", "3" }, row1.Value);

            IEnumerableObjectClass row2 = sheet.ReadRow<IEnumerableObjectClass>();
            Assert.Equal(new string[] { "1", null, "2" }, row2.Value);

            IEnumerableObjectClass row3 = sheet.ReadRow<IEnumerableObjectClass>();
            Assert.Equal(new string[] { "1" }, row3.Value);

            IEnumerableObjectClass row4 = sheet.ReadRow<IEnumerableObjectClass>();
            Assert.Empty(row4.Value);

            IEnumerableObjectClass row5 = sheet.ReadRow<IEnumerableObjectClass>();
            Assert.Equal(new string[] { "Invalid" }, row5.Value);
        }

        [Fact]
        public void ReadRow_AutoMappedIEnumerableInt_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            IEnumerableIntClass row1 = sheet.ReadRow<IEnumerableIntClass>();
            Assert.Equal(new int[] { 1, 2, 3 }, row1.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<IEnumerableIntClass>());

            IEnumerableIntClass row3 = sheet.ReadRow<IEnumerableIntClass>();
            Assert.Equal(new int[] { 1 }, row3.Value);

            IEnumerableIntClass row4 = sheet.ReadRow<IEnumerableIntClass>();
            Assert.Empty(row4.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<IEnumerableIntClass>());
        }

        [Fact]
        public void ReadRow_AutoMappedIListObject_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            IListObjectClass row1 = sheet.ReadRow<IListObjectClass>();
            Assert.Equal(new string[] { "1", "2", "3" }, row1.Value);

            IListObjectClass row2 = sheet.ReadRow<IListObjectClass>();
            Assert.Equal(new string[] { "1", null, "2" }, row2.Value);

            IListObjectClass row3 = sheet.ReadRow<IListObjectClass>();
            Assert.Equal(new string[] { "1" }, row3.Value);

            IListObjectClass row4 = sheet.ReadRow<IListObjectClass>();
            Assert.Empty(row4.Value);

            IListObjectClass row5 = sheet.ReadRow<IListObjectClass>();
            Assert.Equal(new string[] { "Invalid" }, row5.Value);
        }

        [Fact]
        public void ReadRow_AutoMappedIListInt_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            IListIntClass row1 = sheet.ReadRow<IListIntClass>();
            Assert.Equal(new int[] { 1, 2, 3 }, row1.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<IListIntClass>());

            IListIntClass row3 = sheet.ReadRow<IListIntClass>();
            Assert.Equal(new int[] { 1 }, row3.Value);

            IListIntClass row4 = sheet.ReadRow<IListIntClass>();
            Assert.Empty(row4.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<IListIntClass>());
        }

        [Fact]
        public void ReadRow_AutoMappedListObject_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            ListObjectClass row1 = sheet.ReadRow<ListObjectClass>();
            Assert.Equal(new string[] { "1", "2", "3" }, row1.Value);

            ListObjectClass row2 = sheet.ReadRow<ListObjectClass>();
            Assert.Equal(new string[] { "1", null, "2" }, row2.Value);

            ListObjectClass row3 = sheet.ReadRow<ListObjectClass>();
            Assert.Equal(new string[] { "1" }, row3.Value);

            ListObjectClass row4 = sheet.ReadRow<ListObjectClass>();
            Assert.Empty(row4.Value);

            ListObjectClass row5 = sheet.ReadRow<ListObjectClass>();
            Assert.Equal(new string[] { "Invalid" }, row5.Value);
        }

        [Fact]
        public void ReadRow_AutoMappedListInt_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            ListIntClass row1 = sheet.ReadRow<ListIntClass>();
            Assert.Equal(new int[] { 1, 2, 3 }, row1.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<ListIntClass>());

            ListIntClass row3 = sheet.ReadRow<ListIntClass>();
            Assert.Equal(new int[] { 1 }, row3.Value);

            ListIntClass row4 = sheet.ReadRow<ListIntClass>();
            Assert.Empty(row4.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<ListIntClass>());
        }

        [Fact]
        public void ReadRow_AutoMappedObservableCollectionInt_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            ObservableCollectionIntClass row1 = sheet.ReadRow<ObservableCollectionIntClass>();
            Assert.Equal(new int[] { 1, 2, 3 }, row1.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<ObservableCollectionIntClass>());

            ObservableCollectionIntClass row3 = sheet.ReadRow<ObservableCollectionIntClass>();
            Assert.Equal(new int[] { 1 }, row3.Value);

            ObservableCollectionIntClass row4 = sheet.ReadRow<ObservableCollectionIntClass>();
            Assert.Empty(row4.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<ObservableCollectionIntClass>());
        }

        [Fact]
        public void ReadRow_DefaultMappedObjectArray_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");
            importer.Configuration.RegisterClassMap<DefaultObjectArrayClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            ObjectArrayClass row1 = sheet.ReadRow<ObjectArrayClass>();
            Assert.Equal(new string[] { "1", "2", "3" }, row1.Value);

            ObjectArrayClass row2 = sheet.ReadRow<ObjectArrayClass>();
            Assert.Equal(new string[] { "1", null, "2" }, row2.Value);

            ObjectArrayClass row3 = sheet.ReadRow<ObjectArrayClass>();
            Assert.Equal(new string[] { "1" }, row3.Value);

            ObjectArrayClass row4 = sheet.ReadRow<ObjectArrayClass>();
            Assert.Empty(row4.Value);

            ObjectArrayClass row5 = sheet.ReadRow<ObjectArrayClass>();
            Assert.Equal(new string[] { "Invalid" }, row5.Value);
        }

        [Fact]
        public void ReadRow_DefaultMappedStringArray_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");
            importer.Configuration.RegisterClassMap<DefaultStringArrayClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            StringArrayClass row1 = sheet.ReadRow<StringArrayClass>();
            Assert.Equal(new string[] { "1", "2", "3" }, row1.Value);

            StringArrayClass row2 = sheet.ReadRow<StringArrayClass>();
            Assert.Equal(new string[] { "1", null, "2" }, row2.Value);

            StringArrayClass row3 = sheet.ReadRow<StringArrayClass>();
            Assert.Equal(new string[] { "1" }, row3.Value);

            StringArrayClass row4 = sheet.ReadRow<StringArrayClass>();
            Assert.Empty(row4.Value);

            StringArrayClass row5 = sheet.ReadRow<StringArrayClass>();
            Assert.Equal(new string[] { "Invalid" }, row5.Value);
        }

        [Fact]
        public void ReadRow_DefaultMappedIntArray_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");
            importer.Configuration.RegisterClassMap<DefaultIntArrayClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            IntArrayClass row1 = sheet.ReadRow<IntArrayClass>();
            Assert.Equal(new int[] { 1, 2, 3 }, row1.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<IntArrayClass>());

            IntArrayClass row3 = sheet.ReadRow<IntArrayClass>();
            Assert.Equal(new int[] { 1 }, row3.Value);

            IntArrayClass row4 = sheet.ReadRow<IntArrayClass>();
            Assert.Empty(row4.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<IntArrayClass>());
        }

        [Fact]
        public void ReadRow_DefaultMappedIEnumerableObject_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");
            importer.Configuration.RegisterClassMap<DefaultIEnumerableObjectClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            IEnumerableObjectClass row1 = sheet.ReadRow<IEnumerableObjectClass>();
            Assert.Equal(new string[] { "1", "2", "3" }, row1.Value);

            IEnumerableObjectClass row2 = sheet.ReadRow<IEnumerableObjectClass>();
            Assert.Equal(new string[] { "1", null, "2" }, row2.Value);

            IEnumerableObjectClass row3 = sheet.ReadRow<IEnumerableObjectClass>();
            Assert.Equal(new string[] { "1" }, row3.Value);

            IEnumerableObjectClass row4 = sheet.ReadRow<IEnumerableObjectClass>();
            Assert.Empty(row4.Value);

            IEnumerableObjectClass row5 = sheet.ReadRow<IEnumerableObjectClass>();
            Assert.Equal(new string[] { "Invalid" }, row5.Value);
        }

        [Fact]
        public void ReadRow_DefaultMappedIEnumerableInt_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");
            importer.Configuration.RegisterClassMap<DefaultIEnumerableIntClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            IEnumerableIntClass row1 = sheet.ReadRow<IEnumerableIntClass>();
            Assert.Equal(new int[] { 1, 2, 3 }, row1.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<IEnumerableIntClass>());

            IEnumerableIntClass row3 = sheet.ReadRow<IEnumerableIntClass>();
            Assert.Equal(new int[] { 1 }, row3.Value);

            IEnumerableIntClass row4 = sheet.ReadRow<IEnumerableIntClass>();
            Assert.Empty(row4.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<IEnumerableIntClass>());
        }

        [Fact]
        public void ReadRow_DefaultMappedIListObject_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");
            importer.Configuration.RegisterClassMap<DefaultIListObjectClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            IListObjectClass row1 = sheet.ReadRow<IListObjectClass>();
            Assert.Equal(new string[] { "1", "2", "3" }, row1.Value);

            IListObjectClass row2 = sheet.ReadRow<IListObjectClass>();
            Assert.Equal(new string[] { "1", null, "2" }, row2.Value);

            IListObjectClass row3 = sheet.ReadRow<IListObjectClass>();
            Assert.Equal(new string[] { "1" }, row3.Value);

            IListObjectClass row4 = sheet.ReadRow<IListObjectClass>();
            Assert.Empty(row4.Value);

            IListObjectClass row5 = sheet.ReadRow<IListObjectClass>();
            Assert.Equal(new string[] { "Invalid" }, row5.Value);
        }

        [Fact]
        public void ReadRow_DefaultMappedIListInt_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");
            importer.Configuration.RegisterClassMap<DefaultIListIntClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            IListIntClass row1 = sheet.ReadRow<IListIntClass>();
            Assert.Equal(new int[] { 1, 2, 3 }, row1.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<IListIntClass>());

            IListIntClass row3 = sheet.ReadRow<IListIntClass>();
            Assert.Equal(new int[] { 1 }, row3.Value);

            IListIntClass row4 = sheet.ReadRow<IListIntClass>();
            Assert.Empty(row4.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<IListIntClass>());
        }

        [Fact]
        public void ReadRow_DefaultMappedListObject_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");
            importer.Configuration.RegisterClassMap<DefaultListObjectClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            ListObjectClass row1 = sheet.ReadRow<ListObjectClass>();
            Assert.Equal(new string[] { "1", "2", "3" }, row1.Value);

            ListObjectClass row2 = sheet.ReadRow<ListObjectClass>();
            Assert.Equal(new string[] { "1", null, "2" }, row2.Value);

            ListObjectClass row3 = sheet.ReadRow<ListObjectClass>();
            Assert.Equal(new string[] { "1" }, row3.Value);

            ListObjectClass row4 = sheet.ReadRow<ListObjectClass>();
            Assert.Empty(row4.Value);

            ListObjectClass row5 = sheet.ReadRow<ListObjectClass>();
            Assert.Equal(new string[] { "Invalid" }, row5.Value);
        }

        [Fact]
        public void ReadRow_DefaultMappedListInt_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");
            importer.Configuration.RegisterClassMap<DefaultListIntClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            ListIntClass row1 = sheet.ReadRow<ListIntClass>();
            Assert.Equal(new int[] { 1, 2, 3 }, row1.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<ListIntClass>());

            ListIntClass row3 = sheet.ReadRow<ListIntClass>();
            Assert.Equal(new int[] { 1 }, row3.Value);

            ListIntClass row4 = sheet.ReadRow<ListIntClass>();
            Assert.Empty(row4.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<ListIntClass>());
        }

        [Fact]
        public void ReadRow_DefaultMappedObservableCollectionInt_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");
            importer.Configuration.RegisterClassMap<DefaultObservableCollectionIntClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            ObservableCollectionIntClass row1 = sheet.ReadRow<ObservableCollectionIntClass>();
            Assert.Equal(new int[] { 1, 2, 3 }, row1.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<ObservableCollectionIntClass>());

            ObservableCollectionIntClass row3 = sheet.ReadRow<ObservableCollectionIntClass>();
            Assert.Equal(new int[] { 1 }, row3.Value);

            ObservableCollectionIntClass row4 = sheet.ReadRow<ObservableCollectionIntClass>();
            Assert.Empty(row4.Value);

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<ObservableCollectionIntClass>());
        }

        [Fact]
        public void ReadRow_CustomMappedIntArray_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");
            importer.Configuration.RegisterClassMap<CustomIntArrayClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            IntArrayClass row1 = sheet.ReadRow<IntArrayClass>();
            Assert.Equal(new int[] { 1, 2, 3 }, row1.Value);

            IntArrayClass row2 = sheet.ReadRow<IntArrayClass>();
            Assert.Equal(new int[] { 1, -1, 2 }, row2.Value);

            IntArrayClass row3 = sheet.ReadRow<IntArrayClass>();
            Assert.Equal(new int[] { 1 }, row3.Value);

            IntArrayClass row4 = sheet.ReadRow<IntArrayClass>();
            Assert.Empty(row4.Value);

            IntArrayClass row5 = sheet.ReadRow<IntArrayClass>();
            Assert.Equal(new int[] { -2 }, row5.Value);
        }

        [Fact]
        public void ReadRow_CustomMappedIListInt_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");
            importer.Configuration.RegisterClassMap<CustomIListIntClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            IListIntClass row1 = sheet.ReadRow<IListIntClass>();
            Assert.Equal(new int[] { 1, 2, 3 }, row1.Value);

            IListIntClass row2 = sheet.ReadRow<IListIntClass>();
            Assert.Equal(new int[] { 1, -1, 2 }, row2.Value);

            IListIntClass row3 = sheet.ReadRow<IListIntClass>();
            Assert.Equal(new int[] { 1 }, row3.Value);

            IListIntClass row4 = sheet.ReadRow<IListIntClass>();
            Assert.Empty(row4.Value);

            IListIntClass row5 = sheet.ReadRow<IListIntClass>();
            Assert.Equal(new int[] { -2 }, row5.Value);
        }

        [Fact]
        public void ReadRow_CustomMappedListInt_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");
            importer.Configuration.RegisterClassMap<CustomListIntClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            ListIntClass row1 = sheet.ReadRow<ListIntClass>();
            Assert.Equal(new int[] { 1, 2, 3 }, row1.Value);

            ListIntClass row2 = sheet.ReadRow<ListIntClass>();
            Assert.Equal(new int[] { 1, -1, 2 }, row2.Value);

            ListIntClass row3 = sheet.ReadRow<ListIntClass>();
            Assert.Equal(new int[] { 1 }, row3.Value);

            ListIntClass row4 = sheet.ReadRow<ListIntClass>();
            Assert.Empty(row4.Value);

            ListIntClass row5 = sheet.ReadRow<ListIntClass>();
            Assert.Equal(new int[] { -2 }, row5.Value);
        }

        [Fact]
        public void ReadRow_CustomMappedObservableCollectionInt_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithComma.xlsx");
            importer.Configuration.RegisterClassMap<CustomObservableCollectionIntClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            ObservableCollectionIntClass row1 = sheet.ReadRow<ObservableCollectionIntClass>();
            Assert.Equal(new int[] { 1, 2, 3 }, row1.Value);

            ObservableCollectionIntClass row2 = sheet.ReadRow<ObservableCollectionIntClass>();
            Assert.Equal(new int[] { 1, -1, 2 }, row2.Value);

            ObservableCollectionIntClass row3 = sheet.ReadRow<ObservableCollectionIntClass>();
            Assert.Equal(new int[] { 1 }, row3.Value);

            ObservableCollectionIntClass row4 = sheet.ReadRow<ObservableCollectionIntClass>();
            Assert.Empty(row4.Value);

            ObservableCollectionIntClass row5 = sheet.ReadRow<ObservableCollectionIntClass>();
            Assert.Equal(new int[] { -2 }, row5.Value);
        }

        public class ObjectArrayClass
        {
            public object[] Value { get; set; }
        }

        public class DefaultObjectArrayClassMap : ExcelClassMap<ObjectArrayClass>
        {
            public DefaultObjectArrayClassMap()
            {
                Map(p => p.Value);
            }
        }

        public class StringArrayClass
        {
            public string[] Value { get; set; }
        }

        public class DefaultStringArrayClassMap : ExcelClassMap<StringArrayClass>
        {
            public DefaultStringArrayClassMap()
            {
                Map(p => p.Value);
            }
        }

        public class IntArrayClass
        {
            public int[] Value { get; set; }
        }

        public class DefaultIntArrayClassMap : ExcelClassMap<IntArrayClass>
        {
            public DefaultIntArrayClassMap()
            {
                Map(p => p.Value);
            }
        }

        public class CustomIntArrayClassMap : ExcelClassMap<IntArrayClass>
        {
            public CustomIntArrayClassMap()
            {
                Map(p => p.Value)
                    .WithElementMap(p => p
                        .WithEmptyFallback(-1)
                        .WithInvalidFallback(-2)
                    );
            }
        }

        public class IEnumerableObjectClass
        {
            public IEnumerable<object> Value { get; set; }
        }

        public class DefaultIEnumerableObjectClassMap : ExcelClassMap<IEnumerableObjectClass>
        {
            public DefaultIEnumerableObjectClassMap()
            {
                Map(p => p.Value);
            }
        }

        public class IEnumerableIntClass
        {
            public IEnumerable<int> Value { get; set; }
        }

        public class CustomIEnumerableIntClassMap : ExcelClassMap<IEnumerableIntClass>
        {
            public CustomIEnumerableIntClassMap()
            {
                Map(p => p.Value)
                    .WithElementMap(p => p
                        .WithEmptyFallback(-1)
                        .WithInvalidFallback(-2)
                    );
            }
        }

        public class DefaultIEnumerableIntClassMap : ExcelClassMap<IEnumerableIntClass>
        {
            public DefaultIEnumerableIntClassMap()
            {
                Map(p => p.Value);
            }
        }

        public class IListObjectClass
        {
            public IList<object> Value { get; set; }
        }

        public class DefaultIListObjectClassMap : ExcelClassMap<IListObjectClass>
        {
            public DefaultIListObjectClassMap()
            {
                Map(p => p.Value);
            }
        }

        public class IListIntClass
        {
            public IList<int> Value { get; set; }
        }

        public class CustomIListIntClassMap : ExcelClassMap<IListIntClass>
        {
            public CustomIListIntClassMap()
            {
                Map(p => p.Value)
                    .WithElementMap(p => p
                        .WithEmptyFallback(-1)
                        .WithInvalidFallback(-2)
                    );
            }
        }

        public class DefaultIListIntClassMap : ExcelClassMap<IListIntClass>
        {
            public DefaultIListIntClassMap()
            {
                Map(p => p.Value);
            }
        }

        public class ListObjectClass
        {
            public List<object> Value { get; set; }
        }

        public class DefaultListObjectClassMap : ExcelClassMap<ListObjectClass>
        {
            public DefaultListObjectClassMap()
            {
                Map(p => p.Value);
            }
        }

        public class ListIntClass
        {
            public List<int> Value { get; set; }
        }

        public class DefaultListIntClassMap : ExcelClassMap<ListIntClass>
        {
            public DefaultListIntClassMap()
            {
                Map(p => p.Value);
            }
        }

        public class CustomListIntClassMap : ExcelClassMap<ListIntClass>
        {
            public CustomListIntClassMap()
            {
                Map(p => p.Value)
                    .WithElementMap(p => p
                        .WithEmptyFallback(-1)
                        .WithInvalidFallback(-2)
                    );
            }
        }

        public class ObservableCollectionIntClass
        {
            public ObservableCollection<int> Value { get; set; }
        }

        public class DefaultObservableCollectionIntClassMap : ExcelClassMap<ObservableCollectionIntClass>
        {
            public DefaultObservableCollectionIntClassMap()
            {
                Map(p => p.Value);
            }
        }

        public class CustomObservableCollectionIntClassMap : ExcelClassMap<ObservableCollectionIntClass>
        {
            public CustomObservableCollectionIntClassMap()
            {
                Map(p => p.Value)
                    .WithElementMap(p => p
                        .WithEmptyFallback(-1)
                        .WithInvalidFallback(-2)
                    );
            }
        }

        [Fact]
        public void ReadRow_MultiMapMissingRow_ThrowsExcelMappingException()
        {
            using var importer = Helpers.GetImporter("SplitWithCustomSeparators.xlsx");
            importer.Configuration.RegisterClassMap<DefaultMissingColumnClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            Assert.Throws<ExcelMappingException>(() => sheet.ReadRow<MissingColumnClass>());
        }

        [Fact]
        public void ReadRow_MultiMapOptionalMissingRow_ReturnsExpected()
        {
            using var importer = Helpers.GetImporter("SplitWithCustomSeparators.xlsx");
            importer.Configuration.RegisterClassMap<OptionalMissingColumnClassMap>();

            ExcelSheet sheet = importer.ReadSheet();
            sheet.ReadHeading();

            MissingColumnClass row = sheet.ReadRow<MissingColumnClass>();
            Assert.Null(row.MissingColumn);
        }

        public class MissingColumnClass
        {
            public int[] MissingColumn { get; set; }
        }

        private class DefaultMissingColumnClassMap : ExcelClassMap<MissingColumnClass>
        {
            public DefaultMissingColumnClassMap()
            {
                Map(p => p.MissingColumn);
            }
        }

        private class OptionalMissingColumnClassMap : ExcelClassMap<MissingColumnClass>
        {
            public OptionalMissingColumnClassMap()
            {
                Map(p => p.MissingColumn)
                    .MakeOptional();
            }
        }
    }
}