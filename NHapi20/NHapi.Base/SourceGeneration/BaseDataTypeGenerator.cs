namespace NHapi.Base.SourceGeneration
{
    using System.IO;
    using System.Text;

    /// <summary>   A base data type generator. </summary>
    internal class BaseDataTypeGenerator
    {
        #region Public Methods and Operators

        /// <summary>   Builds base data types. </summary>
        ///
        /// <param name="baseDirectory">    Pathname of the base directory. </param>
        /// <param name="version">          The version. </param>

        public static void BuildBaseDataTypes(string baseDirectory, System.String version)
        {
            string targetDir = baseDirectory + @"\" + PackageManager.GetVersionPackagePath(version) + "Datatype";

            BuildFile("DT", targetDir, version);
            BuildFile("ST", targetDir, version);
            BuildFile("IS", targetDir, version);
            BuildFile("ID", targetDir, version);
            BuildFile("TM", targetDir, version);
        }

        #endregion

        #region Methods

        /// <summary>   Builds a file. </summary>
        ///
        /// <param name="dataType">     Type of the data. </param>
        /// <param name="targetDir">    Target dir. </param>
        /// <param name="version">      The version. </param>

        private static void BuildFile(string dataType, string targetDir, string version)
        {
            string fileName = targetDir + @"\" + dataType + ".cs";
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                string source = GetClassSource(dataType, version);
                byte[] data = System.Text.Encoding.ASCII.GetBytes(source);
                fs.Write(data, 0, data.Length);
            }
        }

        /// <summary>   Gets class source. </summary>
        ///
        /// <param name="dataType"> Type of the data. </param>
        /// <param name="version">  The version. </param>
        ///
        /// <returns>   The class source. </returns>

        private static string GetClassSource(string dataType, string version)
        {
            string namespaceName = PackageManager.GetVersionPackageName(version);
            namespaceName = namespaceName.Substring(0, namespaceName.Length - 1);

            string baseClass = "NHapi.Base.Model.Primitive." + dataType;

            if (dataType.Equals("ST"))
            {
                baseClass = "AbstractPrimitive";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\n\n");
            sb.Append("using NHapi.Base.Model;\n");

            sb.Append("namespace " + namespaceName + ".Datatype\n");
            sb.Append("{\n");
            sb.Append("/// <summary>");
            sb.Append("/// Summary description for " + dataType + ".\n");
            sb.Append("/// </summary>\n");
            sb.Append("public class " + dataType + ": " + baseClass + "\n");
            sb.Append("{\n");
            sb.Append("/// <summary>Return the version\n");
            sb.Append("/// <returns>" + version + "</returns>\n");
            sb.Append("///</summary>\r\n");
            sb.Append(@"
            virtual public System.String Version
            {
			    get
			    {
				    return """ + version + @""";
			    }
		    }
            ");

            if (dataType.Equals("ID") || dataType.Equals("IS"))
            {
                sb.Append("\n\n");
                sb.Append(@"
                ///<summary>Construct the type
                ///<param name=""theMessage"">message to which this Type belongs</param>
                ///<param name=""theTable"">The table which this type belongs</param>
                ///</summary>
                public " + dataType + @"(IMessage theMessage,int theTable):base(theMessage, theTable)
                {}
                ");

                sb.Append("\n\n");
                sb.Append(@"
                ///<summary>Construct the type
                ///<param name=""message"">message to which this Type belongs</param>
                ///<param name=""theTable"">The table which this type belongs</param>
                ///<param name=""description"">The description of this type</param>
                ///</summary>
		        public " + dataType
                          + @"(IMessage message, int theTable, string description) : base(message,theTable, description)
    	        {}
                ");
            }
            else
            {
                sb.Append("\n\n");
                sb.Append(@"
                ///<summary>Construct the type
                ///<param name=""theMessage"">message to which this Type belongs</param>
                ///</summary>
                public " + dataType + @"(IMessage theMessage):base(theMessage)
                {}
                ");

                sb.Append("\n\n");
                sb.Append(@"
                ///<summary>Construct the type
                ///<param name=""message"">message to which this Type belongs</param>
                ///<param name=""description"">The description of this type</param>
                ///</summary>
		        public " + dataType + @"(IMessage message, string description) : base(message,description)
    	        {}
                ");
            }
            sb.Append("}\r");
            sb.Append("}\r");
            return sb.ToString();
        }

        #endregion
    }
}