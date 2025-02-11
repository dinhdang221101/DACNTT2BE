using System.Xml;

namespace DHPhoneStore
{
    public class SqlStatementsManagerClass
    {
        private static List<XmlDocument>? _xmlDocs;
        public SqlStatementsManagerClass() { }
        public SqlStatementsManagerClass(string basePath)
        {
            try
            {
                string[] filePaths = Directory.GetFiles(Path.Combine(basePath, "Statements"),
                    "*.xml",
                    SearchOption.TopDirectoryOnly);
                List<string> sqlArr = filePaths.OfType<string>().ToList();
                //string filePath = sqlArr[0];
                // Load XML document
                _xmlDocs = new List<XmlDocument>();
                foreach (string filePath in filePaths)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(filePath);
                    _xmlDocs.Add(xmlDoc);
                }
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                
            }
        }
        public string ReadStatementById(string targetId)
        {
            try
            {
                // Construct XPath query to find the statement with the given ID
                string xpathQuery = $"/Statements/Statement[@id='{targetId}']";

                // Select the matching node
                foreach (XmlDocument doc in _xmlDocs)
                {
                    XmlNode node = doc.SelectSingleNode(xpathQuery);

                    // Check if the node exists
                    if (node != null)
                    {
                        // Return the statement value
                        return node.InnerText.Trim();
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}

