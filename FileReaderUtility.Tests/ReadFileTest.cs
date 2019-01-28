using System;
using Xunit;

namespace FileReaderUtility.Tests
{
    public class ReadFileTest
    {

        [Fact]
        public void ReadXMLTest()
        {
            String FILE_CONTENT = "<test>";
            var filePath = "/Users/modestekouassi/Projects/FileReaderUtility/FileReaderUtility/wwwroot/uploads/EmptyXmlFile.xml";
            String content  = ReadFiles.ReadXMLFile(filePath);
            bool result = content.Equals(FILE_CONTENT) ? true : false;
            Assert.True(result);
        }


        [Fact]
        public void ReadJSONTest()
        {
            String FILE_CONTENT = "{test}";
            var filePath = "/Users/modestekouassi/Projects/FileReaderUtility/FileReaderUtility/wwwroot/uploads/EmptyJSONFile.json";
            String content = ReadFiles.ReadXMLFile(filePath);
            Assert.Equal(content, FILE_CONTENT);
        }

        [Fact]
        public void ReadTextTest()
        {

            String FILE_CONTENT = "test";
            var filePath = "/Users/modestekouassi/Projects/FileReaderUtility/FileReaderUtility/wwwroot/uploads/EmptyTextFile.txt";
            String content = ReadFiles.ReadXMLFile(filePath);
            bool result = content.Equals(FILE_CONTENT) ? false : true;
            Assert.False(result);

        }
    }
}
